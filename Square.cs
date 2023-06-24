using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campoMinado
{
    public class Square
    {
        
        public enum SquareStatus
        {
            Hidden,
            Revealed,
            Flagged
        }
        public  int i {get; set;}
        public  int y {get; set;}
        public  Boolean bomb { get; set; }
        public int quantBombs { get; set; }
        public List<Square> vizinhos { get; set; }
        public SquareStatus status { get; set; }
        public Square(int i, int y)
        {
            this.i = i;
            this.y = y;
        }

        public Square()
        {
        }

        
        public override string ToString()
        {
            return $"i:  {i}  y: {y}" ;
        }
    }
}
