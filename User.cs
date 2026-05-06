using System;
using System.Collections.Generic;

public class User
{
    private string UserName { get; set; }
    private string Password { get; set; }
    public bool IsAdmin { get; private set; }
    internal static List<User> Users = new List<User>();
    private static User LoggedUser { get; set; }///<summary>User who's currently logged in</summary>

    ///<summary>
    ///Public method for adding a new user.
    ///</summary>
    public static void AddUser()
    {
      User user = new User();
    }

  
    public static string GetUserName(User user)
    {
      return user.UserName;
    }

    public static User GetLoggedUser()
    {
      return LoggedUser;
    }
    ///<summary>
    ///Private constructor for User class. Creates a new user and adds it to the list of users.
    ///</summary>
    private User()
    {
      string password, passwordRepeated = " ";
      Console.WriteLine("Rejestracja nowego użytkownika.\n\nPodaj nazwę użytkownika:");
      UserName = Console.ReadLine();
      Console.WriteLine("Podaj hasło:");
      password = MaskPassword();
      do
      {
        Console.WriteLine("\n\nPodaj hasło ponownie:");
        passwordRepeated = MaskPassword();
        if(passwordRepeated!=password)
        {
          Console.WriteLine("Podane hasła nie są identyczne."); 
          Console.Clear();
        }
      }
      while (passwordRepeated != password);
      IsAdmin = false;
      Users.Add(this);
      Console.Clear();
      Console.WriteLine("Użytkownik został dodany pomyślnie.");
      Console.ReadKey();
      Console.Clear();
      Menu.LoginMenu();
    }

    ///<summary>
    ///Masks the password while typing it in the console.
   ///</summary>
    private static string MaskPassword()
    {
      string password = "";
      ConsoleKeyInfo key;
      do
      {
        key = Console.ReadKey(intercept: true);
        if (key.Key == ConsoleKey.Backspace)
        {
          if (password.Length > 0)
          {
            Console.Write("\b \b");
            password = password.Remove(password.Length - 1);
          }
        }
        else if (key.Key != ConsoleKey.Enter)
        {
          password += key.KeyChar;
          Console.Write("*");
        }
      }
      while (key.Key != ConsoleKey.Enter);
      return password;
    }
    ///<summary>
    ///Constructor for User class. Creates a new user and adds it to the list of users.
    ///</summary>
    public User(string userName, string password, bool isAdmin = false)
    {
      UserName = userName;
      Password = password;
      IsAdmin = isAdmin;
      Users.Add(this);
    }


   ///<summary>
   ///Logs in a user.
   ///</summary>
    public static void Login()
    {
      if(LoggedUser != null)
      {
        Console.WriteLine("Jesteś już zalogowany.");
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
      }
      else
      {
        Console.WriteLine("Podaj nazwę użytkownika:");
        string userName = Console.ReadLine();
        Console.WriteLine("Podaj hasło:");
        string password = MaskPassword();
        User matchedUser = null;
        foreach (var user in Users)
        {
          if (user.UserName == userName && user.Password == password)
          {
            matchedUser = user;
            break;
          }
        }

        if (matchedUser != null)
        {
          LoggedUser = matchedUser;
          Console.WriteLine("\n\nZalogowano pomyślnie.");
          Console.ReadKey();
          Console.Clear();
          Menu.ShowMenu();
        }
        else
        {
          Console.WriteLine("\n\nPodano niepoprawną nazwę użytkownika lub hasło.");
          Console.ReadKey();
          Console.Clear();
          Login();
        }
      }
      
    }

    internal static void LogOut()
    {
        LoggedUser = null;
        if(LoggedUser == null)
        {
            Console.WriteLine("Wylogowano pomyślnie.");
        }
    }
}