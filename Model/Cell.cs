using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public sealed class Cell
    {
        public int HorPosition { get; private set; }
        public int VertPosition { get; private set; }

        public Content Content { get; set; }

        public Cell(int horPosition, int vertPosition)
        {
            VertPosition = vertPosition;
            HorPosition = horPosition;
        }
    }
}
