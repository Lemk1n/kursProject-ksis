using System.Text;
using Network;

namespace client
{
    class MessagesHandler
    {
        private UdpProtocol udp;

        public MessagesHandler(int port)
        {
            udp = new UdpProtocol(port);
        }

        public void SendMessage(string text)
        {
            byte[] datagram = Encoding.UTF8.GetBytes(text);
            udp.Send(datagram);
        }

        public void Connect(User user)
        {
            user.Port += 1;
            udp.Connect(user);
        }

        public string ReceiveMessages()
        {
            byte[] message = udp.Receive();
            return Encoding.UTF8.GetString(message);
        }
    }
}
