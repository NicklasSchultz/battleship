using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Battleship.View
{
   public class EveneHandler : UserControl
    {
        public static readonly RoutedEvent MyCustomEvent = EventManager.RegisterRoutedEvent(
        "MyCustom",
        RoutingStrategy.Bubble,
        typeof(RoutedEventHandler),
        typeof(EveneHandler));
        public event RoutedEventHandler MyCustom
        {
            add { AddHandler(MyCustomEvent, value); }
            remove { RemoveHandler(MyCustomEvent, value); }
        }
    }
}
