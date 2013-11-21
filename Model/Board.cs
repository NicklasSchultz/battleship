using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public sealed class Board
    {
        private List<Cell> _cells;

        public Board()
        {
            _cells = new List<Cell>(100);
            for (int i = 0; i < 100; i++)
            {
                int row = i / 10;
                int column = i % 10;

                _cells.Add(new Cell(row, column));
            }
            System.Windows.MessageBox.Show("EHHEH");
            this[2,2].Content = new Water(this[2,2]);
            this[1, 5].Content = new Ship(this[1, 5]);
        }
        public Cell this[int hor, int vert]
        {
            get
            {
                Cell cell = _cells[vert + hor * 8];
                return cell;
            }
            set { this[hor, vert] = value; }
        }
        public List<Cell> Cells
        {
            get
            {
                return _cells;
            }
        }
    }
}
