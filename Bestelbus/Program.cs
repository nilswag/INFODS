
static long Bestelbus(long r, long[] gewichten)
{
    long Ritten(long n)
    {
        long ritten = 0;

        long lading = 0;
        foreach (long gewicht in gewichten)
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

    long i = 0;
    long j = gewichten.Sum() + 1;

    while (i < j - 1)
    {
        long m = (i + j) / 2;

        long _r = Ritten(m);

        if (_r < r)
            j = m;
        if (_r >= r)
            i = m;
    }

    return i;
}

string[] line = Console.ReadLine().Split();
long n = long.Parse(line[0]);
long r = long.Parse(line[1]);

long[] arr = new long[n];

long i = 0;
while (i < n)
{
    line = Console.ReadLine().Split();
    foreach (string str in line)
    {
        arr[i++] = long.Parse(str);
        if (i == n) break;
    }
}
    

Console.WriteLine(Bestelbus(r, arr));