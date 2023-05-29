using BY.Store.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace BY.Store.API.Controllers
{
    public class CustomersController : BaseController
    {
        public CustomersController(IApplicationParams applicationParams) : base(applicationParams)
        {
        }

        [HttpGet("ShowCurrentCustomer")]
        public IActionResult ShowCurrentCustomer()
        {
            return Ok(_applicationParams.CurrentCustomerId);
        }

        [HttpPost("ChangeCustomerUsingId")]
        public IActionResult ChangeCustomerUsingId(int id)
        {
            _applicationParams.CurrentCustomerId = id;
            return Ok(_applicationParams.CurrentCustomerId);
        }
    }
}
