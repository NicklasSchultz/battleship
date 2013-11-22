using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    class Ship : Content
    {
        private int Size;
        private Cell Cell;

        public Ship(Cell cell)
            : base(cell)
        {
            Cell = cell;
        }

        public Ship(Cell cell, int size)
            :base(cell, size)
        {
            Cell = cell;
            Size = size;
        }

        public int getSize()
        {
            return Size;
        }

        public Cell getStartCell()
        {
            return Cell;
        }
    }
}
