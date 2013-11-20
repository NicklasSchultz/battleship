using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Battleship.ViewModels;

namespace Battleship.ViewModels
{
   public class MainWindowViewModel
    {
       public BoardViewModel BoardViewModel { get; set; }

       public MainWindowViewModel(BoardViewModel BoardViewModel)
       {
           this.BoardViewModel = BoardViewModel;
       }       
    }
}
