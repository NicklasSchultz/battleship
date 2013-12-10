﻿using System;
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
                builder = new BattleshipBuilder(bvm, new Player(), new Player());
            }

            else if (b.Name.Equals("load"))
            {
                menu.Content = new MainMenu();
            }
            else if (b.Name.Equals("next"))
            {
                builder.progressGame();
                if (!builder.BoatsPlaced)
                {
                    shipmenu = new ShipMenu();
                    bv.resetShips(shipmenu);
                    m.Menu = shipmenu;
                } else if (builder.resetBoard){
                    bv.resetBoard();
                }
            }
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
                    if (builder.Shoot(column, row)!=-1)
                    {
                        //shoot ok
                    }
                }
                else
                {
                    if (builder.CurrentState == State.PLACE_BOAT_STATE)
                    {
                        bv.setMarkedCells();
                    }
                }
            }
        }
    }
}
