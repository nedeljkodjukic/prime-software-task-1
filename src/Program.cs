using RentalSystem;
using RentalSystem.Vehicles;

// Input

var driver = new Driver(name: "John Markson", age: 30, experience: 8);

var vehicle = Vehicle.Create(vehicleType: VehicleType.Car, brand: "Mitsubishi", model: "Miriage", value: 15000, safetyRating: 3);

var startDate = new DateOnly(2024, 6, 6);
var endDate = new DateOnly(2024, 6, 18);
var returnDate = DateOnly.FromDateTime(DateTime.Now);

// Invoice print

var rental = new Rental(driver, startDate, endDate, returnDate, vehicle);

Invoice.Print(rental);