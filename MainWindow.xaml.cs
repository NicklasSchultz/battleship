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
        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("start");
        }

        private void LoadGame(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("load");
        }
        private void Exit(object sender, RoutedEventArgs e)
        {

        }
    }
}
