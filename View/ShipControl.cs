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
        private int row;
        private int column;
        Orientation Orientation;
        int size;

        public ShipControl()
        {
            initIsOccupied();
        }

        public bool shipFits()
        {
            if (Orientation.Equals(Orientation.Horizontal))
            {
                return 10 > (column + size - 1);
            }
            else
            {
                return 10 > (row + size - 1);
            }
        }

        public bool isOccupied()
        {
            if (shipFits())
            {
                for (int i = 0; i < size; i++)
                {
                    if (Orientation.Equals(Orientation.Horizontal))
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

        public bool checkValidPlacement(int row, int column, Orientation orientation, int size)
        {
            this.row = row;
            this.column = column;
            this.Orientation = orientation;
            this.size = size;

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

        private void setOccupied()
        {
            for (int i = 0; i < size; i++)
            {
                if (Orientation.Equals(Orientation.Horizontal))
                {
                    occupied[row, column + i] = true;
                }
                else
                {
                    occupied[row + i, column] = true;
                }
            }
            setSurroundingOccupied();
        }

        private void setSurroundingOccupied()
        {
            for (int i = -1; i <= size; i++)
            {
                if (Orientation.Equals(Orientation.Horizontal))
                {
                    try
                    {
                        occupied[row - 1, column + i] = true;
                        occupied[row + 1, column + i] = true;
                    }
                    catch (IndexOutOfRangeException e)
                    {
                        
                    }
                    
                }
                else
                {
                    try
                    {
                        occupied[row + i, column - 1] = true;
                        occupied[row + i, column + 1] = true;
                    }
                    catch (IndexOutOfRangeException e)
                    {

                    }
                    
                }
            }
            if (Orientation.Equals(Orientation.Horizontal))
            {
                try
                {
                    occupied[row, column - 1] = true;
                    occupied[row, column + size] = true;
                } catch(IndexOutOfRangeException e){

                }
               
            }
            else
            {
                try {
                occupied[row -1, column] = true;
                occupied[row + size, column] = true;
                } catch(IndexOutOfRangeException e){

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
