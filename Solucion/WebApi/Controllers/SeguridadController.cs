using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebApi.Modelos;

namespace WebApi.Controllers
{
    [Route("Seguridad")]
    [EnableCors("MyPolicy")]
    [ApiController]
    [Authorize]
    public class SeguridadController : ControllerBase
    {
        private readonly BDPruebaContext _context;
        private IConfiguration _configuration;
        public SeguridadController(BDPruebaContext context,IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }
        [HttpPost]
        [AllowAnonymous]
        [Route("ValidarUsuario")]
        public async Task<IActionResult> ValidarUsuario([FromBody] Usuarios usuarios)
        {
            if (usuarios == null) return BadRequest();
            var result = await _context.Usuarios.Where(o => o.NombreUsuario == usuarios.NombreUsuario && o.Clave == usuarios.Clave).FirstOrDefaultAsync();
            if(result!=null)
            {
                var token = BuildToken(usuarios);
                    usuarios.Token = token;
                return Ok(usuarios);
            }
            else 
            {
                return NotFound();
            }
         
        }
        private string BuildToken(Usuarios usuarios)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Auth:Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,usuarios.NombreUsuario),
             };
             var token=new JwtSecurityToken(_configuration["Auth:Jwt:Issuer"], _configuration["Auth:Jwt:Audience"], claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(_configuration["Auth:Jwt:TokenExpirationInMinutes"])), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
