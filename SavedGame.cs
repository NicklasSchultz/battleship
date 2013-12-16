using Battleship.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
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



        public int Player1ID { get; set; }

        public int Player2ID { get; set; }

        [ForeignKey("Player1ID")]
        public virtual Player Player1 { get; set; }

        [ForeignKey("Player2ID")]
        public virtual Player Player2 { get; set; }

        public SavedGame(String name, Player player1, Player player2)
        {
            this.Name = "name";
            this.Player1 = player1;
            this.Player2 = player2;
        }
        public SavedGame()
        {
        }

        internal void Save()
        {
            using (var db = new GameContext())
            {
                db.SavedGames.Add(this);
                db.Players.Add(Player1);
                db.Players.Add(Player2);
                db.Boards.Add(Player1.UserBoard);
                db.Boards.Add(Player1.TargetBoard);
                db.Boards.Add(Player2.UserBoard);
                db.Boards.Add(Player2.TargetBoard);
                for (int i = 0; i < 100; i++)
                {
                            db.CellValues.Add(Player1.UserBoard.Model.ElementAt(i));
                            db.CellValues.Add(Player1.TargetBoard.Model.ElementAt(i));
                            db.CellValues.Add(Player2.UserBoard.Model.ElementAt(i));
                            db.CellValues.Add(Player2.TargetBoard.Model.ElementAt(i));
                }
                db.SaveChanges();
            }

        }
    }
}
