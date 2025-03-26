private const int maxFibonacciNumber = 50;

public long Fibonacci(int n)
{
    if (n >= maxFibonacciNumber)
    {
        throw new System.Exception("Not supported");
    }

    if (n == 0 || n == 1)
    {
        return n;
    }

    return Fibonacci(n - 1) + Fibonacci(n - 2);
}