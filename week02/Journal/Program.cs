using System;

class Program
{
    static void Main(string[] args)
    {
        Entry entry = new Entry();
        entry.GetPrompt();
        entry.GetDate();
        Console.WriteLine(entry._prompt);
        String entryInput = Console.ReadLine();
        entry._entry = entryInput;
        entry.Display();
     
    }
}