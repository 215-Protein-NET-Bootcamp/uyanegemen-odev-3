using Microsoft.AspNetCore.Mvc;
using OdevApi.Base.Request;
using OdevApi.Service.Abstract;
using Serilog;

namespace OdevApi.Auth
{
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenManagementService tokenManagementService;

        public TokenController(ITokenManagementService tokenManagementService) : base()
        {
            this.tokenManagementService = tokenManagementService;
        }


        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] TokenRequest tokenRequest)
        {
            string userAgent = Request.Headers["User-Agent"].ToString();
            var result = await tokenManagementService.GenerateTokensAsync(tokenRequest, DateTime.UtcNow, userAgent);

            if (result.Success)
            {
                Log.Information($"Role {result.Response}: is loged in.");
                return Ok(result);
            }

            return Unauthorized(result);
        }
    }
}
