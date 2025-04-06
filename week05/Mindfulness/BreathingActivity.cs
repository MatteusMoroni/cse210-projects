public class BreathingActivity : Activity
{


    public BreathingActivity(string name, string description) : base(name, description)
    {
        _name = name;
        _description = description;

    }

    public void Run() {
        DisplayStartingMessage();
        int duration = _duration;
        do {
            Console.Write($"Breathe in... ");
            ShowCountdown(4);
            Console.Write($"\n");
            Console.Write("Now, Breathe out... ");
            ShowCountdown(6);
            Console.Write($"\n \n");
            
            duration -= 10; // 4 + 6 = 10 seconds for each cycle
        } while (duration > 0);
        Console.WriteLine($"Well done!! \n You have completed another {_duration} seconds of the {_name} activity.");
    }
    


}