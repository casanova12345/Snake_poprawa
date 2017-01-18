using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;

namespace Snake
{
    class Wprowadzanie
    {
        private static Hashtable Przyciski = new Hashtable();

        public static bool Klawisze(Keys klawisz)
        {
            if (Przyciski[klawisz] == null)
            {
                return false;
            }

            return (bool)Przyciski[klawisz];
        }

        public static void ZmianaStatusu(Keys klawisz, bool status)
        {
            Przyciski[klawisz] = status;
        }
    }
}
