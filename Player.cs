using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Model;
using Battleship.ViewModel;

namespace Battleship
{
    public class Player
    {
        public BoardModel UserBoard { get; private set; }
        public BoardModel TargetBoard { get; private set; }
        public Player()
        {
            UserBoard=new BoardModel();
            TargetBoard = new BoardModel();
        }
    }
}
