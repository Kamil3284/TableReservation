using System;
using System.Collections.Generic;

public class User
{
    private string UserName { get; set; }
    private string Password { get; set; }
    public bool IsAdmin { get; private set; }
    internal static List<User> Users = new List<User>();
    public static User LoggedUser { get; private set; }///<summary>User who's currently logged in</summary>

    ///<summary>
    ///Public method for adding a new user.
    ///</summary>
    public static void AddUser()
    {
      User user = new User();
    }

    ///<summary>
    ///Private constructor for User class. Creates a new user and adds it to the list of users.
    ///</summary>
    private User()
    {
      string PasswordRepeated = " ";
      Console.WriteLine("Rejestracja nowego użytkownika:\nPodaj nazwę użytkownika:");
      UserName = Console.ReadLine();
      Console.WriteLine("Podaj hasło:");
      Password = Console.ReadLine();
      do
      {
        Console.WriteLine("Podaj hasło ponownie:");
        PasswordRepeated = Console.ReadLine();
        if(PasswordRepeated!=Password)
        {
          Console.WriteLine("Podane hasła nie są identyczne."); 
          Console.Clear();
        }
      }
      while (PasswordRepeated != Password) ;
      Console.Clear();
      IsAdmin = false;
      Console.WriteLine("Użytkownik został dodany pomyślnie.");
      Users.Add(this);
    }

    ///<summary>
    ///Constructor for User class. Creates a new user and adds it to the list of users.
    ///</summary>
    public User(string userName, string password)
    {
      UserName = userName;
      Password = password;
      IsAdmin = false;
      Users.Add(this);
    }


   ///<summary>
   ///Logs in a user.
   ///</summary>
    public static void Login()
    {
      Console.WriteLine("Podaj nazwę użytkownika:");
      string userName = Console.ReadLine();
      Console.WriteLine("Podaj hasło:");
      string password = Console.ReadLine();
      User matchedUser = null;
      foreach (var user in User.Users)
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
        Console.WriteLine("Zalogowano pomyślnie.");
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
      }
      else
      {
        Console.WriteLine("Podano niepoprawną nazwę użytkownika lub hasło.");
        Login();
      }
    }


  
}