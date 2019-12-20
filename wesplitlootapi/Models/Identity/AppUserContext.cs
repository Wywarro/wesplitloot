using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace wesplitlootapi.Models.Identity
{
  public class AppUserContext : IAppUserContext
  {
    private readonly IMongoDatabase _database = null;

    public AppUserContext(IOptions<Settings> settings)
    {
      var client = new MongoClient(settings.Value.ConnectionString);
      if (client != null)
      {
        _database = client.GetDatabase(settings.Value.Database);
      }
    }

    public IMongoCollection<AppUser> AppUsers
    {
      get
      {
        return _database.GetCollection<AppUser>("AppUser");
      }
    }
  }

  public interface IAppUserContext
  {
    IMongoCollection<AppUser> AppUsers { get; }
  }
}
