using System;

class Employee
{
	int id;
	public int getId()
	{
		return id;
	}
	public void setId(int id)
	{
		this.id = id;
	}
	public void printEmployeedetails()
	{
        Console.WriteLine($"Id\t:\t{id}");
        Console.WriteLine($"name\t:\t{name}");
        Console.WriteLine($"salary\t:\t{salary}");
        Console.WriteLine($"DateofBirth\t:\t{DateofBirth}");
    }

    public string name { get; set; }

    private double salary; // Backing field to store the actual salary value

    public double Salary
    {
        get
        {
            return salary - (salary * 10 / 100);
        }
        set
        {
            salary = value;
        }
    }

    public DateTime DateofBirth { set; get; }
}
