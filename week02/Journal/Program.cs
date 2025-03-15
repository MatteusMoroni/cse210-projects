using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

class Program
{
    static async Task Main(string[] args)
    
    {
        string menuInput = "";
        Journal journal = new Journal();
        
        

        do{
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1. Entry");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. save");
            Console.WriteLine("5. Exit");
            Console.WriteLine("Enter your choice: ");
            menuInput = Console.ReadLine();
            switch (menuInput)
            {
                case "1":
                       
                    journal.AddEntry(new Entry());

                    break;
 

                case "2":
                    journal.Display();
                    break;
      
                case "3":
                    journal.LoadFile();

                    break;
                case "4":
                    journal.SaveFile();
                    break;

                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }

        } while (menuInput != "5");

    }
}