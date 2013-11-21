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
                Cell cell = _cells[vert + hor * 10];
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
            Ship s = new Ship(this[2, 4], 4);
            for (int i = 0; i < s.getSize(); i++)
            {
                Cell c = s.getStartCell();
                this[c.GetHorPosition(), c.GetVerPosition()+i].Content = s;
            }
                this[5, 5].Content = new Ship(this[5, 5]);
            this[5, 6].Content = new Ship(this[5, 7]);
            this[5, 7].Content = new Ship(this[5, 7]);
        }
    }
}
