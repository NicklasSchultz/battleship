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
using Battleship.Board;
using Battleship.Ships;

namespace Battleship
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Field[,] cells = new Field[10,10];
        public MainWindow()
        {
            InitializeComponent();
            CreateShips();
        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Field field = new Field();
                    this.field.Children.Add(field);
                    cells[i,j] = field;    
                }
            }
        }

        private void CreateShips()
        {
            shipView sv = new shipView();
            this.field.Children.Add(sv);
        }
    }
}
