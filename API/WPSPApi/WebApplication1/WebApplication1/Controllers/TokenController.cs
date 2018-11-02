using Microsoft.AspNetCore.Mvc;
using WPSPApi.JWTSecurity;
using WPSPApi.Models;
using Microsoft.AspNetCore.Authorization;
using System.Web.Http.Cors;

namespace WPSPApi.Controllers
{
    [Route("token")]
    [AllowAnonymous]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TokenController : Controller
    {
        [HttpPost]
        public IActionResult Create([FromBody]LoginInputModel inputModel)
        {
            string user = inputModel.Username;
            string pwd = inputModel.Password;

            if (user == "james" && pwd == "bond")
            {
                var token = new JwtTokenBuilder()
                                    .AddSecurityKey(JwtSecurityKey.Create("fiver-secret-key"))
                                    .AddSubject("james bond")
                                    .AddIssuer("Fiver.Security.Bearer")
                                    .AddAudience("Fiver.Security.Bearer")
                                    .AddClaim("MembershipId", "111")
                                    .AddExpiry(1)
                                    .Build();

                //return Ok(token);
                return Ok(token.Value);
            }
            else
            {
                return Unauthorized();
            }
        }
    }
}
