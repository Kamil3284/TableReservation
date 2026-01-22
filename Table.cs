using System;
using System.Collections.Generic;

public class Table
{
    private int Seats { get; set; } //Number of seats in the table
    private bool IsReserved { get; set; } //Is the table reserved?
    public static List<Table> Tables { get; private set; } = new List<Table>(); //List of all tables
    public static List<Table> ReservedTables { get; private set; } = new List<Table>(); //List of reserved tables
    public static List<Table> FreeTables { get; private set; } = new List<Table>(); //List of free tables

    ///<summary>
    ///Constructor for Table class taking number of seats as an argument
    ///<summary>
    public Table(int seats)
    {
        Seats = seats;
        IsReserved = false;
    }

    ///<summary>
    ///Returns the number of seats in the table
    ///</summary>
    public static int GetSeats(Table table)
    {
        return table.Seats;
    }


    ///<summary>
    ///Changes the status of the table to reserved
    ///</summary>
    public static void ReserveTable(Table table)
    {
        if(table.IsReserved == false)
        {
            table.IsReserved = true;
        }
    }

    ///<summary>
    ///Changes the status of the table to free
    ///</summary>
    public static void FreeTable(Table table)
    {
        if(table.IsReserved == true)
        {
            table.IsReserved = false;
        }
    }

    ///<summary>
    ///Adds a table object to the list of table objects
    ///</summary>
    public static void AddTable()
    {
        int seats = 0;
        Console.WriteLine("Ile miejsc ma mieć stolik?");

        int.TryParse(Console.ReadLine(), out seats);
        if (seats <= 0)
        {
            Console.WriteLine("Podano niepoprawną liczbę miejsc.");
            Console.ReadKey();
            Console.Clear();
            AddTable();
        }
        else
        {
            Table table = new Table(seats);
            Tables.Add(table);
            FreeTables.Add(table);
            Console.WriteLine("Stolik został dodany.");
            Menu.BackToMenu();
        }
    }

    ///<summary>
    ///Adds a table object to the list of table objects
    ///</summary>
    public static void AddTable(int seats)
    {
        Table table = new Table(seats);
        Tables.Add(table);
        FreeTables.Add(table);
    }

  ///<summary>
  ///Helper method for RemoveTableCompletely method. Checks if the table is in the other lists and removes it from them.
  ///</summary>
    private static void CheckOtherLists(Table table)
    {
        if (FreeTables.Contains(table))
        {
            FreeTables.Remove(table);
        }
        else if (ReservedTables.Contains(table))
        {
            ReservedTables.Remove(table);
        }
    }

    ///<summary>
    ///Removes a table object from the list of table objects
    ///</summary>
    public static void RemoveTableCompletely(Table table)
    {
        Tables.Remove(table);
        CheckOtherLists(table);
    }

    ///<summary>
    ///Removes a table object from the list of table objects
    ///</summary>
    public static void RemoveTableCompletely()
    {
        Console.WriteLine("Który stolik chcesz usunąć? Uwaga! Stolik zostanie trwale usunięty!");
        ShowAllTables(Tables);
        int tableNumber = Convert.ToInt32(Console.ReadLine()) - 1;
        RemoveTableCompletely(Tables[tableNumber]);
        Console.WriteLine("Stolik został usunięty.");
        Menu.BackToMenu();
    }

    ///<summary>
    ///Moves a table object from one list to another. Used for reserving and freeing tables.
    ///Takes a table object and two lists as arguments.
    ///</summary>
    public static void MoveTable(Table table, List<Table> from, List<Table> to)
    {
        from.Remove(table);
        to.Add(table);
    }

    ///<summary>
    ///Shows all tables in the given list
    ///</summary>
    public static string ShowAllTables(List<Table> tables)
    {
        if (tables.Count == 0)
        {
            return "Brak stolików.";
        }
        else if (tables.Count == 1)
        {
            return " jest " + tables.Count + " stolik. \n" + tables[0].Seats + " osobowy";
        }
        else if (tables.Count > 1 && tables.Count < 5)
        {
            return string.Format(" są {0} stoliki.\n{1}", tables.Count, ListTables(tables));
        }
        else
        {
            return $" jest {tables.Count} stolików.\n{ListTables(tables)}";
        }

    }

  ///<summary>
  ///Helper method for ShowAllTables method. Lists all tables in the given list.
  ///</summary>
    private static string ListTables(List<Table> tables)
    {
        int counter = 0;
        if (tables.Count > 0)
        {
            string output = "";
            foreach (var table in tables)
            {
                counter++;
                output += counter + ". " + table.Seats + " osobowy\n";
            }
            return output;
        }
        else return String.Empty;
    }

  ///<summary>
  ///Lists all tables in the given list and their status
  ///</summary>
    public static void ListAllTables(List<Table> tables)
    {
        Console.WriteLine($"Wszystkie stoliki:");
        foreach (var t in tables)
        {
            Console.Write($"{t.Seats} osobowy");
            Console.Write(t.IsReserved == true ? "\tZarezerwowany\n" : "\tWolny\n");
        }
        Console.WriteLine("\n");
        Menu.BackToMenu();
    }

}