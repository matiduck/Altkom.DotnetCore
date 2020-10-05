using Microsoft.AspNetCore.Mvc;
using System;

namespace Altkom.DotnetCore.WebApi.Controllers
{
    [Route("api/documents")]
    public class DocumentsController : Controller
    {
        [HttpGet("~/api/customers/{customerId}/documents")]
        public IActionResult GetDocumentsByCustomer(Guid customerId)
        {
            throw new NotImplementedException();
        }
    }
}
