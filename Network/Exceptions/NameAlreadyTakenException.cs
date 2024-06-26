﻿using System;

namespace Werewolf.Network.Exceptions
{
    public class NameAlreadyTakenException : Exception
    {
        public NameAlreadyTakenException(string name)
            : base($"`{name}' đã được đặt.")
        {
        }
    }
}
