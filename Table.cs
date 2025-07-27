using System;
using System.Collections.Generic;

public class Table{
  public int Seats{get;set;} //How many seats are in the table
  public static List<Table> Tables = new List<Table>{new Table (2), new Table(4)}; //List of all tables
  public static List<Table> ReservedTables = new List<Table>(); //List of reserved tables
  public static List<Table> FreeTables = new List<Table>(Tables); //List of free tables
  
  public Table(int seats)
  {
    Seats = seats;
  }
  
public static void AddTable()
  {
    Console.WriteLine("How many seats are in the table?");
    int seats = Convert.ToInt32(Console.ReadLine());
    Table table = new Table(seats);
    Tables.Add(table);
    
  }

public static void AddTable(int seats)
  {
    Table table = new Table(seats);
    Tables.Add(table);
    
  }

public static void RemoveTableCompletely(Table table)
  {
    Tables.Remove(table);

  }
public static void MoveTable(Table table, List<Table> from, List<Table> to)
  {
    from.Remove(table);
    to.Add(table);
  }
  
public static void RemoveTableCompletely()
  {
    Console.WriteLine("Which table would you like to remove?");
    ListTables(Tables);
    Tables.RemoveAt(Convert.ToInt32(Console.ReadLine())-1);
    
  }

  public static string NumberOfTables(List<Table> tables)
  {
    if(tables.Count==0)
    {
      return "Brak stolików.";
    }
    else if(tables.Count==1)
    {
      return " jest "+tables.Count+" stolik. \n"+tables[0];
      
    }
    else if(tables.Count>1 && tables.Count<5)
      {
        return string.Format (" są {0} stoliki. \n {1}", tables.Count,ListTables(tables));
      }
    else
    {
      return $" jest {tables.Count} stolików.\n{ListTables(tables)}";
    }
  }

  private static string ListTables(List<Table> tables)
  {
    int counter=0;
    if(tables.Count>0)
    {
      string output = "";
      foreach(Table table in tables)
      {
        counter++;
        output+= counter+". "+table.Seats+"\n";
      }
      return output;
    }
    else return String.Empty;
    }
  }
