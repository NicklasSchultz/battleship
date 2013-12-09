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
        BoardViewModel model;
        private Destroyer destroyer;
        private AirCraftCarrier airCraftCarrier;
        private Submarine submarine;
        private PatrolBoat patrolBoat;

        public BoardView()
        {


            InitializeComponent();

        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            model = this.DataContext as BoardViewModel;
            model.PropertyChanged += new PropertyChangedEventHandler(boardChange);

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
        }

        private void boardChange(object sender, PropertyChangedEventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    UserControl c = new Cell();
                    switch (model.Board.Model[i, j])
                    {
                        case BoardConstants.water:
                            c = new Cell();
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
                        case BoardConstants.airCraftCarrier:
                            c = airCraftCarrier;
                            Grid.SetRow(c, airCraftCarrier.startY);
                            Grid.SetColumn(c, airCraftCarrier.startX);
                            if (airCraftCarrier.Orientation.Equals(Orientation.Horizontal))
                            {
                                Grid.SetColumnSpan(c, airCraftCarrier.Size);
                            }
                            else
                                Grid.SetRowSpan(c, airCraftCarrier.Size);
                            break;
                        case BoardConstants.destroyer:
                            c = destroyer;
                            Grid.SetRow(c, destroyer.startY);
                            Grid.SetColumn(c, destroyer.startX);
                            if (destroyer.Orientation.Equals(Orientation.Horizontal))
                            {
                                Grid.SetColumnSpan(c, destroyer.Size);
                            }
                            else
                                Grid.SetRowSpan(c, destroyer.Size);
                            break;
                        case BoardConstants.patrolBoat:
                            c = patrolBoat;
                            Grid.SetRow(c, patrolBoat.startY);
                            Grid.SetColumn(c, patrolBoat.startX);
                            if (patrolBoat.Orientation.Equals(Orientation.Horizontal))
                            {
                                Grid.SetColumnSpan(c, patrolBoat.Size);
                            }
                            else
                                Grid.SetRowSpan(c, patrolBoat.Size);
                            break;
                        case BoardConstants.submarine:
                            c = submarine;
                            Grid.SetRow(c, submarine.startY);
                            Grid.SetColumn(c, submarine.startX);
                            if (submarine.Orientation.Equals(Orientation.Horizontal))
                            {
                                Grid.SetColumnSpan(c, submarine.Size);
                            }
                            else
                                Grid.SetRowSpan(c, submarine.Size);
                            break;
                        default:
                            break;
                    }
                    if (VisualTreeHelper.GetParent(c) != null)
                    {
                        ((Grid)VisualTreeHelper.GetParent(c)).Children.Remove(c);
                    }
                    mainGrid.Children.Add(c);
                }
            }
        }

        private void panel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                if (e.KeyStates == DragDropKeyStates.ControlKey)
                {
                    e.Effects = DragDropEffects.Copy;
                }
                else
                {
                    e.Effects = DragDropEffects.Move;
                }
            }
        }

        private void panel_Drop(object sender, DragEventArgs e)
        {
            if (e.Handled == false)
            {
                Point pos = e.GetPosition(this);
                int column = (int)((pos.X / mainGrid.ActualWidth) * 10);
                int row = (int)((pos.Y / mainGrid.ActualHeight) * 10);
                int size = (int)e.Data.GetData("Size");
                UIElement _element = (UIElement)e.Data.GetData("Object");
                Ship ship = (Ship)_element;
                setBoat(ship);
                int[] x = new int[size];
                int[] y = new int[size];
                Grid g = (Grid)VisualTreeHelper.GetParent(_element);
                g.Children.Remove(ship);

                ship.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(flipBoat);

                if (orientation.Equals(Orientation.Horizontal))
                {
                    ship.Orientation = Orientation.Horizontal;
                    for (int i = 0; i < size; i++)
                    {
                        x[i] = column + i;
                        y[i] = row;
                    }
                }
                else
                {
                    ship.Orientation = Orientation.Vertical;
                    for (int i = 0; i < size; i++)
                    {
                        x[i] = column;
                        y[i] = row + i;
                    }
                }
                ship.startX = column;
                ship.startY = row;
                ship.Size = size;
                ship.Orientation = orientation;
                model.addShip(x, y, ship);
            }
        }

        public void setBoat(Ship o)
        {
            if (o.GetType() == typeof(PatrolBoat))
            {
                patrolBoat = (PatrolBoat)o;
            }
            if (o.GetType() == typeof(Submarine))
            {
                submarine = (Submarine)o;
            }
            if (o.GetType() == typeof(AirCraftCarrier))
            {
                airCraftCarrier = (AirCraftCarrier)o;
            }
            if (o.GetType() == typeof(Destroyer))
            {
                destroyer = (Destroyer)o;
            }
        }

        private void flipBoat(object o, MouseButtonEventArgs a)
        {
            if (orientation.Equals(Orientation.Vertical))
            {
                orientation = Orientation.Horizontal;
            }
            else
            {
                orientation = Orientation.Vertical;
            }
        }

        private void gridClicked(object sender, MouseButtonEventArgs e)
        {
        }
    }
}
