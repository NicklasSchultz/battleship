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
        public Player Player1 { get; private set; }
        public Player Player2 { get; private set; }
        private BoardModel visibleBoard;
        private Player currentPlayer;
        public bool TookShoot { get; private set; }
        public int CurrentState { get; private set; }
        public bool resetBoard { get; private set; }
        public bool BoatsPlaced { get; private set; }
        public BattleshipBuilder(ModelHolder modelHolder, Player player1, Player player2, int state)
        {
            TookShoot = false;
            BoatsPlaced = false;
            resetBoard = false;
            CurrentState = state;
            this.modelHolder = modelHolder;
            this.Player1 = player1;
            this.Player1.Name = "Player1";
            this.Player2 = player2;
            this.Player2.Name = "Player2";
            currentPlayer = player1;
            visibleBoard = player1.UserBoard;
            modelHolder.modelChanged(visibleBoard);
        }


        public void progressGame()
        {
            if (CurrentState == State.PLACE_BOAT_STATE)
            {
                if (visibleBoard.allBoatsPlaced())
                {
                    if (currentPlayer.Equals(Player2))
                    {
                        CurrentState = State.GAME_STATE;
                        currentPlayer = nextPlayer();
                        resetBoard = true;
                        visibleBoard = currentPlayer.TargetBoard;
                        modelHolder.modelChanged(visibleBoard);
                    }
                    else
                    {
                        BoatsPlaced = true;
                        currentPlayer = nextPlayer();
                        visibleBoard = currentPlayer.UserBoard;
                        modelHolder.modelChanged(visibleBoard);
                    }

                }
                else
                {
                    MessageBox.Show("Placera ut alla skepp");
                    BoatsPlaced = false;
                }
            }
            else if (CurrentState == State.GAME_STATE)
            {
                resetBoard = false;
                if (visibleBoard.finished())
                {
                    MessageBox.Show("Vinnare " + currentPlayer.Name);
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
            return currentPlayer.Equals(Player1) ? Player2 : Player1;
        }

        public int Shoot(int x, int y)
        {
            if (validShoot(x, y))
            {
                nextPlayer();
                int i = 0;
                foreach (CellValue c in currentPlayer.UserBoard.Model)
                {
                    if (c.X == x && c.Y == y)
                        i = c.Value;
                }
                if(i==BoardConstants.ship){
                    currentPlayer.TargetBoard.modifyCoordinate(x, y, BoardConstants.hit);
                    modelHolder.modelChanged(currentPlayer.TargetBoard);
                    return BoardConstants.hit;
                }else{
                    currentPlayer.TargetBoard.modifyCoordinate(x,y,BoardConstants.miss);
                    modelHolder.modelChanged(currentPlayer.TargetBoard);
                    return BoardConstants.miss;
                }
            }
            return -1;
        }

        public String getPlayer()
        {
            return currentPlayer.Name;
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
            int val = 0;
            foreach (CellValue c in currentPlayer.TargetBoard.Model)
            {
                if (c.X == x && c.Y == y)
                    val = c.Value;
            }
            return val != BoardConstants.hit && val != BoardConstants.miss;
        }
    }

}
