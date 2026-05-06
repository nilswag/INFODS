
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

string[] line = Console.ReadLine().Split();
int n = Int32.Parse(line[0]);
int r = Int32.Parse(line[1]);

int[] arr = new int[n];

int i = 0;
while (i < n)
{
    line = Console.ReadLine().Split();
    foreach (string str in line)
    {
        arr[i++] = int.Parse(str);
        if (i == n) break;
    }
}
    

Console.WriteLine(Bestelbus(r, arr));