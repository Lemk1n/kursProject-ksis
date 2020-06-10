namespace client
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.fpanelUsers = new System.Windows.Forms.FlowLayoutPanel();
            this.btnShowScreen = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnStopSending = new System.Windows.Forms.Button();
            this.btnScreen = new System.Windows.Forms.Button();
            this.btnToChat = new System.Windows.Forms.Button();
            this.btnFullScreen = new System.Windows.Forms.Button();
            this.pnlVideo = new System.Windows.Forms.Panel();
            this.pictVideo = new System.Windows.Forms.PictureBox();
            this.pnlContent = new System.Windows.Forms.Panel();
            this.pnlChat = new System.Windows.Forms.Panel();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnSendMessage = new System.Windows.Forms.Button();
            this.pnlMessages = new System.Windows.Forms.Panel();
            this.pnlButtons.SuspendLayout();
            this.pnlVideo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictVideo)).BeginInit();
            this.pnlContent.SuspendLayout();
            this.pnlChat.SuspendLayout();
            this.SuspendLayout();
            // 
            // fpanelUsers
            // 
            this.fpanelUsers.AutoScroll = true;
            this.fpanelUsers.BackColor = System.Drawing.Color.LightSkyBlue;
            this.fpanelUsers.Dock = System.Windows.Forms.DockStyle.Left;
            this.fpanelUsers.Location = new System.Drawing.Point(0, 0);
            this.fpanelUsers.Margin = new System.Windows.Forms.Padding(0);
            this.fpanelUsers.Name = "fpanelUsers";
            this.fpanelUsers.Size = new System.Drawing.Size(209, 578);
            this.fpanelUsers.TabIndex = 1;
            this.fpanelUsers.Paint += new System.Windows.Forms.PaintEventHandler(this.fpanelUsers_Paint);
            // 
            // btnShowScreen
            // 
            this.btnShowScreen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnShowScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowScreen.Location = new System.Drawing.Point(333, 21);
            this.btnShowScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnShowScreen.Name = "btnShowScreen";
            this.btnShowScreen.Size = new System.Drawing.Size(153, 28);
            this.btnShowScreen.TabIndex = 4;
            this.btnShowScreen.Text = "Показать экран";
            this.btnShowScreen.UseVisualStyleBackColor = true;
            this.btnShowScreen.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // pnlButtons
            // 
            this.pnlButtons.BackColor = System.Drawing.Color.Aquamarine;
            this.pnlButtons.Controls.Add(this.btnStopSending);
            this.pnlButtons.Controls.Add(this.btnScreen);
            this.pnlButtons.Controls.Add(this.btnToChat);
            this.pnlButtons.Controls.Add(this.btnShowScreen);
            this.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlButtons.Location = new System.Drawing.Point(209, 514);
            this.pnlButtons.Margin = new System.Windows.Forms.Padding(4);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(968, 64);
            this.pnlButtons.TabIndex = 5;
            // 
            // btnStopSending
            // 
            this.btnStopSending.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStopSending.BackColor = System.Drawing.Color.Aquamarine;
            this.btnStopSending.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStopSending.Location = new System.Drawing.Point(494, 21);
            this.btnStopSending.Margin = new System.Windows.Forms.Padding(4);
            this.btnStopSending.Name = "btnStopSending";
            this.btnStopSending.Size = new System.Drawing.Size(153, 28);
            this.btnStopSending.TabIndex = 8;
            this.btnStopSending.Text = "Прекратить показ";
            this.btnStopSending.UseVisualStyleBackColor = false;
            this.btnStopSending.Click += new System.EventHandler(this.btnStopSending_Click);
            // 
            // btnScreen
            // 
            this.btnScreen.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScreen.Location = new System.Drawing.Point(766, 21);
            this.btnScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnScreen.Name = "btnScreen";
            this.btnScreen.Size = new System.Drawing.Size(153, 28);
            this.btnScreen.TabIndex = 7;
            this.btnScreen.Text = "Экран";
            this.btnScreen.UseVisualStyleBackColor = true;
            this.btnScreen.Click += new System.EventHandler(this.btnScreen_Click);
            // 
            // btnToChat
            // 
            this.btnToChat.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnToChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToChat.Location = new System.Drawing.Point(55, 23);
            this.btnToChat.Margin = new System.Windows.Forms.Padding(4);
            this.btnToChat.Name = "btnToChat";
            this.btnToChat.Size = new System.Drawing.Size(153, 28);
            this.btnToChat.TabIndex = 6;
            this.btnToChat.Text = "Чат";
            this.btnToChat.UseVisualStyleBackColor = true;
            this.btnToChat.Click += new System.EventHandler(this.btnToChat_Click);
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFullScreen.Location = new System.Drawing.Point(928, 4);
            this.btnFullScreen.Margin = new System.Windows.Forms.Padding(4);
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(36, 28);
            this.btnFullScreen.TabIndex = 4;
            this.btnFullScreen.UseVisualStyleBackColor = true;
            this.btnFullScreen.Click += new System.EventHandler(this.button1_Click);
            // 
            // pnlVideo
            // 
            this.pnlVideo.Controls.Add(this.btnFullScreen);
            this.pnlVideo.Controls.Add(this.pictVideo);
            this.pnlVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlVideo.Location = new System.Drawing.Point(0, 0);
            this.pnlVideo.Margin = new System.Windows.Forms.Padding(4);
            this.pnlVideo.Name = "pnlVideo";
            this.pnlVideo.Size = new System.Drawing.Size(968, 514);
            this.pnlVideo.TabIndex = 6;
            // 
            // pictVideo
            // 
            this.pictVideo.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.pictVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictVideo.Location = new System.Drawing.Point(0, 0);
            this.pictVideo.Margin = new System.Windows.Forms.Padding(4);
            this.pictVideo.Name = "pictVideo";
            this.pictVideo.Size = new System.Drawing.Size(968, 514);
            this.pictVideo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictVideo.TabIndex = 0;
            this.pictVideo.TabStop = false;
            // 
            // pnlContent
            // 
            this.pnlContent.Controls.Add(this.pnlChat);
            this.pnlContent.Controls.Add(this.pnlVideo);
            this.pnlContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContent.Location = new System.Drawing.Point(209, 0);
            this.pnlContent.Margin = new System.Windows.Forms.Padding(4);
            this.pnlContent.Name = "pnlContent";
            this.pnlContent.Size = new System.Drawing.Size(968, 514);
            this.pnlContent.TabIndex = 7;
            // 
            // pnlChat
            // 
            this.pnlChat.BackColor = System.Drawing.Color.Aquamarine;
            this.pnlChat.Controls.Add(this.txtMessage);
            this.pnlChat.Controls.Add(this.btnSendMessage);
            this.pnlChat.Controls.Add(this.pnlMessages);
            this.pnlChat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChat.Location = new System.Drawing.Point(0, 0);
            this.pnlChat.Margin = new System.Windows.Forms.Padding(4);
            this.pnlChat.Name = "pnlChat";
            this.pnlChat.Size = new System.Drawing.Size(968, 514);
            this.pnlChat.TabIndex = 8;
            // 
            // txtMessage
            // 
            this.txtMessage.BackColor = System.Drawing.Color.Aquamarine;
            this.txtMessage.Location = new System.Drawing.Point(55, 391);
            this.txtMessage.Margin = new System.Windows.Forms.Padding(4);
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(864, 70);
            this.txtMessage.TabIndex = 1;
            // 
            // btnSendMessage
            // 
            this.btnSendMessage.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSendMessage.BackColor = System.Drawing.Color.Aquamarine;
            this.btnSendMessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendMessage.Location = new System.Drawing.Point(415, 470);
            this.btnSendMessage.Margin = new System.Windows.Forms.Padding(4);
            this.btnSendMessage.Name = "btnSendMessage";
            this.btnSendMessage.Size = new System.Drawing.Size(153, 28);
            this.btnSendMessage.TabIndex = 9;
            this.btnSendMessage.Text = "Отправить";
            this.btnSendMessage.UseVisualStyleBackColor = false;
            this.btnSendMessage.Click += new System.EventHandler(this.btnSendMessage_Click);
            // 
            // pnlMessages
            // 
            this.pnlMessages.BackColor = System.Drawing.Color.Aquamarine;
            this.pnlMessages.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlMessages.Location = new System.Drawing.Point(0, 0);
            this.pnlMessages.Margin = new System.Windows.Forms.Padding(4);
            this.pnlMessages.Name = "pnlMessages";
            this.pnlMessages.Size = new System.Drawing.Size(968, 367);
            this.pnlMessages.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1177, 578);
            this.Controls.Add(this.pnlContent);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.fpanelUsers);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMain_FormClosed);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.pnlButtons.ResumeLayout(false);
            this.pnlVideo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictVideo)).EndInit();
            this.pnlContent.ResumeLayout(false);
            this.pnlChat.ResumeLayout(false);
            this.pnlChat.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel fpanelUsers;
        private System.Windows.Forms.Button btnShowScreen;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnToChat;
        private System.Windows.Forms.Button btnScreen;
        private System.Windows.Forms.Button btnStopSending;
        private System.Windows.Forms.Button btnFullScreen;
        private System.Windows.Forms.Panel pnlVideo;
        private System.Windows.Forms.PictureBox pictVideo;
        private System.Windows.Forms.Panel pnlContent;
        private System.Windows.Forms.Panel pnlChat;
        private System.Windows.Forms.Panel pnlMessages;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnSendMessage;
    }
}