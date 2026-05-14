
static void printSet(HashSet<(long, long)> set, (long, long) origin)
{
    for (long y = -2; y <= 2; y++)
    {
        for (long x = -2; x <= 2; x++)
        {
            (long, long) pos = (origin.Item1 + x, origin.Item2 - y);
            char c = set.Contains(pos) ? '0' : '.';
            Console.Write(c);
        }
        Console.WriteLine();
    }
}

static HashSet<(long, long)> iterate(HashSet<(long, long)> oldSet)
{
    bool checkPos((long, long) pos)
    {
        long[] range;
        if (oldSet.Contains(pos))
            range = [2, 3];
        else
            range = [3];

        long n = 0;
        for (long dy = -1; dy <= 1; dy++)
        {
            for (long dx = -1; dx <= 1; dx++)
            {
                long x = pos.Item1 + dx;
                long y = pos.Item2 + dy;

                if ((x, y) == pos) continue;
                if (oldSet.Contains((x, y))) n++;
            }
        }

        return range.Contains(n);
    }

    HashSet<(long, long)> newSet = [];
    foreach (var p in oldSet)
    {
        for (long dy = -1; dy <= 1; dy++)
        {
            for (long dx = -1; dx <= 1; dx++)
            {
                long x = p.Item1 + dx;
                long y = p.Item2 + dy;

                if (checkPos((x, y))) newSet.Add((x, y));
            }
        }
    }

    return newSet;
}

static string[] splitInput()
{
    return Console.ReadLine().Split([' '], StringSplitOptions.RemoveEmptyEntries);
}

HashSet<(long, long)> set = [];

string[] line = splitInput();
long r = long.Parse(line[0]);
long t = long.Parse(line[1]);

(long, long) origin = (long.Parse(line[3]), long.Parse(line[4]));

for (long i = 0; i < r; i++)
{
    line = splitInput();
    long y = long.Parse(line[0]);
    for (long j = 1; j < line.Length; j++)
        set.Add((
            long.Parse(line[j]),
            y
            ));
}

for (long i = 0; i < t; i++)
{
    set = iterate(set);
    printSet(set, origin);
    Console.WriteLine();
}