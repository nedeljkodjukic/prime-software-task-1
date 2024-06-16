namespace RentalSystem.Vehicles;

class Motorcycle : Vehicle
{
    public Motorcycle(string brand, string model, decimal value)
        : base(VehicleType.Motorcycle, brand, model, value)
    {
    }

    public override decimal DailyCost(int daysRented)
        => daysRented <= 7 ? 15 : 10;

    public override decimal DailyInsuranceCost => Value * 0.0002m;
}
