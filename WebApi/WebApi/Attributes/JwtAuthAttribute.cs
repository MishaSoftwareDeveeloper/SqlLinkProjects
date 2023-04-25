using System;
using System.Threading.Tasks;
using System.Threading;
using System.Web.Http.Filters;
using System.Security.Principal;
using BL.Handlers;
using System.Collections.Generic;
using System.Security.Claims;

namespace WebApi.Attributes
{
  public class JwtAuthAttribute : Attribute, IAuthenticationFilter
  {
    public bool AllowMultiple => false;

    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    {
      var request = context.Request;
      var authorization = request.Headers.Authorization;

      if (authorization == null || authorization.Scheme != "Bearer")
        return;

      if (string.IsNullOrEmpty(authorization.Parameter))
      {
        context.ErrorResult = new AuthenticationFailureResult("Missing Jwt Token", request);
        return;
      }

      var token = authorization.Parameter;
      var principal = await AuthenticateJwtToken(token);

      if (principal == null)
        context.ErrorResult = new AuthenticationFailureResult("Invalid token", request);
      else
        context.Principal = principal;
    }

    protected Task<IPrincipal> AuthenticateJwtToken(string token)
    {
      JwtHandler handler = new JwtHandler();
      if (handler.ValidateToken(token, out string username))
      {
        var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, username)
                };

        var identity = new ClaimsIdentity(claims, "Name");
        IPrincipal user = new ClaimsPrincipal(identity);

        return Task.FromResult(user);
      }

      return Task.FromResult<IPrincipal>(null);
    }

  
    public Task ChallengeAsync(HttpAuthenticationChallengeContext context, CancellationToken cancellationToken)
    {
      return Task.FromResult(0);
    }
  }
}
