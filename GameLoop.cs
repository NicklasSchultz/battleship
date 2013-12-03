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
        private BoardModel player1 = new BoardModel();
        private BoardModel player2 = new BoardModel();
        BoardViewModel bm;
        BoardView bv;

        public GameLoop(MainWindowViewModel mwwm)
        {
            this.mwwm = mwwm;
            bv = mwwm.Content as BoardView;
            bm = bv.DataContext as BoardViewModel;
            bm.Board = player1;

        }

        public void HandleEvent(object sender, EventArgs arg)
        {
            bm.Board = next();

        }

        private BoardModel next()
        {
            if (bm.Board == player2)
            {
                return player1;
            }
            return player2;
        }
    }
}
