using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Battleship.Ships;

namespace Battleship.Board
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {
        public Board()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            PlaceBoats();
            
        }
        public void PlaceBoats()
        {
            Destroyer d = new Destroyer();
            Carrier c = new Carrier();
            Grid.SetColumn(d, 4);
            Grid.SetRow(d, 4);
            Grid.SetColumnSpan(d, 4);
            Grid.SetColumn(c, 2);
            Grid.SetRow(c, 6);
            Grid.SetColumnSpan(c, 5);
            mainGrid.Children.Add(d);
            mainGrid.Children.Add(c);
        }
    }
}
