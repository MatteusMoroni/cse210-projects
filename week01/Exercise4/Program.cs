using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        int number = -1;
        List<int> numbers = new List<int>();

        while (number != 0) {

            Console.WriteLine("Enter number:");
            string userInput = Console.ReadLine();
            number = int.Parse(userInput);

            if (number == 0) { 
                break; 
            }            
            
            numbers.Add(number);

        }
        
        int sum = 0;
        int numberListSize = numbers.Count;
        

        foreach (var item in numbers)
        {
            sum += item;    
        }
        
        float average = ((float)sum) / numberListSize;

        float largest  = 0;

        foreach (var item in numbers)
        {
            if (item > largest) {
                largest = item;
            }    
        }

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"size: {numberListSize}");

    }
}