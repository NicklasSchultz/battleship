using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Battleship
{
    class BattleshipBuilder
    {
        private ModelHolder modelHolder;
        private Player player2;
        private Player player1;
        private BoardModel visibleBoard;
        private Player currentPlayer;

        public BattleshipBuilder(ModelHolder modelHolder, Player player1, Player player2)
        {
            this.modelHolder = modelHolder;
            this.player1 = player1;
            this.player2 = player2;
            currentPlayer = player1;
            modelHolder.modelChanged(player1.UserBoard);
        }


        public void startGame(object sender, EventArgs args)
        {
                currentPlayer = nextPlayer();
                visibleBoard = currentPlayer.TargetBoard;
                modelHolder.modelChanged(visibleBoard);
        }

        private Player nextPlayer()
        {
            return currentPlayer.Equals(player1) ? player2 : player1;
        }

    }

}
