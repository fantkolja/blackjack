﻿using BlackJack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack.Game.Strategy
{
    interface IStrategy
    {
        public bool RequestNextDraw(List<Card> cards);
    }
}