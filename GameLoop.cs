using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.ViewModel;
using Battleship.Model;
using Battleship.View;
using System.Windows;

namespace Battleship
{
    class GameLoop
    {

        private MainWindowViewModel mwwm;
        private Player player1=new Player();
        private Player player2 = new Player();
        private Player currentPlayer;
        private BoardViewModel bm;
        private BoardView bv;

        public GameLoop(MainWindowViewModel mwwm)
        {
            currentPlayer = player1;
            this.mwwm = mwwm;
            bv = mwwm.Content as BoardView;
            bm = bv.DataContext as BoardViewModel;
            bm.Board = player1.Board;

        }
        public void start()
        {
            while(true){
                currentPlayer = nextPlayer();
                bm.Board = currentPlayer.Board;
                currentPlayer.makeMove(nextPlayer().Board);
            }
        }

        private Player nextPlayer()
        {
            return currentPlayer.Equals(player1)?player2:player1;
        }

        public void HandleEvent(object sender, EventArgs arg)
        {
            
        }
    }
}
