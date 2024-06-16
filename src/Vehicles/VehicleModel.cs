namespace RentalSystem.Vehicles;

public class VehicleModel
{
    public string Brand { get; init; }
    public string Model { get; init; }

    public VehicleModel(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    public override string ToString()
        => $"{Brand} {Model}";
}
