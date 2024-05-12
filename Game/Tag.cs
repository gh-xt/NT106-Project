using System;

namespace Werewolf.Game
{
    [Flags]
    public enum Tag
    {
        NONE = 0,
        ISDEAD = 1,
        WEREWOLF_TARGET = 4,
        WITCH_TARGET = 8,
        DEAD = 16,
    }
}
