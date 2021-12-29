using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/v1/antiforgery")]
    [ApiController]
    public class AntiForgeryController : ControllerBase
    {
        private IAntiforgery _antiForgery;
        private IWebHostEnvironment _env;
        public AntiForgeryController(IAntiforgery antiForgery, IWebHostEnvironment env)
        {
            _antiForgery = antiForgery;
            _env = env;
        }

        [HttpGet]
        [Route("")]
        [IgnoreAntiforgeryToken]
        public IActionResult GenerateAntiForgeryTokens()
        {
            var tokens = _antiForgery.GetAndStoreTokens(HttpContext);
            Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken, new CookieOptions
            {
                HttpOnly = false,
                SameSite = SameSiteMode.Lax,
                Secure = true,
                Path = "/",
                Domain = _env.IsDevelopment() ? "therapyapp.local" : "therapyapp.ch"
            });
            return NoContent();
        }
    }
}
