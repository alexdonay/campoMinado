using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace campoMinado
{
    public class Square
    {
        public  int i {get; set;}
        public  int y {get; set;}
        public  Boolean bomb { get; set; }
        public int quantBombs { get; set; }
        public Square cima { get; set; }
        public Square direira { get; set; }
        public Square baixo { get; set; }
        public Square esquarda { get; set; }
        public Square cimaDireita { get; set; }
        public Square cimaEsquerda { get; set; }
        public Square baixoDireita { get; set; }
        public Square baixoEsquerda { get; set; }
        public Square(int i, int y)
        {
            this.i = i;
            this.y = y;
        }

        public override string ToString()
        {
            return $"i:  {i}  y: {y}" ;
        }
    }
}
