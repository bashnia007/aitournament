﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AICup
{
    public class Player : IGameObject
    {
        public ObjectsEnum Symbol => ObjectsEnum.Player;
        public Position Position { get; set; }
    }
}