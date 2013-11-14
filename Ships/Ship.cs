using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Ships
{
    public class Ship
    {
        int length;
        int life;
        bool isSunked = false;

        public Ship(int length)
        {
            this.length = length;
            this.life = length;
        }

        public void hit()
        {
            this.life = this.life - 1;
            if (life == 0)
            {
                isSunked = true;
            }
        }

        public int getLength()
        {
            return length;
        }

        public bool shipSunked(bool b)
        {
            return isSunked;
        }
    }
}
