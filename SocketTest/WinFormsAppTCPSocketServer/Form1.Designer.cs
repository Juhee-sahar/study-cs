namespace WinFormsAppTCPSocketServer
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
            button3 = new Button();
            textBox1 = new TextBox();
            label1 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(13, 13);
            button1.Margin = new Padding(4);
            button1.Name = "button1";
            button1.Size = new Size(478, 82);
            button1.TabIndex = 0;
            button1.Text = "연결 요청 수락";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnAcceptIncomingAsync_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 231);
            button2.Name = "button2";
            button2.Size = new Size(485, 82);
            button2.TabIndex = 2;
            button2.Text = "전송";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnSendAll_Click;
            // 
            // button3
            // 
            button3.Location = new Point(12, 588);
            button3.Name = "button3";
            button3.Size = new Size(485, 82);
            button3.TabIndex = 4;
            button3.Text = "접속종료";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnStopServer_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(12, 188);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(485, 27);
            textBox1.TabIndex = 5;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 165);
            label1.Name = "label1";
            label1.Size = new Size(152, 20);
            label1.TabIndex = 6;
            label1.Text = "텍스트를 입력하세요.";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(504, 682);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Margin = new Padding(4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Button button2;
        private Button button3;
        private TextBox textBox1;
        private Label label1;
    }
}
