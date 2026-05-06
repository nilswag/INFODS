
static int Collatz(long i)
{
    static int helper(long i , int n)
    {
        if (i < 1) return 1;
        if (i == 1) return n;
        if (i % 2 == 0) return helper(i / 2, ++n);
        else return helper(3 * i + 1, ++n);
    }

    return helper(i, 0);
}

string line;
while ((line = Console.ReadLine()) != "")
    Console.WriteLine(Collatz(long.Parse(line)));