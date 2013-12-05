using Battleship.Model;
using Battleship.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Battleship.View
{
    public class ShipControl
    {
        private bool[,] occupied = new bool[10, 10];
        private int[] row;
        private int[] column;

        public ShipControl()
        {
        }

        public bool shipFits()
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] > 9 || column[i] > 9)
                {
                    return false ;
                }
            }
            return true;
        }

        public bool isOccupied()
        {
            if (shipFits())
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (occupied[row[i], column[i]])
                    {
                        return true;
                    }
                }
                return false;
            }
            else
            {
                return true;
            }

            
        }

        public bool checkValidPlacement(int[] row, int[] column, BoardModel bm)
        {
            this.row = row;
            this.column = column;
            setArray(bm);
            if (!isOccupied())
            {
                setOccupied();
                return true;
            }
            else
            {
                return false;
            }
        }

        private void setArray(BoardModel model)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (model.Model[i, j] == BoardConstants.water)
                    {
                        occupied[i, j] = false;
                    }
                    else
                    {
                        occupied[i, j] = true;
                    }
                }
            }
        }

        private void setOccupied()
        {
            for (int i = 0; i < row.Length; i++)
            {
                occupied[row[i], column[i]] = true;
            }
            setSurroundingOccupied();
        }

        private void setSurroundingOccupied()
        {
            for (int i = 0; i < row.Length; i++)
            {
                for (int j = row[i] - 1; j <= row[i] + 1; j++)
                {
                    try
                    {
                        occupied[row[j], column[j]] = true;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                    }
                }

            }
        }
    }
}
