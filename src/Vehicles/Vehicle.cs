namespace RentalSystem.Vehicles;

public abstract class Vehicle
{
    public VehicleType Type { get; init; }
    public VehicleModel Model { get; init; }
    public decimal Value { get; init; }
    public abstract decimal DailyCost(int daysRented);
    public abstract decimal DailyInsuranceCost { get; }

    public Vehicle(VehicleType type, string brand, string model, decimal value)
    {
        Type = type;
        Value = value;
        Model = new VehicleModel(brand, model);
    }

    public static Vehicle Create(VehicleType vehicleType, string brand, string model, decimal value, int safetyRating = 1)
        => vehicleType switch
        {
            VehicleType.Car => new Car(brand, model, value, safetyRating),
            VehicleType.Cargovan => new Cargovan(brand, model, value),
            VehicleType.Motorcycle => new Motorcycle(brand, model, value),
            _ => throw new NotImplementedException()
        };
}