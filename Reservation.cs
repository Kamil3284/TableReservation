using System;
using System.Collections.Generic;

public class Reservation
{
    private DateTime TimeOfReservation { get; set; } //Time when the reservation was made
    private DateOnly ReservationDay { get; set; } //Only day of the reservation
    private TimeOnly ReservationTime { get; set; } //Only time of the reservation
    private Table T { get; set; } //Table class object
    private int NumberOfPeople { get; set; } //Number of people in the reservation
    private string NameOfReserver { get; set; } //Person who made the reservation
    public static List<Reservation> Reservations {get; private set;} = new List<Reservation>(); //List of all reservations
    private User ReservingUser {get; set; } //User who made the reservation

    ///<summary>
    ///Constructor of the Reservation class. Creates new Reservation object.
    ///</summary>
    public Reservation()
    {
        if(User.LoggedUser != null)
        {
            ReservingUser = User.LoggedUser;      
        }
        else
        {
            Console.WriteLine("Nie jesteś zalogowany. Zaloguj się, aby zarezerwować stolik.");
            Console.ReadKey();
            Console.Clear();
            Menu.LoginMenu();
        }
        Console.WriteLine("Na jaki dzień chcesz zarezerwować stolik? (DD/MM/YYYY)");
        //TODO:
        //Usprawnić, aby nie można było zarezerwować stolika na godzinę, która już minęła, oraz sprawdzić, czy wpisane dane są poprawne. 
        while(ReservationDay == DateOnly.MinValue)
        {
            try
            {
                ReservationDay = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Podano niepoprawną datę.");
            }
        }
        //TODO:
        //Usprawnić, aby nie można było zarezerwować stolika na godzinę, która już minęła, oraz sprawdzić, czy wpisane dane są poprawne. 
        while(ReservationTime == TimeOnly.MinValue)
        {
            try
            {
                Console.WriteLine("Na którą godzinę chcesz zarezerwować stolik? (HH:MM)");
                ReservationTime = TimeOnly.ParseExact(Console.ReadLine(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch
            {
                Console.WriteLine("Podano niepoprawną godzinę.");

            }
        }

        TimeOfReservation = DateTime.Now;
        Console.WriteLine("Na ile osób chcesz zarezerwować stolik?");
        NumberOfPeople = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Podaj swoje imię i nazwisko.");
        NameOfReserver = Console.ReadLine();
        Console.WriteLine("Wybierz stolik z listy proponowanych stolików:");
        for (int i = 0; i < Table.FreeTables.Count; i++)
        {
            if (Table.GetSeats(Table.FreeTables[i]) >= NumberOfPeople)
            {
                Console.WriteLine($"{i}.{Table.GetSeats(Table.FreeTables[i])} osobowy");
            }
        }
        int tableNumber;
        while (!int.TryParse(Console.ReadLine(), out tableNumber) || tableNumber < 1 || tableNumber > Table.FreeTables.Count)
        {
            Console.WriteLine("Podano niepoprawny numer stolika. Spróbuj ponownie:");
        }
        tableNumber--;
        T = Table.FreeTables[tableNumber];
        Table.MoveTable(T, Table.FreeTables, Table.ReservedTables);
        Reservations.Add(this);
        Table.ReserveTable(T);
        Console.WriteLine("Rezerwacja została wykonana pomyślnie.\n");
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
    }

    ///<summary>
    ///Constructor of the Reservation class. Creates new Reservation object.
    ///</summary>
    public Reservation(Table table, DateOnly reservationDay, TimeOnly reservationTime, int numberOfPeople, string nameOfReserver, User user = null)
    {
        TimeOfReservation = DateTime.Now;
        ReservationDay = reservationDay;
        ReservationTime = reservationTime;
        T = table;
        NumberOfPeople = numberOfPeople;
        NameOfReserver = nameOfReserver;
        if(user != null)
        {
            ReservingUser = user;
        }
        Table.MoveTable(table, Table.FreeTables, Table.ReservedTables);
        Reservations.Add(this);
        Table.ReserveTable(table);
    }
    
    ///<summary>
    ///Edits existing reservation.
    ///</summary>
    public static void EditReservation()
    {
        if (Reservations.Count == 0)
        {
            Console.WriteLine("Brak rezerwacji do edycji.\n");
        }
        else
        {
            Reservation.ShowReservations();
            Console.WriteLine("Którą rezerwację chcesz edytować?");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Reservation reservation = Reservation.Reservations[userInput - 1];
            ReservationEditMenu(reservation);
            Console.WriteLine("Rezerwacja została zaktualizowana.\n");
            Console.WriteLine("Czy chcesz edytować coś jeszcze? (T/N)");
            if (Console.ReadLine().ToUpper() == "T")
            {
                EditReservation();
            }
            else
            {
                Console.ReadKey();
                Console.Clear();
                Menu.ShowMenu();   
            }
        }
    }
    ///<summary>
    ///Edits existing reservation.
    ///</summary>
    public static void EditReservation(Reservation reservation)
    {
        ReservationEditMenu(reservation);
        Console.WriteLine("Rezerwacja została zaktualizowana.\n");
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
    }

    ///<summary>
    ///Helper method for EditReservation method. Shows menu for editing reservation.
    ///</summary>
    private static void ReservationEditMenu(Reservation reservation)
    {
        Console.WriteLine("Co chcesz edytować?");
        Console.WriteLine("1. Datę rezerwacji");
        Console.WriteLine("2. Godzinę rezerwacji");
        Console.WriteLine("3. Liczbę osób");
        Console.WriteLine("4. Stolik");
        Console.WriteLine("5. Anuluj edycję");
        int userInput = Convert.ToInt32(Console.ReadLine());
        switch(userInput)
        {
        case 1:
            {
                Console.WriteLine("Podaj nową datę rezerwacji (DD/MM/YYYY)");
                tryAgain:
                try
                {
                    reservation.ReservationDay = DateOnly.ParseExact(Console.ReadLine(), "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Podano niepoprawną datę.");
                    goto tryAgain;
                }
                break;
            }
        case 2:
            {
                Console.WriteLine("Podaj nową godzinę rezerwacji (HH:MM)");
                tryAgain:
                try
                {
                    reservation.ReservationTime = TimeOnly.ParseExact(Console.ReadLine(), "HH:mm", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch
                {
                    Console.WriteLine("Podano niepoprawną godzinę.");
                    goto tryAgain;
                }
                break;
            }
        case 3:
            {
                Console.WriteLine("Podaj nową liczbę osób");
                reservation.NumberOfPeople = Convert.ToInt32(Console.ReadLine());
                break;
            }
        case 4:
            {
                Console.WriteLine("Wybierz nowy stolik z listy proponowanych stolików:");
                for (int i = 0; i < Table.FreeTables.Count; i++)
                {
                    if (Table.GetSeats(Table.FreeTables[i]) >= reservation.NumberOfPeople)
                    {
                        Console.WriteLine($"{i}.{Table.GetSeats(Table.FreeTables[i])} osobowy");
                    }
                }
        int tableNumber;
        while (!int.TryParse(Console.ReadLine(), out tableNumber) || tableNumber < 1 || tableNumber > Table.FreeTables.Count)
        {
            Console.WriteLine("Podano niepoprawny numer stolika. Spróbuj ponownie:");
        }
        tableNumber--;
        int oldTableIndex = Table.Tables.IndexOf(reservation.T);
        reservation.T = Table.FreeTables[tableNumber];
        Table.MoveTable(reservation.T, Table.FreeTables, Table.ReservedTables);
        Table.ReserveTable(reservation.T);
        Table.FreeTable(Table.Tables[oldTableIndex]);
        break;
    }
        case 5:
            {
                Console.ReadKey();
                Console.Clear();
                Menu.ShowMenu();
                break;
            }
        default:
            {
                Console.WriteLine("Podano niepoprawną opcję.");
                ReservationEditMenu(reservation);
                break;
            }          
        }
    }


    ///<summary>
    ///Adds a reservation to the list of reservations.
    ///</summary>
    public static void AddReservation()
    {
        Reservation reservation = new Reservation();
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
    }
    
    ///<summary>
    ///Removes a reservation from the list of reservations.
    ///</summary>
    public static void CancelReservation()
    {
        if (Reservations.Count == 0)
        {
            Console.WriteLine("Brak rezerwacji do anulowania.\n");
        
        }
        else
        {
            Reservation.ShowReservations();
            Console.WriteLine("Którą rezerwację chcesz anulować?");
            int userInput = Convert.ToInt32(Console.ReadLine());
            Reservation reservation = Reservation.Reservations[userInput - 1];
            Table.MoveTable(reservation.T, Table.ReservedTables, Table.FreeTables);
            Reservations.Remove(reservation);
            Table.FreeTable(reservation.T);
            Console.WriteLine("Rezerwacja została anulowana.\n");
            Console.ReadKey();
            Console.Clear();
            Menu.ShowMenu();
        }
    }

    ///<summary>
    ///Shows all reservations.
    ///</summary>
    public static void ShowReservations()
    {
        if (Reservations.Count == 0)
        {
            Console.WriteLine("Brak rezerwacji.");
        }
        else
        {
            for (int i = 0; i < Reservations.Count; i++)
            {
                int counter = i + 1;
                Reservation r = Reservations[i];
                Console.WriteLine($"Rezerwacja numer {counter}:\nLiczba osób: {r.NumberOfPeople}\nZarezerwowany stolik: {Table.GetSeats(r.T)} osobowy, \nWybrana data i godzina: {r.ReservationDay.ToString("dd-MM-yyyy")} {r.ReservationTime.ToString("HH:mm")} \nOsoba rezerwująca: {r.NameOfReserver} \nCzas wykonania rezerwacji: {r.TimeOfReservation.ToString("dd-MM-yyyy HH:mm")}\nUżytkownik dokonujący rezerwacji:{User.GetUserName(r.ReservingUser)}.\n");
            }
        }
        Console.WriteLine("\nNaciśnij dowolny klawisz, aby kontynuować.");
        Console.ReadKey();
        Console.Clear();
        Menu.ShowMenu();
    }
}