using RentalSystem.Vehicles;

namespace RentalSystem;

public class Rental
{
    public Driver Driver { get; init; }

    public Vehicle Vehicle { get; init; }

    public DateOnly StartDate { get; init; }

    public DateOnly EndDate { get; init; }

    public DateOnly ReturnDate { get; init; }

    public Rental(Driver driver, DateOnly startDate, DateOnly endDate, DateOnly returnDate, Vehicle vehicle)
    {
        Driver = driver;
        StartDate = startDate;
        EndDate = endDate;
        ReturnDate = returnDate;
        Vehicle = vehicle;
    }

    public int ReservationDays => EndDate.DayNumber - StartDate.DayNumber;
    public int RentedDays => ReturnDate.DayNumber - StartDate.DayNumber;


    public decimal RentalCostPerDay => Vehicle.DailyCost(RentedDays);
    public decimal EarlyReturnDiscountCost => RentalCostPerDay * (ReservationDays - RentedDays) / 2;
    public decimal TotalRentalCost => RentalCostPerDay * RentedDays + RentalCostPerDay * (ReservationDays - RentedDays) / 2;


    public decimal InitialInsurancePerDay => Vehicle.DailyInsuranceCost;
    // negative for discount, positive for addition
    public decimal InsuranceChange => Vehicle.Type switch
    {
        VehicleType.Car => (Vehicle as Car)!.SafetyRating > 3 ? -InitialInsurancePerDay * 0.1m : 0,
        VehicleType.Motorcycle => Driver.Age < 25 ? InitialInsurancePerDay * 0.2m : 0,
        VehicleType.Cargovan => Driver.Experience > 5 ? -InitialInsurancePerDay * 0.15m : 0,
        _ => 0
    };
    public decimal InsurancePerDay => InitialInsurancePerDay + InsuranceChange;
    public decimal EarlyReturnDiscountInsuranceCost => InsurancePerDay * (ReservationDays - RentedDays);
    public decimal TotalInsurance => InsurancePerDay * RentedDays;

    public decimal Total => TotalRentalCost + TotalInsurance;
}
