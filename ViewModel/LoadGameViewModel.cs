using Battleship.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Battleship.ViewModel
{
    class LoadGameViewModel : BaseViewModel
    {
        private IList<SavedGame> _names = new List<SavedGame>();

        public IList<SavedGame> Names
        {
            get { return _names; }
            set
            {
                _names = value;
                this.RaisPropertyChangedEvent("Names");
            }
        }

        
        public int SelectedIndex { get; set; }
        public void loadGames()
        {
            using (var db = new GameContext())
            {
                
                IEnumerable games = db.SavedGames.AsEnumerable();
                foreach (var item in games)
                {
                    SavedGame game = item as SavedGame;
                    game.Player1 = (Player) db.Players.Where(s => s.Id == game.Player1ID).First<Player>();
                    game.Player2 = (Player)db.Players.Where(s => s.Id == game.Player2ID).First<Player>();

                    game.Player1.UserBoard = (BoardModel)db.Boards.Where(b => b.Id == game.Player1.UserBoardID).First<BoardModel>();
                    game.Player1.TargetBoard = (BoardModel)db.Boards.Where(b => b.Id == game.Player1.TargetBoardID).First<BoardModel>();
                    game.Player2.UserBoard = (BoardModel)db.Boards.Where(b => b.Id == game.Player2.UserBoardID).First<BoardModel>();
                    game.Player2.TargetBoard = (BoardModel)db.Boards.Where(b => b.Id == game.Player2.TargetBoardID).First<BoardModel>();

                    game.Player1.UserBoard.Model = db.CellValues.Where(c => c.BoardModelID == game.Player1.UserBoardID).ToList<CellValue>();
                    game.Player1.TargetBoard.Model = db.CellValues.Where(c => c.BoardModelID == game.Player1.TargetBoardID).ToList<CellValue>();
                    game.Player2.UserBoard.Model = db.CellValues.Where(c => c.BoardModelID == game.Player2.UserBoardID).ToList<CellValue>();
                    game.Player2.TargetBoard.Model = db.CellValues.Where(c => c.BoardModelID == game.Player2.TargetBoardID).ToList<CellValue>();

                    Names.Add(game);
                }
            }
        }
        public SavedGame getSelectedGame()
        {
            return Names.ElementAt(SelectedIndex);
        }
    }
}
