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
    public class BattleshipBuilder
    {
        private ModelHolder modelHolder;
        private Player player2;
        private Player player1;
        private BoardModel visibleBoard;
        private Player currentPlayer;
        public bool TookShoot { get; private set; }
        public int CurrentState { get; private set; }
        public bool resetBoard { get; private set; }
        public bool BoatsPlaced { get; private set; }
        public BattleshipBuilder(ModelHolder modelHolder, Player player1, Player player2)
        {
            TookShoot = false;
            BoatsPlaced = false;
            resetBoard = true;
            CurrentState = State.PLACE_BOAT_STATE;
            this.modelHolder = modelHolder;
            this.player1 = player1;
            this.player2 = player2;
            currentPlayer = player1;
            visibleBoard = player1.UserBoard;
            modelHolder.modelChanged(player1.UserBoard);
        }


        public void progressGame()
        {
            if (CurrentState == State.PLACE_BOAT_STATE)
            {
                if (visibleBoard.allBoatsPlaced())
                {
                    if (currentPlayer.Equals(player2))
                    {
                        BoatsPlaced = true;
                        CurrentState = State.GAME_STATE;
                        currentPlayer = nextPlayer();
                        resetBoard = true;
                        visibleBoard = currentPlayer.TargetBoard;
                        modelHolder.modelChanged(visibleBoard);
                    }
                    else
                    {
                        currentPlayer = nextPlayer();
                        visibleBoard = currentPlayer.UserBoard;
                        modelHolder.modelChanged(visibleBoard);
                    }

                }
                else
                {
                    MessageBox.Show("Placera ut alla skepp");
                }
            }
            else if (CurrentState == State.GAME_STATE)
            {
                resetBoard = false;
                if (visibleBoard.finished())
                {
                    MessageBox.Show("vinnare" + currentPlayer);
                }
                else
                {
                    TookShoot = false;
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

        public int Shoot(int x, int y)
        {
            if (validShoot(x, y))
            {
                int i=nextPlayer().UserBoard.Model[x, y];
                if(i==BoardConstants.ship){
                    currentPlayer.TargetBoard.modifyCoordinate(x, y, BoardConstants.hit);
                    return BoardConstants.hit;
                }else{
                    currentPlayer.TargetBoard.modifyCoordinate(x,y,BoardConstants.miss);
                    return BoardConstants.miss;
                }
            }
            return -1;
        }

        private bool validShoot(int x, int y)
        {
            BoardModel model = nextPlayer().UserBoard;

            if (!TookShoot && CurrentState == State.GAME_STATE && noShotAtSameCoord(x, y))
            {
                TookShoot = true;
                return true;
            }
            return false;
        }
        private bool noShotAtSameCoord(int x, int y)
        {
            BoardModel model = currentPlayer.TargetBoard;
            return model.Model[x, y] != BoardConstants.hit && model.Model[x, y] != BoardConstants.miss;
        }
    }

}
