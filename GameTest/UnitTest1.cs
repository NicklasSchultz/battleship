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
        public void TestMiss()
        {
            Player player1 = new TestPlayer();
            Player player2 = new TestPlayer();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            game.progressGame();
            game.progressGame();

            int didTakeShoot = game.Shoot(0, 1);
            Assert.AreEqual(BoardConstants.miss, didTakeShoot);
        }
        [TestMethod]
        public void TestShootInPlaceBoatsState()
        {
            Player player1 = new TestPlayer();
            Player player2 = new TestPlayer();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            game.progressGame();

            int didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(-1, didTakeShoot);
        }
        [TestMethod]
        public void TestTwoShotsDuringOneTurn()
        {
            Player player1 = new TestPlayer();
            Player player2 = new TestPlayer();
            
            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);
            game.progressGame();
            game.progressGame();
            int didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(BoardConstants.hit, didTakeShoot);
            didTakeShoot = game.Shoot(1, 0);
            Assert.AreEqual(-1, didTakeShoot);
        }
        [TestMethod]
        public void TestValidShot()
        {
            Player player1 = new TestPlayer();
            Player player2 = new TestPlayer();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);

            game.progressGame();
            game.progressGame();

            int didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(BoardConstants.hit, didTakeShoot);
        }
        [TestMethod]
        public void TwoShotsOnSameCoord()
        {
            Player player1 = new TestPlayer();
            Player player2 = new TestPlayer();

            BattleshipBuilder game = new BattleshipBuilder(new ModelHolderImpl(), player1, player2);

            game.progressGame();
            game.progressGame();

            int didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(BoardConstants.hit, didTakeShoot);
            game.progressGame();
            didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(BoardConstants.hit, didTakeShoot);
            game.progressGame();
            didTakeShoot = game.Shoot(0, 0);
            Assert.AreEqual(-1, didTakeShoot);
            game.progressGame();
        }
    }
}
