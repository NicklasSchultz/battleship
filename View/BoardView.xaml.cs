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

            for (int i = 0; i < 10; i++)
            {
                mainGrid.RowDefinitions.Add(new RowDefinition());
                mainGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < 100; i++)
            {
                    var cellView = new Cell();
                    Grid.SetColumn(cellView, i%10);
                    Grid.SetRow(cellView, i/10);
                    cellView.SetBinding(DataContextProperty, "[" + i + "]");
                   this.mainGrid.Children.Add(cellView);
            }
        }

        private void panel_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("Object"))
            {
                // These Effects values are used in the drag source's 
                // GiveFeedback event handler to determine which cursor to display. 
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
                Grid _grid = (Grid)sender;
                Point pos = e.GetPosition(this);

                int x = (int)((pos.X / mainGrid.ActualWidth) * 10);
                int y = (int)((pos.Y / mainGrid.ActualHeight) * 10);

                UIElement _element = (UIElement)e.Data.GetData("Object");
                UserControl d = (UserControl)_element;
                Grid g = (Grid) VisualTreeHelper.GetParent(_element);
                g.Children.Remove(_element);
                Grid.SetColumn(d, x);
                Grid.SetRow(d, y);
                Grid.SetColumnSpan(d, 3);
                _grid.Children.Add(d);
            }
        }
    }
}
