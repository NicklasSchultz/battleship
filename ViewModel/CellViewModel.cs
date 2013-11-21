using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.Model;
using Battleship.ViewModel;

namespace Battleship.ViewModel
{
    public class CellViewModel : BaseViewModel
    {
        private readonly Cell _cell;
        private readonly BoardViewModel _boardViewModel;
        private bool _isMarked;
        private bool _isSelected;

        public CellViewModel(Cell cell, BoardViewModel boardViewModel)
        {
            _cell = cell;
            _boardViewModel = boardViewModel;
        }

        public Content Content { get { return _cell.Content; } }

        public Cell Cell { get { return _cell; } }

        public bool IsMarked
        {
            get { return _isMarked; }
            set
            {
                if (_isMarked != value)
                {
                    _isMarked = value;
                }
            }
        }
       
        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;

                }
            }
        
        }
    }


}
