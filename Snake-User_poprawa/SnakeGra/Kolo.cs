using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Kolo
    {
        public int X { get; set; }
        public int Y { get; set; }

        public Kolo()
        {
            X = 0;
            Y = 0;
        }
        // dodany konstruktor i metoda
        public Kolo(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
        public void UstawWsp(int X, int Y)
        {
            this.X = X;
            this.Y = Y;
        }
    }
}
