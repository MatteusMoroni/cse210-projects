public class ActivityRunning : Activity
{
    private double _distance;

    public ActivityRunning(int minutes, double distance) : base(minutes)
    {
        _distance = distance;

    }

    
    public override string GetSummary()
    {
        double speed = CalculateSpeed(_distance);
        double pace = CalculatePace(speed);
        return $"{_date} Running ({_minutes})- Distance {_distance} miles, Speed {speed} mph, Pace: {pace} min per mile";
    }

}