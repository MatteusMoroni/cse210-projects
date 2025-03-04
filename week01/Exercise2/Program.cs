using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("What is your grade percentage?");
        string letter = "";
        string message = "";
        string userInput = Console.ReadLine();
        int grade = int.Parse(userInput);
        if (grade >= 90)
        {
            letter = "A";
            message = "Congratulations! You passed!";

        }
        else if (grade >= 80)
        {
            letter = "B";
            message = "Congratulations! You passed!";;
        }
        else if (grade >= 70)
        {
            letter = "C";
            message = "Congratulations! You passed!";
        }
        else if (grade >= 60)
        {
            letter = "D";
            message = "Sorry, You not passed. Try again next time!";
        }
        else
        {
            Console.WriteLine("You got an F!");
            Console.WriteLine("Sorry, You not passed. Try again next time!");
        }

        Console.WriteLine($"Your grade is {letter}.");
        Console.WriteLine(message);
    }
}