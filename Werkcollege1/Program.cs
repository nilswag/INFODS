namespace Werkcollege1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Opdracht2();
            Console.WriteLine('\n');
            Opdracht3();
        }

        private static void Opdracht2()
        {
            /*
            Invariant: Huizen[i] != Huizen[j]
            Variant: ?
            */
            static (int, int) ZoekHuisNummer(char[] huizen, int startNr, int eindNr)
            {
                int i = startNr;
                int j = eindNr;

                while (i < j - 1)
                {
                    int m = (i + j) / 2;
                    if (huizen[i] == huizen[m])
                        i = m;
                    else
                        j = m;
                }

                return (i, j);
            }

            char[] huizen = [
                'N',
                'N', 'N', 'N', 'N', 'B', 'B', 'B', 'B', 'B',
                'B'
            ];
            int startNr = 0;
            int eindNr = huizen.Length - 1;

            Console.WriteLine(ZoekHuisNummer(huizen, startNr, eindNr));
            for (int i = startNr; i <= eindNr; i++) Console.Write($"{i} ");
            Console.Write('\n');
            foreach (char c in huizen) Console.Write($"{c} ");
        }

        private static void Opdracht3()
        {
            /*
            Invariant: i <= portie < j
            */
            static int ZoekGrootstePortie(int[] pizzas, int n)
            {
                int i = 1; // minimale portie
                int j = pizzas.Max();
                int x = 0;

                while (i < j - 1)
                {
                    x = (i + j) / 2;

                    int nPorties = 0;
                    foreach (int p in pizzas) nPorties += p / x;

                    if (nPorties >= n)
                        i = x;
                    else
                        j = x;
                }

                return x;
            }

            int[] pizzas = [7, 9];
            int portie = ZoekGrootstePortie(pizzas, 3);
            Console.WriteLine($"Grootste portie: {portie}");
        }
    }
}
