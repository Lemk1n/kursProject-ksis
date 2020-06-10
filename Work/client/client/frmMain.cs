using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Windows.Forms;
using Network;
using Timer = System.Windows.Forms.Timer;

namespace client
{
    public partial class frmMain : Form
    {
        public Network.TcpClient server;
        private DataHandler handler;
        public List<User> usersList;
        private bool isSendVideo, isFullScreen;
        private Thread receiveThread, messagesThread, usersListThread;
        private Control choosenUser;
        private User CurrentUser;
        private Timer timer;
        private int y;
        private MessagesHandler messagesHandler;
        private string localLogin;
        public frmMain()
        {
            InitializeComponent();
            isSendVideo = false;
        }

        private void GetUsersList()
        {
            while (true)
            {
                try
                {
                    byte[] buffer = (byte[])server.Receive();
                    if (buffer.Length != 0)
                    {
                        Stream stream = Converter.ArrayToStream(buffer);
                        BinaryFormatter formatter = new BinaryFormatter();
                        usersList = (List<User>)formatter.Deserialize(stream);
                        CleanUserList();
                        DrawUsersList();
                    }
                }
                catch
                {
                   
                }
            }
        }

        private void CleanUserList()
        {
            foreach (Control control in fpanelUsers.Controls)
            {
                if (fpanelUsers.InvokeRequired)
                    fpanelUsers.Invoke(new Action<Control>(ctrl => fpanelUsers.Controls.Remove(ctrl)), control);
                else
                    fpanelUsers.Controls.Remove(control);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            localLogin = usersList[usersList.Count - 1].Login;
            isFullScreen = false;
            handler = new DataHandler(usersList[usersList.Count - 1].Port);
            messagesHandler = new MessagesHandler(usersList[usersList.Count - 1].Port + 1);
            DrawUsersList();
            GetUser();
            pnlVideo.Show();
            pnlChat.Hide();
            receiveThread = new Thread(new ThreadStart(Receiver));
            receiveThread.Start();
            messagesThread = new Thread(new ThreadStart(ReceiverMessages));
            messagesThread.Start();
            server = new TcpClient();
            server.ConnectServer(1);
            usersListThread = new Thread(new ThreadStart(GetUsersList));
            usersListThread.Start();
        }

        private void ReceiverMessages()
        {
            while (true)
            {
                string message = messagesHandler.ReceiveMessages();
                CreateComment(message, false);
            } 
        }

        private Control CreateUserProfile(User user)
        {
            Panel panel = new Panel();
            panel.Location = new Point(0, 0);
            panel.Size = new Size(150, 25);
            panel.BackColor = Color.Aquamarine;
            Label label = new Label {Text = user.Login};
            label.AutoSize = true;
            label.Location = new Point(10, 6);
            panel.Controls.Add(label);
            panel.Click += ClickPanel;
            return panel;
        }

        private void ClickPanel(object sender, EventArgs e)
        {
            if (choosenUser != null) choosenUser.BackColor = Color.Aquamarine;
            choosenUser = (Panel) sender;
            choosenUser.BackColor = Color.Bisque;
        }

        private void AddElementToUserList(Control control)
        {
            if (fpanelUsers.InvokeRequired)
                fpanelUsers.Invoke(new Action<Control>(ctrl => fpanelUsers.Controls.Add(ctrl)), control);
            else
                fpanelUsers.Controls.Add(control);
        }

        private void DrawUsersList()
        {
            foreach (var user in usersList.Where(user => user.Login.Equals(localLogin)))
            {
                AddElementToUserList(CreateLabel(localLogin, 15));
            }
            foreach (var user in usersList.Where(user => !user.Login.Equals(localLogin)))
            {
                AddElementToUserList(CreateUserProfile(user));
            }
            /*
            AddElementToUserList(CreateLabel(usersList[usersList.Count - 1].Login, 15));
            for (int i = 0; i < usersList.Count - 1; i++)
            {

                AddElementToUserList(CreateUserProfile(usersList[i]));
            }*/
        }

        private void CreateComment(string text, bool isMyComment)
        {
            Label message = (Label)CreateLabel(text, 10);
            message.TextAlign = ContentAlignment.MiddleCenter;
            message.Size = new Size(300, 20);
            if (isMyComment)
            {
                message.Location = new Point(350, y);
                message.BackColor = Color.AliceBlue;
            }
            else
            {
                message.Location = new Point(100, y);
                message.BackColor = Color.Beige;
            }
            y += 50;
            if (pnlMessages.InvokeRequired)
            {
                pnlMessages.Invoke(new Action<Control>((ctrl) => pnlMessages.Controls.Add(ctrl)), message);
            }
            else
            {
                pnlMessages.Controls.Add(message);
            }
        }

        private Control CreateLabel(string text, float fontSize)
        {
            Label label = new Label
            {
                Text = text,
                Margin = new Padding(5),
                Font = new Font(FontFamily.GenericSansSerif, fontSize), 
            };
            return label;
        }

        private int GetUser()
        {
            CurrentUser = null;
            if (choosenUser != null)
                CurrentUser = FindUser();
            if (CurrentUser != null)
            {
                handler.CurrentUser = CurrentUser;
                handler.CallUser();
                return 0;
            }
            return 1;
        }

        private User FindUser()
        {
            foreach (Control control in choosenUser.Controls)
            {
                if (control is Label)
                {
                    string login = control.Text;
                    foreach (var user in usersList)
                    {
                        if (user.Login == login)
                            return user;
                    }
                }
            }
            return null;
        }

        private void GetScreen()
        {
            isSendVideo = true;
            Bitmap background;
            int numberImage = 0;
            timer = new Timer { Interval = 10 };
            timer.Tick += (s, e) =>
            {
                background = ScreenCapture.CaptureScreen(true);
                handler.SendImage(background, numberImage++);
            };
            timer.Start();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            if ((GetUser() == 0) && !isSendVideo)
                GetScreen();
        }

        private void Receiver()
        {
            while (true)
            {
                if (!isSendVideo)
                {
                    Bitmap bmp = handler.ReceiveImage();
                    if (bmp != null)
                        pictVideo.Image = bmp;
                }
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            receiveThread.Abort();
            messagesThread.Abort();
            usersListThread.Abort();
            Application.Exit();
        }

        private void btnStopSending_Click(object sender, EventArgs e)
        {
            if (timer != null)
                timer.Stop();
            isSendVideo = false;
        }

        private void btnToChat_Click(object sender, EventArgs e)
        {
            pnlVideo.Hide();
            //pnlChat.BackColor = Color.FromName("Aquamarine");
            pnlChat.Show();
        }

        private void fpanelUsers_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSendMessage_Click(object sender, EventArgs e)
        {
            if (GetUser() != 0) return;
            messagesHandler.Connect(CurrentUser);
            messagesHandler.SendMessage(txtMessage.Text);
            CreateComment(txtMessage.Text, true);
            txtMessage.Text = "";
        }

        private void btnScreen_Click(object sender, EventArgs e)
        {
            pnlVideo.Show();
            pnlChat.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!isFullScreen)
            {
                WindowState = FormWindowState.Maximized;
                isFullScreen = true;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                isFullScreen = false;
            }
        }
    }
}
