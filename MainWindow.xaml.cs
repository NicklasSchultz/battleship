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

        private BoardViewModel bvm;
        private BattleshipBuilder builder;
        private BoardView bv;
        private void HandleChildEvent(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            MainWindowViewModel m = this.DataContext as MainWindowViewModel;

            
            if (b.Name.Equals("new"))
            {
                bv = new BoardView();
                bvm = bv.DataContext as BoardViewModel;
                m.Menu = new ShipMenu();
                m.Content = bv;
                builder = new BattleshipBuilder(bvm, new Player(), new Player());
                bvm.SomethingHappened += builder.startGame;

            }

            else if (b.Name.Equals("load"))
            {
                menu.Content = new MainMenu();
            }
            else if (b.Name.Equals("next"))
            {
                bvm.DoSomething();   
            }
            e.Handled = true;
        }
        private void gridClicked(object sender, MouseButtonEventArgs e) {
            Point pos = e.GetPosition(this);
            int column = (int)((pos.X / bv.mainGrid.ActualWidth) * 10);
            int row = (int)((pos.Y / bv.mainGrid.ActualHeight) * 10);
           // MessageBox.Show("blubb");
            builder.Shoot(column,row);
        }

    }
}
