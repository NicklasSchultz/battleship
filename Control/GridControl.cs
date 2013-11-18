using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace Battleship.Control
{
    public class GridControl : Grid
    {
        protected override void OnRender(DrawingContext dc)
        {
                foreach (var rowDefinition in RowDefinitions)
                {
                    dc.DrawLine(new Pen(Brushes.Black, 0.5), new Point(0, rowDefinition.Offset), new Point(ActualWidth, rowDefinition.Offset));
                }

                foreach (var columnDefinition in ColumnDefinitions)
                {
                    dc.DrawLine(new Pen(Brushes.Black, 0.5), new Point(columnDefinition.Offset, 0), new Point(columnDefinition.Offset, ActualHeight));
                }
                dc.DrawRectangle(Brushes.Transparent, new Pen(Brushes.Black, 0.5), new Rect(0, 0, ActualWidth, ActualHeight));
          
            base.OnRender(dc);
        }
        static GridControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(GridControl), new FrameworkPropertyMetadata(typeof(GridControl)));
        }
    }
}
