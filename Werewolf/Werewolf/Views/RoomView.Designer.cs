namespace Werewolf.Views
{
    partial class RoomView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomView));
            this.UserList = new System.Windows.Forms.ListBox();
            this.StartGame = new System.Windows.Forms.Button();
            this.SendMessage = new System.Windows.Forms.Button();
            this.SettingsBtn = new System.Windows.Forms.Button();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(516, 48);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(147, 342);
            this.UserList.TabIndex = 0;
            // 
            // StartGame
            // 
            this.StartGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartGame.Image = ((System.Drawing.Image)(resources.GetObject("StartGame.Image")));
            this.StartGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.StartGame.Location = new System.Drawing.Point(516, 7);
            this.StartGame.Name = "StartGame";
            this.StartGame.Size = new System.Drawing.Size(147, 35);
            this.StartGame.TabIndex = 1;
            this.StartGame.Text = "Bắt đầu";
            this.StartGame.UseVisualStyleBackColor = true;
            // 
            // SendMessage
            // 
            this.SendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMessage.Image = ((System.Drawing.Image)(resources.GetObject("SendMessage.Image")));
            this.SendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendMessage.Location = new System.Drawing.Point(516, 405);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(147, 35);
            this.SendMessage.TabIndex = 2;
            this.SendMessage.Text = "Gửi";
            this.SendMessage.UseVisualStyleBackColor = true;

            // 
            // SettingsBtn
            // 
            this.SettingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SettingsBtn.Image = ((System.Drawing.Image)(resources.GetObject("SettingsBtn.Image")));
            this.SettingsBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SettingsBtn.Location = new System.Drawing.Point(347, 7);
            this.SettingsBtn.Name = "SettingsBtn";
            this.SettingsBtn.Size = new System.Drawing.Size(147, 35);
            this.SettingsBtn.TabIndex = 3;
            this.SettingsBtn.Text = "Cài đặt";
            this.SettingsBtn.UseVisualStyleBackColor = true;

            // 
            // ChatBox
            // 
            this.ChatBox.BackColor = System.Drawing.SystemColors.Window;
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatBox.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ChatBox.Location = new System.Drawing.Point(14, 48);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.ReadOnly = true;
            this.ChatBox.Size = new System.Drawing.Size(480, 342);
            this.ChatBox.TabIndex = 4;
            this.ChatBox.Text = "";
            // 
            // Message
            // 
            this.Message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(14, 414);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(480, 19);
            this.Message.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Kết nối với phòng: ";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.Location = new System.Drawing.Point(123, 17);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(165, 15);
            this.textBox1.TabIndex = 7;
            // 
            // RoomView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 447);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.SettingsBtn);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.StartGame);
            this.Controls.Add(this.UserList);
            this.Name = "RoomView";
            this.Text = "RoomView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.Button StartGame;
        private System.Windows.Forms.Button SendMessage;
        private System.Windows.Forms.Button SettingsBtn;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;

    }
}