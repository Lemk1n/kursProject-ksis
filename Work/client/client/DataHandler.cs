using System;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Network;

namespace client
{
    public class DataHandler
    {
        public User CurrentUser { get; set; }
        private UdpProtocol client;
        private int localPort;

        public DataHandler(int port)
        {
            localPort = port;
            client = new UdpProtocol(localPort);
        }

        public void CallUser()
        {
            if (CurrentUser != null)
                client.Connect(CurrentUser);
        }

        private const int PackageSize = 60000;

        public void SendImage(Bitmap bmp, int imageNumber)
        {
            int count = 0, currentBit = 0;
            byte[] arr = StreamToArray(ScreenCapture.VaryQualityLevel(bmp));
            int numberBits = (arr.Length/PackageSize) + ((arr.Length%PackageSize) == 0 ? 0 : 1);
            while (count < arr.Length)
            {
                int arrLength = (arr.Length - count) > PackageSize ? PackageSize : arr.Length - count;
                byte[] tempArr = new byte[arrLength];
                Array.Copy(arr, count, tempArr, 0, arrLength);
                ImageBit bit = new ImageBit()
                {
                    NumberBits = numberBits,
                    CurrentBit = currentBit++,
                    Data = tempArr,
                    ImageNumber = imageNumber,
                    Size = arr.Length
                };
                tempArr = Serialize(bit);
                count += arrLength;
                client.Send(tempArr);
            }
        }

        private byte[] Serialize(ImageBit image)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            formatter.Serialize(ms, image);
            return StreamToArray(ms);
        }

        private byte[] StreamToArray(Stream stream)
        {
            const int bufferSize = 16 * 1024;
            byte[] buffer = new byte[bufferSize];
            stream.Position = 0;
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = stream.Read(buffer, 0, buffer.Length)) > 0)
                    ms.Write(buffer, 0, read);
                return ms.ToArray();
            }
        }

        private static byte[] response = {100};

        public Bitmap ReceiveImage()
        {
            int receivedPackages = 0;
            ImageBit image = Deserialize(client.Receive());
            ImageBit[] arrStructs = new ImageBit[image.NumberBits];
            arrStructs[image.CurrentBit] = image;
            int imageNumber = image.ImageNumber;
            receivedPackages++;
            while (true)
            {
                image = Deserialize(client.Receive());
                if (imageNumber == image.ImageNumber)
                {
                    receivedPackages++;
                    arrStructs[image.CurrentBit] = image;
                    if ((receivedPackages == (image.NumberBits)) && (imageNumber == image.ImageNumber))
                    {
                        client.SendResponse(response);
                        return AssemblyBitmap(arrStructs, image.Size);
                    }
                }
                else
                {
                    imageNumber = image.ImageNumber;
                    arrStructs = new ImageBit[image.NumberBits];
                    arrStructs[image.CurrentBit] = image;
                    receivedPackages = 1;
                }
             }
        }

        private ImageBit Deserialize(byte[] array)
        {
            Stream stream = Converter.ArrayToStream(array);
            BinaryFormatter formatter = new BinaryFormatter();
            return (ImageBit)formatter.Deserialize(stream);
        }

        private Bitmap AssemblyBitmap(ImageBit[] arr, int size)
        {
            int copiedBytes = 0;
            byte[] outputArr = new byte[size];
            foreach (var elem in arr)
            {
                Array.Copy(elem.Data, 0, outputArr, copiedBytes, elem.Data.Length);
                copiedBytes += elem.Data.Length;
            }
            using (var ms = new MemoryStream(outputArr))
            {
                return new Bitmap(ms);
            }
        }
    }

    [Serializable]
    public class ImageBit
    {
        public int NumberBits;
        public int CurrentBit;
        public int ImageNumber;
        public int Size;
        public byte[] Data;
    }
}
