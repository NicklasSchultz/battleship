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
            InitializeBoard();
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
        private void InitializeBoard()
        {
            foreach (Cell cell in _cells)
            {
                cell.Content = new Water(cell);
            }
        }
    }
}
