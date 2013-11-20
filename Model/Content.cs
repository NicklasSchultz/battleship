using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public abstract class Content
    {
        protected Cell Cell;
        protected int Size;

        protected Content(Cell cell)
        {
            Cell = cell;
        }

        protected Content(Cell cell, int size)
        {
            Cell = cell;
            Size = size;
        }
    }
}
