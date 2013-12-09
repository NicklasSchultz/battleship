using Battleship.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public static class BoardConstants
    {
        public const int water=0;
        public const int ship=1;
        public const int hit=2;
        public const int miss = 3;
        public const int airCraftCarrier = 4;
        public const int destroyer = 5;
        public const int submarine = 6;
        public const int patrolBoat = 7;

        public static int getBoatSize(Ship o)
        {
            if (o.GetType() == typeof(PatrolBoat))
            {
                return patrolBoat;
            }
            if (o.GetType() == typeof(Submarine))
            {
                return submarine;
            }
            if (o.GetType() == typeof(AirCraftCarrier))
            {
                return airCraftCarrier;
            }
            if (o.GetType() == typeof(Destroyer))
            {
                return destroyer;
            }
            return 0;
        }
    }


}
