using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class TestPlayer:Player
    {
        public TestPlayer(){
            placeShips();
        }

        private void placeShips()
        {
            for (int i = 0; i < 5; i++)
            {
                UserBoard.modifyCoordinate(i, 0, BoardConstants.ship);
            }
            for (int i = 0; i < 4; i++)
            {
                UserBoard.modifyCoordinate(i, 2, BoardConstants.ship);
            }
            for (int i = 0; i < 3; i++)
            {
                UserBoard.modifyCoordinate(i, 4, BoardConstants.ship);
            }
            for (int i = 0; i < 2; i++)
            {
                UserBoard.modifyCoordinate(i, 6, BoardConstants.ship);
            }
        }
    }
}
