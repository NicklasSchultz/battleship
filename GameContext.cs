using Battleship.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
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
        public DbSet<CellValue> CellValues { get; set; }

        public GameContext()
        {
          //  Database.SetInitializer(new DropCreateDatabaseAlways<GameContext>());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }

}
