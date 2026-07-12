using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthMicroservice.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SecureController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetData()
        {
            return Ok(new
            {
                Message = "Congratulations! JWT Authentication is working."
            });
        }
    }
}