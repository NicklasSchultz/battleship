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
            initArray();
        }

        public void initArray()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    occupied[i, j] = false;
                }
            }
        }

        private bool isOccupied()
        {
            for (int i = 0; i < row.Length; i++)
            {
                if (occupied[column[i], row[i]])
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkValidPlacement(int[] column, int[] row)
        {
            this.row = row;
            this.column = column;
            if (!isOccupied())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void setOccupied()
        {
            for (int col = column[0] - 1; col <= column[column.Length - 1] + 1; col++)
            {
                for (int ro =  row[0] - 1; ro <= row[row.Length - 1] + 1; ro++)
                {
                    if(col <10 && ro <10 && col>=0 && ro>=0)
                        occupied[col, ro] = true;
                }
            }
        }
    }
}