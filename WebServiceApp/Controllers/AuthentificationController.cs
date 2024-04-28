using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceApp.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthentificationController : ControllerBase
{
    private string _secretForKey = string.Empty;
    private string _issuer = string.Empty;
    private string _audience = string.Empty;
    private readonly IConfiguration _configuration;
    public class AuthenticationRequestBody
    {
        public string? UserName { get; set; }
        public string? Password { get; set; }
    }
    private class StoreUser
    {
        public int? UserId { get; set; }
        public string? UserName { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }  
        public string? UserRole { get; set; }  
        public StoreUser(int userid, string userName, string firstName, string lastName, string userRole)
        {
            UserId = userid;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            UserRole = userRole;
        }
    }
    
    public AuthentificationController(IConfiguration configuration)
    {
    _secretForKey = configuration["Authentication:SecretForKey"];
     _issuer = configuration["Authentication:Issuer"];
    _audience = configuration["Authentication:Audience"];
    }

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        var user = ValidateUserCredentials(authenticationRequestBody.UserName, authenticationRequestBody.Password);
        if (user == null)
        {
            return Unauthorized();
        }

        var secutityKey =
            new SymmetricSecurityKey(Convert.FromBase64String(_secretForKey));
        var signingCredentials = new SigningCredentials(secutityKey, SecurityAlgorithms.HmacSha256);
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));
        claimsForToken.Add(new Claim("given_name", user.FirstName));
        claimsForToken.Add(new Claim("family_name", user.LastName));
        claimsForToken.Add(new Claim("user_role", user.UserRole));
        
        var jwtSecurityToken = new JwtSecurityToken(
            _issuer,
            _audience,
            claimsForToken,
            DateTime.UtcNow,
            DateTime.UtcNow.AddHours(1),
            signingCredentials);
        var tokenToReturn = new JwtSecurityTokenHandler()
            .WriteToken(jwtSecurityToken);
        return Ok(tokenToReturn);
    }

    private StoreUser ValidateUserCredentials(string? userName, string? password)
    {
        return new StoreUser(1, userName ?? "", "Yuliya", "Buiko", "admin");
    }
}