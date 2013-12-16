using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.ViewModel;
using Battleship.Model;
using System.Windows.Controls;
using Battleship.View;
using System.Windows;
using System.Windows.Input;

namespace Battleship.ViewModel
{
    public class BoardViewModel : BaseViewModel, ModelHolder
    {
        private BoardModel _board = new BoardModel();
        public EventHandler eventHandler;
        public BoardModel Board
        {
            get { return _board; }
            set
            {
                this._board = value;
                this.RaisPropertyChangedEvent("Board");
            }
        }

        public void coordinateClicked(int x, int y)
        {
            foreach (CellValue c in _board.Model)
            {
                if (c.X == x && c.Y == y)
                {
                    if (c.Value > 3)
                    {
                        _board.modifyCoordinate(x, y, BoardConstants.hit);
                        Board = _board;
                    }
                    else if (c.Value == BoardConstants.water)
                    {
                        _board.modifyCoordinate(x, y, BoardConstants.miss);
                        Board = _board;
                    }
                    DoSomething();
                }
            }
            
        }

        public void addShip(int[] x, int[] y)
        {
            for (int i = 0; i < x.Length; i++)
            {
                _board.modifyCoordinate(x[i], y[i], BoardConstants.ship);
            }
            Board = _board;
        }

        public void modelChanged(BoardModel model)
        {
            Board = model;
        }
        public event EventHandler SomethingHappened;

        public void DoSomething()
        {
            EventHandler handler = SomethingHappened;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
        private void gridClicked(object sender, MouseButtonEventArgs e)
        { }

        public void shipSelected()
        {

        }
    }
}
