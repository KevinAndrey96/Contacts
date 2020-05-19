using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{

    [Route("api/Login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        private readonly UserContext _context;
        public LoginController(UserContext context)
        {
            _context = context;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userlog)
        {
            var _userInfo = _context.Users.FirstOrDefault(b => b.email == userlog.Username && b.password == userlog.Pass);
            if (_userInfo != null)
            {
                return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
            else
            {
                return Unauthorized();
                //return Ok(new { token = GenerarTokenJWT(_userInfo) });
            }
        }

        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }



        






        public IConfiguration Configuration { get; }
        private string GenerarTokenJWT(User usuarioInfo)
        {
            string clavesecreta = Configuration.GetConnectionString("SecretKey");
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes("OLAh6Yh5KwNFvOqgltw7")
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256
                );
            var _Header = new JwtHeader(_signingCredentials);


            var _Claims = new[] {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.NameId, usuarioInfo.Id.ToString()),
                new Claim("firstName", usuarioInfo.firstName),
                new Claim("lastName", usuarioInfo.lastName),
                new Claim(JwtRegisteredClaimNames.Email, usuarioInfo.email),
            };

            
            string issuer = Configuration.GetConnectionString("Issuer");
            string audience = Configuration.GetConnectionString("Audience");
            var _Payload = new JwtPayload(
                    issuer: issuer,
                    audience: audience,
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    // Exipra a la 24 horas.
                    expires: DateTime.UtcNow.AddHours(24)
                );

            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            return new JwtSecurityTokenHandler().WriteToken(_Token);
        }
    }
}
