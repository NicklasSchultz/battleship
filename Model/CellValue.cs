using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Model
{
    public class CellValue
    {
        public int id { get; set; }
        public int _x;
        public int _y;
        public int _value;
        public int BoardModelID { get; set; }
        [ForeignKey("BoardModelID")]
        public virtual BoardModel bm { get; set; }

        public int X
        {
            get { return _x; }
            set { _x = value; }
        }
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }
        public int Value
        {
            get { return _value; }
            set { _value = value; }
        }

        public CellValue(int x, int y, int value)
        {
            X = x;
            Y = y;
            Value = value;
        }

        public CellValue() { }
    }
}
