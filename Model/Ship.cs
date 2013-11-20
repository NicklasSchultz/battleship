using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    class Ship : Content
    {
        public Ship(Cell cell)
            : base(cell)
        {

        }
        public Ship(Cell cell, int size) :base(cell, size)
        {

        }
    }
}
