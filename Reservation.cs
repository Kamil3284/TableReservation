using System;
using System.Collections.Generic;

public class Reservation{
  private DateTime TimeOfReservation{get;set;}
  private Table Table{get;set;}
  private int NumberOfPeople{get;set;}
  private string NameOfReserver{get;set;}
  public static List<Reservation> Reservations = new List<Reservation>();
  
  public Reservation(Table table, int numberOfPeople, string nameOfReserver){
    TimeOfReservation = DateTime.Now;
    Table = table;
    NumberOfPeople = numberOfPeople;
    NameOfReserver = nameOfReserver;
    Table.MoveTable(table, Table.FreeTables, Table.ReservedTables);
    Reservations.Add(this);
  }

  public static void CancelReservation(Reservation reservation)
  {
    Table.MoveTable(reservation.Table, Table.ReservedTables, Table.FreeTables);
    Reservations.Remove(reservation);
  }

  public static void ShowReservations()
  {
    foreach(var r in Reservations)
    {
      Console.WriteLine($"Zarezerwowany stolik: {r.Table}, dla {r.NumberOfPeople} osób, przez {r.NameOfReserver} o {r.TimeOfReservation}");
    }
  }



  
}