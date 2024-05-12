﻿using System;
using System.Data;
using Werewolf.Network;

namespace Werewolf.Game
{
    public class Player : IEquatable<Player>
    {
        public User User { get; }
        private Role pri_Role;
        private Tag pri_Tag;
        private Team override_Team;

        public string Name => User.Name;
        public Role Role
        {
            get => pri_Role;
            set => pri_Role = value;
        }
        public Team Team => override_Team ?? pri_Role.DefaultTeam;

        public Player(User user)
        {
            User = user;
            pri_Role = null;
            pri_Tag = Werewolf.Game.Tag.NONE;
            override_Team = null;
        }

        public void RemoveTag(Tag tag) => pri_Tag ^= tag;
        public bool IsTagged(Tag tag) => pri_Tag.HasFlag(tag);

        public bool Equals(Player other) => Name.Equals(other.Name);
    }
}