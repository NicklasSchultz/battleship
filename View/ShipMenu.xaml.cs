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

namespace Battleship.View
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class ShipMenu : UserControl
    {

        private List<ShipView> ships = new List<ShipView>();
        private ShipView shipview;

        public ShipMenu()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ships.Add(new ShipView(4));
            ships.Add(new ShipView(3));
            ships.Add(new ShipView(5));
            ships.Add(new ShipView(2));

            int row = 0;
            foreach (ShipView s in ships)
            {
                Grid.SetRow(s,row);
                Grid.SetColumn(s,0);
                Grid.SetColumnSpan(s, s.size);
                s.MouseLeftButtonDown += new MouseButtonEventHandler(shipSelected);
                grid.Children.Add(s);
                row++;
            }
        }

        private void shipSelected(object sender, MouseButtonEventArgs e)
        {
            ((ShipView)sender).shipRec.StrokeThickness = 5;
            ((ShipView)sender).shipRec.Stroke = Brushes.Blue;
            Selected = ((ShipView)sender);
        }

        public ShipView Selected
        {
            get { return shipview; }
            set {
                if (shipview != null)
                {
                    shipview.shipRec.Stroke = Brushes.Black;
                    shipview.shipRec.StrokeThickness = 1;
                }
                shipview = value;
                shipview.shipRec.StrokeThickness = 5;
                shipview.shipRec.Stroke = Brushes.Blue;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //BUBBLE blubb
        }

        private void Rotate(object sender, RoutedEventArgs e)
        {
            Selected.Orientation = Selected.Orientation.Equals(Orientation.Horizontal) ? Orientation.Vertical : Orientation.Horizontal;
        }

        
    }
}
