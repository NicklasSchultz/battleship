﻿using Battleship.Game;
using Battleship.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.ViewModel
{
    public abstract class BaseViewModel : ViewModelHolder
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisPropertyChangedEvent(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }

        public abstract void ModelChanged(BoardModel board);
    }
}
