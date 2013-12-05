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
using Battleship.Game;

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
            Button b = e.OriginalSource as Button;
            MainWindowViewModel m = this.DataContext as MainWindowViewModel;

            if (b.Name.Equals("new"))
            {
                BoardView bv = new BoardView();
                BoardViewModel bvm = bv.DataContext as BoardViewModel;
                m.Menu = new ShipMenu();
                m.Content = bv;
            }
            else if (b.Name.Equals("next"))
            {
                
            }
            else if (b.Name.Equals("load"))
            {
                menu.Content = new MainMenu();
            }
            e.Handled = true;
        }
    }
}
