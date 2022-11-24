using Exercices10.Models;
using Exercices10.Service;
using Microsoft.AspNetCore.Mvc;

namespace Exercices10.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private ICustomersRepository CustomersRepository;
        public CustomersController(ICustomersRepository customersRepository)
        {
            CustomersRepository = customersRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(CustomersRepository.GetCustomers());
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get([FromRoute] int id)
        {
            if(ModelState.IsValid)
            {
                return Ok(CustomersRepository.GetCustomerById(id));
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Post([FromBody] Customer2 customer)
        {
            if(ModelState.IsValid)
            {
                return Ok(CustomersRepository.AddCustomer(customer));
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if(ModelState.IsValid)
            {
                var customer = CustomersRepository.GetCustomerById(id);
                return Ok(CustomersRepository.DeleteCustomer(customer));
            }
            return BadRequest();
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Put([FromRoute] int id,[FromBody] Customer2 customer)
        {
            if(ModelState.IsValid)
            {
                var cust = CustomersRepository.GetCustomerById(id);
                cust.LastName = customer.LastName;
                cust.FirstName = customer.FirstName;
                cust.Gender = customer.Gender;
                return Ok(CustomersRepository.UpdateCustomer(cust));
            }
            return BadRequest();
        }
    }
}
