using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Model;
using Battleship.ViewModels;

namespace Battleship.ViewModels
{
    public sealed class BoardViewModel : MainWindowViewModel
    {

        private readonly Board _board;

        public List<CellViewModel> Cells { get; private set; }

        public BoardViewModel(Board board)
        {
            _board = board;

            Cells = _board.Cells.Select(cell => new CellViewModel(cell, this)).ToList();
        }
    }
}
