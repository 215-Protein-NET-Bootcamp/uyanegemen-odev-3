using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace OdevApi.Auth
{
    [ApiController]
    [Route("protein/v1/api/[controller]")]
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
