using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    public enum Kierunek
    {
        Up,
        Down,
        Left,
        Right
    };
    public class Ustawienia
    {
        public static int Szerokosc { get; set; }
        public static int Wysokosc { get; set; }
        public static int Predkosc { get; set; }
        public static int Wynik { get; set; }
        public static int Punkty { get; set; }
        public static bool KoniecGry { get; set; }
        public static Kierunek kierunek { get; set; }
        // dodane zmienne
        public static int MinBonus { get; set; }
        public static int MaxBonus { get; set; }
        public Ustawienia()
        {
            Szerokosc = 20;
            Wysokosc = 20;
            Predkosc = 10;
            Wynik = 0;
            Punkty = 10;
            KoniecGry = false;
            kierunek = Kierunek.Down;
            //
            MinBonus = 0;
            MaxBonus = 3;
        }
    }
  
}
