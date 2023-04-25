using BL;
using BL.Handlers;
using BL.Models;
using System.Web.Http;

namespace WebApi.Controllers
{
  public class LoginController : ApiController
  {
    [AllowAnonymous]
    // POST: api/Login
    [HttpPost]
    public IHttpActionResult Login([FromBody] AuthRequest req)
    {
      AuthResponse authResponse = new LoginHandler().Login(req);
      if (authResponse == null)
      {
        return NotFound();
      }

      return Ok(authResponse);
    }

  }
}
