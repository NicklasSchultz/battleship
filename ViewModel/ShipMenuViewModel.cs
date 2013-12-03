using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.ViewModel
{
    class ShipMenuViewModel:BaseViewModel
    {

        public Double RelativeWidth
        {
            get { return relativeWidth; }
            set
            {
                if (relativeWidth != value)
                {
                    relativeWidth = value;
                }
            }
        }
        private Double relativeWidth;
    }
}
