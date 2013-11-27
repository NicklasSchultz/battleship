using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battleship.View
{
    public abstract class Ship : UserControl
    {

        public int startX { get; set; }
        public int startY { get; set; }
        public Orientation Orientation{get ;  set;}

        public Ship()
        {

        }
    }
}
