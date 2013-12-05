using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.ViewModel;
using Battleship.Model;

namespace Battleship.ViewModel
{
    public class BoardViewModel : BaseViewModel,ModelHolder
    {
        private BoardModel _board = new BoardModel();
        public EventHandler eventHandler;
        private bool next = false;
        public BoardModel Board
        {
            get { return _board; }
            set
            {
                this._board = value;
                this.RaisPropertyChangedEvent("Board");
            }
        }

        public bool Next
        {
            get { return next; }
            set
            {
                this.Next = value;
            }
        }


        public void coordinateClicked(int x, int y)
        {
            if (_board.Model[x, y] == BoardConstants.water || _board.Model[x, y] == BoardConstants.ship)
            {
                if (_board.Model[x, y] == BoardConstants.ship)
                {
                    _board.modifyCoordinate(x, y, BoardConstants.hit);
                    Board = _board;
                    eventHandler(this, EventArgs.Empty);
                    RaisPropertyChangedEvent("Board");
                }
                else
                {
                    this._board.modifyCoordinate(x, y, BoardConstants.miss);
                    Board = _board;
                    eventHandler(this, EventArgs.Empty);
                }
            }
        }

        public void addShip(int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                _board.modifyCoordinate(x[i], y[i], BoardConstants.ship);
                Board = _board;
            }
        }

        public void modelChanged(BoardModel model)
        {
            Board = model;
        }
    }
}
