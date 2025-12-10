using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.Interfaces;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure.Services
{
    public class AuthService : IAuthService
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;
        
        public AuthService(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }
        
        public async Task<string> LoginEmployeeAsync(string document, string email)
        {
            var employee = await _context.Employees
                .FirstOrDefaultAsync(e => e.Document == document && e.Email == email);
            
            if (employee == null) 
                throw new UnauthorizedAccessException("Credenciales inválidas");
            
            return GenerateJwtToken(employee.Document, employee.Email);
        }
        
        private string GenerateJwtToken(string document, string email)
        {
            var key = Encoding.ASCII.GetBytes(_config["Jwt:Secret"] ?? "secret-key-min-32-chars-1234567890");
            var tokenHandler = new JwtSecurityTokenHandler();
            
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim("document", document),
                    new Claim("email", email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key), 
                    SecurityAlgorithms.HmacSha256Signature)
            };
            
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }

    public interface IAuthService
    {  
        Task<string> LoginEmployeeAsync(string document, string email);
    }
}