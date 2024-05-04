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

        public static Role Cupid;
        public static Role Hunter;
        public static Role LittleGirl;
        public static Role Seer;
        public static Role Villager;
        public static Role Werewolf;
        public static Role Witch;

        static Role()
        {
            allRoles = new Dictionary<int, Role>();

            Cupid = new Role(0, "Cupid", Team.Village, true,
                "Đêm đầu tiên em sẽ chọn ra hai người. Hai người này sẽ yêu nhau, nghĩa là " +
                "rằng nếu một người chết vào ban đêm hoặc ban ngày thì người còn lại sẽ tự tử vì đau buồn. Lỡ như" +
                "đôi tình nhân cùng tồn tại đến cuối cùng thì sẽ chiến thắng.");
            Hunter = new Role(1, "Thợ săn", Team.Village, true,
                "Khi bạn chết, bạn giết một người mà bạn chọn.");
            LittleGirl = new Role(2, "Ti hí", Team.Village, true,
                "Trong đêm, khi người sói thức giấc, bạn có thể thấy những tin nhắn họ gửi cho nhau.");
            Seer = new Role(3, "Tiên tri", Team.Village, true,
                "Mỗi đêm bạn có thể khám phá vai trò của người chơi mà bạn lựa chọn.");
            Villager = new Role(4, "Dân làng", Team.Village, false,
                "Bạn không có kỹ năng đặc biệt.");
            Werewolf = new Role(5, "Ma sói", Team.Werewolf, false,
                "Trong đêm, bạn có thể trò chuyện với những người sói khác và bầu chọn một người. Người đó " +
                "Ai có nhiều phiếu bầu nhất sẽ bị coi là mục tiêu và sẽ chết vào sáng hôm sau.");
            Witch = new Role(6, "Phù tủy", Team.Village, true,
                "Trong đêm, bạn có thể lựa chọn giữa 3 hành động: sử dụng thuốc chữa bệnh; nó cho phép " +
                "Để tránh mục tiêu của người sói bị giết, hãy dùng thuốc độc để giết người" +
                "theo lựa chọn của bạn, hoặc không làm gì cả. Bạn chỉ có một lọ thuốc cho toàn bộ trò chơi.");
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
