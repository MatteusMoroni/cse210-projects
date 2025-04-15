public class ActivitySwiming : Activity
{
 
    private double _swimingLaps;

    public ActivitySwiming ( int minutes, double swimingLaps) : base(minutes)
    {
        _swimingLaps = swimingLaps;

    }


    
    public override string GetSummary()
    {
       double distance = _swimingLaps *  50 / 1000 * 0.62;
       double speed = CalculateSpeed(distance); 
       double pace = CalculatePace(speed);
       
        return $"{_date} Swiming ({_minutes})- Laps {_swimingLaps}, Speed {speed} mph, Pace: {pace} min per mile";
    }



}