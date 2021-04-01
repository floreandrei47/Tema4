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
    public class CustomersController : ControllerBase
    {
        private static List<Customer> customers = new List<Customer>()
        {
            new Customer()
            {
                IdCustomer=1,
                Name="Ionescu Paul",
                ModelBought="Octavia"
            },
            new Customer()
            {
                 IdCustomer=2,
                Name="Florea Andrei",
                ModelBought="A7"
            },
             new Customer()
            {
                IdCustomer=3,
                Name="Sirghe Cosmin",
                ModelBought="Impreza"
            },
              new Customer()
            {
                IdCustomer=4,
                Name="Huludet Marian",
                ModelBought="Octavia"
            },
               new Customer()
            {
                IdCustomer=5,
                Name="Cocoveica Alexandru",
                ModelBought="A7"

            },


        };

        [HttpGet]
        public IActionResult GetAllCustomers()
        {
            return Ok(customers);
        }

        // Afisarea clientii si modelele pe care le-au achizitionat, cerinta 4 din tema
        [HttpGet]
        [Route("customer/{model}")]

        public IActionResult GetCustomerByModel(string Model)
        {
            List<string> cust = new List<string>();

            for (int i = 0; i < customers.Count(); i++)
            {
                if (customers[i].ModelBought == Model)
                {
                    cust.Add(customers[i].ModelBought);
                    cust.Add(customers[i].Name);
                }

            }
            return Ok(cust);
        }

        [HttpPost]
        [Route("customer")]
        public IActionResult CreateNewCustomer([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            customers.Add(customer);

            return Ok(customer);
        }
    }
}
