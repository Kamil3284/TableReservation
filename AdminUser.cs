using System;

public class AdminUser : User
{
    private static int AdminCount = 0;
    private static readonly int MaxAdmins = 1;
    private static readonly string AdminCreationCode = "!QAZzaq1";

    private AdminUser(string userName, string password) : base(userName, password, true)
    {
    }

    public static AdminUser Create(string userName, string password, string adminCreationCode)
    {
        if (adminCreationCode != AdminCreationCode)
            {
                throw new UnauthorizedAccessException("Invalid admin code.");
            }
        if (AdminCount >= MaxAdmins)
            {
                throw new InvalidOperationException("Maximum number of admins reached.");
            }
        AdminCount++;
        return new AdminUser(userName, password);
    }
}