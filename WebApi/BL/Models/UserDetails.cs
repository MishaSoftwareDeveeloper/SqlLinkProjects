using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Models
{
  public class UserDetails
  {
    public int Id { get; set; }
    public string name { get; set; }
    public string Team { get; set; }
    public DateTime? joinedAt { get; set; }
    public string avatar { get; set; }
  }
}
