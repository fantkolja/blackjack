﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    public class WeakStrategy : IStrategy
    {
        public bool DecideMove(int currentPoints)
        {
            return currentPoints < 13;
        }
    }
}
