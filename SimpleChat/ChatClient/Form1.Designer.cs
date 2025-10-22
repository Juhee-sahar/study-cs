namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            textBoxIP = new TextBox();
            textBoxPortNum = new TextBox();
            label2 = new Label();
            BtnServerConnect = new Button();
            textBox1 = new TextBox();
            BtnSendChatMassage = new Button();
            labelChatLog = new Label();
            BtnServerDisconnect = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 20);
            label1.Name = "label1";
            label1.Size = new Size(35, 20);
            label1.TabIndex = 0;
            label1.Text = "IP : ";
            // 
            // textBoxIP
            // 
            textBoxIP.Location = new Point(56, 17);
            textBoxIP.Name = "textBoxIP";
            textBoxIP.Size = new Size(237, 27);
            textBoxIP.TabIndex = 1;
            // 
            // textBoxPortNum
            // 
            textBoxPortNum.Location = new Point(365, 17);
            textBoxPortNum.Name = "textBoxPortNum";
            textBoxPortNum.Size = new Size(128, 27);
            textBoxPortNum.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(299, 20);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 2;
            label2.Text = "PORT : ";
            // 
            // BtnServerConnect
            // 
            BtnServerConnect.Location = new Point(501, 11);
            BtnServerConnect.Name = "BtnServerConnect";
            BtnServerConnect.Size = new Size(269, 39);
            BtnServerConnect.TabIndex = 4;
            BtnServerConnect.Text = "연결";
            BtnServerConnect.UseVisualStyleBackColor = true;
            BtnServerConnect.Click += BtnServerConnect_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 551);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(758, 91);
            textBox1.TabIndex = 6;
            // 
            // BtnSendChatMassage
            // 
            BtnSendChatMassage.Location = new Point(12, 648);
            BtnSendChatMassage.Name = "BtnSendChatMassage";
            BtnSendChatMassage.Size = new Size(758, 39);
            BtnSendChatMassage.TabIndex = 7;
            BtnSendChatMassage.Text = "전송";
            BtnSendChatMassage.UseVisualStyleBackColor = true;
            BtnSendChatMassage.Click += BtnSendChatMassage_Click;
            // 
            // labelChatLog
            // 
            labelChatLog.BorderStyle = BorderStyle.FixedSingle;
            labelChatLog.Location = new Point(12, 61);
            labelChatLog.Name = "labelChatLog";
            labelChatLog.Size = new Size(758, 482);
            labelChatLog.TabIndex = 8;
            // 
            // BtnServerDisconnect
            // 
            BtnServerDisconnect.Location = new Point(659, 702);
            BtnServerDisconnect.Name = "BtnServerDisconnect";
            BtnServerDisconnect.Size = new Size(111, 39);
            BtnServerDisconnect.TabIndex = 9;
            BtnServerDisconnect.Text = "연결 해제";
            BtnServerDisconnect.UseVisualStyleBackColor = true;
            BtnServerDisconnect.Click += BtnServerDisconnect_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 753);
            Controls.Add(BtnServerDisconnect);
            Controls.Add(labelChatLog);
            Controls.Add(BtnSendChatMassage);
            Controls.Add(textBox1);
            Controls.Add(BtnServerConnect);
            Controls.Add(textBoxPortNum);
            Controls.Add(label2);
            Controls.Add(textBoxIP);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxIP;
        private TextBox textBoxPortNum;
        private Label label2;
        private Button BtnServerConnect;
        private TextBox textBox1;
        private Button BtnSendChatMassage;
        private Label labelChatLog;
        private Button BtnServerDisconnect;
    }
}
