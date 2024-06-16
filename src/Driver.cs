namespace RentalSystem;

public class Driver
{
    public string Name { get; init; }
    public int Age { get; init; }
    public int Experience { get; init; }

    public Driver(string name, int age, int experience)
    {
        Name = name;
        Age = age;
        Experience = experience;
    }
}
