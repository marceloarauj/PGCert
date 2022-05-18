using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        [HttpPost("payment")]
        public IActionResult Payment()
        {
            return null;
        }

        [HttpGet("search/{id}")]
        public IActionResult Search(int id)
        {
            return null;
        }
    }
}
