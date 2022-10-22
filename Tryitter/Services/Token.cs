using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Tryitter.Model;

namespace Tryitter.Services;

public class Token
{
  public static string Generate(UserModel user)
  {
    var tokenHanlder = new JwtSecurityTokenHandler();
    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Contants.Token.secret));

    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

    var tokenDescriptor = new SecurityTokenDescriptor()
    {
      Subject = AddClaims(user),
      SigningCredentials = credentials,
      Expires = DateTime.Now.AddDays(7)
    };

    var token = tokenHanlder.CreateToken(tokenDescriptor);

    return tokenHanlder.WriteToken(token);
  }

  public static string GetUserId(string token)
  {
    var tokenHanlder = new JwtSecurityTokenHandler();
    var jwtSecurityToken = tokenHanlder.ReadJwtToken(token);

    return jwtSecurityToken.Claims.First(x => x.Type == "Id").Value;
  }

  private static ClaimsIdentity AddClaims(UserModel user)
  {
    var claims = new ClaimsIdentity();

    claims.AddClaim(new Claim(ClaimTypes.Name, user.Name));
    claims.AddClaim(new Claim(ClaimTypes.Email, user.Email));
    claims.AddClaim(new Claim("Id", user.UserId.ToString()));

    return claims;
  }
}