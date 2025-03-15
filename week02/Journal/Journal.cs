using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
public class Journal {
    public List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry) {
        Console.WriteLine(entry._prompt);
        string entryInput = Console.ReadLine();
        entry._entry = entryInput;
        _entries.Add(entry);
    }

    public void Display() {
        foreach (Entry entry in _entries) {
            entry.Display();
        }
    }

    public void SaveFile() {
        Console.WriteLine("What would you like to name your file?");
        string fileName = Console.ReadLine();
        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        
        

        if(!File.Exists(fileName)) {
            Console.WriteLine("File doesn't exists. Creating....");
            File.Create(fileName).Close();
            Console.WriteLine("Saving ....");
            string jsonString = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON string to file
            File.WriteAllText(fileName, jsonString);
            

        }
        else {
            Console.WriteLine("File already exists. Saving ....");
            string updatedJson = JsonSerializer.Serialize(_entries, new JsonSerializerOptions { WriteIndented = true });

            // Write JSON string to file
            File.WriteAllText(fileName, updatedJson);
        }

    }

    public void LoadFile() {
        
        Console.WriteLine("What file would you like to load?");
        string fileNameImput = Console.ReadLine();
        string fileName = fileNameImput;
        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        

        if(File.Exists(fileName)) {
            string jsonString = File.ReadAllText(fileName);
            List<Entry> entries = JsonConvert.DeserializeObject<List<Entry>>(jsonString);
            _entries = entries;
            Console.WriteLine("File loaded successfully.");

        }
        else {
            Console.WriteLine($"File {fileName} doesn't exists.");
        }
    }
}