using System;

class Program
{
    static void DisplayWelcome()
    {
    Console.WriteLine("Hello! Welcome to the program.");
    }

    static string PromptUserName()
    {
        Console.WriteLine("Please enter your name:");
        return Console.ReadLine();
    }
    static int PromptUserNumber ()
    {
        Console.WriteLine("Please enter your favorite number:");
        return int.Parse(Console.ReadLine());
    }

    static string DisplayResult (int number, string Username)
    {
        return $"{Username}, the square of your number is {number}";
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }


    static void Main(string[] args)
    {
        DisplayWelcome();
        string Username = PromptUserName();
        Console.WriteLine($"Hello, {Username}!");
        int UserNumber = PromptUserNumber();
        int SquaredNumber = SquareNumber(UserNumber);
        Console.WriteLine(DisplayResult(SquaredNumber, Username));   


    }
}