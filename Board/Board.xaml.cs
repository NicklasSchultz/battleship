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
using Battleship.Board;

namespace Battleship.Board
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class Board : UserControl
    {

        int current = 2;

        public Board()
        {
            InitializeComponent();

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 100; i++)
            {
                    var r = new Cell();
                    r.SetBinding(DataContextProperty, "[" + i + "]");
                    r.index = i;
                    r.MouseLeftButtonUp += new MouseButtonEventHandler(mouse_click);
                    Grid.SetColumn(r, i%10);
                    Grid.SetRow(r, (int)i/10);
                    mainGrid.Children.Add(r);
                }
            
        }
        private void mouse_click(object sender, EventArgs e)
        {
            var r = (Cell)sender;
            int i = r.index;

            if (current == 2)
            {
                Destroyer d = new Destroyer();
                Grid.SetRow(d, getRow(i));
                Grid.SetColumn(d, getColumn(i));
                Grid.SetColumnSpan(d, d.getSize());
                mainGrid.Children.Add(d);
            }
            else if (current == 1)
            {
                Carrier d = new Carrier();
                Grid.SetRow(d, getRow(i));
                Grid.SetColumn(d, getColumn(i));
                Grid.SetColumnSpan(d, d.getSize());
                mainGrid.Children.Add(d);
            }
            current--;
        }

        private int getColumn(int i)
        {
            return i%10;
        }
        private int getRow(int i)
        {
            return i/10;
        }
    }
}
