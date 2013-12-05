using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using Battleship.Model;

namespace Battleship.Game
{
    public interface ViewModelHolder : INotifyPropertyChanged
    {
        void ModelChanged(BoardModel board);
    }
}
