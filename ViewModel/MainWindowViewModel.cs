using Battleship.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Battleship.Model;

namespace Battleship.ViewModel
{
    class MainWindowViewModel:BaseViewModel
    {
        UserControl _menu=new ShipMenu();
        UserControl _content=new BoardView();

        public UserControl Menu { get { return _menu; }
            set { _menu = value;
            RaisPropertyChangedEvent("Menu");
            }
        }
        public UserControl Content
        {
            get {
                return _content; }
            set
            {
                _content = value;
                RaisPropertyChangedEvent("Content");
            }
        }
        public void viewChanged()
        {

        }
    }
}
