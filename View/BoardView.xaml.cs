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

        private UserControl[,] cells = new UserControl[10, 10];
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
                    ((Cell)cells[i, j]).X = i;
                    ((Cell)cells[i, j]).Y = j;
                }
            }

        }
        private void setViewToWater()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cells[i, j].GetType() == typeof(Cell))
                    {
                        ((Cell)cells[i, j]).rectangle.Fill = Brushes.LightBlue;
                    }
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

                Cell g = (Cell)sender;
                int row = g.Y;
                int col = g.X;


                for (int i = 0; i < size; i++)
                {
                    if (cells[col, row].GetType() == typeof(Cell))
                    {
                        if (shipview.Orientation.Equals(Orientation.Horizontal))
                        {
                            int xPos = col + i;
                            if (xPos < 10)
                            {
                                if (cells[col + i, row].GetType() == typeof(Cell))
                                    ((Cell)cells[col + i, row]).rectangle.Fill = Brushes.Aqua;
                            }
                            else
                            {
                                if (cells[col - (xPos - 9), row].GetType() == typeof(Cell))
                                    ((Cell)cells[col - (xPos - 9), row]).rectangle.Fill = Brushes.Aqua;
                            }
                        }
                        else
                        {
                            int yPos = row + i;
                            if (yPos < 10)
                            {
                                if (cells[col, row + i].GetType() == typeof(Cell))
                                    ((Cell)cells[col, row + i]).rectangle.Fill = Brushes.Aqua;
                            }
                            else
                            {
                                if (cells[col, row - (yPos - 9)].GetType() == typeof(Cell))
                                    ((Cell)cells[col, row - (yPos - 9)]).rectangle.Fill = Brushes.Aqua;
                            }
                        }
                    }
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
                        case BoardConstants.ship:
                            c = new ShipView();
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

        private void gridClicked(object sender, MouseButtonEventArgs e)
        {
        }

        public void setMarkedCells()
        {
            int size = shipmenu.Selected.size;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {

                    if (cells[i, j].GetType() == typeof(Cell))
                    {
                        if (((Cell)cells[i, j]).rectangle.Fill == Brushes.Aqua)
                        {
                            ((Cell)cells[i, j]).rectangle.Fill = Brushes.CadetBlue;
                            cells[i, j] = shipmenu.Selected;
                            size--;
                            shipmenu.grid.Children.Remove(shipmenu.Selected);
                            model.addShip(i, j);
                        }
                        if (size == 0)
                        {
                            shipmenu.Selected = null;
                        }
                    }
                }
            }

        }
    }
}
