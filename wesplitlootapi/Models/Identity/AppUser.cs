using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCore.Identity.MongoDB;

namespace wesplitlootapi.Models.Identity
{
  public class AppUser : MongoIdentityUser
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
  }
}
