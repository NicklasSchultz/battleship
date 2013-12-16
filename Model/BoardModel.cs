using Battleship.Model;
using Battleship.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Battleship.Model
{
    public class BoardModel
    {
        public int Id { get; set; }
        public List<CellValue> Model { get; set; }
        public BoardModel()
        {
            Model = new List<CellValue>();
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    CellValue c = new CellValue(i, j, BoardConstants.water);
                    c.bm = this;
                    Model.Add(c);

                }
            }
        }
        public void modifyCoordinate(int x, int y, int boardConstant)
        {
            foreach (CellValue c in Model)
            {
                if (c.X == x && c.Y == y)
                {
                    c.Value = boardConstant;
                }
            }
        }

        public bool allBoatsPlaced()
        {
            int b = 0;
            foreach (CellValue c in Model)
            {
                if (c.Value == BoardConstants.ship)
                    b++;
            }
            return b > 13;
        }

        internal bool finished()
        {
            int h = 0;
            foreach (CellValue c in Model)
            {
                if (c.Value == BoardConstants.hit)
                    h++;
            }
            return h == 14;
        }
    }
}
