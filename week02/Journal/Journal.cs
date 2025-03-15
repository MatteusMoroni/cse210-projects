using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;
using System.Net.Http;
using System.Threading.Tasks;
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

    public void SaveFile(string folderPath) {
        Console.WriteLine("What would you like to name your file?");
        string fileName = Console.ReadLine();
        fileName = Path.Combine(folderPath, fileName);
        

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

    public async Task LoadFile(string folderPath) {
        
        Console.WriteLine("What file would you like to load?");
        string fileNameImput = Console.ReadLine();
        string fileName = fileNameImput;
        fileName = Path.Combine(folderPath, fileName);
        using HttpClient client = new HttpClient();
        string jsonResponse = await client.GetStringAsync(folderPath);

        if(File.Exists(fileName)) {
            string fileContent = await File.ReadAllTextAsync(fileName);
            List<Entry> entries = JsonConvert.DeserializeObject<List<Entry>>(fileContent);
            _entries = entries;
            Console.WriteLine("File loaded successfully.");

        }
        else {
            Console.WriteLine("File doesn't exists.");
        }
    }
}