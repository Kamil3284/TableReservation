using System;
using System.Collections.Generic;

class Program {
  public static void Main (string[] args) {
    Table.AddTable(4);
    Table.AddTable(8);
    Table.AddTable(2);
    Table.AddTable(6);
    Table.AddTable(10);
    Table.AddTable(12);
    Console.WriteLine("Łącznie jest {0} stolików.",Table.NumberOfTables(Table.Tables));
    Reservation reservation = new Reservation(Table.FreeTables[0], 4, "John Doe");
    Console.WriteLine($"Łącznie jest {Table.NumberOfTables(Table.Tables)} stolików.");
    Console.WriteLine($"Wolnych{Table.NumberOfTables(Table.FreeTables)}");
    Console.WriteLine($"Zarezerwowanych{Table.NumberOfTables(Table.ReservedTables)}");
    Reservation.ShowReservations();
  }
}