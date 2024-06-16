using System.Text;

namespace RentalSystem;

public static class Invoice
{
    private static readonly string DefaultDateTimeFormat = "yyyy-MM-dd";
    private static readonly string DefaultCostNumberFormat = "C";

    public static void Print(Rental rental)
    {
        var stringBulder = new StringBuilder();

        stringBulder.AppendLine("XXXXXXXXXX");
        stringBulder.AppendLine($"Date: {DateTime.Now.ToString(DefaultDateTimeFormat)}");
        stringBulder.AppendLine($"Customer Name: {rental.Driver.Name}");
        stringBulder.AppendLine($"Rented Vehicle: {rental.Vehicle.Model.ToString()}");

        stringBulder.AppendLine(string.Empty);

        stringBulder.AppendLine($"Reservation start date: {rental.StartDate.ToString(DefaultDateTimeFormat)}");
        stringBulder.AppendLine($"Reservation end date: {rental.EndDate.ToString(DefaultDateTimeFormat)}");
        stringBulder.AppendLine($"Reserved rental days: {rental.ReservationDays}");

        stringBulder.AppendLine(string.Empty);

        stringBulder.AppendLine($"Actual return date: {rental.ReturnDate.ToString(DefaultDateTimeFormat)}");
        stringBulder.AppendLine($"Actual rental days: {rental.RentedDays}");

        stringBulder.AppendLine(string.Empty);

        stringBulder.AppendLine($"Rental cost per day: {rental.RentalCostPerDay.ToString(DefaultCostNumberFormat)}");

        if (rental.InsuranceChange != 0)
        {
            stringBulder.AppendLine($"Initial insurance per day: {rental.InitialInsurancePerDay.ToString(DefaultCostNumberFormat)}");
            if (rental.InsuranceChange > 0)
                stringBulder.AppendLine($"Initial addition per day: {rental.InsuranceChange.ToString(DefaultCostNumberFormat)}");
            else
                stringBulder.AppendLine($"Initial discount per day: {((-1) * rental.InsuranceChange).ToString(DefaultCostNumberFormat)}");
        }
        stringBulder.AppendLine($"Insurance per day: {rental.InsurancePerDay.ToString(DefaultCostNumberFormat)}");


        if (rental.RentedDays != rental.ReservationDays)
        {
            stringBulder.AppendLine(string.Empty);
            stringBulder.AppendLine($"Early return discount for rent: {rental.EarlyReturnDiscountCost.ToString(DefaultCostNumberFormat)}");
            stringBulder.AppendLine($"Early return discount for insurance: {rental.EarlyReturnDiscountInsuranceCost.ToString(DefaultCostNumberFormat)}");
        }

        stringBulder.AppendLine(string.Empty);

        stringBulder.AppendLine($"Total rent: {rental.TotalRentalCost.ToString(DefaultCostNumberFormat)}");
        stringBulder.AppendLine($"Total insurance: {rental.TotalInsurance.ToString(DefaultCostNumberFormat)}");
        stringBulder.AppendLine($"Total: {rental.Total.ToString(DefaultCostNumberFormat)}");

        stringBulder.AppendLine("XXXXXXXXXX");

        Console.WriteLine(stringBulder.ToString());
    }
}
