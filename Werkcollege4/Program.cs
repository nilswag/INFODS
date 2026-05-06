
int binarySearch(int[] arr, int v)
{
    int helper(int i, int j)
    {
        int m = (i + j) / 2;
        if (arr[m] < v) return helper(m, j);
        if (arr[m] > v) return helper(i, m);
        return m;
    }

    return helper(0, arr.Length - 1);
}

int[] arr = [
    0, 1, 2, 3, 6, 7, 8
];
Console.WriteLine(binarySearch(arr, 6));