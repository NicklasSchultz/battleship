﻿using Battleship.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    interface ModelHolder
    {
       void modelChanged(BoardModel model);
    }
}