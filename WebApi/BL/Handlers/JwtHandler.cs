using DAL;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace BL.Handlers
{
  public class JwtHandler
  {
    private readonly string secret = "my secret 132456";
    public string GetToken(Users user)
    {
      var tokenHandler = new JwtSecurityTokenHandler();
      var key = Encoding.UTF8.GetBytes(secret);

      var tokenDescriptor = new SecurityTokenDescriptor
      {
        Subject = new ClaimsIdentity(new Claim[]
          {
                    new Claim(ClaimTypes.Name, user.name),
                    new Claim(ClaimTypes.Email, user.email)
          }),
        Expires = DateTime.UtcNow.AddMinutes(10),
        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
      };

      var token = tokenHandler.CreateToken(tokenDescriptor);

      return tokenHandler.WriteToken(token);
    }

    public bool ValidateToken(string token, out string username)
    {
      username = null;
      var handler = new JwtSecurityTokenHandler();
      var securityToken = handler.ReadToken(token) as JwtSecurityToken;
      username = securityToken.Claims.First(claim => claim.Type == "unique_name").Value;

      if (string.IsNullOrEmpty(username))
        return false;

      var key = Encoding.UTF8.GetBytes(secret);
      var securityKey = new SymmetricSecurityKey(key);

      var tokenHandler = new JwtSecurityTokenHandler();
      try
      {
        tokenHandler.ValidateToken(token, new TokenValidationParameters
        {
          ValidateIssuer = false,
          ValidateAudience = false,
          ValidateIssuerSigningKey = true,
          IssuerSigningKey = securityKey
        }, out SecurityToken validatedToken);
      }
      catch(Exception ex)
      {
        return false;
      }

      return true;
    }
  }
}
