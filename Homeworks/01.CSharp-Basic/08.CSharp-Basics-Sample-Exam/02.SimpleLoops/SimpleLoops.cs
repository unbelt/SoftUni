using System;
using System.Numerics;

class SimpleLoops
{
    static void Main()
    {
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());

        decimal tn = decimal.Parse(Console.ReadLine());

        if (tn == 1)
        {
            Console.WriteLine(t1);
        }
        else if (tn == 2)
        {
            Console.WriteLine(t2);
        }
        else if (tn == 3)
        {
            Console.WriteLine(t3);
        }
        else
        {
            BigInteger result = 0;

            for (int i = 3; i < tn; i++)
            {
                result = t1 + t2 + t3;
                t1 = t2;
                t2 = t3;
                t3 = result;
            }

            Console.WriteLine(result);
        }
    }
}