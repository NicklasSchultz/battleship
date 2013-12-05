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
                    UserControl c;
                    if (model.Board.Model[i, j] == BoardConstants.water)
                    {
                        c = new Cell();
                    }
                    else if (model.Board.Model[i, j] == BoardConstants.miss)
                    {
                        c = new Miss();
                    }
                    else if(model.Board.Model[i,j] == BoardConstants.hit)
                    {
                        c = new Hit();
                    }
                    else
                    {
                        c = new ShipView();
                    }
                    Grid.SetRow(c, j);
                    Grid.SetColumn(c, i);
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

                int[] x = new int[size];
                int[] y = new int[size];
                Grid g = (Grid)VisualTreeHelper.GetParent(_element);
                

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
                if(model.placementOk(x,y)){
                    model.addShip(x, y, ship);
                    g.Children.Remove(_element);
                }
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
            Point pos = e.GetPosition(this);
            int x = (int)((pos.X / mainGrid.ActualWidth) * 10);
            int y = (int)((pos.Y / mainGrid.ActualHeight) * 10);

            model.coordinateClicked(x, y);
        }
    }
}
