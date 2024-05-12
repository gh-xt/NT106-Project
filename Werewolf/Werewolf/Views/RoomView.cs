using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Threading;
using Werewolf.Network.Events;
using Werewolf.Network;
using System.Windows.Documents;

namespace Werewolf.Views
{
    public partial class RoomView : Form
    {
        private readonly MainWindow _window;
        private bool has_Scroll;

        public RoomView()
        {
            InitializeComponent();

            ChatBox.Text = string.Empty; // Xóa nội dung trong RichTextBox

            IPAddress.Text = Client.Instance.IPAddressString;

            if (!Client.Instance.IsHost)
            {
                SettingsBtn.Visible = false;
                StartGame.Visible = false;
            }

            Client.Instance.ServerEvents.Add_Listener<UserListSetEventArgs>((sender, e) =>
            {
                foreach (string user in e.UserList)
                    AddUser(user);
            });

            Client.Instance.ServerEvents.Add_Listener<ChatMessageSentEventArgs>((sender, e) =>
            {
                AddChatMessage(e.Name, e.Message);
            });

            Client.Instance.ServerEvents.Add_Listener<UserJoinedEventArgs>((sender, e) =>
            {
                AddUser(e.Name);
                AddChatMessage(string.Empty, $"{e.Name} vừa vào phòng!");
            });

            Client.Instance.ServerEvents.Add_Listener<UserLeftEventArgs>((sender, e) =>
            {
                RemoveUser(e.Name);
                AddChatMessage(string.Empty, $"{e.Name} bị ngắt kết nối!");
            });

            Client.Instance.ServerEvents.Add_Listener<GameStartedEventArgs>((sender, e) =>
            {
                BeginInvoke((Action)(() =>
                {
                    GameView view = _window.SetView<GameView>(); // Gọi SetView của MainWindow để chuyển sang GameView
                    view.SetRoles(e.RoleIds);
                    view.SetUsers(UserList.Items.Cast<string>().ToArray());
                }));
            });

            Client.Instance.ListenServerEvents();
        }

        private void AddChatMessage(string name, string message)
        {
            string nameIfPresent = string.IsNullOrEmpty(name) ? name : $"<{name}>: ";

            if (InvokeRequired)
            {
                // Nếu không ở trên luồng UI chính, sử dụng Invoke để thực hiện các thay đổi trên luồng UI chính
                Invoke((Action)(() =>
                {
                    AppendText($"{nameIfPresent}{message}\n");

                    // Kiểm tra xem liệu cần cuộn xuống cuối không
                    if (ShouldAutoScroll())
                        ScrollToBottom();
                }));
            }
            else
            {
                // Nếu đang ở trên luồng UI chính, thực hiện các thay đổi trực tiếp
                AppendText($"{nameIfPresent}{message}\n");

                // Kiểm tra xem liệu cần cuộn xuống cuối không
                if (ShouldAutoScroll())
                    ScrollToBottom();
            }
        }

        private void AppendText(string text)
        {
            // Thêm văn bản vào RichTextBox
            ChatBox.AppendText(text);
        }

        private bool ShouldAutoScroll()
        {
            // Kiểm tra xem liệu nội dung của RichTextBox đã được cuộn xuống cuối cùng chưa
            int visibleLines = ChatBox.ClientSize.Height / ChatBox.Font.Height;
            return ChatBox.GetLineFromCharIndex(ChatBox.GetCharIndexFromPosition(new System.Drawing.Point(0, ChatBox.ClientSize.Height))) >= ChatBox.Lines.Length - visibleLines;
        }

        private void ScrollToBottom()
        {
            // Cuộn xuống cuối cùng của RichTextBox
            ChatBox.SelectionStart = ChatBox.Text.Length;
            ChatBox.ScrollToCaret();
        }


        private void AddUser(string name)
        {
            BeginInvoke((Action)(() =>
            {
                UserList.Items.Add(name); // Thêm người dùng vào danh sách
            }));
        }

        private void RemoveUser(string name)
        {
            BeginInvoke((Action)(() =>
            {
                UserList.Items.Remove(name); // Xóa người dùng khỏi danh sách
            }));
        }

        private void SettingsBtn_Click(object sender, EventArgs e)
        {
            if (!Client.Instance.IsHost) return;

            GameSettingsWindow gameSettingsWindow = new GameSettingsWindow(_window); // Tạo cửa sổ cài đặt trò chơi
            gameSettingsWindow.SetRoomView(this); // Đặt RoomView cho cửa sổ cài đặt trò chơi
            gameSettingsWindow.ShowDialog(); // Hiển thị cửa sổ cài đặt trò chơi
        }

        private async void StartGame_Click(object sender, EventArgs e)
        {
            if (!Client.Instance.IsHost) return;
            StartGame.Enabled = false; // Vô hiệu hóa nút bắt đầu trò chơi

            for (int i = 5; i >= 1; --i)
            {
                Server.Instance.SendEvent(new ChatMessageSentEventArgs(string.Empty, $"Trò chơi bắt đầu trong {i} giây..."));
                await Task.Delay(1000);
            }

            Server.Instance.SendEvent(new GameStartedEventArgs(Game.Game.Instance.Get_Roles().Select(role => role.Id).ToArray()));
        }

        private void SendMessage_Click(object sender, EventArgs e)
        {
            string message = Message.Text.Trim();
            if (string.IsNullOrWhiteSpace(message)) return;

            Client.Instance.SendEvent(new SendChatMessageEventArgs(message)); // Gửi tin nhắn đến máy chủ
            Message.Text = string.Empty; // Xóa nội dung trong ô nhập tin nhắn
        }
        public void EnableStartGameButton() => StartGame.Enabled = true;
    }
}
