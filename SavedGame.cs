using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class SavedGame
    {
        private String name;
        private Player player1;
        private Player player2;

        public SavedGame(String name, Player player1, Player player2)
        {
            this.name = name;
            this.player1 = player1;
            this.player2 = player2;
        }
    }
}
