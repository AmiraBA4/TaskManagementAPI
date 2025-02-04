using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TaskManagement.Services;





public class AuthService : IAuthService
{
private readonly IConfiguration _configuration;

public AuthService(IConfiguration configuration)
{
    _configuration = configuration;
}

public string Authenticate(string username, string password)
{
    // Valider les informations d'identification de l'utilisateur
    // Pour cet exemple, nous utilisons des valeurs en dur
    if (username != "utilisateur" || password != "motdepasse")
        return null;

    // Générer le token JWT
    var tokenHandler = new JwtSecurityTokenHandler();
    var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:SecretKey"]);
    var tokenDescriptor = new SecurityTokenDescriptor
    {
        Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, username) }),
        Expires = DateTime.UtcNow.AddHours(1),
        Issuer = _configuration["JwtSettings:Issuer"],
        Audience = _configuration["JwtSettings:Audience"],
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
    };
    var token = tokenHandler.CreateToken(tokenDescriptor);
    return tokenHandler.WriteToken(token);
}
}
