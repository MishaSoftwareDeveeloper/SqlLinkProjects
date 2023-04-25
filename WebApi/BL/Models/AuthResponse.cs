using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
  public class AuthResponse
  {
    public string token {  get; set; }
    public UserDetails personalDetails { get; set; }
  }
}
