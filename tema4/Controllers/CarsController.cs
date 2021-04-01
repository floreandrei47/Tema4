using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tema4.Models;

namespace tema4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {

        private static List<CarEntity> cars = new List<CarEntity>()
        {
                new CarEntity()
                {
                Id= 1,
                Model = "A4",
                Brand = "Audi",
                HorsePower = 150,
                Selected=false
                },

                new CarEntity()
                {
                    Id=2,
                    Brand="BMW",
                    Model="120d",
                    HorsePower=140,
                    Selected=false
                },
                new CarEntity()
                {
                    Id=3,
                    Brand="Mercedes",
                    Model="AMG GTR",
                    HorsePower=630,
                    Selected=false
                }


        };
        

        //Afisare masina dupa ID, metoda GET
        [HttpGet]
        [Route("car/{id}")]

        public IActionResult GetCarById(int Id)
        {
            return Ok(cars.FirstOrDefault(x => x.Id == Id));
        }

        //Adaugare masina, metoda POST, cerinta 1 din tema

        [HttpPost]
        [Route("car")]
        public IActionResult CreateNewCar([FromBody] CarEntity model)
        {
            if (model == null)
            { 
                return BadRequest();
            }

            cars.Add(model);

            return Ok(model);
        }

        //Modificare masina, metoda PUT, cerinta 1 din tema

        [HttpPut]
        [Route("car/{id}")]
        public IActionResult UpdateCar(int Id, [FromBody] CarEntity model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var car = cars.FirstOrDefault(x => x.Id == Id);
            if (car == null)
            {
                return NotFound();
            }

            car.Brand = model.Brand;
            car.Model = model.Model;
            car.HorsePower = model.HorsePower;
            car.Selected = model.Selected;

            return Ok(car);
        }

        //Stergere masina, metoda DELETE, cerinta 1 din tema
        [HttpDelete]
        [Route("car/{id}")]

        public IActionResult DeleteCar(int Id)
        {
            if (Id <= 0)
            {
                return BadRequest();
            }

            var car = cars.FirstOrDefault(x => x.Id == Id);
            if (car == null)
            {
                return NotFound();
            }

            cars.Remove(car);

            return Ok();
        }

        // Afisarea toate masinile, metoda GET, cerinta 2 din tema
        [HttpGet]
        public IActionResult GetAllCars()
        {
            return Ok(cars);
        }


        //Cautam o masina dupa model si modificam Selected in TRUE, astfel un client a ales o masina, cerinta 3 din tema

        [HttpPut]
        [Route("car/buy/{model}")]
        public IActionResult SelectCar(string Model, [FromBody] CarEntity model)
        {
            if (model == null)
            {
                return BadRequest();
            }

            var car = cars.FirstOrDefault(x => x.Model == Model);
            if (car == null)
            {
                return NotFound();
            }
            car.Id = model.Id;
            car.Brand = model.Brand;
            car.HorsePower = model.HorsePower;
            car.Selected = model.Selected;

            return Ok(car);
        }

    }


}
