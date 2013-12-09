using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Battleship;
using Battleship.Model;

namespace GameTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestDoubleShot()
        {
            Player player1 = new Player();
            Player player2 = new Player();
            
            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            placeBoats(player1);
            game.progressGame();
            placeBoats(player2);
            game.progressGame();
            bool didTakeShoot = game.Shoot(1, 1);
            Assert.AreEqual(true, didTakeShoot);
            didTakeShoot = game.Shoot(1, 1);
            Assert.AreEqual(false, didTakeShoot);
        }
        [TestMethod]
        public void TestValidShot()
        {
            Player player1 = new Player();
            Player player2 = new Player();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            placeBoats(player1);
            game.progressGame();
            placeBoats(player2);
            game.progressGame(); 
            bool didTakeShoot = game.Shoot(1, 1);
            Assert.AreEqual(true, didTakeShoot);
        }
        [TestMethod]
        public void TestInValidShot()
        {
            Player player1 = new Player();
            Player player2 = new Player();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            placeBoats(player1);
            game.progressGame();
            placeBoats(player2);
            game.progressGame(); 
            bool didTakeShoot = game.Shoot(-1, 1);
            Assert.AreEqual(false, didTakeShoot);
        }
        private void placeBoats(Player player)
        {
            for (int i = 0; i < 5; i++)
            {
                player.UserBoard.modifyCoordinate(i, 0, BoardConstants.ship);
            }
            for (int i = 0; i < 4; i++)
            {
                player.UserBoard.modifyCoordinate(i, 2, BoardConstants.ship);
            }
            for (int i = 0; i < 3; i++)
            {
                player.UserBoard.modifyCoordinate(i, 4, BoardConstants.ship);
            }
            for (int i = 0; i < 2; i++)
            {
                player.UserBoard.modifyCoordinate(i, 6, BoardConstants.ship);
            }

        }
    }
}
