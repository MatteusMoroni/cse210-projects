using System;

class Program
{
    static void Main(string[] args)
    {
        Fraction frac = new Fraction(5,10);
        Console.WriteLine(frac.GetFractionString());
        Console.WriteLine(frac.GetDecimalValue());
        frac.UpdateTop(4);
        Console.WriteLine(frac.GetFractionString());

    }
}