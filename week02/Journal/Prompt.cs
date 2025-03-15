
public class Prompt
{
    public List<string> _prompts = new List<string>();

    public void AddPromptList(string prompt)
    {
        _prompts.Add(prompt);

    }

    public string RamdomPrompt(List<string> prompts)
    {
        Random random = new Random();
        int index = random.Next(prompts.Count);
        string randomPrompt = prompts[index];
        return randomPrompt;
    }

}
