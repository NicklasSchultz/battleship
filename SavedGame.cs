using Battleship.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    public class SavedGame
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

        public SavedGame(String name, Player player1, Player player2)
        {
            this.Name = name;
            this.Player1 = player1;
            this.Player2 = player2;
        }

        internal void Save()
        {
            DBGame game = new DBGame();
            DBPlayer dbPlayer1 = new DBPlayer();
            DBPlayer dbPlayer2 = new DBPlayer();
            dbPlayer1.UserBoard = boardToDBBoard(Player1.UserBoard);
            Model1Container model = new Model1Container();
            model.DBGameSet.Add(game);

        }

        private DBBoard boardToDBBoard(BoardModel board)
        {
            DBBoard dbBoard = new DBBoard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DBBoardConstant constant = new DBBoardConstant();
                    constant.X = i;
                    constant.Y = j;
                    constant.Constant = board.Model[i, j];
                    dbBoard.DBBoardConstant.Add(constant);
                }
            }
            return dbBoard;
        }
    }
}
