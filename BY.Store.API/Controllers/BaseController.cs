using BY.Store.Shared.Params;
using Microsoft.AspNetCore.Mvc;

namespace BY.Store.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected IApplicationParams _applicationParams;

        public BaseController(IApplicationParams applicationParams)
        {
            _applicationParams = applicationParams;
        }
    }
}
