public class Activity {
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description) {
        _name = name;
        _description = description;
 
    }

    public void DisplayStartingMessage() {
        Console.WriteLine($"Welcome to the {_name} activity \n");
        Console.WriteLine(_description + "\n");
        Console.WriteLine($"How long, in seconds, would you like for your session?");
        string input = Console.ReadLine();
        int duration = int.Parse(input);
        SetDuration(duration);
        Console.WriteLine($"\n");
        Console.Write($"Get ready... ");
        ShowCountdown(5);
        Console.Write($"\n \n");

    }
    public void SetDuration(int duration) {
        _duration = duration;
    }
    public void ShowSpinner(){
        Console.WriteLine("Loading...");
        for (int i = 0; i < 3; i++) {
            Console.Write(".");
            System.Threading.Thread.Sleep(1000); // Simulate loading time
        }
        Console.WriteLine("\n");
    }

    public void DisplayEndingMessage() {
        Console.WriteLine($"Well done!! \n You have completed another {_duration} seconds of the {_name} activity.");
        ShowSpinner();
    }

    public void ShowCountdown(int seconds) {

        for (int i = seconds; i > 0; i--) {
            Console.Write($"{i}");
            Thread.Sleep(1000); // Simulate countdown time
            Console.Write("\b \b");
        }
    }
}