using System;
using System.Collections;
using System.Linq;

public static class Menu
{
    private static int ChosenOption { get; set; }

    public static void LoginMenu()
    {
        ChosenOption = -1;
        do
        {
            try
            {
                Console.WriteLine("Wybierz opcję:");
                Console.WriteLine("1. Zaloguj się");
                Console.WriteLine("2. Zarejestruj się");
                Console.WriteLine("0. Wyjdź z programu");
                ChosenOption = Convert.ToInt32(Console.ReadLine());
                if (ChosenOption < 0 || ChosenOption > 2)
                {
                    Console.WriteLine("Wybrano niepoprawną opcję. Spróbuj ponownie.");
                    Console.ReadKey();
                    Console.Clear();
                    ChosenOption = -1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Należy wybrać jedną z opcji, aby przejść dalej. Spróbuj ponownie.");
                Console.ReadKey();
                Console.Clear();
                ChosenOption = -1;
            }
        }
        while (ChosenOption < 0 || ChosenOption > 2);

        LoginMenuChoice(ChosenOption);
    }

    private static void LoginMenuChoice(int chosenOption)
    {
        switch (chosenOption)
        {
            case 1:
                {
                    User.Login();
                    break;
                }
            case 2:
                {
                    User.AddUser();
                    break;
                }
            case 0:
            {
                Environment.Exit(0);
                break;
            }
            default:
                {
                    Console.WriteLine("Wybrano niepoprawną opcję.");
                    LoginMenu();
                    break;
                }
        }
    }


    ///<summary>
    ///Shows menu depending on the user's role.
    ///</summary>
    public static void ShowMenu()
    {
        if (User.GetLoggedUser().GetType() == typeof(AdminUser)) //Check if the user is an admin
        {
            AdminMenu();
        }
        else
        {
            ClientMenu();
        }
    }

    ///<summary>
    ///Shows menu for admin.
    ///</summary>
    private static void AdminMenu()
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Dodaj stolik");
        Console.WriteLine("2. Usuń stolik");
        Console.WriteLine("3. Zarezerwuj stolik");
        Console.WriteLine("4. Anuluj rezerwację");
        Console.WriteLine("5. Wyświetl rezerwacje");
        Console.WriteLine("6. Wyświetl stoliki");
        Console.WriteLine("7. Wyświetl wolne stoliki");
        Console.WriteLine("8. Wyświetl zarezerwowane stoliki");
        Console.WriteLine("9. Wyjdź z programu");
        Console.WriteLine("0. Wyloguj się");
        ChosenOption = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        AdminMenuChoice(ChosenOption);
    }

    ///<summary>
    ///Shows menu for client.
    ///</summary>
    private static void ClientMenu()
    {
        Console.WriteLine("Wybierz opcję:");
        Console.WriteLine("1. Zarezerwuj stolik");
        Console.WriteLine("2. Edytuj rezerwację");
        Console.WriteLine("3. Anuluj rezerwację");
        Console.WriteLine("4. Wyjdź z programu");
        Console.WriteLine("0. Wyloguj się");
        ChosenOption = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        ClientMenuChoice(ChosenOption);
    }

    ///<summary>
    ///Helper method for ClientMenu method. Depending on the chosen option, it calls the appropriate method.
    ///</summary>
    private static void ClientMenuChoice(int chosenOption)
    {
        switch (chosenOption)
        {

            case 1://Rezerwacja stolika
                {
                    Reservation.AddReservation();
                    break;
                }
            case 2://Edycja rezerwacji
                {
                    Reservation.EditReservation();
                    break;
                }
            case 3://Usuwanie rezerwacji
                {
                    Reservation.CancelReservation();
                    break;
                }
            case 4://Wyjście z programu
                {
                    Environment.Exit(0);
                    break;
                }
            case 0://Wylogowanie
                {
                    User.LogOut();
                    Menu.LoginMenu();
                    break;
                }
            default:
                {
                    Console.WriteLine("Wybrano niepoprawną opcję.");
                    Menu.ShowMenu();
                    break;
                }
        }
    }


    ///<summary>
    ///Helper method for AdminMenu method. Depending on the chosen option, calls the appropriate method.
    ///</summary>
    private static void AdminMenuChoice(int chosenOption)
    {
        switch (chosenOption)
        {

            case 1://Dodanie stolików
                {
                    Table.AddTable();
                    Menu.BackToMenu();
                    break;
                }
            case 2://Usuwanie stolików
                {
                    Table.RemoveTableCompletely();
                    Menu.BackToMenu();
                    break;
                }
            case 3://Dodanie rezerwacji
                {
                    Reservation.AddReservation();
                    Menu.BackToMenu();
                    break;
                }
            case 4://Anulowanie rezerwacji
                {
                    Reservation.CancelReservation();
                    Menu.BackToMenu();
                    break;
                }
            case 5://Wyświetlanie wszystkich rezerwacji
                {
                    Reservation.ShowReservations();
                    break;
                }
            case 6://Wyświetlanie wszystkich stolików
                {
                    Table.ListAllTables(Table.Tables);
                    Menu.BackToMenu();
                    break;
                }
            case 7://Wyświetlanie wszystkich wolnych stolików
                {
                    Table.ListAllTables(Table.FreeTables);
                    Menu.BackToMenu();
                    break;
                }
            case 8://Wyświetlanie wszystkich zarezerwowanych stolików
                {
                    Table.ListAllTables(Table.ReservedTables);
                    Menu.BackToMenu();
                    break;
                }
            case 9://Wyjście z programu
                {
                    Environment.Exit(0);
                    break;
                }
            case 0://Wylogowanie
                {
                    User.LogOut();
                    Menu.LoginMenu();
                    break;
                }
            default:
                {
                    Console.WriteLine("Wybrano niepoprawną opcję.");
                    Menu.BackToMenu();
                    break;
                }
        }
    }

    ///<summary>
    ///Back to menu method. Waits for the user to press Esc key to return to menu.
    ///</summary>
    public static void BackToMenu()
    {
        Console.WriteLine("Naciśnij Esc, aby powrócić do menu.");
        while (true)
        {
            ConsoleKeyInfo cki = Console.ReadKey(true);
            if (cki.Key == ConsoleKey.Escape)
            {
                Console.Clear();
                Menu.ShowMenu();
                break;
            }
        }
    }
}
