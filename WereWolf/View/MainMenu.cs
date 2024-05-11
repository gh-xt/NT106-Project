using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WereWolf
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
            InitializeForm(); // Khởi tạo form khi hiển thị lên
        }


        private void InitializeForm()
        {
           
            UserName.Focus();

            // Đảm bảo không có RadioButton nào được chọn khi form hiển thị
            radioButton1.Checked = false;
            radioButton2.Checked = false;

            // Vô hiệu hóa cả hai Panel khi form hiển thị
            DisableAllPanels();

            // Cập nhật màu nền của các panel
            UpdatePanelColors();
        }

        private void DisableAllPanels()
        {
            panel1.Enabled = false;
            panel2.Enabled = false;
        }

        private void UpdatePanelColors()
        {
            // Cập nhật màu nền của panel1
            panel1.BackColor = panel1.Enabled ? SystemColors.ControlLight : SystemColors.Control;

            // Cập nhật màu nền của panel2
            panel2.BackColor = panel2.Enabled ? SystemColors.ControlLight : SystemColors.Control;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
               
                panel1.Enabled = true;
                panel2.Enabled = false; // Vô hiệu hóa panel2 nếu radioButton1 được chọn
            }
            else
            {
                panel1.Enabled = false;
            }

            UpdatePanelColors(); // Cập nhật màu nền của các panel sau khi thay đổi trạng thái
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                
                panel2.Enabled = true;
                panel1.Enabled = false; // Vô hiệu hóa panel1 nếu radioButton2 được chọn
            }
            else
            {
                panel2.Enabled = false;
            }

            UpdatePanelColors(); // Cập nhật màu nền của các panel sau khi thay đổi trạng thái
        }

       
    }
}