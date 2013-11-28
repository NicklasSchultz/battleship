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

namespace Battleship.View
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {

        public bool donePlaceing = false;
        public Orientation orientation = Orientation.Horizontal;
        public ShipControl control = new ShipControl();

        public BoardView()
        {
            InitializeComponent();

        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 100; i++)
            {
                var cellView = new Cell();
                Grid.SetColumn(cellView, i % 10);
                Grid.SetRow(cellView, i / 10);
                this.mainGrid.Children.Add(cellView);
            }
        }



        private void clickListner(object s, MouseButtonEventArgs a)
        {
            Point pos = a.GetPosition(this);

            int x = (int)((pos.X / mainGrid.ActualWidth) * 10);
            int y = (int)((pos.Y / mainGrid.ActualHeight) * 10);

            UserControl u;
            if (getBoatSize(s) == 0)
            {
                u = new Miss();
            }
            else
            {
                u = new Hit();
            }
            Grid.SetColumn(u, x);
            Grid.SetRow(u, y);
            mainGrid.Children.Add(u);
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
                Grid _grid = (Grid)sender;
                Point pos = e.GetPosition(this);


                int column = (int)((pos.X / mainGrid.ActualWidth) * 10);
                int row = (int)((pos.Y / mainGrid.ActualHeight) * 10);

                UIElement _element = (UIElement)e.Data.GetData("Object");
                int size = (int)e.Data.GetData("Size");

                Ship ship = (Ship)_element;
                ship.startX = column;
                    ship.startY = row;
                    ship.size = size;
                if (control.checkValidPlacement(ship.startY, ship.startX, orientation, size))
                {


                    Grid g = (Grid)VisualTreeHelper.GetParent(_element);
                    g.Children.Remove(_element);

                    Grid.SetColumn(ship, column);
                    Grid.SetRow(ship, row);

                    ship.PreviewMouseLeftButtonUp += new MouseButtonEventHandler(flipBoat);

                    if (orientation.Equals(Orientation.Horizontal))
                    {
                        ship.Orientation = Orientation.Horizontal;
                        Grid.SetColumnSpan(ship, size);
                        Grid.SetRowSpan(ship, 1);

                    }
                    else
                    {
                        ship.Orientation = Orientation.Vertical;
                        Grid.SetRowSpan(ship, size);
                        Grid.SetColumnSpan(ship, 1);
                    }

                    _grid.Children.Add(ship);
                    if (g.Children.Count == 1)
                    {
                        donePlaceing = true;
                    }
                }
            }
        }



        private void flipBoat(object o, MouseButtonEventArgs a)
        {
            if (donePlaceing)
            {
                Point pos = a.GetPosition(this);

                int x = (int)((pos.X / mainGrid.ActualWidth) * 10);
                int y = (int)((pos.Y / mainGrid.ActualHeight) * 10);

                UserControl u;
                if (getBoatSize(o) == 0)
                {
                    u = new Miss();
                }
                else
                {
                    u = new Hit();
                }
                Grid.SetColumn(u, x);
                Grid.SetRow(u, y);
                mainGrid.Children.Add(u);
            }
            else
            {
                Ship u = (Ship)o;
                mainGrid.Children.Remove(u);

                if (orientation.Equals(Orientation.Vertical))
                {
                    Grid.SetColumnSpan(u, getBoatSize(o));
                    Grid.SetRowSpan(u, 1);
                    orientation = Orientation.Horizontal;
                }
                else
                {
                    Grid.SetRowSpan(u, getBoatSize(o));
                    Grid.SetColumnSpan(u, 1);
                    orientation = Orientation.Vertical;
                }
                mainGrid.Children.Add(u);
            }
        }

        private int getBoatSize(object o)
        {
            if (o.GetType() == typeof(PatrolBoat))
            {
                return PatrolBoat.size;
            }
            if (o.GetType() == typeof(Submarine))
            {
                return Submarine.size;
            }
            if (o.GetType() == typeof(AirCraftCarrier))
            {
                return AirCraftCarrier.size;
            }
            if (o.GetType() == typeof(Destroyer))
            {
                return Destroyer.size;
            }
            return 0;
        }

        private void gridClicked(object sender, MouseButtonEventArgs e)
        {
            Point pos = e.GetPosition(this);
            int x = (int)((pos.X / mainGrid.ActualWidth) * 10);
                int y = (int)((pos.Y / mainGrid.ActualHeight) * 10);
            BoardViewModel model = this.DataContext as BoardViewModel;
            model.coordinateClicked(x,y);
        }
    }
}
