using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text.Json;

public class GoalManager
{
    private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void Start(){
        string option;
        do{
            Console.WriteLine("Welcome to the Goal Manager! \n");
            DisplayPlayerInfo();
            Console.WriteLine();
            Console.WriteLine("Select an option:");
            Console.WriteLine();
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Quit");
    

            Console.Write("Select an option: ");
            option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    CreateGoal();
                    Console.WriteLine();
                    break;
                case "2":
                    ListGoalsDetails();
                    Console.WriteLine();
                    break;
                case "3":
                    SaveGoals();
                    Console.WriteLine();
                    break;
                case "4":
                    LoadGoals();
                    Console.WriteLine();
                    break;
                case "5":
                    RecordEvent();
                    Console.WriteLine();
                    break;
                case "6":
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }            
        } while (option != "6");

    }

    public void DisplayPlayerInfo(){
        Console.WriteLine($"You have {_score} points.");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetShortName()}");
        }
    }

    public void ListGoalsDetails()
    {
        Console.WriteLine("Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal()
    {
        Console.WriteLine();
        Console.WriteLine("Select the type of goal:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select an option: ");
        string input = Console.ReadLine();
        int option = int.Parse(input);
        string points = "0";

        Console.Write("Enter the short name of the goal: ");
        string shortName = Console.ReadLine();

        Console.Write("Enter the description of the goal: ");
        string description = Console.ReadLine();
        

        switch (option)
        {
            case 1:
                Console.Write("Enter the points for the goal: ");
                points = Console.ReadLine();
                _goals.Add(new SimpleGoal(shortName, description, points));
                break;
            case 2:
                _goals.Add(new EternalGoal(shortName, description, "10"));
                break;
            case 3:
                Console.Write("Enter the points for the goal: ");
                points = Console.ReadLine();
                Console.Write("Enter the target number of times to complete this goal: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter the bonus points for completing this goal: ");
                int bonusPoints = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(shortName, description, points, target, bonusPoints));
                break;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }

    public void RecordEvent()
    {
        ListGoalNames();
        Console.Write("Select a goal to record an event: ");
        string input = Console.ReadLine();
        int index = int.Parse(input) - 1;
        if (index >= 0 && index < _goals.Count)
        {
            _goals[index].RecordEvent();
            _score += int.Parse(((Goal)_goals[index]).GetPoints());
            DisplayPlayerInfo();
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }

    public void SaveGoals()
    {
        Console.WriteLine("What would you like to name your file?");
        string fileName = Console.ReadLine();
        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            IncludeFields = true
        };
        options.Converters.Add(new GoalConverter());

        
        string updatedJson = JsonSerializer.Serialize(_goals, options);

        if (!File.Exists(fileName))
        {
            Console.WriteLine("File doesn't exist. Creating....");
            File.Create(fileName).Close();
        }

        Console.WriteLine("Saving ....");
        File.WriteAllText(fileName, updatedJson);
    }



    public void LoadGoals() {
        
        Console.WriteLine("What file would you like to load?");
        string fileNameImput = Console.ReadLine();
        string fileName = fileNameImput;
        fileName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);
        

        if(File.Exists(fileName)) {
            var options = new JsonSerializerOptions
            {
                Converters = { new GoalConverter() },
                IncludeFields = true,
                WriteIndented = true
            };

            string json = File.ReadAllText(fileName);
            List<Goal> loadedGoals = JsonSerializer.Deserialize<List<Goal>>(json, options);
            _goals = loadedGoals;

        }
        else {
            Console.WriteLine($"File {fileName} doesn't exists.");
        }
    }

}