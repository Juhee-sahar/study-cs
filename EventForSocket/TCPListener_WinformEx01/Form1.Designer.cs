namespace WinFormsApp2
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
            button1 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            button2 = new System.Windows.Forms.Button();
            textBox1 = new System.Windows.Forms.TextBox();
            button3 = new System.Windows.Forms.Button();
            textBox2 = new System.Windows.Forms.TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(11, 11);
            button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(307, 29);
            button1.TabIndex = 0;
            button1.Text = "연결 요청 대기";
            button1.UseVisualStyleBackColor = true;
            button1.Click += BtnAcceptIncomingAsync_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9, 227);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(54, 20);
            label1.TabIndex = 1;
            label1.Text = "메시지";
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(71, 259);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(247, 29);
            button2.TabIndex = 2;
            button2.Text = "메시지 전송";
            button2.UseVisualStyleBackColor = true;
            button2.Click += BtnSendAll_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new System.Drawing.Point(71, 227);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(248, 27);
            textBox1.TabIndex = 3;
            textBox1.Text = "메시지를 입력해주세요";
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(11, 45);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(307, 29);
            button3.TabIndex = 4;
            button3.Text = "서버 종료";
            button3.UseVisualStyleBackColor = true;
            button3.Click += BtnStopServer_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new System.Drawing.Point(15, 83);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new System.Drawing.Size(299, 138);
            textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(326, 300);
            Controls.Add(textBox2);
            Controls.Add(button3);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(button1);
            Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox textBox2;
    }
}
