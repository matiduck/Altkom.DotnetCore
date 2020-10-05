using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Altkom.Dotnecore.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/customers")]
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
    }
}
