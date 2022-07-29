using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OdevApi.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthTestController : ControllerBase
    {
        public AuthTestController() : base()
        {

        }


        [HttpGet("NoToken")]
        public string NoToken()
        {
            return "NoToken";
        }

        [HttpGet("Authorize")]
        [Authorize]
        public string Authorize()
        {
            return "Authorize";
        }

        
      
    }
}
