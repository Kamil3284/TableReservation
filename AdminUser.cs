using System;

public class AdminUser : User
{


  public AdminUser(string userName, string password, bool IsAdmin=true) : base(userName, password)
  {
      User.Users.Add(this);
  }










  
}