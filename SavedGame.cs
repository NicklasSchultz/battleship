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
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }

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
                db.SaveChanges();
            }

        }
    }
}
