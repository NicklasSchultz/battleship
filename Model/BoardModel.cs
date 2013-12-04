using Battleship.Model;
using Battleship.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Battleship.ViewModel
{
    public class BoardModel
    {
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

        public void resetToWater(Ship s)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (_model[i, j] == BoardConstants.getBoatSize(s))
                    {
                        _model[i, j] = BoardConstants.water;
                    }
                }
            }
        }
    }
}
