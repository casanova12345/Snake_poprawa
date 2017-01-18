using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Wonsz : Kolo
    {
        // dodana cała klasa
        private List<Kolo> wonsz = new List<Kolo>();
        public Wonsz() : base() { }
        public Wonsz(int X, int Y) : base(X, Y) { }

        public void DodajGloweWonsza(int X, int Y)
        {
            this.wonsz.Add( new Wonsz(X, Y));
        }

        public int GdzieX(int i)
        {
            return wonsz[i].X;
        }

        public int GdzieY(int i)
        {
            return wonsz[i].Y;
        }

        public void UstawCzescWonsza(int X, int Y, int czesc)
        {
            this.wonsz[czesc].UstawWsp(X, Y);
        }

        public void PrzesunWonsza(int czesc)
        {
            wonsz[czesc].UstawWsp(wonsz[czesc-1].X, wonsz[czesc-1].Y);
        }

        public void ZwiekszWonsza()
        {
            wonsz.Add(new Wonsz(wonsz[wonsz.Count - 1].X, wonsz[wonsz.Count - 1].Y));
        }


        public int JakDlugiWonsz()
        {
            return wonsz.Count;
        }

        public void UsunWonsza()
        {
            this.wonsz.Clear();
        }
    }
}
