using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public class ModelHolderImpl:ModelHolder
    {
        public BoardModel Model { get; set; }
        public void modelChanged(BoardModel model)
        {
            Model = model;
        }
    }
}
