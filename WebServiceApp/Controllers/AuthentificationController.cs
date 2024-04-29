using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceApp.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthentificationController : ControllerBase
{
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
    private readonly IConfiguration _config;
    public AuthentificationController(IConfiguration config)
    {
        _config = config;

    }
    

    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        var _secretForKey = _config["Authentication:SecretForKey"];
        var _issuer = _config["Authentication:Issuer"];
        var _audience = _config["Authentication:Audience"];
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