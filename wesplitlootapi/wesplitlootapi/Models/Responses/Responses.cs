using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace wesplitlootapi.Models.Responses
{
  public class LoginResponse
  {
    public string Token { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public LoginResponse(string token, string userName, string email)
    {
      Token = token;
      UserName = userName;
      Email = email;
    }
  }

  public class SignUpReponse
  {
    public string Token { get; private set; }
    public string UserName { get; private set; }
    public string Email { get; private set; }
    public SignUpReponse(string token, string userName, string email)
    {
      Token = token;
      UserName = userName;
      Email = email;
    }
  }

  public class UserDataResponse
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
  }
}
