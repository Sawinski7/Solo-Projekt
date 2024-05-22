using System.Runtime.CompilerServices;
using ProjektSolo;
using System.IO;

namespace ProjektSolo
{
    internal class Program
    {
        public static List<Plyta.Utwor> listaUtworow = new List<Plyta.Utwor>();
        public static List<Plyta> listaPlyt = new List<Plyta>();

        static void Main(string[] args)
        {
            int wybor;

            do
            {
                Console.WriteLine("Menadżer zbioru płyt");
                Console.WriteLine("1. Dodaj płytę");
                Console.WriteLine("2. Wyświetl wszystkie płyty");
                Console.WriteLine("3. Wyświetl szczegółowe informacje na temat wybranej płyty");
                Console.WriteLine("4. Wyświetl wykonawców wykonujących utwory na danej płycie");
                Console.WriteLine("5. Wyświetl szczegóły na temat wybranego utworu");
                Console.WriteLine("6. Zapisz całość do pliku");
                Console.WriteLine("7. Odczytaj całość z pliku");
                Console.WriteLine("8. Zakończ");
                wybor = Convert.ToInt32(Console.ReadLine());

                if(wybor == 1)
                {
                    DodajPlyte();
                }
                else if(wybor == 2)
                {
                    WyswietlPlyty();
                }
                else if(wybor == 3)
                {
                    WyswietlSzczegolPlyty();
                }
                else if(wybor == 4)
                {
                    WyswietlWykonawcow();
                }
                else if(wybor == 5)
                {
                    WyswietlSzczegolUtworu();
                }
                else if(wybor == 6)
                {
                    Zapis();
                }
                else if (wybor == 7)
                {
                    Odczyt();
                }
            }
            while(wybor != 8);
        }

        static void DodajPlyte()
        {
            Console.Clear();
            Console.Write("Podaj tytuł płyty: ");
            string tytul = Console.ReadLine();
            Console.Write("Podaj typ płyty: ");
            string typ = Console.ReadLine().ToUpper();
            Console.Write("Podaj czas trwania płyty: ");
            string czasTrwania = Console.ReadLine();

            while (true)
            {
                Console.Write("Czy chcesz dodać utwór? (t/n)");
                string wyb = Console.ReadLine().ToLower();

                if(wyb == "n")
                {
                    break;
                }
                else if(wyb == "t")
                {
                    Console.Write("Podaj tytuł utworu: ");
                    string tytUtworu = Console.ReadLine();
                    Console.Write("Podaj czas trwania utworu: ");
                    string czasUtworu = Console.ReadLine();
                    Console.Write("Podaj wykonawców utworu: ");
                    string wykUtworu = Console.ReadLine();
                    Console.Write("Podaj kompozytora utworu: ");
                    string komUtworu = Console.ReadLine();
                    Console.Write("Podaj numer utworu: ");
                    int nUtworu = Convert.ToInt32(Console.ReadLine());

                    Plyta.Utwor nowyUtwor = new Plyta.Utwor(tytUtworu, czasUtworu, wykUtworu, komUtworu, nUtworu);
                    listaUtworow.Add(nowyUtwor);
                }
                else
                {
                    Console.WriteLine("Zły klawisz");
                }    
            }

            Console.Write("Podaj wykonawców utworów na płycie: ");
            string wykPlyty = Console.ReadLine();
            Console.Write("Podaj numer płyty: ");
            int nPlyty = Convert.ToInt32(Console.ReadLine());

            Plyta nowaPlyta = new Plyta(tytul, typ, czasTrwania, listaUtworow, wykPlyty, nPlyty);
            listaPlyt.Add(nowaPlyta);
            Console.Clear();
            Console.WriteLine("Dodano płytę\n");
        }

        static void WyswietlPlyty()
        {
            Console.Clear();
            Console.WriteLine("Lista wszystkich płyt:");

            for (int i = 0; i<listaPlyt.Count; i++)
            {
                Console.WriteLine(listaPlyt[i].tytul);
            }
            Console.WriteLine("\n");
        }

        static void WyswietlSzczegolPlyty()
        {
            Console.Clear();
            Console.Write("Podaj numer płyty, w celu wyświetlenie jej szczegółów: ");
            int wyb = Convert.ToInt32(Console.ReadLine()) - 1;

            if(wyb < 0 || wyb >= listaPlyt.Count)
            {
                Console.WriteLine("Podano zły numer płyty");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"Poniżej wyświetlam szczegółowe informacje o płycie {listaPlyt[wyb].tytul}");
                Console.WriteLine($"Tytuł płyty: {listaPlyt[wyb].tytul}");
                Console.WriteLine($"Typ płyty: {listaPlyt[wyb].typ}");
                Console.WriteLine($"Czas trwania płyty: {listaPlyt[wyb].czasTrwania}");
                Console.WriteLine("Utwory znajdujące się na płycie:");
                foreach(var utwor in listaPlyt[wyb].utwory)
                {
                    Console.WriteLine($"{utwor.id}. {utwor.tytul}");
                }
            }
        }
        static void WyswietlWykonawcow()
        {
            Console.Clear();
            Console.Write("Podaj numer płyty, w celu wyświetlenie jej wykonawców: ");
            int wyb = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine($"Lista wszystkich wykonawców utworów na płycie {listaPlyt[wyb].tytul}: {listaPlyt[wyb].wykonawcy}\n");
        }

        static void WyswietlSzczegolUtworu()
        {
            Console.Clear();
            Console.Write("Podaj numer płyty: ");
            int wybPlyty = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Podaj numer utworu: ");
            int wybUtworu = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Clear();
            Console.WriteLine($"Poniżej wyświetlam szczegółowe informacje o utworze {listaPlyt[wybPlyty].utwory[wybUtworu].tytul} z płyty {listaPlyt[wybPlyty].tytul}");
            Console.WriteLine($"Tytuł utworu: {listaPlyt[wybPlyty].utwory[wybUtworu].tytul}");
            Console.WriteLine($"Czas trwania utworu: {listaPlyt[wybPlyty].utwory[wybUtworu].czasTrwania}");
            Console.WriteLine($"Wykonawcy wykonujący utwór: {listaPlyt[wybPlyty].utwory[wybUtworu].wykonawcy}");
            Console.WriteLine($"Kompozytor utworu: {listaPlyt[wybPlyty].utwory[wybUtworu].kompozytor}\n");
        }

        static void Zapis()
        {
            Console.Clear();
            StreamWriter sw = new StreamWriter("Info.txt", true);
            foreach(var plyta in listaPlyt)
            {
                sw.WriteLine($"Tytuł płyty: {plyta.tytul}");
                sw.WriteLine($"Typ płyty: {plyta.typ}");
                sw.WriteLine($"Czas trwania płyty: {plyta.czasTrwania}");
                sw.WriteLine($"Utwory znajdujące się na płycie:");
                foreach (var utwor in plyta.utwory)
                {
                    sw.WriteLine($"Numer utworu: {utwor.id}, Tytuł utworu: {utwor.tytul}, Czas trwania utworu: {utwor.czasTrwania}, Wykonawcy utworu: {utwor.wykonawcy}, Kompozytor utworu: {utwor.kompozytor}");
                }
                sw.WriteLine($"Tytuł płyty: {plyta.wykonawcy}");
                sw.WriteLine($"Numer płyty: {plyta.id}\n");
            }
            sw.Close();
            Console.WriteLine("Dane zostały zapisane do pliku\n");
        }
        static void Odczyt()
        {
            Console.Clear();
            using StreamReader reader = new("Info.txt");
            string text = reader.ReadToEnd();
            Console.WriteLine(text);
        }
    }
}
