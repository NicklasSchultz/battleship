using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Battleship.Model;
using Battleship.ViewModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Battleship
{
    public class Player
    {
        public int Id { get; set; }
        public String Name { get; set; }

        [ForeignKey("TargetBoardID")]
        public virtual BoardModel TargetBoard { get; set; }

        [ForeignKey("UserBoardID")]
        public virtual BoardModel UserBoard { get; set; }

        public int TargetBoardID { get; private set; }

        public int UserBoardID { get; private set; }

        public Player()
        {
            UserBoard = new BoardModel();
            TargetBoard = new BoardModel();
        }
    }
}
