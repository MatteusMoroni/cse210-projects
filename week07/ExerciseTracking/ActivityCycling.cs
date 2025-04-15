public class ActivityCycling : Activity
{
    private double _speed;


    public ActivityCycling( int minutes, double distance) : base(minutes)
    {
        _speed = CalculateSpeed(distance); // Initialize speed to 0	


    }

    
    public override string GetSummary()
    {
        double distance =  (_speed * _minutes) * 60;
        double pace = CalculatePace(distance);
        return $"{_date} Cycling ({_minutes})- Distance {distance} miles, Speed {_speed} mph, Pace: {pace} min per mile";
    }



}