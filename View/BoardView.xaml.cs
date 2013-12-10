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

        private Cell[,] cells = new Cell[10, 10];
        BoardViewModel model;
        private ShipMenu shipmenu;
        private ShipControl control = new ShipControl();
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
                    if (cells[i, j].rectangle.Fill != Brushes.CadetBlue)
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

                Cell g = (Cell)sender;
                int row = g.Y;
                int col = g.X;

                List<int> x = new List<int>();
                List<int> y = new List<int>();

                for (int i = 0; i < size; i++)
                {
                    if (shipview.Orientation.Equals(Orientation.Horizontal))
                    {
                        int xPos = col + i;
                        if (xPos < 10)
                        {
                            if (cells[col + i, row].rectangle.Fill != Brushes.CadetBlue)
                            {
                                x.Add(col + i);
                                y.Add(row);
                            }
                        }
                        else
                        {
                            if (cells[col - (xPos - 9), row].rectangle.Fill != Brushes.CadetBlue)
                            {
                                x.Add(col - (xPos - 9));
                                y.Add(row);
                            }
                        }
                    }
                    else
                    {
                        int yPos = row + i;
                        if (yPos < 10)
                        {
                            if (cells[col, row + i].rectangle.Fill != Brushes.CadetBlue)
                            {
                                x.Add(col);
                                y.Add(row + i);
                            }
                        }
                        else
                        {
                            if (cells[col, row - (yPos - 9)].rectangle.Fill != Brushes.CadetBlue)
                            {
                                x.Add(col);
                                y.Add(row - (yPos - 9));
                            }
                        }
                    }
                }
                Brush brush;
                if (control.checkValidPlacement(x.ToArray(), y.ToArray()))
                {
                    brush = Brushes.Aqua;
                }
                else
                {
                    brush = Brushes.Red;
                }
                for (int i = 0; i < x.Count; i++)
                {

                    cells[x.ElementAt(i), y.ElementAt(i)].rectangle.Fill = brush;
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
                            c = cells[i, j];
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
            int count = 0;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (cells[i, j].rectangle.Fill == Brushes.Aqua)
                    {
                        control.setOccupied();
                        Grid parent = ((Grid)VisualTreeHelper.GetParent(shipmenu.Selected));
                        if (parent != null)
                        {
                            parent.Children.Remove(shipmenu.Selected);
                        }
                        cells[i, j].rectangle.Fill = Brushes.CadetBlue;
                        model.addShip(i, j);
                        count++;
                    }
                    if (count == size)
                    {
                        shipmenu.Selected = null;
                    }
                }
            }
        }
    }
}
