using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.Dotnecore.IServices;
using Altkom.DotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/customers")]
    //[ApiController] //typy referencyjne z body  
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var customers = _customerService.Get();

            return Ok(customers);
        }

        [HttpGet("{id}", Name = nameof(GetCustomerById))]
        public IActionResult GetCustomerById(Guid id)
        {
            var customer = _customerService.Get(id);

            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }


        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            _customerService.Add(customer);

            return CreatedAtRoute(nameof(GetCustomerById), new { Id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
    
        public IActionResult Put(Guid id,[FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerService.Update(customer);

            return NoContent();
        }

        [HttpPatch("{id}")] //jsonPatch.com
        public IActionResult Patch(Guid id, [FromBody] Customer customer)
        {
            if (id != customer.Id)
            {
                return BadRequest();
            }

            _customerService.Update(customer);

            return NoContent();
        }
    }
}
