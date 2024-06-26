﻿using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;

using Werewolf.Network;

namespace Werewolf.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
        private readonly MainWindow main_Window;

        public MainView(MainWindow window)
        {
            InitializeComponent();
            main_Window = window;
        }
        private string GetIPAddress()
        {
            string IPAddress = string.Empty;
            IPHostEntry Host = default(IPHostEntry);
            string Hostname = null;
            Hostname = System.Environment.MachineName;
            Host = Dns.GetHostEntry(Hostname);
            foreach (IPAddress IP in Host.AddressList)
            {
                if (IP.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                {
                    IPAddress = Convert.ToString(IP);
                }
            }
            return IPAddress;
        }

        private void ConnectClient(string ipAddressString = null)
        {
            UserName.Text = UserName.Text.Trim();
            string ip = GetIPAddress();

            if (UserName.Text.Length < 3)
            {
                MessageBox.Show("Tên của bạn phải chứa ít nhất 3 chữ cái!", "Lỗi - Tên không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            IPAddress ipAddress = IPAddress.Parse(ip);

            if (ipAddressString != null)
            {
                bool isValid = IPAddress.TryParse(ipAddressString, out ipAddress);

                if (!isValid)
                {
                    MessageBox.Show("Địa chỉ IP không hợp lệ!", "Lỗi - Địa chỉ IP không hợp lệ", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
            }
            else
                Server.Instance.Start();

            if (Client.Instance.Connect(UserName.Text, ipAddress))
                main_Window.SetView<RoomView>();
            else
            {
                MessageBox.Show("Tên người dùng bạn chọn đã được sử dụng!", "Lỗi - Tên người dùng đã sử dụng", MessageBoxButton.OK, MessageBoxImage.Error);
                Client.Instance.Disconnect();
            }
        }

        private void RoomConnectBtn_Click(object sender, RoutedEventArgs e) => ConnectClient(RoomIPAddress.Text);
        private void RoomCreateBtn_Click(object sender, RoutedEventArgs e) => ConnectClient();
    }
}