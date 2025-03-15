public class Entry {
   public string _entry;
    public string _date;
    public string _prompt;



    public void GetPrompt() {

        Prompt prompts = new Prompt();
        prompts.AddPromptList("Who was the most interesting person I interacted with today?");
        prompts.AddPromptList("What did I accomplish today?");
        prompts.AddPromptList("What was the best part of my day?");
        prompts.AddPromptList("How did I see the hand of the Lord in my life today?");
        prompts.AddPromptList("What was the strongest emotion I felt today?");
        prompts.AddPromptList("If I had one thing I could do over today, what would it be?");
        
       _prompt = prompts.RamdomPrompt(prompts._prompts);

    }

    public void GetDate() {
        _date = DateTime.Now.ToString("dd/MM/yyyy");
    }

    public void Display() {
        Console.WriteLine(_date);
        Console.WriteLine(_prompt);
        Console.WriteLine(_entry);
    }
}

