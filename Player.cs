using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Model;
using Battleship.ViewModel;

namespace Battleship
{
    class Player
    {
        private BoardModel _userBoard = new BoardModel();
        private BoardModel _targetBoard = new BoardModel();

        public BoardModel UserBoard
        {
            get { return _userBoard; }
            set
            {
            }
        }
        public BoardModel TargetBoard
        {
            get { return _targetBoard; }
            set
            {
            }
        }

        public Player()
        {

        }

    }
}
