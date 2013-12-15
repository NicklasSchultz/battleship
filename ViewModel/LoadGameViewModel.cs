using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                    Names.Add(game);
                }
            }
        }
        public SavedGame getSelectedGame()
        {
            System.Windows.Forms.MessageBox.Show("Test " + SelectedIndex);
            return Names.ElementAt(SelectedIndex);
        }
    }
}
