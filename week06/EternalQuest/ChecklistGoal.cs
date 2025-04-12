using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;

public class ChecklistGoal : Goal
{
    [JsonInclude]
    private int _amountCompleted;
    [JsonInclude]
    private int _target;
    [JsonInclude]
    private int _bonusPoints;
    
    [JsonConstructor]
    public ChecklistGoal(string _shortName, string _description, string _points, int _target, int _bonusPoints) : base(_shortName, _description, _points)
    {
        this._amountCompleted = 0; // Initialize with a default value
        this._target = _target;
        this._bonusPoints = _bonusPoints;
    }
    
    public override void RecordEvent()
    {
        if (_amountCompleted < _target)
        {
            _amountCompleted++;
            Console.WriteLine($"Congratulations you have earned {_points} points. You have completed this goal {_amountCompleted} times.");
            if (_amountCompleted == _target)
            {
                Console.WriteLine($"Congratulations! You have earned an additional {_bonusPoints} bonus points!");
            }
        }
        else
        {
            Console.WriteLine("You have already completed this goal the maximum number of times.");
        }
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }

    public override string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[ X ] {_shortName} ({_description}) - {_points} points (Completed: {_amountCompleted}/{_target})";
        }
        return $"[  ] {_shortName} ({_description}) - {_points} points (Completed: {_amountCompleted}/{_target})";
    }

    public override Goal GetStringRepresentation()
    {

        return this;
    }

}