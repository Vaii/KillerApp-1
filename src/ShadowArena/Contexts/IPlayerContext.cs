﻿using System.Collections.Generic;
using Shadow_Arena.Models;

namespace Shadow_Arena.Contexts
{
    interface IPlayerContext
    {
        void Add(Player player);
        void Delete(Player player);
        void Update(Player player);
        ICollection<Player> Read();
    }
}
