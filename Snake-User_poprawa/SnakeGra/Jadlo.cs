using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Jadlo : Kolo
    {
        // dodana cała klasa
        private int wielkoscJadla = 0;
        public Jadlo() : base() { }
        public Jadlo(int X, int Y) : base(X, Y) { }

        public void UstawWielkoscJadla(int punkty)
        {
            this.wielkoscJadla = punkty;
        }
        public int JakWielkieJadlo()
        {
            return this.wielkoscJadla;
        }
    }
}
