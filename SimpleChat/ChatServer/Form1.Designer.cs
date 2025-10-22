namespace ChatServer
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
            button1 = new Button();
            button2 = new Button();
            label1 = new Label();
            labelClintList = new Label();
            label3 = new Label();
            labelChatLog = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            checkBox1 = new CheckBox();
            label6 = new Label();
            textBox2 = new TextBox();
            button3 = new Button();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(370, 40);
            button1.TabIndex = 0;
            button1.Text = "연결 대기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnAcceptIncoming_Click;
            // 
            // button2
            // 
            button2.Location = new Point(400, 12);
            button2.Name = "button2";
            button2.Size = new Size(370, 40);
            button2.TabIndex = 1;
            button2.Text = "프로그램 종료";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnDisconnectServer_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 73);
            label1.Name = "label1";
            label1.Size = new Size(134, 20);
            label1.TabIndex = 2;
            label1.Text = "클라이언트 리스트";
            // 
            // labelClintList
            // 
            labelClintList.BackColor = SystemColors.ButtonHighlight;
            labelClintList.BorderStyle = BorderStyle.FixedSingle;
            labelClintList.Location = new Point(12, 107);
            labelClintList.Name = "labelClintList";
            labelClintList.Size = new Size(256, 439);
            labelClintList.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(289, 73);
            label3.Name = "label3";
            label3.Size = new Size(74, 20);
            label3.TabIndex = 4;
            label3.Text = "채팅 로그";
            // 
            // labelChatLog
            // 
            labelChatLog.BackColor = SystemColors.ButtonHighlight;
            labelChatLog.BorderStyle = BorderStyle.FixedSingle;
            labelChatLog.Location = new Point(289, 107);
            labelChatLog.Name = "labelChatLog";
            labelChatLog.Size = new Size(481, 439);
            labelChatLog.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 560);
            label5.Name = "label5";
            label5.Size = new Size(184, 20);
            label5.TabIndex = 6;
            label5.Text = "클라이언트에 메세지 전송";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 583);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(758, 93);
            textBox1.TabIndex = 7;
            textBox1.TextAlign = HorizontalAlignment.Right;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(12, 682);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(111, 24);
            checkBox1.TabIndex = 8;
            checkBox1.Text = "모든 사용자";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(160, 686);
            label6.Name = "label6";
            label6.Size = new Size(35, 20);
            label6.TabIndex = 9;
            label6.Text = "IP : ";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(201, 682);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(391, 27);
            textBox2.TabIndex = 10;
            textBox2.TextAlign = HorizontalAlignment.Right;
            // 
            // button3
            // 
            button3.Location = new Point(620, 682);
            button3.Name = "button3";
            button3.Size = new Size(150, 27);
            button3.TabIndex = 11;
            button3.Text = "전송";
            button3.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 753);
            Controls.Add(button3);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(checkBox1);
            Controls.Add(textBox1);
            Controls.Add(label5);
            Controls.Add(labelChatLog);
            Controls.Add(label3);
            Controls.Add(labelClintList);
            Controls.Add(label1);
            Controls.Add(button2);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Label label1;
        private Label labelClintList;
        private Label label3;
        private Label labelChatLog;
        private Label label5;
        private TextBox textBox1;
        private CheckBox checkBox1;
        private Label label6;
        private TextBox textBox2;
        private Button button3;
    }
}
