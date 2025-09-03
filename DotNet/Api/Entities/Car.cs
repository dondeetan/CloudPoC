namespace Api.Entities;

// Create a new Car class with default properties
public class Car
{
    public int Id { get; set; } // Unique identifier for the car
    public string Make { get; set; } = string.Empty; // Manufacturer of the car
    public string Model { get; set; } = string.Empty; // Model of the car
    public int Year { get; set; } // Year of manufacture
    public string Color { get; set; } = string.Empty; // Color of the car
}
