
using System.ComponentModel.DataAnnotations;

static int Bestelbus(int r, int[] gewichten)
{
    int Ritten(int n)
    {
        int ritten = 0;

        int lading = 0;
        foreach (int gewicht in gewichten)
        {
            if (gewicht > n) break;
            if (gewicht + lading >= n)
            {
                lading = 0;
                ritten++;
            }

            lading += gewicht;
        }
        return ritten;
    }

    int i = 0;
    int j = gewichten.Sum() + 1;

    while (i < j - 1)
    {
        int m = (i + j) / 2;

        int _r = Ritten(m);

        if (_r < r)
            j = m;
        if (_r >= r)
            i = m;
    }

    return i;
}

int r = 5;
int[] weights = [ 7, 8, 10, 9, 1, 3, 5, 4, 2, 6 ];
Console.WriteLine(Bestelbus(r, weights));