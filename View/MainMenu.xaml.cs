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

namespace Battleship.View
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : EveneHandler
    {
        public MainMenu()
        {
            InitializeComponent();

        }

        private void StartNewGame(object sender, RoutedEventArgs e)
        {
            var newEventArgs = new RoutedEventArgs(MyCustomEvent);
            RaiseEvent(newEventArgs);
        }

        private void LoadGame(object sender, MouseButtonEventArgs e)
        {

        }
        private void Exit(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
