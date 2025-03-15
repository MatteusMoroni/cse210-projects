using System;


class Program
{
    static void Main(string[] args)
    {
        Resume resume = new Resume("John Doe");
        resume._job.Add(new Job("Software Developer", "Microsoft", 2015, 2018));
        resume._job.Add(new Job("Software Engineer", "Microsoft", 2019, 2022));
        resume._job.Add(new Job("Manager", "Apple", 2022, 2023));
        resume.Display();
    }
}