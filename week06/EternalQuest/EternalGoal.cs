using System.Text.Json;
using System.Text.Json.Serialization;

public class EternalGoal : Goal
{
    [JsonInclude]
    private int _timesCompleted;

    [JsonConstructor]
    public EternalGoal(string _shortName, string _description, string _points, int _timesCompleted = 0) : base(_shortName, _description, _points)
    {

        this._timesCompleted = _timesCompleted;
    }
    
    
    public override void RecordEvent()
    {
        _timesCompleted++;
        Console.WriteLine($"Congratulations you have earned {_points} points. You have completed this goal {_timesCompleted} times.");
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetDetailsString()
    {
        return $"[  ] {_shortName} ({_description}) - {_points} points (Completed: {_timesCompleted})";
    } 
    
    public override Goal GetStringRepresentation()
    {

        return this;
    }
}