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
        private int[,] _model = new int[10, 10];
        public int[,] Model
        {
            get { return _model; }
        }
        public BoardModel()
        {
            initBoard();
        }

        private void initBoard()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    _model[i, j] = BoardConstants.water;
                }
            }
        }
        public void modifyCoordinate(int x, int y, int boardConstant)
        {
            _model[x, y] = boardConstant;
        }

        public bool allBoatsPlaced()
        {
            int b = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (_model[i, j] == BoardConstants.ship)
                    {
                        b++;
                    }
                }
            }
            return b > 13;
        }

        internal bool finished()
        {
            int h = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (_model[i, j] == BoardConstants.hit)
                    {
                        h++;
                    }
                }
            }
            return h == 14;
        }
    }
}
