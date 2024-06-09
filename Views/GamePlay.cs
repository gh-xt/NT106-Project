using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Threading;
using System.Xml.Linq;
using Werewolf.Game;
using Werewolf.Network;
using Werewolf.Network.Events;
using Werewolf.Views;

namespace Werewolf
{
    public partial class GamePlay : Form
    {
        public GamePlay()
        {
            InitializeComponent();
        }

        List<string> listplayers = new List<string>();
        List<string> listplayersPOM = new List<string>();
        int brWerewolf = 0, brSeer = 0, brWitch = 0, brVillager = 0;
        int brWerewolfPOM = 0, brSeerPOM = 0, brWitchPOM = 0, brVillagerPOM = 0;
        List<int> listWerewolf = new List<int>();
        List<int> listSeer = new List<int>();
        List<int> listWitch = new List<int>();

        int brBreach = 0;

        HashSet<int> imported = new HashSet<int>();

        int hh = 0;
        int mm = 0;
        int ss = 0;
        int partyWolf = 0;
        int partyTruth = 0;

        string action = "";


        string lossSeer = "";
        string lossWerewolf = "";
        string lossWitch = "";
        string lossVilla = "";
        int round = 1;
        string pomWitch = "", pomWerewolf = "";
        bool end = false;

        int pomVoteM = -1, pomKillM = -1, pomVoteD = -1, pomKillD = -1, pomVoteP = -1, pomKillP = -1, pomVoteG = -1, pomKillG = -1;
        int indexVoteM = -1, indexKillM = -1, indexVoteD = -1, indexKillD = -1, indexVoteP = -1, indexKillP = -1, indexVoteG = -1, indexKillG = -1;

        bool fillPomlist = false;
        private void Form1_Load(object sender, EventArgs e)
        {
            brWerewolf = Convert.ToInt32(txtBox_Werewolf.Text);
            brSeer = Convert.ToInt32(txtBox_Seer.Text);
            brWitch = Convert.ToInt32(txtBox_Witch.Text);
            brVillager = Convert.ToInt32(txtBox_Villager.Text);

            brWerewolfPOM = brWerewolf;
            brSeerPOM = brSeer;
            brWitchPOM = brWitch;
            brVillagerPOM = brVillager;

            partyWolf = Convert.ToInt32(txtBox_BoardWerewolf.Text);
            partyTruth = Convert.ToInt32(txtBox_BoardJustice.Text);

        }

        public void SetUsers(string[] users)
        {
            foreach (string user in users)
            {
                userList.Items.Add(user);
            }

            foreach (var item in userList.Items)
            {
                listplayers.Add(item.ToString());
            }

            RaspredeliUlogi();
            lblusercount.Text = listplayers.Count.ToString();
        }

        private void TxtBox_Werewolf_TextChanged(object sender, EventArgs e)
        {
            int number;

            bool success = Int32.TryParse(txtBox_Werewolf.Text, out number);
            if (success)
            {
                int tidy = number + brVillager + brSeer + brWitch;
                if (tidy > listplayers.Count)
                {
                    MessageBox.Show("Số lượng quá lớn!");
                    txtBox_Werewolf.Text = brWerewolf.ToString();
                }
                else
                {
                    brWerewolf = number;
                }
            }
            else
            {
                MessageBox.Show("Hãy nhập một số!");
                txtBox_Werewolf.Text = "";
                txtBox_Werewolf.Focus();
            }
        }

        private void TxtBox_Villager_TextChanged(object sender, EventArgs e)
        {
            int number;

            bool success = Int32.TryParse(txtBox_Villager.Text, out number);
            if (success)
            {
                int tidy = brWerewolf + number + brSeer + brWitch;
                if (tidy > listplayers.Count)
                {
                    MessageBox.Show("Số lượng quá lớn!");
                    txtBox_Villager.Text = brVillager.ToString();
                }
                else
                {
                    brVillager = number;
                }
            }
            else
            {
                MessageBox.Show("Hmmm!");
                txtBox_Villager.Text = "";
                txtBox_Villager.Focus();
            }
        }

        private void TxtBox_Seer_TextChanged(object sender, EventArgs e)
        {
            int number;

            bool success = Int32.TryParse(txtBox_Seer.Text, out number);
            if (success)
            {
                int tidy = brWerewolf + brVillager + number + brWitch;
                if (tidy > listplayers.Count)
                {
                    MessageBox.Show("Số lượng quá lớn!");
                    txtBox_Seer.Text = brSeer.ToString();
                }
                else
                {
                    brSeer = number;
                }
            }
            else
            {
                MessageBox.Show("Nghiêm túc! Nhập một số...");
                txtBox_Seer.Text = "";
                txtBox_Seer.Focus();
            }
        }

        private void TxtBox_Witch_TextChanged(object sender, EventArgs e)
        {
            int number;

            bool success = Int32.TryParse(txtBox_Witch.Text, out number);
            if (success)
            {
                int tidy = brWerewolf + brVillager + brSeer + number;
                if (tidy > listplayers.Count)
                {
                    MessageBox.Show("Số lượng quá lớn!");
                    txtBox_Witch.Text = brWitch.ToString();
                }
                else
                {
                    brWitch = number;
                }
            }
            else
            {
                MessageBox.Show("Bạn phải nhập một số!");
                txtBox_Witch.Text = "";
                txtBox_Witch.Focus();
            }
        }

        private void userList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            if (!Client.Instance.IsHost) return;
            btn_Start.Enabled = false;

            if (listplayers.Count < 4)
            {
                MessageBox.Show("Vui lòng tìm đủ 4 người chơi!");
            }
            else if (listplayers.Count > 3)
            {
                if (brWitch + brSeer + brWerewolf + brVillager != listplayers.Count)
                {
                    MessageBox.Show("Something go wrong!");
                }
                else
                {
                    if (textBox_round.Text == "1")
                    {
                        if (!(lossSeer != "" || lossWerewolf != "" || lossWitch != ""))
                        {

                            brWerewolfPOM = brWerewolf;
                            brSeerPOM = brSeer;
                            brWitchPOM = brWitch;
                            brVillagerPOM = brVillager;

                            listWitch.Clear();
                            listWerewolf.Clear();
                            listSeer.Clear();
                            imported.Clear();
                            lbl_action.Text = "";
                            lossWitch = "";
                            lossWerewolf = "";
                            lossSeer = "";
                            pomWerewolf = "";
                            pomWitch = "";


                            btn_Justice.Enabled = true;
                            btn_Werewolf.Enabled = true;
                            timer1.Stop();
                            hh = 0;
                            mm = 0;
                            ss = 0;
                            lblTime.Text = "00:00:00";

                            timer1.Start();

                            groupBox_news.Visible = true;
                            pictureBox5.Visible = false;
                            if (end == true)
                            {
                                txtBox_Werewolf.Enabled = true;
                                txtBox_Seer.Enabled = true;
                                txtBox_Witch.Enabled = true;
                                txtBox_Villager.Enabled = true;
                                end = false;
                                if (fillPomlist == false)
                                {
                                    fillPomlist = true;
                                    foreach (string m in listplayers)
                                        listplayersPOM.Add(m);
                                }
                            }
                            else
                            {

                                txtBox_Werewolf.Enabled = false;
                                txtBox_Seer.Enabled = false;
                                txtBox_Witch.Enabled = false;
                                txtBox_Villager.Enabled = false;
                                if (fillPomlist == false)
                                {
                                    fillPomlist = true;
                                    foreach (string m in listplayers)
                                        listplayersPOM.Add(m);
                                }
                            }

                            int maxBr = listplayers.Count;
                            Random r = new Random();

                            List<int> lobby = new List<int>();

                            for (int i = 0; i < brWerewolf; i++)
                            {
                                lobby.Add(1);
                            }
                            for (int i = 0; i < brVillager; i++)
                            {
                                lobby.Add(2);
                            }
                            for (int i = 0; i < brWitch; i++)
                            {
                                lobby.Add(3);
                            }
                            for (int i = 0; i < brSeer; i++)
                            {
                                lobby.Add(4);
                            }

                            int brlobby = lobby.Count;
                            int rBr = 0;
                            foreach (string player in listplayers)
                            {
                                int indexLivce = r.Next(0, brlobby);
                                int role1Livce = lobby[indexLivce];

                                lobby.RemoveAt(indexLivce);
                                brlobby--;

                                if (role1Livce == 1)
                                {

                                    listWerewolf.Add(rBr);
                                    imported.Add(rBr);
                                }
                                else if (role1Livce == 2)
                                {

                                }
                                else if (role1Livce == 3)
                                {
                                    listWitch.Add(rBr);
                                    imported.Add(rBr);
                                }
                                else if (role1Livce == 4)
                                {
                                    listSeer.Add(rBr);
                                    imported.Add(rBr);
                                }
                                rBr++;
                            }
                            DisplayOutput();
                        }
                        else
                        {
                            MessageBox.Show("Không thể tạo lại!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Trò chơi đang diễn ra, không thể tạo lại!");
                    }
                }
            }
            Server.Instance.SendEvent(new GenerateEventArgs());

        }

        private bool checkrole1(int random)
        {
            bool zname = false;
            foreach (int i in listWitch)
            {
                if (random == i)
                    zname = true;
            }
            foreach (int i in listSeer)
            {
                if (random == i)
                    zname = true;
            }
            foreach (int i in listWerewolf)
            {
                if (random == i)
                    zname = true;
            }
            return zname;
        }

        private void RaspredeliUlogi()
        {
            if (listplayers.Count < 4)
            {
                brWitch = 0;
                brWerewolf = 0;
                brSeer = 0;
            }
            else if (listplayers.Count == 4)
            {
                brWitch = 1;
                brSeer = 1;
                brWerewolf = 1;
            }
            else if (listplayers.Count >= 6 && listplayers.Count < 8)
            {
                brWitch = 1;
                brSeer = 1;
                brWerewolf = 2;
            }
            else if (listplayers.Count >= 8 && listplayers.Count < 11)
            {
                brWitch = 1;
                brSeer = 2;
                brWerewolf = 3;
            }
            else if (listplayers.Count >= 11)
            {
                decimal brIg = listplayers.Count;
                brWitch = Decimal.ToInt32(Math.Round(brIg * (decimal)0.1));
                brSeer = Decimal.ToInt32(Math.Round(brIg * (decimal)0.2));
                brWerewolf = Decimal.ToInt32(Math.Round(brIg * (decimal)0.3));
            }

            brVillager = listplayers.Count - (brWitch + brWerewolf + brSeer);
            txtBox_Witch.Text = brWitch.ToString();
            txtBox_Werewolf.Text = brWerewolf.ToString();
            txtBox_Seer.Text = brSeer.ToString();
            txtBox_Villager.Text = brVillager.ToString();
        }


        private void Timer1_Tick(object sender, EventArgs e)
        {
            ss++;
            if (ss == 60)
            {
                mm++;
                ss = 0;
            }
            if (mm == 60)
            {
                hh++;
                mm = 0;
            }

            string time = "";
            if (hh < 10)
            {
                time += "0" + hh;
            }
            else
                time += hh;
            time += ":";
            if (mm < 10)
            {
                time += "0" + mm;
            }
            else
                time += mm;
            time += ":";
            if (ss < 10)
            {
                time += "0" + ss;
            }
            else
                time += ss;
            lblTime.Text = time;

        }



        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (button3.Visible == false)
            {
                if (txtBox_Werewolf.Text == "0")
                {
                    action = "";
                    MessageBox.Show("Một ngôi làng không có ma sói!");
                }
                else
                {
                    action = "Giết";
                    lbl_action.Text = "Hành động: Ma sói đi săn!";
                }
            }
            else
            {
                action = "";
                MessageBox.Show("Người dân muốn bỏ phiếu trước, sau đó Ma sói sẽ giết người!");
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (button3.Visible == false)
            {
                if (txtBox_Seer.Text == "0")
                {
                    action = "";
                    MessageBox.Show("Tiên tri đã hi sinh!");
                }
                else
                {
                    action = "Đã kiểm tra";
                    lbl_action.Text = "Hành động: Tiên tri đang kiểm tra!";
                }

            }
            else
            {
                action = "";
                MessageBox.Show("Bỏ phiếu là ưu tiên hàng đầu!");
            }
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (button3.Visible == false)
            {
                if (txtBox_Witch.Text == "0")
                {
                    action = "";
                    MessageBox.Show("Phù thủy đã biến mất");
                }
                else
                {
                    action = "Đã được cứu sống";
                    lbl_action.Text = "Hành động: Phù thủy cứu người!";
                }

            }
            else
            {
                action = "";
                MessageBox.Show("Bầu cử ở vị trí số 1, sức khỏe ở vị trí thứ 2!");
            }
        }

        private void ListBox_Werewolf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (action != "")
            {
                int poz = Convert.ToInt32(listBox_Werewolf.SelectedIndex.ToString());
                DisplayOutput_Action(action, poz, "Werewolf");

                if (pomVoteM > -1 && indexVoteM > -1)
                {
                    listplayersPOM.RemoveAt(pomVoteM);
                    listWerewolf.RemoveAt(indexVoteM);
                    reduceIndex(pomVoteM);
                    brWerewolf--;
                    txtBox_Werewolf.Text = brWerewolf.ToString();

                    DisplayOutput_Day();

                    pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                    indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;
                    lbl_action.Text = "";

                    if (txtBox_Werewolf.Text == "0")
                    {
                        brWerewolf = brWerewolfPOM;
                        brSeer = brSeerPOM;
                        brWitch = brWitchPOM;
                        brVillager = brVillagerPOM;

                        txtBox_Werewolf.Text = brWerewolf.ToString();
                        txtBox_Seer.Text = brSeer.ToString();
                        txtBox_Witch.Text = brWitch.ToString();
                        txtBox_Villager.Text = brVillager.ToString();

                        partyTruth++;
                        txtBox_BoardJustice.Text = partyTruth.ToString();
                        listWitch.Clear();
                        listWerewolf.Clear();
                        listSeer.Clear();
                        imported.Clear();
                        lbl_action.Text = "";
                        lossWitch = "";
                        lossWerewolf = "";
                        lossSeer = "";
                        pomWerewolf = "";
                        pomWitch = "";
                        textBox_details.Text = "";
                        textBox_death.Text = "";
                        textBox_round.Text = "1";
                        listBox_Villager.Items.Clear();
                        listBox_Witch.Items.Clear();
                        listBox_Werewolf.Items.Clear();
                        listBox_Seer.Items.Clear();
                        button3.Visible = false;
                        round = 1;
                        timer1.Stop();
                        hh = 0;
                        mm = 0;
                        ss = 0;
                        lblTime.Text = "00:00:00";

                        timer1.Start();
                        end = true;

                        txtBox_Werewolf.Enabled = true;
                        txtBox_Seer.Enabled = true;
                        txtBox_Witch.Enabled = true;
                        txtBox_Villager.Enabled = true;

                        listplayersPOM.Clear();
                        fillPomlist = false;

                        MessageBox.Show("Không còn tên ma sói nào nữa, dân làng đã thắng!");
                        Btn_Generate_Click(sender, e);
                    }
                }

            }
            else
            {
                MessageBox.Show("Bấm vào 'Action Button' để chọn hành động!");
            }
        }


        private void reduceIndex(int pogolemOd)
        {
            for (int i = 0; i < listWerewolf.Count; i++)
            {
                if (listWerewolf[i] > pogolemOd)
                    listWerewolf[i] = listWerewolf[i] - 1;
            }
            for (int i = 0; i < listSeer.Count; i++)
            {
                if (listSeer[i] > pogolemOd)
                    listSeer[i] = listSeer[i] - 1;
            }
            for (int i = 0; i < listWitch.Count; i++)
            {
                if (listWitch[i] > pogolemOd)
                    listWitch[i] = listWitch[i] - 1;
            }
        }


        private void ListBox_Seer_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (action != "")
            {
                int poz = Convert.ToInt32(listBox_Seer.SelectedIndex.ToString());
                DisplayOutput_Action(action, poz, "Seer");
                if (pomVoteP > -1 && indexVoteP > -1)
                {
                    listplayersPOM.RemoveAt(pomVoteP);
                    listSeer.RemoveAt(indexVoteP);
                    reduceIndex(pomVoteP);
                    brSeer--;
                    txtBox_Seer.Text = brSeer.ToString();

                    DisplayOutput_Day();
                    pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                    indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;
                    lbl_action.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bấm vào 'Action Button' để chọn hành động!");
            }
        }

        private void listBox_Witch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (action != "")
            {
                int poz = Convert.ToInt32(listBox_Witch.SelectedIndex.ToString());
                DisplayOutput_Action(action, poz, "Witch");
                if (pomVoteD > -1 && indexVoteD > -1)
                {
                    listplayersPOM.RemoveAt(pomVoteD);
                    listWitch.RemoveAt(indexVoteD);
                    reduceIndex(pomVoteD);
                    brWitch--;
                    txtBox_Witch.Text = brWitch.ToString();

                    DisplayOutput_Day();
                    pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                    indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;
                    lbl_action.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bấm vào 'Action Button' để chọn hành động!");
            }
        }

        private void ListBox_Villager_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (action != "")
            {
                int poz = Convert.ToInt32(listBox_Villager.SelectedIndex.ToString());
                DisplayOutput_Action(action, poz, "Villager");
                if (pomVoteG > -1 && indexVoteG > -1)
                {
                    listplayersPOM.RemoveAt(pomVoteG);
                    reduceIndex(pomVoteG);
                    brVillager--;
                    txtBox_Villager.Text = brVillager.ToString();

                    DisplayOutput_Day();
                    pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                    indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;
                    lbl_action.Text = "";
                }
            }
            else
            {
                MessageBox.Show("Bấm vào 'Action Button' để chọn hành động!");
            }
        }

        private void Btn_Werewolf_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Ma sói đã thắng!!! Bạn có chắc chắn muốn kết thúc trò chơi không?", "!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {



                brWerewolf = brWerewolfPOM;
                brSeer = brSeerPOM;
                brWitch = brWitchPOM;
                brVillager = brVillagerPOM;

                txtBox_Werewolf.Text = brWerewolf.ToString();
                txtBox_Seer.Text = brSeer.ToString();
                txtBox_Witch.Text = brWitch.ToString();
                txtBox_Villager.Text = brVillager.ToString();

                partyWolf++;
                txtBox_BoardWerewolf.Text = partyWolf.ToString();

                listWitch.Clear();
                listWerewolf.Clear();
                listSeer.Clear();
                imported.Clear();
                lbl_action.Text = "";
                lossWitch = "";
                lossWerewolf = "";
                lossSeer = "";
                pomWerewolf = "";
                pomWitch = "";
                textBox_details.Text = "";
                textBox_death.Text = "";
                textBox_round.Text = "1";
                listBox_Villager.Items.Clear();
                listBox_Witch.Items.Clear();
                listBox_Werewolf.Items.Clear();
                listBox_Seer.Items.Clear();
                round = 1;
                button3.Visible = false;
                timer1.Stop();
                hh = 0;
                mm = 0;
                ss = 0;
                lblTime.Text = "00:00:00";

                timer1.Start();
                end = true;

                txtBox_Werewolf.Enabled = true;
                txtBox_Seer.Enabled = true;
                txtBox_Witch.Enabled = true;
                txtBox_Villager.Enabled = true;

                listplayersPOM.Clear();

                fillPomlist = false;

                Btn_Generate_Click(sender, e);

            }
            else if (dialogResult == DialogResult.No)
            {
            }
        }

        private void btn_Justice_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Dân làng đã thắng!!! Bạn có chắc chắn muốn kết thúc trò chơi không?", "!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                brWerewolf = brWerewolfPOM;
                brSeer = brSeerPOM;
                brWitch = brWitchPOM;
                brVillager = brVillagerPOM;

                txtBox_Werewolf.Text = brWerewolf.ToString();
                txtBox_Seer.Text = brSeer.ToString();
                txtBox_Witch.Text = brWitch.ToString();
                txtBox_Villager.Text = brVillager.ToString();

                partyTruth++;
                txtBox_BoardJustice.Text = partyTruth.ToString();

                listWitch.Clear();
                listWerewolf.Clear();
                listSeer.Clear();
                imported.Clear();
                lbl_action.Text = "";
                lossWitch = "";
                lossWerewolf = "";
                lossSeer = "";
                pomWerewolf = "";
                pomWitch = "";
                textBox_details.Text = "";
                textBox_death.Text = "";
                textBox_round.Text = "1";
                listBox_Villager.Items.Clear();
                listBox_Witch.Items.Clear();
                listBox_Werewolf.Items.Clear();
                listBox_Seer.Items.Clear();
                button3.Visible = false;
                round = 1;
                timer1.Stop();
                hh = 0;
                mm = 0;
                ss = 0;
                lblTime.Text = "00:00:00";

                timer1.Start();
                end = true;

                txtBox_Werewolf.Enabled = true;
                txtBox_Seer.Enabled = true;
                txtBox_Witch.Enabled = true;
                txtBox_Villager.Enabled = true;

                listplayersPOM.Clear();

                fillPomlist = false;
                Btn_Generate_Click(sender, e);
            }
            else if (dialogResult == DialogResult.No)
            {

            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            action = "Đã bỏ phiếu";
            lbl_action.Text = "Hành động: Bỏ phiếu!";
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            if (txtBox_Villager.Text == "0")
            {
                MessageBox.Show("Không còn dân làng!");
            }
            else
            {
                lbl_action.Text = "Hành động: Không có hành động!";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if ((lossSeer != "" || txtBox_Seer.Text == "0") && lossWerewolf != "" && (lossWitch != "" || txtBox_Witch.Text == "0"))
            {
                bool ubien = false;

                round++;
                textBox_round.Text = round.ToString();

                textBox_details.Text = "Tin từ tối hôm trước:" + Environment.NewLine;
                textBox_details.Text += "---------------------------" + Environment.NewLine;
                textBox_details.Text += lossSeer + Environment.NewLine +
                    lossWerewolf + Environment.NewLine;

                if (pomWitch != pomWerewolf)
                {
                    textBox_details.Text += "Mặc dù Phù thủy đã cố gắng hết sức nhưng anh ấy đã tử vong " + pomWerewolf + "." + Environment.NewLine;
                    textBox_death.Text += pomWerewolf + ";" + Environment.NewLine;
                    ubien = true;
                }
                else
                    textBox_details.Text += "Phù thủy đã cứu sống thành công nạn nhân " + pomWerewolf + Environment.NewLine;

                lbl_action.Text = "";
                lossWitch = "";
                lossWerewolf = "";
                lossSeer = "";
                pomWerewolf = "";
                pomWitch = "";
                lbl_action.Text = "";
                action = "";
                button3.Visible = true;



                if (ubien == true)
                {
                    ubien = false;
                    if (pomKillM > -1 && indexKillM > -1)
                    {
                        listplayersPOM.RemoveAt(pomKillM);
                        listWerewolf.RemoveAt(indexKillM);
                        reduceIndex(pomKillM);
                        brWerewolf--;
                        txtBox_Werewolf.Text = brWerewolf.ToString();

                        pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                        indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;

                    }

                    if (pomKillP > -1 && indexKillP > -1)
                    {
                        listplayersPOM.RemoveAt(pomKillP);
                        listSeer.RemoveAt(indexKillP);
                        reduceIndex(pomKillP);
                        brSeer--;
                        txtBox_Seer.Text = brSeer.ToString();

                        pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                        indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;

                    }

                    if (pomKillD > -1 && indexKillD > -1)
                    {
                        listplayersPOM.RemoveAt(pomKillD);
                        listWitch.RemoveAt(indexKillD);
                        reduceIndex(pomKillD);
                        brWitch--;
                        txtBox_Witch.Text = brWitch.ToString();

                        pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                        indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;

                    }
                    if (pomKillG > -1 && indexKillG > -1)
                    {
                        listplayersPOM.RemoveAt(pomKillG);
                        reduceIndex(pomKillG);
                        brVillager--;
                        txtBox_Villager.Text = brVillager.ToString();

                        pomVoteM = -1; pomKillM = -1; pomVoteD = -1; pomKillD = -1; pomVoteP = -1; pomKillP = -1; pomVoteG = -1; pomKillG = -1;
                        indexVoteM = -1; indexKillM = -1; indexVoteD = -1; indexKillD = -1; indexVoteP = -1; indexKillP = -1; indexVoteG = -1; indexKillG = -1;

                    }

                }

                DisplayOutput_Day();
                if (round > 1)
                {
                    txtBox_Werewolf.Enabled = false;
                    txtBox_Seer.Enabled = false;
                    txtBox_Witch.Enabled = false;
                    txtBox_Villager.Enabled = false;

                    button3.Visible = true;

                    end = false;



                }

                if (txtBox_Werewolf.Text == "0")
                {
                    brWerewolf = brWerewolfPOM;
                    brSeer = brSeerPOM;
                    brWitch = brWitchPOM;
                    brVillager = brVillagerPOM;

                    txtBox_Werewolf.Text = brWerewolf.ToString();
                    txtBox_Seer.Text = brSeer.ToString();
                    txtBox_Witch.Text = brWitch.ToString();
                    txtBox_Villager.Text = brVillager.ToString();

                    partyTruth++;
                    txtBox_BoardJustice.Text = partyTruth.ToString();
                    listWitch.Clear();
                    listWerewolf.Clear();
                    listSeer.Clear();
                    imported.Clear();
                    lbl_action.Text = "";
                    lossWitch = "";
                    lossWerewolf = "";
                    lossSeer = "";
                    pomWerewolf = "";
                    pomWitch = "";
                    textBox_details.Text = "";
                    textBox_death.Text = "";
                    textBox_round.Text = "1";
                    listBox_Villager.Items.Clear();
                    listBox_Witch.Items.Clear();
                    listBox_Werewolf.Items.Clear();
                    listBox_Seer.Items.Clear();
                    button3.Visible = false;
                    round = 1;
                    timer1.Stop();
                    hh = 0;
                    mm = 0;
                    ss = 0;
                    lblTime.Text = "00:00:00";

                    timer1.Start();
                    end = true;

                    txtBox_Werewolf.Enabled = true;
                    txtBox_Seer.Enabled = true;
                    txtBox_Witch.Enabled = true;
                    txtBox_Villager.Enabled = true;

                    listplayersPOM.Clear();
                    fillPomlist = false;



                    MessageBox.Show("Không còn tên ma sói nào nữa, dân làng đã thắng!");

                    Btn_Generate_Click(sender, e);
                }
            }
            else
            {
                MessageBox.Show("Tất cả người chơi cần phải thực hiện chức năng của mình trước khi qua ngày mới.");
            }
        }

        private void DisplayOutput()
        {
            
            listBox_Werewolf.Items.Clear();
            foreach (int i in listWerewolf)
            {
                listBox_Werewolf.Items.Add(listplayers[i]);
            }

            listBox_Seer.Items.Clear(); ;
            foreach (int i in listSeer)
            {
                listBox_Seer.Items.Add(listplayers[i]);
            }

            listBox_Witch.Items.Clear();
            foreach (int i in listWitch)
            {
                listBox_Witch.Items.Add(listplayers[i]);
            }

            listBox_Villager.Items.Clear();
            int pom = 0;
            foreach (string s in listplayers)
            {
                if (!checkrole1(pom))
                {
                    listBox_Villager.Items.Add(s);
                }
                pom++;
            }
        }

        private void DisplayOutput_Day()
        {
            listBox_Werewolf.Items.Clear();
            foreach (int i in listWerewolf)
            {
                listBox_Werewolf.Items.Add(listplayersPOM[i]);
            }

            listBox_Seer.Items.Clear(); ;
            foreach (int i in listSeer)
            {

                listBox_Seer.Items.Add(listplayersPOM[i]);
            }

            listBox_Witch.Items.Clear();
            foreach (int i in listWitch)
            {
                listBox_Witch.Items.Add(listplayersPOM[i]);
            }

            listBox_Villager.Items.Clear();
            int pom = 0;
            foreach (string s in listplayersPOM)
            {
                if (!checkrole1(pom))
                {
                    listBox_Villager.Items.Add(s);
                }
                pom++;
            }
        }


        private void DisplayOutput_Action(string action, int poz, string role1)
        {
            int brpomWerewolf = 0;
            listBox_Werewolf.Items.Clear();
            int br = 0;
            foreach (int i in listWerewolf)
            {
                if (role1 == "Werewolf" && br == poz)
                {

                    if (action == "Đã kiểm tra")
                    {
                        lossSeer = "Tiên tri đã hoàn thành xuất sắc nhiệm vụ và phát hiện ra ma sói " + listplayersPOM[i] + ".";
                        listBox_Werewolf.Items.Add(listplayersPOM[i] + "<=" + action);
                    }
                    if (action == "Giết")
                    {
                        lossWerewolf = "Tin buồn là người chơi đã bị giết " + listplayersPOM[i] + ".";
                        listBox_Werewolf.Items.Add(listplayersPOM[i] + "<=" + action);
                        pomWerewolf = listplayersPOM[i];
                        brpomWerewolf = i;
                        indexKillM = br;
                        pomKillM = i;
                    }
                    if (action == "Đã được cứu sống")
                    {
                        lossWitch = "Phù thủy đã cứu sống anh ấy " + listplayersPOM[i] + ".";
                        listBox_Werewolf.Items.Add(listplayersPOM[i] + "<=" + action);
                        pomWitch = listplayersPOM[i];
                    }
                    if (action == "Đã bỏ phiếu")
                    {
                        lossVilla = listplayersPOM[i];
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn bỏ phiếu cho người chơi này không?", "!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            textBox_death.Text += lossVilla + ";" + Environment.NewLine;

                            pomVoteM = i;
                            indexVoteM = br;
                            button3.Visible = false;

                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            listBox_Werewolf.Items.Add(listplayersPOM[i] + "<=" + action);
                        }
                    }
                }
                else
                {
                    listBox_Werewolf.Items.Add(listplayersPOM[i]);
                }
                br++;
            }

            br = 0;
            listBox_Seer.Items.Clear();
            foreach (int i in listSeer)
            {
                if (role1 == "Seer" && br == poz)
                {

                    if (action == "Đã kiểm tra")
                    {
                        lossSeer = "Tiên tri đã lãng phí thời gian để kiểm tra anh ta " + listplayersPOM[i] + ".";
                        listBox_Seer.Items.Add(listplayersPOM[i] + "<=" + action);
                    }
                    if (action == "Giết")
                    {
                        lossWerewolf = "Tin buồn là người chơi đã bị giết vào ngày " + listplayersPOM[i] + ".";
                        pomWerewolf = listplayersPOM[i];
                        listBox_Seer.Items.Add(listplayersPOM[i] + "<=" + action);

                        indexKillP = br;
                        pomKillP = i;
                    }
                    if (action == "Đã được cứu sống")
                    {
                        lossWitch = "Phù thủy đã cứu sống anh ấy " + listplayersPOM[i] + ".";
                        listBox_Seer.Items.Add(listplayersPOM[i] + "<=" + action);
                        pomWitch = listplayersPOM[i];
                    }
                    if (action == "Đã bỏ phiếu")
                    {
                        lossVilla = listplayersPOM[i];
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn bỏ phiếu cho người chơi này không?", "!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            textBox_death.Text += lossVilla + ";" + Environment.NewLine;


                            pomVoteP = i;
                            indexVoteP = br;
                            button3.Visible = false;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            listBox_Seer.Items.Add(listplayersPOM[i] + "<=" + action);
                        }
                    }
                }
                else
                {
                    listBox_Seer.Items.Add(listplayersPOM[i]);
                }
                br++;
            }
            br = 0;
            listBox_Witch.Items.Clear();
            foreach (int i in listWitch)
            {
                if (role1 == "Witch" && br == poz)
                {

                    if (action == "Đã kiểm tra")
                    {
                        lossSeer = "Tiên tri đã lãng phí thời gian để kiểm tra anh ta " + listplayersPOM[i] + ".";
                        listBox_Witch.Items.Add(listplayersPOM[i] + "<=" + action);
                    }
                    if (action == "Giết")
                    {
                        lossWerewolf = "Tin buồn, đó là một thảm họa " + listplayersPOM[i] + ".";
                        listBox_Witch.Items.Add(listplayersPOM[i] + "<=" + action);
                        pomWerewolf = listplayersPOM[i];

                        indexKillD = br;
                        pomKillD = i;
                    }
                    if (action == "Đã được cứu sống")
                    {
                        lossWitch = "Phù thủy đã cứu sống anh ấy " + listplayersPOM[i] + ".";
                        listBox_Witch.Items.Add(listplayersPOM[i] + "<=" + action);
                        pomWitch = listplayersPOM[i];
                    }
                    if (action == "Đã bỏ phiếu")
                    {
                        lossVilla = listplayersPOM[i];
                        DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn bỏ phiếu cho người này không?", "!", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            textBox_death.Text += lossVilla + ";" + Environment.NewLine;


                            pomVoteD = i;
                            indexVoteD = br;
                            button3.Visible = false;
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            listBox_Witch.Items.Add(listplayersPOM[i] + "<=" + action);
                        }
                    }
                }
                else
                {
                    listBox_Witch.Items.Add(listplayersPOM[i]);
                }
                br++;
            }
            br = 0;

            listBox_Villager.Items.Clear();
            int pom = 0;
            foreach (string s in listplayersPOM)
            {
                if (!checkrole1(pom))
                {
                    if (role1 == "Villager" && br == poz)
                    {

                        if (action == "Đã kiểm tra")
                        {
                            lossSeer = "Tiên tri đã lãng phí thời gian để kiểm tra anh ta " + s + ".";
                            listBox_Villager.Items.Add(s + "<=" + action);
                        }
                        if (action == "Giết")
                        {
                            lossWerewolf = "Tin buồn, đó là một thảm họa " + s + ".";
                            listBox_Villager.Items.Add(s + "<=" + action);
                            pomWerewolf = s;
                            indexKillG = br;
                            pomKillG = pom;
                        }
                        if (action == "Đã được cứu sống")
                        {
                            lossWitch = "Phù thủy đã cứu sống anh ấy " + s + ".";
                            listBox_Villager.Items.Add(s + "<=" + action);
                            pomWitch = s;
                        }
                        if (action == "Đã bỏ phiếu")
                        {
                            lossVilla = s;
                            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn bỏ phiếu cho người chơi này không?", "!", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                textBox_death.Text += lossVilla + ";" + Environment.NewLine;


                                pomVoteG = pom;
                                indexVoteG = br;
                                button3.Visible = false;
                            }
                            else if (dialogResult == DialogResult.No)
                            {
                                listBox_Villager.Items.Add(s + "<=" + action);
                            }
                        }
                    }
                    else
                    {
                        listBox_Villager.Items.Add(s);
                    }

                    br++;
                }
                pom++;
            }
        }

        private int GiveMeANumber(int max)
        {
            var range = Enumerable.Range(0, max).Where(i => !imported.Contains(i));

            var rand = new System.Random();
            int index = rand.Next(0, max - imported.Count);
            return range.ElementAt(index);
        }
    }
}
