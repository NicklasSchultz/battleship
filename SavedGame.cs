using Battleship.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
            String cs = "Data Source = localhost;";
            using (var db = new Model2Container())
            {
                if (db.Database.Exists())
                    MessageBox.Show("tjänare");
                DBGame game = new DBGame();
                DBPlayer dbPlayer1 = new DBPlayer();
                DBPlayer dbPlayer2 = new DBPlayer();
                dbPlayer1.UserBoard = boardToDBBoard(Player1.UserBoard);

                db.DBGameSet.Add(game);
                int i=db.DBGameSet.Count();
                MessageBox.Show("herrrråå" + i);
            }
            
        }

        private DBBoard boardToDBBoard(BoardModel board)
        {
            DBBoard dbBoard = new DBBoard();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    DBBoardValue constant = new DBBoardValue();
                    constant.x = i;
                    constant.y = j;
                    constant.value = board.Model[i, j];
                    dbBoard.BoardValues.Add(constant);
                }
            }
            return dbBoard;
        }
    }
}
