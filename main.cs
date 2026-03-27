using System;

partial class Program {
  public static void Main (string[] args) {
    Table.AddTable(2);
    Table.AddTable(2);
    Table.AddTable(4);
    Table.AddTable(4);
    Table.AddTable(6);
    Table.AddTable(8);
    Table.AddTable(10);
    Table.AddTable(12);
    Reservation reservation = new Reservation(Table.FreeTables[0], new DateOnly(2026,12,5), new TimeOnly(13,20,0), 10, "Marek Bredow");
    Reservation reservation2 = new Reservation(Table.FreeTables[0], new DateOnly(2027,2,27), new TimeOnly(19,10,0), 2, "Piotr Zimowski");
    User user = new User("user", "user");
    AdminUser admin = new AdminUser("admin", "admin");
    //Reservation.ShowReservations();
    Menu.LoginMenu();

    //TO DO:
    //Dodać wczytywanie danych z pliku, jak i zapisywanie ich do pliku.
    //Dodać możliwość edycji rezerwacji.
    //Dodać możliwość edycji stolików.
    //Dodać możliwość edycji użytkowników.
    
  }
}