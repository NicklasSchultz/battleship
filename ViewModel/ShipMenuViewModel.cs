using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.ViewModel
{
    class ShipMenuViewModel:BaseViewModel
    {

        private ShipView shipView;

        public ShipView Selected
        {
            get { return shipView; }
            set { shipView = value; }
        }
    }
}
