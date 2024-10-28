namespace MultiChatClient
{
    partial class ChatView
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
        /*
        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
        }

        #endregion

        #region Windows Form Designer generated code
        */
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxInputMessage = new System.Windows.Forms.TextBox();
            this.BtnSendMessage = new System.Windows.Forms.Button();
            this.BtnCloseProgram = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.TextBox();
            this.ParticipantsBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.NoticeBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // TextBoxInputMessage
            // 
            this.TextBoxInputMessage.Location = new System.Drawing.Point(25, 398);
            this.TextBoxInputMessage.Name = "TextBoxInputMessage";
            this.TextBoxInputMessage.Size = new System.Drawing.Size(574, 25);
            this.TextBoxInputMessage.TabIndex = 0;
            this.TextBoxInputMessage.TextChanged += new System.EventHandler(this.TextChangedTextBoxInputMessage);
            // 
            // BtnSendMessage
            // 
            this.BtnSendMessage.Location = new System.Drawing.Point(623, 398);
            this.BtnSendMessage.Name = "BtnSendMessage";
            this.BtnSendMessage.Size = new System.Drawing.Size(75, 26);
            this.BtnSendMessage.TabIndex = 1;
            this.BtnSendMessage.Text = "전송";
            this.BtnSendMessage.UseVisualStyleBackColor = true;
            this.BtnSendMessage.Click += new System.EventHandler(this.ClickBtnSendMessage);
            // 
            // BtnCloseProgram
            // 
            this.BtnCloseProgram.Location = new System.Drawing.Point(704, 401);
            this.BtnCloseProgram.Name = "BtnCloseProgram";
            this.BtnCloseProgram.Size = new System.Drawing.Size(75, 26);
            this.BtnCloseProgram.TabIndex = 2;
            this.BtnCloseProgram.Text = "종료";
            this.BtnCloseProgram.UseVisualStyleBackColor = true;
            this.BtnCloseProgram.Click += new System.EventHandler(this.ClickBtnCloseProgram);
            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.Color.White;
            this.ChatBox.Enabled = false;
            this.ChatBox.Location = new System.Drawing.Point(26, 88);
            this.ChatBox.Multiline = true;
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ChatBox.Size = new System.Drawing.Size(573, 292);
            this.ChatBox.TabIndex = 3;
            // 
            // ParticipantsBox
            // 
            this.ParticipantsBox.BackColor = System.Drawing.Color.White;
            this.ParticipantsBox.Enabled = false;
            this.ParticipantsBox.Location = new System.Drawing.Point(623, 119);
            this.ParticipantsBox.Multiline = true;
            this.ParticipantsBox.Name = "ParticipantsBox";
            this.ParticipantsBox.ReadOnly = true;
            this.ParticipantsBox.Size = new System.Drawing.Size(156, 261);
            this.ParticipantsBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.label1.Location = new System.Drawing.Point(623, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 28);
            this.label1.TabIndex = 5;
            this.label1.Text = "참여자 목록";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // NoticeBox
            // 
            this.NoticeBox.Enabled = false;
            this.NoticeBox.Location = new System.Drawing.Point(26, 45);
            this.NoticeBox.Name = "NoticeBox";
            this.NoticeBox.Size = new System.Drawing.Size(573, 25);
            this.NoticeBox.TabIndex = 6;
            // 
            // ChatView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.NoticeBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ParticipantsBox);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.BtnCloseProgram);
            this.Controls.Add(this.BtnSendMessage);
            this.Controls.Add(this.TextBoxInputMessage);
            this.Name = "ChatView";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TextBoxInputMessage;
        private System.Windows.Forms.Button BtnSendMessage;
        private System.Windows.Forms.Button BtnCloseProgram;
        private System.Windows.Forms.TextBox ChatBox;
        private System.Windows.Forms.TextBox ParticipantsBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NoticeBox;

        public TextBox GetTextBoxInputMessage => TextBoxInputMessage;
        public TextBox GetChatBox => ChatBox;
    }
}
