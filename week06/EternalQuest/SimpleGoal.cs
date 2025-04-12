using System.Text.Json;
using System.Text.Json.Serialization;

public class SimpleGoal : Goal
{
    [JsonInclude]
    public bool _isComplete;

    [JsonConstructor]
    public SimpleGoal(string _shortName, string _description, string _points,  bool _isComplete = false) : base(_shortName, _description, _points)
    {
        this._isComplete = _isComplete;
    }
    
    public override void RecordEvent()
    {
        _isComplete = true;
        Console.WriteLine($"Congratulations you have earned {_points} points");
    }
    
    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override Goal GetStringRepresentation()
    {

        return this;
    }
}