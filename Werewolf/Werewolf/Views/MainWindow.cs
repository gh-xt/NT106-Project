using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Werewolf.Network;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Werewolf.Views
{
    public partial class MainWindow : Form
    {
        public MainWindow()
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

        private string GetIPAddress()
        {
            string ipAddress = string.Empty;
            string hostname = Dns.GetHostName();
            IPHostEntry host = Dns.GetHostEntry(hostname);

            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress = ip.ToString();
                    break; // Dừng khi tìm thấy địa chỉ IPv4 đầu tiên
                }
            }

            return ipAddress;
        }

        private void ConnectClient(string ipAddressString = null)
        {
            UserName.Text = UserName.Text.Trim();
            string ip = GetIPAddress();

            if (UserName.Text.Length < 3)
            {
                MessageBox.Show("Tên của bạn phải chứa ít nhất 3 chữ cái!", "Lỗi - Tên không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            IPAddress ipAddress = IPAddress.Parse(ip);

            if (ipAddressString != null)
            {
                bool isValid = IPAddress.TryParse(ipAddressString, out ipAddress);

                if (!isValid)
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi - Địa chỉ IP không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                // Khởi động máy chủ nếu không có địa chỉ IP được cung cấp
                //Server.Instance.Start(); // Khởi động Server trong WinForms
            }

            if (Client.Instance.Connect(UserName.Text, ipAddress))
            {
                // Thực hiện hành động chuyển giao diện tại đây (ví dụ: hiển thị RoomView)
                MessageBox.Show("Kết nối thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Gọi phương thức SetView của _window để chuyển giao diện
                //_window.SetView<RoomView>();
            }
            else
            {
                MessageBox.Show("Tên người dùng bạn chọn đã được sử dụng!", "Lỗi - Tên người dùng đã sử dụng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Client.Instance.Disconnect();
            }
        }

        private void RoomConnectBtn_Click(object sender, EventArgs e)
        {
            ConnectClient(RoomIPAddress.Text);
        }

        private void RoomCreateBtn_Click(object sender, EventArgs e)
        {
            ConnectClient();
        }
    }


}


