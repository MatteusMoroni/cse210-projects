using System;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();
 

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}