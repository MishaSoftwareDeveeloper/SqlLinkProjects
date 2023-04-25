using BL.Models;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Handlers
{
  public class LoginHandler
  {
    public AuthResponse Login(AuthRequest request)
    {
      AuthResponse res = null;
      using (var db = new TestEntities())
      {
        var user = db.Users.SingleOrDefault(u=>u.email == request.Email && u.password == request.Password);
        if(user != null)
        {
          res = new AuthResponse();
          res.token = new JwtHandler().GetToken(user);
          res.personalDetails = new UserDetails()
          {
            Id = user.id,
            name = user.name,
            avatar = user.avatar,
            joinedAt = user.joinedAt,
            Team = user.Team
          };
        }
        return res;
      }
    }
  }
}
