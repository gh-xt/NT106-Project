using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media;
using Werewolf.Game.Exceptions;
using Werewolf.Game;

namespace Werewolf.Views
{
    public partial class GameSettingsWindow : Form
    {
        private RoomView room_View;

        public GameSettingsWindow(MainWindow window)
        {
            InitializeComponent();
            Owner = window;
            room_View = null;

            Closing += (sender, e) =>
            {
                try
                {
                    Game.Game.Instance.Validate_Roles();

                    if (room_View != null)
                        room_View.EnableStartGameButton();
                }
                catch (NotEnoughWerewolfException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Phải có ít nhất 1 Ma sói!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (TooMuchWerewolfException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Chắc chắn phải có nhiều Dân làng hơn Ma sói!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (NotEnoughRolesException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Không có đủ vai trò cho tất cả người chơi!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                catch (TooMuchRolesException)
                {
                    e.Cancel = true;
                    MessageBox.Show("Có quá nhiều vai trò!", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            foreach (Role role in Role.GetAllRoles())
            {
                if (!Game.Game.Instance.Contain_Role(role) || !role.IsUnique)
                    AddRoleAndSort(AvailableRoleList, role);
            }

            foreach (Role role in Game.Game.Instance.Get_Roles())
                AddRoleAndSort(ChosenRoleList, role);
        }

        private void AddRoleAndSort(ListBox listBox, Role addedRole)
        {
            ItemCollection collection = listBox.Items;

            ListBoxItem item = new ListBoxItem
            {
                DataContext = addedRole,
                Foreground = new SolidColorBrush(addedRole.DefaultTeam.Color),
                Content = addedRole.Name
            };

            collection.Add(item);
            List<ListBoxItem> list = collection.Cast<ListBoxItem>().ToList();
            list.Sort((item1, item2) => ((Role)item1.DataContext).Name.CompareTo(((Role)item2.DataContext).Name));

            collection.Clear();
            foreach (ListBoxItem listBoxItem in list)
                collection.Add(listBoxItem);
        }


        private void OkBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
        public void SetRoomView(RoomView roomView)
        {

            room_View = roomView;
        }

        private void ChosenRoleList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
