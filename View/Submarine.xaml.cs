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
    /// Interaction logic for Submarine.xaml
    /// </summary>
    public partial class Submarine : Ship
    {
        private int size;
        private int starty;
        private int startx;
        private Orientation orientation;

        public Submarine()
        {
            size = 3;
            InitializeComponent();
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Package the data.
                DataObject data = new DataObject();
                data.SetData(sub);
                data.SetData("Object", this);
                data.SetData("Size", 3);

                // Inititate the drag-and-drop operation.
                DragDrop.DoDragDrop(this, data, DragDropEffects.Copy | DragDropEffects.Move);
                
            }
        }
        public override int startX
        {
            get
            {
                return startx;
            }
            set
            {
                startx = value;
            }
        }

        public override int startY
        {
            get
            {
                return starty;
            }
            set
            {
                starty = value;
            }
        }

        public override Orientation Orientation
        {
            get
            {
                return orientation;
            }
            set
            {
                orientation = value;
            }
        }

        public override int Size
        {
            get
            {
                return size;
            }
            set
            {
                size = value;
            }
        }
    }
}
