using Api.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class CarsController : ControllerBase
{
    private static readonly List<Car> Cars =
    [
        new Car { Id = 1, Make = "Toyota", Model = "Camry", Year = 2020, Color = "Blue" },
        new Car { Id = 2, Make = "Honda", Model = "Civic", Year = 2019, Color = "Red" },
        new Car { Id = 3, Make = "Ford", Model = "Mustang", Year = 2021, Color = "Black" },
        new Car { Id = 4, Make = "Chevrolet", Model = "Malibu", Year = 2018, Color = "White" },
        new Car { Id = 5, Make = "Nissan", Model = "Altima", Year = 2022, Color = "Silver" }
    ];

    [HttpGet]
    public ActionResult<IEnumerable<Car>> GetAll()
    {
        return Ok(Cars);
    }

    [HttpGet("{id}")]
    public ActionResult<Car> GetById(int id)
    {
        var car = Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
            return NotFound();
        return Ok(car);
    }

    [HttpPost]
    public ActionResult<Car> Create(Car car)
    {
        car.Id = Cars.Max(c => c.Id) + 1;
        Cars.Add(car);
        return CreatedAtAction(nameof(GetById), new { id = car.Id }, car);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, Car updatedCar)
    {
        var car = Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
            return NotFound();

        car.Make = updatedCar.Make;
        car.Model = updatedCar.Model;
        car.Year = updatedCar.Year;
        car.Color = updatedCar.Color;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var car = Cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
            return NotFound();

        Cars.Remove(car);
        return NoContent();
    }
}