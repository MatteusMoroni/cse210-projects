using System.Reflection.Metadata;
using System.Text.Json;
using System.Text.Json.Serialization;
public class Goal
{
    [JsonInclude]
    protected string _shortName;
    [JsonInclude]
    protected string _description;
    [JsonInclude]
    protected string _points;

    [JsonConstructor]
    public Goal(string _shortName, string _description, string _points)
    {
        this._shortName = _shortName;
        this._description = _description;
        this._points = _points;

    }

    public virtual void RecordEvent()
    {
     
        Console.WriteLine($"Congratulations you have earned {_points} points");
     
    }


    public virtual bool IsComplete()
    {
       
        return true;
    }

    public virtual string GetShortName()
    {
        return _shortName;
    }

    public string GetPoints()
    {
        return _points;
    }

    public virtual string GetDetailsString()
    {
        if (IsComplete())
        {
            return $"[ X ] {_shortName} ({_description}) - {_points} points";
        }
        return $"[  ] {_shortName} ({_description}) - {_points} points";
    } 

    public virtual Goal GetStringRepresentation()
    {
        return this;
    }


}   