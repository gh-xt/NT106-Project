using Werewolf.Properties;

namespace Werewolf.Views
{
    partial class GameSettingsWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AvailableRoleList = new System.Windows.Forms.ListBox();
            this.ChosenRoleList = new System.Windows.Forms.ListBox();
            this.AddRoleBtn = new System.Windows.Forms.Button();
            this.RemoveRoleBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Role có sẵn:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(265, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Role đã thêm:";
            // 
            // AvailableRoleList
            // 
            this.AvailableRoleList.FormattingEnabled = true;
            this.AvailableRoleList.Location = new System.Drawing.Point(13, 51);
            this.AvailableRoleList.Name = "AvailableRoleList";
            this.AvailableRoleList.Size = new System.Drawing.Size(167, 329);
            this.AvailableRoleList.TabIndex = 2;
            // 
            // ChosenRoleList
            // 
            this.ChosenRoleList.FormattingEnabled = true;
            this.ChosenRoleList.Location = new System.Drawing.Point(268, 51);
            this.ChosenRoleList.Name = "ChosenRoleList";
            this.ChosenRoleList.Size = new System.Drawing.Size(167, 329);
            this.ChosenRoleList.TabIndex = 3;
            this.ChosenRoleList.SelectedIndexChanged += new System.EventHandler(this.ChosenRoleList_SelectedIndexChanged);
            // 
            // AddRoleBtn
            // 
            this.AddRoleBtn.Location = new System.Drawing.Point(186, 161);
            this.AddRoleBtn.Name = "AddRoleBtn";
            this.AddRoleBtn.Size = new System.Drawing.Size(75, 32);
            this.AddRoleBtn.TabIndex = 4;
            this.AddRoleBtn.UseVisualStyleBackColor = true;
            // 
            // RemoveRoleBtn
            // 
            this.RemoveRoleBtn.Location = new System.Drawing.Point(186, 206);
            this.RemoveRoleBtn.Name = "RemoveRoleBtn";
            this.RemoveRoleBtn.Size = new System.Drawing.Size(75, 32);
            this.RemoveRoleBtn.TabIndex = 5;
            this.RemoveRoleBtn.UseVisualStyleBackColor = true;
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(360, 398);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(75, 41);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "OK";
            this.OkBtn.UseVisualStyleBackColor = true;
            // 
            // GameSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 451);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.RemoveRoleBtn);
            this.Controls.Add(this.AddRoleBtn);
            this.Controls.Add(this.ChosenRoleList);
            this.Controls.Add(this.AvailableRoleList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "GameSettingsWindow";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox AvailableRoleList;
        private System.Windows.Forms.ListBox ChosenRoleList;
        private System.Windows.Forms.Button AddRoleBtn;
        private System.Windows.Forms.Button RemoveRoleBtn;
        private System.Windows.Forms.Button OkBtn;

    }
}