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

namespace Battleship.ViewModel
{
    public class BoardViewModel : BaseViewModel, ModelHolder
    {
        private BoardModel _board = new BoardModel();
        public EventHandler eventHandler;
        private ShipControl control = new ShipControl();
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
            /*        if (_board.Model[x, y] == BoardConstants.water || isShip(x, y))
                    {
                        if (isShip(x, y))
                        {
                            _board.modifyCoordinate(x, y, BoardConstants.hit);
                            Board = _board;
                            RaisPropertyChangedEvent("Board");
                            eventHandler(this, EventArgs.Empty);

                        }
                        else
                        {
                            this._board.modifyCoordinate(x, y, BoardConstants.miss);
                            Board = _board;
                            this.RaisPropertyChangedEvent("Board");
                            eventHandler(this, EventArgs.Empty);
                        }
                    }*/
        }

        private bool isShip(int x, int y)
        {
            if (_board.Model[x, y] == BoardConstants.airCraftCarrier || _board.Model[x, y] == BoardConstants.submarine || _board.Model[x, y] == BoardConstants.patrolBoat || _board.Model[x, y] == BoardConstants.destroyer)
            {

                return true;
            }
            return false;
        }

        public void addShip(int[] x, int[] y, Ship s)
        {
            _board.resetToWater(s);
            for (int i = 0; i < x.Length; i++)
            {
                _board.modifyCoordinate(x[i], y[i], BoardConstants.getBoatSize(s));
                Board = _board;
            }
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
    }
}
