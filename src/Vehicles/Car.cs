namespace RentalSystem.Vehicles;

class Car : Vehicle
{
    public int SafetyRating { get; init; }

    public Car(string brand, string model, decimal value, int safetyRating)
        : base(VehicleType.Car, brand, model, value)
    {
        SafetyRating = safetyRating;
    }

    public override decimal DailyCost(int daysRented)
        => daysRented <= 7 ? 20 : 15;

    public override decimal DailyInsuranceCost => Value * 0.0001m;
}