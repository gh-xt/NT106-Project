using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

using Werewolf.Game.Exceptions;
using Werewolf.Network;
using Werewolf.Network.Events;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Werewolf.Game
{
    public class Game
    {
        #region Singleton
        private static Game instance = null;
        public static Game Instance
        {
            get
            {
                if (!Server.Instance.Started) throw new InvalidOperationException("Game cannot be used in Clients");
                if (instance == null)
                    instance = new Game();
                return instance;
            }
        }
        #endregion Singleton

        private readonly List<Player> players;
        private readonly List<Role> Roles;

        private Game()
        {
            players = new List<Player>();
            Roles = new List<Role>();
        }

        public void Add_Player(User user) => players.Add(new Player(user));
        public void Del_Players(string name) => players.RemoveAll((p) => p.Name == name);
        public void Del_Players(User user) => Del_Players(user.Name);
        public List<Player> Get_Players() => players;

        public void Add_Role(Role role) => Roles.Add(role);
        public void Del_Role(Role role) => Roles.Remove(role);
        public bool Contain_Role(Role role) => Roles.Any((r) => r.Name == role.Name);
        public List<Role> Get_Roles() => new List<Role>(Roles);

        public void SendEvent<TEventArgs>(TEventArgs args) where TEventArgs : ServerToClientEventArgs
        {
            foreach (Player player in players)
                player.User.SendEvent(args);
        }

        public void SendEvent<TEventArgs>(TEventArgs args, Role role) where TEventArgs : ServerToClientEventArgs
        {
            foreach (Player player in players.Where((p) => p.Role == role))
                player.User.SendEvent(args);
        }

        public void SendEvent<TEventArgs>(TEventArgs args, Tag tag) where TEventArgs : ServerToClientEventArgs
        {
            foreach (Player player in players.Where((p) => p.IsTagged(tag)))
                player.User.SendEvent(args);
        }

        public void Validate_Roles()
        {
            int Villagers_Count = Roles.Count((r) => r.DefaultTeam == Team.Village);
            int Wolfs_Count = Roles.Count((r) => r.DefaultTeam == Team.Werewolf);
            int Roles_Count = Roles.Count;
            int Players_Count = players.Count;

            if (Wolfs_Count < 1) throw new NotEnoughWerewolfException();
            if (Wolfs_Count >= Villagers_Count) throw new TooMuchWerewolfException();
            if (Roles_Count < Players_Count) throw new NotEnoughRolesException();
            if (Roles_Count > Players_Count) throw new TooMuchRolesException();
        }

        public void Assign_Roles_Random()
        {
            Random rand = new Random();
            List<Role> roles = new List<Role>(Roles);

            foreach (Player player in players)
            {
                int randomIndex = rand.Next(0, roles.Count);
                player.Role = roles[randomIndex];
                roles.RemoveAt(randomIndex);
            }
        }

        public async void StartGame_Loop()
        {
            for (int i = 15; i >= -1; --i)
            {
                SendEvent(new TimerUpdatedEventArgs(i));
                await Task.Delay(1000);
            }
        }
    }
}