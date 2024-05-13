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
using WerewolfClient;

namespace Werewolf.Views
{
    /// <summary>
    /// Interaction logic for GameView.xaml
    /// </summary>
    public partial class GameView : UserControl
    {
        private int _currentDay;
        private int _currentTime;
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

        private void ActioBtn(object sender, RoutedEventArgs e)
        {
            if (UserList.SelectedItem != null)
            {
                string selectedUser = UserList.SelectedItem.ToString();
                Player player = Game.Game.Instance.Get_Players().FirstOrDefault(p => p.User.Name == selectedUser);
                if (player != null)
                {
                    string role = player.Role.Name;
                    if (role == "Hunter")
                    {

                    }
                    else if (role == "Witch")
                    {

                    }
                    else if (role == "Seer")
                    {

                    }
                    else
                    {
                        _actionActivated = false;
                    }

                }
            }
        }
        private void VoteWerewolf(ListBox listBox, Player Voted)
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
        /*public void Notify(Model m)
        {
            if (m is WerewolfModel)
            {
                WerewolfModel wm = (WerewolfModel)m;
                switch (wm.Event)
                {
                    case EventEnum.GameStopped:
                        AddChatMessage("Game is finished, outcome is " + wm.EventPayloads["Game.Outcome"]);
                        _updateTimer.Enabled = false;
                        break;
                    case EventEnum.GameStarted:
                        players = wm.Players;
                        _myRole = wm.EventPayloads["Player.Role.Name"];
                        AddChatMessage("Your role is " + Role + ".");
                        _currentPeriod = Game.PeriodEnum.Night;
                        EnableButton(Action, true);
                        switch (_myRole)
                        {
                            case WerewolfModel.ROLE_PRIEST:
                                Action.Text = WerewolfModel.ACTION_HOLYWATER;
                                break;
                            case WerewolfModel.ROLE_GUNNER:
                                Action.Text = WerewolfModel.ACTION_SHOOT;
                                break;
                            case WerewolfModel.ROLE_JAILER:
                                Action.Text = WerewolfModel.ACTION_JAIL;
                                break;
                            case WerewolfModel.ROLE_WEREWOLF_SHAMAN:
                                Action.Text = WerewolfModel.ACTION_ENCHANT;
                                break;
                            case WerewolfModel.ROLE_BODYGUARD:
                                Action.Text = WerewolfModel.ACTION_GUARD;
                                break;
                            case WerewolfModel.ROLE_DOCTOR:
                                Action.Text = WerewolfModel.ACTION_HEAL;
                                break;
                            case WerewolfModel.ROLE_SERIAL_KILLER:
                                Action.Text = WerewolfModel.ACTION_KILL;
                                break;
                            case WerewolfModel.ROLE_SEER:
                            case WerewolfModel.ROLE_WEREWOLF_SEER:
                                Action.Text = WerewolfModel.ACTION_REVEAL;
                                break;
                            case WerewolfModel.ROLE_AURA_SEER:
                                Action.Text = WerewolfModel.ACTION_AURA;
                                break;
                            case WerewolfModel.ROLE_MEDIUM:
                                Action.Text = WerewolfModel.ACTION_REVIVE;
                                break;
                            default:
                                EnableButton(Action, false);
                                break;
                        }
                        break;
                    case EventEnum.SwitchToDayTime:
                        AddChatMessage("Switch to day time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Day;
                        LBPeriod.Text = "Day time of";
                        break;
                    case EventEnum.SwitchToNightTime:
                        AddChatMessage("Switch to night time of day #" + wm.EventPayloads["Game.Current.Day"] + ".");
                        _currentPeriod = Game.PeriodEnum.Night;
                        LBPeriod.Text = "Night time of";
                        break;
                    case EventEnum.UpdateDay:
                        // TODO  catch parse exception here
                        string tempDay = wm.EventPayloads["Game.Current.Day"];
                        _currentDay = int.Parse(tempDay);
                        LBDay.Text = tempDay;
                        break;
                    case EventEnum.UpdateTime:
                        string tempTime = wm.EventPayloads["Game.Current.Time"];
                        _currentTime = int.Parse(tempTime);
                        LBTime.Text = tempTime;
                        UpdateAvatar(wm);
                        break;
                    case EventEnum.Vote:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            AddChatMessage("Your vote is registered.");
                        }
                        else
                        {
                            AddChatMessage("You can't vote now.");
                        }
                        break;
                    case EventEnum.Action:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            AddChatMessage("Your action is registered.");
                        }
                        else
                        {
                            AddChatMessage("You can't perform action now.");
                        }
                        break;
                    case EventEnum.YouShotDead:
                        AddChatMessage("You're shot dead by gunner.");
                        _isDead = true;
                        break;
                    case EventEnum.OtherShotDead:
                        AddChatMessage(wm.EventPayloads["Game.Target.Name"] + " was shot dead by gunner.");
                        break;
                    case EventEnum.Alive:
                        AddChatMessage(wm.EventPayloads["Game.Target.Name"] + " has been revived by medium.");
                        if (wm.EventPayloads["Game.Target.Id"] == null)
                        {
                            _isDead = false;
                        }
                        break;
                    case EventEnum.ChatMessage:
                        if (wm.EventPayloads["Success"] == WerewolfModel.TRUE)
                        {
                            AddChatMessage(wm.EventPayloads["Game.Chatter"] + ":" + wm.EventPayloads["Game.ChatMessage"]);
                        }
                        break;
                    case Chat:
                        if (wm.EventPayloads["Success"] == WerewolfModel.FALSE)
                        {
                            switch (wm.EventPayloads["Error"])
                            {
                                case "403":
                                    AddChatMessage();
                                    break;
                                case "404":
                                    AddChatMessage();
                                    break;
                                case "405":
                                    AddChatMessage();
                                    break;
                                case "406":
                                    AddChatMessage();
                                    break;
                            }
                        }
                        break;
                }
            }
        }*/
        private void VoteBtn(object sender, RoutedEventArgs e)
        {
            string selectedUser = UserList.SelectedItem.ToString();
            Player player = Game.Game.Instance.Get_Players().FirstOrDefault(p => p.User.Name == selectedUser);
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
            //DeathList.Items.Add (UserList.SelectedItem.ToString());

            int index = UserList.SelectedIndex;
            Player players = (Player)(((ListBoxItem)UserList.Items[index]).DataContext);
            string role = player.Role.Name;
            VoteWerewolf(DeathList, players);
            if (role == "Werewolf")
            {
                
            }
        }

        private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
