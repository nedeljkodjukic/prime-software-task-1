namespace RentalSystem.Vehicles;

class Cargovan : Vehicle
{
    public Cargovan(string brand, string model, decimal value)
        : base(VehicleType.Cargovan, brand, model, value)
    {
    }

    public override decimal DailyCost(int daysRented)
        => daysRented <= 7 ? 50 : 40;

    public override decimal DailyInsuranceCost => Value * 0.0003m;
}