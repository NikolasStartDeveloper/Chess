using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chess
{
    internal class GameState
    {
        private enum StateInGame{
            WhiteWon,
            BlackWon,
            WhiteTurn,
            BlackTurn,
            Stalemate

        }
    }
}
