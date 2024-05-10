using System;
using System.Linq;
using System.Collections.Generic;

namespace Werewolf.Game
{
    public class Role : IEquatable<Role>
    {
        private static readonly Dictionary<int, Role> allRoles;
        public static Role GetRoleById(int id)
        {
            if (!allRoles.ContainsKey(id)) throw new KeyNotFoundException();
            return allRoles[id];
        }
        public static Role[] GetAllRoles() => allRoles.Values.ToArray();
        public static Role Hunter;
        public static Role Seer;
        public static Role Villager;
        public static Role Werewolf;
        public static Role Witch;

        static Role()
        {
            allRoles = new Dictionary<int, Role>();

            Hunter = new Role(1, "Thợ săn", Team.Village, true,
                "Khi bạn chết, bạn có thể giết một người.");
            Seer = new Role(3, "Tiên tri", Team.Village, true,
                "Mỗi đêm bạn có thể khám phá vai trò của người chơi mà bạn chọn.");
            Villager = new Role(4, "Dân làng", Team.Village, false,
                "Bạn không có kỹ năng đặc biệt.");
            Werewolf = new Role(5, "Ma sói", Team.Werewolf, false,
                "Trong đêm, bạn có thể trò chuyện với những Ma sói khác và bầu chọn một người để giết. " +
                "Ai là người có nhiều phiếu bầu nhất sẽ bị coi là mục tiêu và sẽ chết vào sáng hôm sau.");
            Witch = new Role(6, "Phù thủy", Team.Village, true,
                "Trong đêm, bạn có thể lựa chọn 1 trong 3 hành động: sử dụng thuốc chữa bệnh (cho phép " +
                "người sói bị giết thoát chết), hoặc dùng thuốc độc để giết người mà bạn cho rằng đó là Ma sói, " +
                "hoặc không làm gì cả. Bạn chỉ có thể sử dụng 1 lọ thuốc trong suốt cuộc chơi.");
        }

        public int Id { get; }
        public string Name { get; }
        public Team DefaultTeam { get; }
        public bool IsUnique { get; }
        public string Description { get; }

        public Role(int id, string name, Team defaultTeam, bool isUnique, string description)
        {
            Id = id;
            Name = name;
            DefaultTeam = defaultTeam;
            IsUnique = isUnique;
            Description = description;

            allRoles.Add(id, this);
        }

        public override string ToString() => Name;

        public bool Equals(Role other) => Id.Equals(other.Id);
    }
}
