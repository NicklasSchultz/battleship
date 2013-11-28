using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.ViewModel;
using Battleship.Model;

namespace Battleship.ViewModel
{
    public class BoardViewModel : BaseViewModel
    {
        private BoardModel _board = new BoardModel();
        public BoardModel Board
        {
            get { return _board; }
            set
            {
                _board = value;
                RaisPropertyChangedEvent("Board");
            }
        }


        public void coordinateClicked(int x, int y)
        {
            System.Windows.Forms.MessageBox.Show("hejsans ");
            if (_board.Model[x, y] == BoardConstants.water || _board.Model[x, y] == BoardConstants.ship)
            {
                if (_board.Model[x, y] == BoardConstants.ship)
                {
                    _board.modifyCoordinate(x, y, BoardConstants.hit);
                }
                else
                {
                    _board.modifyCoordinate(x, y, BoardConstants.miss);
                }
            }
        }
    }
}
