using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ApiScool.Models;
using ApiScool.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ApiScool.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private ScoolBdContext Context;
        private readonly IConfiguration _configuration;
        public UserController(ScoolBdContext Context, IConfiguration configuration)
        {
            this.Context = Context;
            _configuration = configuration;
        }
        [HttpPost("Login")]
        public ActionResult<object> Login([FromBody] UserInfo user)
        {
           var isValid= this.Context.Usuario.Any(x => x.UserName.Equals(user.username) && x.Password.Equals(user.password));
            if (isValid)
            {
                return Ok(BuildToken(user, new List<string>()));
            }
            else
            {
                return BadRequest("Usuario o contraseña incorrecta");
            }
 
        }

        private UserToken BuildToken(UserInfo userInfo, IList<string> roles)
        {
         

           
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:key"]));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://apiscool20191110023542.azurewebsites.net",
                    audience: "https://apiscool20191110023542.azurewebsites.net",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                return new UserToken { Token = tokenString,Expiracion= DateTime.Now.AddMinutes(5) };
            
            
        }
    }
}