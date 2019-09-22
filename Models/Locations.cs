using coincidence.Models;
using System.Collections.Generic;

namespace coincidence.Models
{
  public class Locations
  {
    public int Id { get; set; }
    public string Address { get; set; }
    public string ManagerName { get; set; }
    public string PhoneNumber { get; set; }

    public ICollection<Coincidence> Coins { get; set; }
  }
}