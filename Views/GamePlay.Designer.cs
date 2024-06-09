namespace Werewolf
{
    partial class GamePlay
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GamePlay));
            this.btn_Start = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btn_Werewolf = new System.Windows.Forms.Button();
            this.btn_Justice = new System.Windows.Forms.Button();
            this.txtBox_BoardWerewolf = new System.Windows.Forms.TextBox();
            this.txtBox_BoardJustice = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox_Werewolf = new System.Windows.Forms.ListBox();
            this.listBox_Seer = new System.Windows.Forms.ListBox();
            this.listBox_Witch = new System.Windows.Forms.ListBox();
            this.listBox_Villager = new System.Windows.Forms.ListBox();
            this.groupBox_news = new System.Windows.Forms.GroupBox();
            this.textBox_death = new System.Windows.Forms.TextBox();
            this.lblUmreni = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox_details = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox_round = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbl_action = new System.Windows.Forms.Label();
            this.txtBox_Villager = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtBox_Witch = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBox_Seer = new System.Windows.Forms.TextBox();
            this.txtBox_Werewolf = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblusercount = new System.Windows.Forms.Label();
            this.userList = new System.Windows.Forms.ListBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            this.groupBox_news.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Start
            // 
            this.btn_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Start.ForeColor = System.Drawing.Color.Black;
            this.btn_Start.Location = new System.Drawing.Point(17, 410);
            this.btn_Start.Name = "btn_Start";
            this.btn_Start.Size = new System.Drawing.Size(147, 40);
            this.btn_Start.TabIndex = 5;
            this.btn_Start.Text = "Bắt đầu";
            this.btn_Start.UseVisualStyleBackColor = true;
            this.btn_Start.Click += new System.EventHandler(this.Btn_Generate_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(183, 410);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(161, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.PictureBox1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(349, 410);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(160, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 14;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(515, 410);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(160, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 15;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(681, 410);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(160, 40);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 20;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTime.Location = new System.Drawing.Point(236, 30);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(79, 20);
            this.lblTime.TabIndex = 801;
            this.lblTime.Text = "00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // btn_Werewolf
            // 
            this.btn_Werewolf.BackColor = System.Drawing.Color.Transparent;
            this.btn_Werewolf.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Werewolf.BackgroundImage")));
            this.btn_Werewolf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Werewolf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Werewolf.Enabled = false;
            this.btn_Werewolf.FlatAppearance.BorderSize = 0;
            this.btn_Werewolf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Werewolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Werewolf.Location = new System.Drawing.Point(17, 266);
            this.btn_Werewolf.Name = "btn_Werewolf";
            this.btn_Werewolf.Size = new System.Drawing.Size(61, 66);
            this.btn_Werewolf.TabIndex = 802;
            this.btn_Werewolf.TabStop = false;
            this.btn_Werewolf.UseVisualStyleBackColor = false;
            this.btn_Werewolf.Click += new System.EventHandler(this.Btn_Werewolf_Click);
            // 
            // btn_Justice
            // 
            this.btn_Justice.BackColor = System.Drawing.Color.Transparent;
            this.btn_Justice.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Justice.BackgroundImage")));
            this.btn_Justice.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_Justice.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn_Justice.Enabled = false;
            this.btn_Justice.FlatAppearance.BorderSize = 0;
            this.btn_Justice.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Justice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btn_Justice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Justice.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btn_Justice.Location = new System.Drawing.Point(103, 266);
            this.btn_Justice.Name = "btn_Justice";
            this.btn_Justice.Size = new System.Drawing.Size(61, 66);
            this.btn_Justice.TabIndex = 803;
            this.btn_Justice.TabStop = false;
            this.btn_Justice.UseVisualStyleBackColor = false;
            this.btn_Justice.Click += new System.EventHandler(this.btn_Justice_Click);
            // 
            // txtBox_BoardWerewolf
            // 
            this.txtBox_BoardWerewolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_BoardWerewolf.Location = new System.Drawing.Point(17, 343);
            this.txtBox_BoardWerewolf.Name = "txtBox_BoardWerewolf";
            this.txtBox_BoardWerewolf.ReadOnly = true;
            this.txtBox_BoardWerewolf.Size = new System.Drawing.Size(61, 30);
            this.txtBox_BoardWerewolf.TabIndex = 804;
            this.txtBox_BoardWerewolf.TabStop = false;
            this.txtBox_BoardWerewolf.Text = "0";
            this.txtBox_BoardWerewolf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtBox_BoardJustice
            // 
            this.txtBox_BoardJustice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_BoardJustice.Location = new System.Drawing.Point(103, 343);
            this.txtBox_BoardJustice.Name = "txtBox_BoardJustice";
            this.txtBox_BoardJustice.ReadOnly = true;
            this.txtBox_BoardJustice.Size = new System.Drawing.Size(61, 30);
            this.txtBox_BoardJustice.TabIndex = 805;
            this.txtBox_BoardJustice.TabStop = false;
            this.txtBox_BoardJustice.Text = "0";
            this.txtBox_BoardJustice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(82, 345);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(19, 25);
            this.label7.TabIndex = 806;
            this.label7.Text = "-";
            // 
            // listBox_Werewolf
            // 
            this.listBox_Werewolf.BackColor = System.Drawing.Color.Black;
            this.listBox_Werewolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Werewolf.ForeColor = System.Drawing.Color.White;
            this.listBox_Werewolf.FormattingEnabled = true;
            this.listBox_Werewolf.ItemHeight = 20;
            this.listBox_Werewolf.Location = new System.Drawing.Point(183, 260);
            this.listBox_Werewolf.Name = "listBox_Werewolf";
            this.listBox_Werewolf.Size = new System.Drawing.Size(160, 144);
            this.listBox_Werewolf.TabIndex = 807;
            this.listBox_Werewolf.SelectedIndexChanged += new System.EventHandler(this.ListBox_Werewolf_SelectedIndexChanged);
            // 
            // listBox_Seer
            // 
            this.listBox_Seer.BackColor = System.Drawing.Color.Navy;
            this.listBox_Seer.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Seer.ForeColor = System.Drawing.Color.White;
            this.listBox_Seer.FormattingEnabled = true;
            this.listBox_Seer.ItemHeight = 20;
            this.listBox_Seer.Location = new System.Drawing.Point(349, 260);
            this.listBox_Seer.Name = "listBox_Seer";
            this.listBox_Seer.Size = new System.Drawing.Size(160, 144);
            this.listBox_Seer.TabIndex = 808;
            this.listBox_Seer.SelectedIndexChanged += new System.EventHandler(this.ListBox_Seer_SelectedIndexChanged);
            // 
            // listBox_Witch
            // 
            this.listBox_Witch.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Witch.FormattingEnabled = true;
            this.listBox_Witch.ItemHeight = 20;
            this.listBox_Witch.Location = new System.Drawing.Point(515, 260);
            this.listBox_Witch.Name = "listBox_Witch";
            this.listBox_Witch.Size = new System.Drawing.Size(160, 144);
            this.listBox_Witch.TabIndex = 809;
            this.listBox_Witch.SelectedIndexChanged += new System.EventHandler(this.listBox_Witch_SelectedIndexChanged);
            // 
            // listBox_Villager
            // 
            this.listBox_Villager.BackColor = System.Drawing.Color.Silver;
            this.listBox_Villager.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.listBox_Villager.FormattingEnabled = true;
            this.listBox_Villager.ItemHeight = 20;
            this.listBox_Villager.Location = new System.Drawing.Point(681, 260);
            this.listBox_Villager.Name = "listBox_Villager";
            this.listBox_Villager.Size = new System.Drawing.Size(160, 144);
            this.listBox_Villager.TabIndex = 810;
            this.listBox_Villager.SelectedIndexChanged += new System.EventHandler(this.ListBox_Villager_SelectedIndexChanged);
            // 
            // groupBox_news
            // 
            this.groupBox_news.Controls.Add(this.textBox_death);
            this.groupBox_news.Controls.Add(this.lblUmreni);
            this.groupBox_news.Controls.Add(this.button3);
            this.groupBox_news.Controls.Add(this.textBox_details);
            this.groupBox_news.Controls.Add(this.button1);
            this.groupBox_news.Controls.Add(this.textBox_round);
            this.groupBox_news.Controls.Add(this.label8);
            this.groupBox_news.Controls.Add(this.lblTime);
            this.groupBox_news.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_news.Location = new System.Drawing.Point(183, 9);
            this.groupBox_news.Name = "groupBox_news";
            this.groupBox_news.Size = new System.Drawing.Size(657, 221);
            this.groupBox_news.TabIndex = 811;
            this.groupBox_news.TabStop = false;
            this.groupBox_news.Text = "Tin tức";
            this.groupBox_news.Visible = false;
            // 
            // textBox_death
            // 
            this.textBox_death.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_death.ForeColor = System.Drawing.Color.Red;
            this.textBox_death.Location = new System.Drawing.Point(497, 63);
            this.textBox_death.Multiline = true;
            this.textBox_death.Name = "textBox_death";
            this.textBox_death.ReadOnly = true;
            this.textBox_death.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_death.Size = new System.Drawing.Size(154, 152);
            this.textBox_death.TabIndex = 12;
            // 
            // lblUmreni
            // 
            this.lblUmreni.AutoSize = true;
            this.lblUmreni.BackColor = System.Drawing.Color.Transparent;
            this.lblUmreni.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblUmreni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblUmreni.Location = new System.Drawing.Point(493, 30);
            this.lblUmreni.Name = "lblUmreni";
            this.lblUmreni.Size = new System.Drawing.Size(77, 20);
            this.lblUmreni.TabIndex = 11;
            this.lblUmreni.Text = "Tử vong:";
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button3.BackgroundImage")));
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button3.Location = new System.Drawing.Point(409, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(78, 26);
            this.button3.TabIndex = 813;
            this.button3.TabStop = false;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.Button2_Click);
            // 
            // textBox_details
            // 
            this.textBox_details.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_details.Location = new System.Drawing.Point(9, 63);
            this.textBox_details.Multiline = true;
            this.textBox_details.Name = "textBox_details";
            this.textBox_details.ReadOnly = true;
            this.textBox_details.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_details.Size = new System.Drawing.Size(482, 152);
            this.textBox_details.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.Color.Black;
            this.button1.Location = new System.Drawing.Point(107, 27);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 26);
            this.button1.TabIndex = 9;
            this.button1.Text = "Ngày tiếp theo";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // textBox_round
            // 
            this.textBox_round.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_round.Location = new System.Drawing.Point(60, 27);
            this.textBox_round.Name = "textBox_round";
            this.textBox_round.ReadOnly = true;
            this.textBox_round.Size = new System.Drawing.Size(41, 26);
            this.textBox_round.TabIndex = 8;
            this.textBox_round.Text = "1";
            this.textBox_round.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 30);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 20);
            this.label8.TabIndex = 7;
            this.label8.Text = "Ngày:";
            // 
            // lbl_action
            // 
            this.lbl_action.AutoSize = true;
            this.lbl_action.BackColor = System.Drawing.Color.Transparent;
            this.lbl_action.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lbl_action.ForeColor = System.Drawing.Color.Red;
            this.lbl_action.Location = new System.Drawing.Point(188, 233);
            this.lbl_action.Name = "lbl_action";
            this.lbl_action.Size = new System.Drawing.Size(0, 20);
            this.lbl_action.TabIndex = 812;
            // 
            // txtBox_Villager
            // 
            this.txtBox_Villager.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_Villager.Location = new System.Drawing.Point(140, 28);
            this.txtBox_Villager.Name = "txtBox_Villager";
            this.txtBox_Villager.Size = new System.Drawing.Size(24, 20);
            this.txtBox_Villager.TabIndex = 800;
            this.txtBox_Villager.TabStop = false;
            this.txtBox_Villager.Text = "0";
            this.txtBox_Villager.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBox_Villager.TextChanged += new System.EventHandler(this.TxtBox_Villager_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(85, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Dân làng";
            // 
            // txtBox_Witch
            // 
            this.txtBox_Witch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_Witch.Location = new System.Drawing.Point(140, 8);
            this.txtBox_Witch.Name = "txtBox_Witch";
            this.txtBox_Witch.Size = new System.Drawing.Size(25, 20);
            this.txtBox_Witch.TabIndex = 4;
            this.txtBox_Witch.Text = "0";
            this.txtBox_Witch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBox_Witch.TextChanged += new System.EventHandler(this.TxtBox_Witch_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(85, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Phù thủy";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Tiên tri";
            // 
            // txtBox_Seer
            // 
            this.txtBox_Seer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_Seer.Location = new System.Drawing.Point(57, 28);
            this.txtBox_Seer.Name = "txtBox_Seer";
            this.txtBox_Seer.Size = new System.Drawing.Size(25, 20);
            this.txtBox_Seer.TabIndex = 3;
            this.txtBox_Seer.Text = "0";
            this.txtBox_Seer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBox_Seer.TextChanged += new System.EventHandler(this.TxtBox_Seer_TextChanged);
            // 
            // txtBox_Werewolf
            // 
            this.txtBox_Werewolf.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtBox_Werewolf.Location = new System.Drawing.Point(57, 8);
            this.txtBox_Werewolf.Name = "txtBox_Werewolf";
            this.txtBox_Werewolf.Size = new System.Drawing.Size(25, 20);
            this.txtBox_Werewolf.TabIndex = 2;
            this.txtBox_Werewolf.Text = "0";
            this.txtBox_Werewolf.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBox_Werewolf.TextChanged += new System.EventHandler(this.TxtBox_Werewolf_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Ma sói";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label9.Location = new System.Drawing.Point(12, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 20);
            this.label9.TabIndex = 814;
            this.label9.Text = "Số người chơi:";
            // 
            // lblusercount
            // 
            this.lblusercount.AutoSize = true;
            this.lblusercount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblusercount.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblusercount.Location = new System.Drawing.Point(128, 57);
            this.lblusercount.Name = "lblusercount";
            this.lblusercount.Size = new System.Drawing.Size(0, 20);
            this.lblusercount.TabIndex = 815;
            // 
            // userList
            // 
            this.userList.FormattingEnabled = true;
            this.userList.Location = new System.Drawing.Point(16, 96);
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(148, 134);
            this.userList.TabIndex = 816;
            this.userList.SelectedIndexChanged += new System.EventHandler(this.userList_SelectedIndexChanged);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(183, 7);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(659, 246);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 817;
            this.pictureBox5.TabStop = false;
            // 
            // GamePlay
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 457);
            this.Controls.Add(this.userList);
            this.Controls.Add(this.lblusercount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.lbl_action);
            this.Controls.Add(this.groupBox_news);
            this.Controls.Add(this.listBox_Villager);
            this.Controls.Add(this.listBox_Witch);
            this.Controls.Add(this.listBox_Seer);
            this.Controls.Add(this.listBox_Werewolf);
            this.Controls.Add(this.txtBox_BoardJustice);
            this.Controls.Add(this.txtBox_BoardWerewolf);
            this.Controls.Add(this.btn_Justice);
            this.Controls.Add(this.btn_Werewolf);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtBox_Villager);
            this.Controls.Add(this.btn_Start);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtBox_Witch);
            this.Controls.Add(this.txtBox_Seer);
            this.Controls.Add(this.txtBox_Werewolf);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox5);
            this.MaximizeBox = false;
            this.Name = "GamePlay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Werewolf";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            this.groupBox_news.ResumeLayout(false);
            this.groupBox_news.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_Start;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_Werewolf;
        private System.Windows.Forms.Button btn_Justice;
        private System.Windows.Forms.TextBox txtBox_BoardWerewolf;
        private System.Windows.Forms.TextBox txtBox_BoardJustice;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox listBox_Werewolf;
        private System.Windows.Forms.ListBox listBox_Seer;
        private System.Windows.Forms.ListBox listBox_Witch;
        private System.Windows.Forms.ListBox listBox_Villager;
        private System.Windows.Forms.GroupBox groupBox_news;
        private System.Windows.Forms.TextBox textBox_round;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_details;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_action;
        private System.Windows.Forms.TextBox textBox_death;
        private System.Windows.Forms.Label lblUmreni;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox txtBox_Villager;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBox_Witch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBox_Seer;
        private System.Windows.Forms.TextBox txtBox_Werewolf;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblusercount;
        private System.Windows.Forms.ListBox userList;
        private System.Windows.Forms.PictureBox pictureBox5;
    }
}

