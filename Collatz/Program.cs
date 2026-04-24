
static int Collatz(int i)
{
    static int helper(int i , int n)
    {
        if (i < 1) return 0;
        if (i == 1) return n;
        if (i % 2 == 0) return helper(i / 2, ++n);
        else return helper(i * 3 + 1, ++n);
    }

    return helper(i, 0);
}

(int, int)[] testCases = [
    (15, 17),
    (871, 178),
    (1, 0),
    (22, 15)
];

foreach ((int, int) t in testCases)
{
    int v = Collatz(t.Item1);
    string msg = v == t.Item2 ? 
          $"passed: ({t.Item1}, {t.Item2})" 
        : $"failed: ({t.Item1}, {t.Item2}) with value {v}";
    Console.WriteLine(msg);
}