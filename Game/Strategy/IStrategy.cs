using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJack
{
    interface IStrategy
    {
        bool ConfirmNextDraw(List<Card> drawnCards);
    }
}
