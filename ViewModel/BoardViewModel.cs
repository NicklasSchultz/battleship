using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Model;
using Battleship.ViewModel;

namespace Battleship.ViewModel
{
    public class BoardViewModel : BaseViewModel
    {

        private Board _board;
        public Board Board { get { return _board; } set { _board = value; RaisPropertyChangedEvent("Board"); } }

        public List<CellViewModel> Cells { get; private set; }

        public BoardViewModel()
        {
            _board = new Board();
            Cells = _board.Cells.Select(cell => new CellViewModel(cell, this)).ToList();
        }
    }
}
