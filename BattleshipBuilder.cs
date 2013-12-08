using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Battleship.Game;

namespace Battleship
{
    class BattleshipBuilder
    {
        private ModelHolder modelHolder;
        private Player player2;
        private Player player1;
        private BoardModel visibleBoard;
        private Player currentPlayer;
        private int state = State.PLACE_BOAT_STATE;

        public BattleshipBuilder(ModelHolder modelHolder, Player player1, Player player2)
        {
            this.modelHolder = modelHolder;
            this.player1 = player1;
            this.player2 = player2;
            currentPlayer = player1;
            visibleBoard = player1.UserBoard;
            modelHolder.modelChanged(player1.UserBoard);
        }


        public void startGame(object sender, EventArgs args)
        {
            if (state == State.PLACE_BOAT_STATE)
            {
                if (visibleBoard.allBoatsPlaced())
                {
                    if (currentPlayer.Equals(player2))
                    {
                    state = State.GAME_STATE;
                    }
                    currentPlayer = nextPlayer();
                    visibleBoard = currentPlayer.UserBoard;
                    modelHolder.modelChanged(visibleBoard);
                }
                else
                {
                    MessageBox.Show("Placera ut alla skepp");
                }
            }
            else if (state == State.GAME_STATE)
            {
                if (visibleBoard.finished())
                {
                    MessageBox.Show("vinnare" + currentPlayer);
                }
                else
                {
                    currentPlayer = nextPlayer();
                    visibleBoard = currentPlayer.TargetBoard;
                    modelHolder.modelChanged(visibleBoard);
                }
            }
        }

        private Player nextPlayer()
        {
            return currentPlayer.Equals(player1) ? player2 : player1;
        }

        public void Shoot(int x, int y)
        {
            currentPlayer.TargetBoard.Model[x, y] = BoardConstants.miss;
        }
    }

}
