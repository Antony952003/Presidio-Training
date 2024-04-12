using System;

public class Doctor
{
    int id;
    public string Name { get; set; }
    public int Age { get; set; }
    public int Experience { get; set; }
    public string Qualification { get; set; }
    public string Speciality { get; set; }

    public Doctor(int id)
    {
        this.id = id;
    }
    public void printDetailsofDoctorofspecifiedspeciality()
    {
        Console.WriteLine();
        Console.WriteLine("________________________________________________");
        Console.WriteLine($"Doctor Id : {id}");
        Console.WriteLine($"Doctor Name : {Name}");
        Console.WriteLine($"Doctor Age : {Age}");
        Console.WriteLine($"Doctor Experience : {Experience}");
        Console.WriteLine($"Doctor Qualification : {Qualification}");
        Console.WriteLine($"Doctor Speciality : {Speciality}");
        Console.WriteLine("________________________________________________");
    }
    
}
