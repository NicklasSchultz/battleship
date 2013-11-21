using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public sealed class Cell
    {
        public int HorPosition;
        public int VertPosition;

        public Content Content { get; set; }

        public Cell(int horPosition, int vertPosition)
        {
            VertPosition = vertPosition;
            HorPosition = horPosition;
        }

        public int GetHorPosition()
        {
            return HorPosition;
        }
        public int GetVerPosition()
        {
            return VertPosition;
        }
    }
}
