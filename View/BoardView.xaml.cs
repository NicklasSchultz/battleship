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
        private Cell[,] cells= new Cell[10,10];
        private Destroyer destroyer;
        private AirCraftCarrier airCraftCarrier;
        private Submarine submarine;
        private ShipMenu shipmenu;
        private PatrolBoat patrolBoat;
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
            model.PropertyChanged += new PropertyChangedEventHandler(boardChange);

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
                    Grid.SetColumn(cells[i,j],i);
                    Grid.SetRow(cells[i, j], j);
                    mainGrid.Children.Add(cells[i,j]);
                }
            }

        }

        private void enter(object sender, MouseEventArgs e)
        {
            shipview = shipmenu.Selected;
            int size = 0;
            if (shipview != null)
            {
                 size = shipview.size;
            }
            Cell g = (Cell)sender;
            g.rectangle.Fill = Brushes.Aqua;
            int row = size % 10;
            int col = size / 10;
            int indez = mainGrid.Children.IndexOf(g);
            for (int i = indez; i < indez + size; i++)
            {
                cells[col, row].rectangle.Fill = Brushes.Aqua;
            }
                
        }
        private void leave(object sender, MouseEventArgs e)
        {
            Cell g = (Cell)sender;
            g.rectangle.Fill = Brushes.LightBlue;
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
                            c.MouseEnter += new MouseEventHandler(enter);
                            c.MouseLeave += new MouseEventHandler(leave);
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
                    mainGrid.Children.Add(c);
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
