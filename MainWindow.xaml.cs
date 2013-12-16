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
        private ShipMenu shipmenu;
        private MainWindowViewModel m;
        private LoadGameView loadGameView;

        private void HandleChildEvent(object sender, RoutedEventArgs e)
        {
            Button b = e.OriginalSource as Button;
            m = this.DataContext as MainWindowViewModel;
            if (b.Name.Equals("new"))
            {
                shipmenu = new ShipMenu();
                bv = new BoardView(shipmenu);
                bvm = bv.DataContext as BoardViewModel;
                m.Menu = shipmenu;
                m.Content = bv;
                builder = new BattleshipBuilder(bvm, new Player(), new Player(), State.PLACE_BOAT_STATE);
            }

            else if (b.Name.Equals("load"))
            {
                loadGameView = new LoadGameView();
                m.Content = loadGameView;
                m.Menu = new LoadGameMenuView();
            }
            else if (b.Name.Equals("next"))
            {
                builder.progressGame();
                if (builder.CurrentState == State.PLACE_BOAT_STATE)
                {
                    shipmenu = new ShipMenu();
                    bv.resetShips(shipmenu);
                    m.Menu = shipmenu;
                }
                else if (builder.CurrentState == State.GAME_STATE)
                {
                    bv.resetBoard();
                    m.Menu = new GameMenu();
                }
                this.Title = builder.getPlayer();

            }
            else if (b.Name.Equals("nextPlayer"))
            {
                builder.progressGame();
                this.Title = builder.getPlayer();
            }
            else if (b.Name.Equals("saveGame"))
            {
                SavedGame save = new SavedGame("title", builder.Player1, builder.Player2);
                save.Save();
            }
            else if (b.Name.Equals("startLoadedGame"))
            {
                LoadGameViewModel loadViewModel = loadGameView.DataContext as LoadGameViewModel;
                SavedGame game = loadViewModel.getSelectedGame();

                if (shipmenu == null)
                {
                    shipmenu = new ShipMenu();
                    bv = new BoardView(shipmenu);
                }
                bvm = bv.DataContext as BoardViewModel;
                m.Menu = new GameMenu();
                m.Content = bv;
               // bvm.modelChanged(game.Player1.TargetBoard);
                builder = new BattleshipBuilder(bvm, game.Player1, game.Player2, State.GAME_STATE);
            }
            else if (b.Name.Equals("exitGame"))
            {
                m.Content = null;
                m.Menu = new MainMenu();
            }
            else if (b.Name.Equals("goBack")) { }
            e.Handled = true;
        }

        private void gridClicked(object sender, MouseButtonEventArgs e)
        {
            Rectangle r = e.OriginalSource as Rectangle;
            if (r != null && r.Name.Equals("rectangle") && r.Fill != Brushes.CadetBlue)
            {
                if (builder.CurrentState == State.GAME_STATE)
                {
                    Point pos = e.GetPosition(this);
                    int column = (int)((pos.X / bv.mainGrid.ActualWidth) * 10);
                    int row = (int)((pos.Y / bv.mainGrid.ActualHeight) * 10);
                    if (builder.Shoot(column, row) != -1)
                    {
                        //shoot ok
                    }
                }
                else
                {
                    if (builder.CurrentState == State.PLACE_BOAT_STATE && shipmenu.Selected != null)
                    {
                        bv.setMarkedCells();
                    }
                }
            }
        }
    }
}
