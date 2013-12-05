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
        public BoardModel UserBoard { get; set; }
        private BoardModel _targetdBoard = new BoardModel();
        public BoardModel TargetBoard { get; set; }

        internal void makeMove(BoardModel boardModel)
        {
            
        }
    }
}
