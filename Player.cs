﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Model;
using Battleship.ViewModel;

namespace Battleship
{
    public class Player
    {
        public int Id { get; set; }
        public BoardModel UserBoard { get; private set; }
        public String Name { get; set; }
        public BoardModel TargetBoard { get; private set; }
        public Player()
        {
            UserBoard=new BoardModel();
            TargetBoard = new BoardModel();
        }
    }
}
