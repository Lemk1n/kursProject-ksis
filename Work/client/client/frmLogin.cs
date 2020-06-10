using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using Network;

namespace client
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsAuthorized())
                {
                    frmMain mainForm = new frmMain();
                    mainForm.usersList = usersList;
                    mainForm.Closed += (s, args) => Close();
                    mainForm.Show();
                    mainForm.Activate();
                    mainForm.server = client;
                    Hide();
                }
                else
                {
                    MessageBox.Show("Wrong login or password!");
                    txtLogin.Text = "";
                    txtPassword.Text = "";
                    this.ActiveControl = txtLogin;
                }

            }
            catch
            {
                MessageBox.Show("Couldn't connect to server!");
                txtLogin.Text = "";
                txtPassword.Text = "";
                this.ActiveControl = txtLogin;
            }
            }

        private TcpClient client = new TcpClient();
        private List<User> usersList;

        private bool IsAuthorized()
        {
            const string responseError = "500", responseOk = "200", responseUserList = "250", requestList = "300";
            client.ConnectServer(0);
            string message = GetResponse();
            if (message.Equals(responseOk))
            {
                SendMessage("login " + txtLogin.Text);
                if (GetResponse().Equals(responseOk))
                {
                    SendMessage("password " + txtPassword.Text);
                    if (GetResponse().Equals(responseOk))
                    {
                        SendMessage(requestList);
                        if (GetResponse().Equals(responseUserList))
                            GetUsersList();
                        return true;
                    }
                    return false;
                }
                return false;
            }
            return false;
        }

        private string GetResponse()
        {
            return Converter.ArrayToString((byte[]) client.Receive());
        }

        private void SendMessage(string message)
        {
            client.Send(Converter.StringToArray(message));
        }

        private void GetUsersList()
        {
            byte[] buffer = (byte[])client.Receive();
            Stream stream = Converter.ArrayToStream(buffer);
            BinaryFormatter formatter = new BinaryFormatter();
            usersList = (List<User>)formatter.Deserialize(stream);
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtLogin;
        }
    }
}
