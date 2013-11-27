using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Battleship.View
{
    public class ShipControl
    {
        private bool[,] occupied = new bool[10, 10];

        public ShipControl()
        {
            initIsOccupied();
        }

        public bool shipFits(int row, int column, Orientation orientation, int size)
        {
            if (orientation.Equals(Orientation.Horizontal))
            {
                return 10 > (column + size - 1);
            }
            else
            {
                return 10 > (row + size - 1);
            }
        }

        public bool isOccupied(int row, int column, Orientation orientation, int size)
        {
            if (shipFits(row, column, orientation, size))
            {
                for (int i = 0; i < size; i++)
                {
                    if (orientation.Equals(Orientation.Horizontal))
                    {
                        if (occupied[row, column + i])
                        {
                            return true;
                        }
                    }
                    else
                    {
                        if (occupied[row + i, column])
                        {
                            return true;
                        }
                    }
                }
                return false;
            }
            return true;
        }

        public void setOccupied(int row, int column, Orientation orientation, int size)
        {
            for (int i = 0; i < size; i++)
            {
                if (orientation.Equals(Orientation.Horizontal))
                {
                    occupied[row, column + i] = true;
                }
                else
                {
                    occupied[row + i, column] = true;
                }
            }
        }

        private void initIsOccupied()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    occupied[i, j] = false;
                }
            }
        }
    }
}
