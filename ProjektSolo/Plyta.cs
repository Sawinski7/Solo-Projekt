using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjektSolo
{
    public class Plyta
    {
        public string tytul;
        public string typ;
        public string czasTrwania;
        public List<Utwor> utwory;
        public string wykonawcy;
        public int id;

        public Plyta(string tytulPlyty, string typPlyty, string czasTrwaniaPlyty, List<Utwor> utworyPlyty, string wykonawcyPlyty, int idPlyty)
        {
            tytul = tytulPlyty;
            typ = typPlyty;
            czasTrwania = czasTrwaniaPlyty;
            utwory = utworyPlyty;
            wykonawcy = wykonawcyPlyty;
            id = idPlyty;
        }

        public class Utwor
        {
            public string tytul;
            public string czasTrwania;
            public string wykonawcy;
            public string kompozytor;
            public int id;

            public Utwor(string tytulUtworu, string czasTrwaniaUtworu, string wykonawcyUtworu, string kompozytorUtworu, int idUtworu)
            {
                tytul = tytulUtworu;
                czasTrwania = czasTrwaniaUtworu;
                wykonawcy = wykonawcyUtworu;
                kompozytor = kompozytorUtworu;
                id = idUtworu;
            }
        }
    }
}
