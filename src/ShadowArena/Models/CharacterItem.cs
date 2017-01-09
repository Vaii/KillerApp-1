﻿using System;
using System.Collections.Generic;

namespace ShadowArena.Models
{
    public partial class CharacterItem
    {
        public int OwningCharacterid { get; set; }
        public int OwnedItemid { get; set; }
        public int Count { get; set; }
        public bool? Equipped { get; set; }

        public virtual Item OwnedItem { get; set; }
        public virtual Character OwningCharacter { get; set; }
    }
}