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

        private List<Ship> ships = new List<Ship>();

        public ShipMenu()
        {
            InitializeComponent();
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            ships.Add(new AirCraftCarrier());
            ships.Add(new Destroyer());
            ships.Add(new Submarine());
            ships.Add(new PatrolBoat());

            Button button = new Button();
            button.Click += new RoutedEventHandler(Button_Click);
            int row = 0;
            foreach (Ship s in ships)
            {
                Grid.SetRow(s,row);
                Grid.SetColumn(s,0);
                Grid.SetColumnSpan(s, getBoatSize(s));
                grid.Children.Add(s);
                row++;
            }
            Grid.SetColumn(button, 1);
            Grid.SetRow(button,row);
            Grid.SetColumnSpan(button,3);
            grid.Children.Add(button);
            
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("GEJE");
        }
    }
}
