using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;
using System.Windows.Media;

using Werewolf.Game;
using Werewolf.Network;
using Werewolf.Network.Events;

namespace Werewolf.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private bool _voteActivated;
        private bool _actionActivated;
        private string _myRole;
        private bool _isDead;
        private readonly MainWindow _window;
        private bool _hasScroll;

    public GameView(MainWindow window)
        {
            InitializeComponent();
            _window = window;
            _hasScroll = false;
            _voteActivated = false;
            _actionActivated = false;
            _isDead = false;

            ChatBox.Document.Blocks.Clear();

            Client.Instance.ServerEvents.Add_Listener<ChatMessageSentEventArgs>((sender, e) =>
            {
                AddChatMessage(e.Name, e.Message);
            });

            Client.Instance.ServerEvents.Add_Listener<UserLeftEventArgs>((sender, e) =>
            {
                RemoveUser(e.Name);
                AddChatMessage(string.Empty, e.Name + " bị ngắt kết nối khỏi trò chơi.");
            });

            Client.Instance.ServerEvents.Add_Listener<SetRoleEventArgs>((sender, e) =>
            {
                Role role = Role.GetRoleById(e.RoleId);
                Client.Instance.Role = role;

                Dispatcher.Invoke(() =>
                {
                    RoleText.Text = role.Name;
                    RoleText.Foreground = new SolidColorBrush(role.DefaultTeam.Color);

                    Inline inline1 = new Italic(new Run("Bạn thắng với phe "));
                    Run team = new Run();

                    if (role.DefaultTeam == Team.Village)
                        team.Text = "Dân làng";
                    else if (role.DefaultTeam == Team.Werewolf)
                        team.Text = "Ma sói";
                    team.Text += ".";
                    team.Foreground = new SolidColorBrush(role.DefaultTeam.Color);

                    AddChatMessage(new Italic(new Run("Bạn thắng với phe ")), new Italic(team));
                    AddChatMessage(new Italic(new Run(role.Description)));
                });
            });

            Client.Instance.ServerEvents.Add_Listener<TimerUpdatedEventArgs>((sender, e) =>
            {
                Dispatcher.Invoke(() =>
                {
                    if (e.Seconds < 0)
                        TimerText.Text = string.Empty;
                    else
                        TimerText.Text = TimeSpan.FromSeconds(e.Seconds).ToString("mm\\:ss");
                });
            });

            if (Server.Instance.Started)
            {
                Game.Game.Instance.Assign_Roles_Random();

                foreach (Player player in Game.Game.Instance.Get_Players())
                    player.User.SendEvent(new SetRoleEventArgs(player.Role.Id));

                Game.Game.Instance.SendEvent(new ChatMessageSentEventArgs(string.Empty, "Đêm đầu tiên bắt đầu sau 15 giây..."));
                Game.Game.Instance.StartGame_Loop();
            }
        }

        private void AddChatMessage(string name, string message)
        {
            Dispatcher.Invoke(() =>
            {
                Inline inline;

                if (name.Length == 0)
                    inline = new Italic(new Run(message));
                else
                    inline = new Run($"<{name}>: {message}");
                AddChatMessage(inline);
            });
        }

        private void AddChatMessage(params Inline[] inlines)
        {
            Paragraph paragraph = new Paragraph();
            foreach (Inline inline in inlines)
                paragraph.Inlines.Add(inline);

            ChatBox.Document.Blocks.Add(paragraph);
            if (!_hasScroll || ChatBox.VerticalOffset == (ChatBox.ExtentHeight - ChatBox.ViewportHeight))
                ChatBox.ScrollToEnd();
        }

        private void RemoveUser(string name)
        {
            Dispatcher.Invoke(() =>
            {
                UserList.Items.Remove(name);
            });
        }

        private void ChatBox_Scroll(object sender, ScrollEventArgs e) => _hasScroll = true;

        private void SendMessage_Click(object sender, RoutedEventArgs e)
        {
            Message.Text = Message.Text.Trim();
            if (string.IsNullOrWhiteSpace(Message.Text)) return;

            Client.Instance.SendEvent(new SendChatMessageEventArgs(Message.Text));
            Message.Text = string.Empty;
        }

        public void SetRoles(int[] roleIds)
        {
            foreach (int id in roleIds)
            {
                Role role = Role.GetRoleById(id);

                ListBoxItem item = new ListBoxItem
                {
                    DataContext = role,
                    Foreground = new SolidColorBrush(role.DefaultTeam.Color),
                    Content = role.Name
                };

                RoleList.Items.Add(item);
            }
        }

        public void SetUsers(string[] users)
        {
            foreach (string user in users)
                UserList.Items.Add(user);
        }

        private void ChatBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void ActionBtn(object sender, RoutedEventArgs e)
        {

        }
        private void VoteWerewolf(ListBox listBox, User Voted)
        {
            ItemCollection collection = listBox.Items;

            ListBoxItem item = new ListBoxItem
            {
                DataContext = Voted,
                Content = Voted.Name
            };

            collection.Add(item);
            List<ListBoxItem> list = collection.Cast<ListBoxItem>().ToList();

            foreach (ListBoxItem listBoxItem in list)
                collection.Add(listBoxItem);
        }
        private void VoteBtn(object sender, RoutedEventArgs e)
        {
            if (_voteActivated)
            {
                Vote.Background = Brushes.Gray;
            }
            else
            {
                Vote.Background = Brushes.Red;
            }
            _voteActivated = !_voteActivated;
            if (_actionActivated)
            {
                Action.Background = Brushes.Gray;
                _actionActivated = false;
            }
            if (UserList.SelectedItem == null) return;
            DeathList.Items.Add (UserList.SelectedItem.ToString());
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
