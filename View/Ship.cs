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

        public abstract int startX { get; set; }
        public abstract int startY { get; set; }
        public abstract Orientation Orientation { get; set; }
        public abstract int Size { get; set; }

        public Ship()
        {
     
        }


    }
}
