namespace Werewolf.Views
{
    partial class GameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameView));
            this.RoleList = new System.Windows.Forms.ListBox();
            this.UserList = new System.Windows.Forms.ListBox();
            this.ChatBox = new System.Windows.Forms.RichTextBox();
            this.Message = new System.Windows.Forms.TextBox();
            this.SendMessage = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RoleList
            // 
            this.RoleList.FormattingEnabled = true;
            this.RoleList.Location = new System.Drawing.Point(-1, 2);
            this.RoleList.Name = "RoleList";
            this.RoleList.Size = new System.Drawing.Size(160, 446);
            this.RoleList.TabIndex = 0;
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.Location = new System.Drawing.Point(602, 2);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(160, 446);
            this.UserList.TabIndex = 1;
            // 
            // ChatBox
            // 
            this.ChatBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatBox.Location = new System.Drawing.Point(165, 30);
            this.ChatBox.Name = "ChatBox";
            this.ChatBox.Size = new System.Drawing.Size(431, 418);
            this.ChatBox.TabIndex = 2;
            this.ChatBox.Text = "";
            // 
            // Message
            // 
            this.Message.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Message.Location = new System.Drawing.Point(-1, 469);
            this.Message.Name = "Message";
            this.Message.Size = new System.Drawing.Size(597, 22);
            this.Message.TabIndex = 3;
            // 
            // SendMessage
            // 
            this.SendMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMessage.Image = ((System.Drawing.Image)(resources.GetObject("SendMessage.Image")));
            this.SendMessage.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.SendMessage.Location = new System.Drawing.Point(603, 454);
            this.SendMessage.Name = "SendMessage";
            this.SendMessage.Size = new System.Drawing.Size(148, 38);
            this.SendMessage.TabIndex = 4;
            this.SendMessage.Text = "Gửi";
            this.SendMessage.UseVisualStyleBackColor = true;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(763, 501);
            this.Controls.Add(this.SendMessage);
            this.Controls.Add(this.Message);
            this.Controls.Add(this.ChatBox);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.RoleList);
            this.Name = "GameView";
            this.Text = "GameView";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox RoleList;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.RichTextBox ChatBox;
        private System.Windows.Forms.TextBox Message;
        private System.Windows.Forms.Button SendMessage;
    }
}