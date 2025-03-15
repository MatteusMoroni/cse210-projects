public class Resume
{
    public string _name;

    public List<Job> _job = new List<Job>();

    public Resume(string name)
    {
        _name = name;
    }
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine($"Jobs: ");
        foreach (Job job in _job)
        {
            job.Display();
        }
    }
}