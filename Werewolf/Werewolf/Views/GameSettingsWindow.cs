using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Werewolf.Views
{
    public partial class GameSettingsWindow : Form
    {
        private RoomView room_View;
        public GameSettingsWindow()
        {
            InitializeComponent();

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
