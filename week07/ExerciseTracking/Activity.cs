using System.Dynamic;

public abstract class Activity{
    protected string _date;
    protected int _minutes;
    public Activity( int minutes){
        DateTime date = DateTime.Now;
        _date = date.ToString("dd MMM yyyy");
        _minutes = minutes;
    }

    public abstract string GetSummary();

    

    protected virtual double CalculateSpeed(double distance)
    {
        return (distance / _minutes) * 60; // Speed in mph
    }
    protected virtual double CalculatePace(double distance)
    {
        return  ( _minutes / distance); // Speed in mph
    }

    public double GetDistance(double distance)
    {
        return distance;
    }


}


