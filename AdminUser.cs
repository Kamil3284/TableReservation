using System;

public class AdminUser : User
{
    public AdminUser(string userName, string password) : base(userName, password, true)
    {
    }
}