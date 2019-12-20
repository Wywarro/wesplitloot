using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using wesplitlootapi.Models;
using wesplitlootapi.Models.Identity;

namespace wesplitlootapi.Repositories
{
  public interface IAppUserRepository
  {
    Task<IEnumerable<AppUser>> GetAllAppUsers();

    Task<AppUser> GetAppUser(string firstName, string lastName);

    Task AddAppUser(AppUser appUser);

    Task<bool> RemoveAppUser(ObjectId Id);

    Task<bool> UpdateAppUser(AppUser appUser);
  }

  public class AppUserRepository : IAppUserRepository
  {
    private readonly IAppUserContext _context;

    public AppUserRepository(IOptions<Settings> settings)
    {
      _context = new AppUserContext(settings);
    }

    public async Task<IEnumerable<AppUser>> GetAllAppUsers()
    {
      try
      {
        return await _context.AppUsers.Find(_ => true).ToListAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }

    public async Task<AppUser> GetAppUser(string firstName, string lastName)
    {
      try
      {
        return await _context.AppUsers
          .Find(user => user.FirstName == firstName && user.LastName == lastName)
          .FirstOrDefaultAsync();
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task AddAppUser(AppUser appUser)
    {
      try
      {
        await _context.AppUsers.InsertOneAsync(appUser);
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> RemoveAppUser(ObjectId id)
    {
      try
      {
        DeleteResult deleteResult = await _context.AppUsers.DeleteOneAsync(
          Builders<AppUser>.Filter.Eq("Id", id));

        return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }

    public async Task<bool> UpdateAppUser(AppUser appUser)
    {
      try
      {
        ReplaceOneResult updateResult = await _context.AppUsers.ReplaceOneAsync(
          filter: user => user.Id == appUser.Id,
          replacement: appUser);

        return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
  }
}
