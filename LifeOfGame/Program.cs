
static void printSet(HashSet<(long, long)> set, (long, long) origin)
{
    for (long y = origin.Item2 - 4; y <= origin.Item2 + 4; y++)
    {
        for (long x = origin.Item1 - 4; x <= origin.Item1 + 4; x++)
        {
            char el = set.Contains((x, y)) ? '0' : '.';
            Console.Write(el);
        }
        Console.Write('\n');
    }
}

static HashSet<(long, long)> iterate(HashSet<(long, long)> old)
{
    HashSet<(long, long)> gen = [];

    long[] range = [2, 3];

    foreach (var pos in old)
    {
        long neighbors = 0;

        for (long i = -1; i <= 1; i++)
        {
            for (long j = -1; j <= 1; j++)
            {
                // TODO van dood naar levend
                (long, long) neighbor = (pos.Item1 + i, pos.Item2 + j);
                if (pos != neighbor && old.Contains(neighbor))
                    neighbors++;
            }
        }

        if (range.Contains(neighbors))
            gen.Add(pos);
    }

    return gen;
}

HashSet<(long, long)> set = [];

string[] line = Console.ReadLine().Split();
long r = long.Parse(line[0]);
long t = long.Parse(line[1]);

(long, long) origin = (long.Parse(line[3]), long.Parse(line[4]));

for (long i = 0; i < r; i++)
{
    line = Console.ReadLine().Split();
    long y = long.Parse(line[0]);
    for (long j = 1; j < line.Length; j++)
        set.Add((
            long.Parse(line[j]),
            y
            ));
}

printSet(set, origin);
for (long i = 0; i < t; i++)
    set = iterate(set);
printSet(set, origin);