namespace Werkcollege1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Opdracht2();
        }

        static void Opdracht2()
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
    }
}
