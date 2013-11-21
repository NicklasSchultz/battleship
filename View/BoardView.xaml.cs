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
using Battleship.View.Ships;
using Battleship.Model;
using Battleship.View;

namespace Battleship.View
{
    /// <summary>
    /// Interaction logic for Board.xaml
    /// </summary>
    public partial class BoardView : UserControl
    {
        public BoardView()
        {
            InitializeComponent();

        }
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);

            for (int i = 0; i < 100; i++)
            {
                var cellView = new CellView();
                this.mainGrid.Children.Add(cellView);
                }
        }
    }
}
