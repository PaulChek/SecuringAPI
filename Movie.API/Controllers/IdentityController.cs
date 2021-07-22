using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Movie.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IdentityController : ControllerBase {
        [HttpGet]
        public IActionResult Get() {
            return new JsonResult(from u in HttpContext.User.Claims select new { u.Type, u.Value, u.Issuer });
        }
    }
}
