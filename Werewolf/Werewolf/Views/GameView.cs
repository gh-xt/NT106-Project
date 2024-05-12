using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using Werewolf.Game;

namespace Werewolf.Views
{
    public partial class GameView : Form
    {
        public GameView()
        {
            InitializeComponent();
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
    }
}
