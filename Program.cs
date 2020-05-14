using CurrencyCalculator;
using System;

namespace OBCS_OperatorCastsExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Dollar d = new Dollar(7.36);
            Euro e = new Euro(4.55);

            Dollar d1 = d + d;
            Euro e1 = e + d;

            Console.WriteLine(d1.ToString());
            Console.WriteLine(e1.ToString());
        }
    }
}
