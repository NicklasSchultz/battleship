using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship
{
    class GameContext:DbContext
    {
        public DbSet<SavedGame> SavedGames { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<BoardModel> Boards { get; set; }
    }
}
