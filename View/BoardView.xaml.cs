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
using Battleship.View;
using Battleship.ViewModel;
using System.ComponentModel;
using Battleship.Model;

namespace Battleship.View
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {

        public Orientation orientation = Orientation.Horizontal;
        private Cell[,] cells = new Cell[10, 10];
        BoardViewModel model;
        private ShipMenu shipmenu;
        private ShipView shipview;
        public BoardView(ShipMenu shipmenu)
        {

            this.shipmenu = shipmenu;
            InitializeComponent();

        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            model = this.DataContext as BoardViewModel;
            model.PropertyChanged += new PropertyChangedEventHandler(boardChanged);

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j] = new Cell();
                    Grid.SetColumn(cells[i, j], i);
                    Grid.SetRow(cells[i, j], j);
                    mainGrid.Children.Add(cells[i, j]);
                    cells[i, j].X = i;
                    cells[i, j].Y = j;
                }
            }

        }
        private void setViewToWater()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    cells[i, j].rectangle.Fill = Brushes.LightBlue;
                }
            }
        }
        private void enter(object sender, MouseEventArgs e)
        {
            setViewToWater();
            shipview = shipmenu.Selected;
            int size = 0;
            if (shipview != null)
            {
                size = shipview.size;
            }
            Cell g = (Cell)sender;
            g.rectangle.Fill = Brushes.Aqua;
            int row = g.Y;
            int col = g.X;
            for (int i = 0; i < size; i++)
            {
                int xx = col+i;
                if(xx<10)
                    cells[col + i, row].rectangle.Fill = Brushes.Aqua;
                else{
                    cells[col - (xx - 9), row].rectangle.Fill = Brushes.Aqua;
                }
          
            }

        }
        private void boardChanged(object sender, PropertyChangedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    UserControl c = new Cell();

                    switch (model.Board.Model[i, j])
                    {
                        case BoardConstants.water:
                            c = cells[i, j];
                            c.MouseEnter += new MouseEventHandler(enter);
                            Grid.SetRow(c, j);
                            Grid.SetColumn(c, i);
                            break;
                        case BoardConstants.miss:
                            c = new Miss();
                            Grid.SetRow(c, j);
                            Grid.SetColumn(c, i);
                            break;
                        case BoardConstants.hit:
                            c = new Hit();
                            Grid.SetRow(c, j);
                            Grid.SetColumn(c, i);
                            break;
                        default:
                            break;
                    }
                    if (VisualTreeHelper.GetParent(c) == null)
                    {
                        mainGrid.Children.Add(c);
                    }
                    else
                    {
                        ((Grid)VisualTreeHelper.GetParent(c)).Children.Remove(c);
                        mainGrid.Children.Add(c);
                    }
                }
            }
        }

        private void flipBoat(object o, MouseButtonEventArgs a)
        {
            Ship s = (Ship)o;
            orientation = orientation.Equals(Orientation.Vertical) ? Orientation.Horizontal : Orientation.Vertical;
            s.Orientation = orientation;
        }

        private void gridClicked(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
