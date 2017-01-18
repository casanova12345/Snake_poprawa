using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Snake
{
    public partial class Form1 : Form
    {
        private Wonsz wonsz = new Wonsz();
        private Jadlo amciu = new Jadlo();

        //private List<Kolo> Snake = new List<Kolo>(); //
        //private Kolo jedzenie = new Kolo(); //
        

        public Form1()
        {
            InitializeComponent();
            new Ustawienia();

            Timer.Interval = 1000 / Ustawienia.Predkosc;
            Timer.Tick += Odswiez;
            Timer.Start();

            StartGry();
        }

        private void StartGry()
        {
            lblKoniecGry.Visible = false;

            new Ustawienia();

            
            wonsz.UsunWonsza();
            wonsz.DodajGloweWonsza(10, 5);
            amciu.UstawWielkoscJadla(1);

            //Snake.Clear();
            //Kolo glowa = new Kolo { X = 10, Y = 5 }; //
            //Snake.Add(glowa); //

            lblPunkty2.Text = Ustawienia.Wynik.ToString();
            GenerowanieJedzenia();
        }

        private void GenerowanieJedzenia()
        {
            int maxXPos = plansza.Size.Width / Ustawienia.Szerokosc;
            int maxYPos = plansza.Size.Height / Ustawienia.Wysokosc;
            Random random = new Random();
            amciu.UstawWsp(random.Next(0, maxXPos), random.Next(0, maxYPos));
            
            //jedzenie = new Kolo { X = random.Next(0, maxXPos), Y = random.Next(0, maxYPos) }; //
        }

        private void Odswiez(object sender, EventArgs e)
        {

            if (Ustawienia.KoniecGry)
            {

                if (Wprowadzanie.Klawisze(Keys.Enter))
                {
                    StartGry();
                }
            }
            else
            {
                if (Wprowadzanie.Klawisze(Keys.Right) && Ustawienia.kierunek != Kierunek.Left)
                    Ustawienia.kierunek = Kierunek.Right;
                else if (Wprowadzanie.Klawisze(Keys.Left) && Ustawienia.kierunek != Kierunek.Right)
                    Ustawienia.kierunek = Kierunek.Left;
                else if (Wprowadzanie.Klawisze(Keys.Up) && Ustawienia.kierunek != Kierunek.Down)
                    Ustawienia.kierunek = Kierunek.Up;
                else if (Wprowadzanie.Klawisze(Keys.Down) && Ustawienia.kierunek != Kierunek.Up)
                    Ustawienia.kierunek = Kierunek.Down;
                Ruch();
            }
            plansza.Invalidate();
        }

        private void plansza_Paint(object sender, PaintEventArgs e)
        {
            Graphics plansza = e.Graphics;
            if (!Ustawienia.KoniecGry)
            {
                                    // Snake.Count
                for (int i = 0; i < wonsz.JakDlugiWonsz(); i++)
                {
                    Brush kolorWonsza;
                    if (i == 0)
                        kolorWonsza = Brushes.Black;
                    else
                        kolorWonsza = Brushes.Green;

                    plansza.FillEllipse(kolorWonsza,
                        new Rectangle(wonsz.GdzieX(i) * Ustawienia.Szerokosc,
                                    wonsz.GdzieY(i) * Ustawienia.Wysokosc,
                                    Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                    plansza.FillEllipse(Brushes.Red,
                        new Rectangle(amciu.X * Ustawienia.Szerokosc,
                                    amciu.Y * Ustawienia.Wysokosc,
                                    Ustawienia.Szerokosc, Ustawienia.Wysokosc));

                    //plansza.FillEllipse(kolorWonsza,
                    //    new Rectangle(Snake[i].X * Ustawienia.Szerokosc,
                    //                Snake[i].Y * Ustawienia.Wysokosc,
                    //                Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                    //plansza.FillEllipse(Brushes.Red,
                    //    new Rectangle(jedzenie.X * Ustawienia.Szerokosc,
                    //                 jedzenie.Y * Ustawienia.Wysokosc,
                    //                 Ustawienia.Szerokosc, Ustawienia.Wysokosc));
                }
            }
            else
            {
                string KoniecGry = "Koniec Gry \nTwoje zdobyte punkty: " + Ustawienia.Wynik + "\nNacisnij Enter aby zaczac ponownie";
                lblKoniecGry.Text = KoniecGry;
                lblKoniecGry.Visible = true;
            }
        }
        private void Ruch()
        {

        int maxXPos = plansza.Size.Width / Ustawienia.Szerokosc;
        int maxYPos = plansza.Size.Height / Ustawienia.Wysokosc;
                        // Snake.Count -1
            for (int i = wonsz.JakDlugiWonsz() - 1; i >= 0; i--)
            {
                if (i == 0)
                {
                    int xPom = wonsz.GdzieX(i), yPom = wonsz.GdzieY(i);

                    switch (Ustawienia.kierunek)
                    {
                        case Kierunek.Right:
                            wonsz.UstawCzescWonsza(xPom + 1, yPom, i);
                            //Snake[i].X++;//
                            break;
                        case Kierunek.Left:
                            wonsz.UstawCzescWonsza(xPom - 1, yPom, i);
                            //Snake[i].X--;//
                            break;
                        case Kierunek.Up:
                            wonsz.UstawCzescWonsza(xPom, yPom - 1, i);
                            //Snake[i].Y--;//
                            break;
                        case Kierunek.Down:
                            wonsz.UstawCzescWonsza(xPom, yPom + 1, i);
                            //Snake[i].Y++;//
                            break;
                    }

                    if (wonsz.GdzieX(i) < 0 || wonsz.GdzieY(i) < 0 || wonsz.GdzieX(i) >= maxXPos || wonsz.GdzieY(i) >= maxYPos)
                    {
                        Smierc();
                    }
                    for (int j = 1; j < wonsz.JakDlugiWonsz(); j++)
                    {
                        if (wonsz.GdzieX(i) == wonsz.GdzieX(j) && wonsz.GdzieY(i) == wonsz.GdzieY(j))
                        {
                            Smierc();
                        }
                    }
                    if (wonsz.GdzieX(0) == amciu.X && wonsz.GdzieY(0) == amciu.Y)
                    {
                        Jesc();
                    }
                }
                else
                {
                    wonsz.PrzesunWonsza(i);
                }


                //    if (Snake[i].X < 0 || Snake[i].Y < 0
                //        || Snake[i].X >= maxXPos || Snake[i].Y >= maxYPos)
                //    {
                //        Smierc();
                //    }

                //    for (int j = 1; j < Snake.Count; j++)
                //    {
                //        if (Snake[i].X == Snake[j].X &&
                //           Snake[i].Y == Snake[j].Y)
                //        {
                //            Smierc();
                //        }
                //    }

                //    if (Snake[0].X == jedzenie.X && Snake[0].Y == jedzenie.Y)
                //    {
                //        Jesc();
                //    }
                //}
                //else
                //{
                //    Snake[i].X = Snake[i - 1].X;
                //    Snake[i].Y = Snake[i - 1].Y;
                //}
            }
        }
        private void Jesc()
        {
            wonsz.ZwiekszWonsza();

            //Kolo kolo = new Kolo
            //{
            //    X = Snake[Snake.Count - 1].X,
            //    Y = Snake[Snake.Count - 1].Y
            //};
            //Snake.Add(kolo);

            Random random = new Random();
            amciu.UstawWielkoscJadla(random.Next(Ustawienia.MinBonus,Ustawienia.MaxBonus));

            Ustawienia.Wynik += Ustawienia.Punkty + amciu.JakWielkieJadlo();
            lblPunkty2.Text = Ustawienia.Wynik.ToString();
            GenerowanieJedzenia();
        }


        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            Wprowadzanie.ZmianaStatusu(e.KeyCode, true);
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            Wprowadzanie.ZmianaStatusu(e.KeyCode, false);
        }
        private void Smierc()
        {
            Ustawienia.KoniecGry = true;
        }
    }
}


