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
using Battleship.ViewModel;
using Battleship.View;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
           
            InitializeComponent();


        }
        private void HandleChildEvent(object sender, RoutedEventArgs e)
        {
            Button b=e.OriginalSource as Button;
            if (b.Name.Equals("new"))
            {
                menu.Content = new ShipMenu();
            }
            else if (b.Name.Equals("load"))
            {
                menu.Content = new MainMenu();
            }
            e.Handled = true;
        }
    }
}
