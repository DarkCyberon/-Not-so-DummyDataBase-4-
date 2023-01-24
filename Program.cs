using System;
using System.IO;

namespace Database {
  class Program {
    public static void Main () {
      string databaseName = InputTheFileName();
      Console.Clear();

      string databasePath = "../{databaseName}.csv";
      string schemePath = "../{databaseName}Scheme.json";

      IsFileHere(databasePath, schemePath);
      string[] databaseLines = File.ReadAllLines(databasePath);
      Scheme scheme = Scheme.ReadScheme(schemePath);

      DataCheck.IsLinesCorrespondToScheme(databaseLines, scheme);

      var table = new Table(databaseLines, scheme);

      DrawTheTable.CollectTheTableToDraw(table);
      Console.ReadKey();
      Console.Clear();

      Console.WriteLine("You want exit?");
      string input = Console.ReadLine().ToLower();
      if (!((input=="yes") || (input == "да")))
        Console.Clear();
      else {
        Console.Clear();
        Main();
      }
    }
    
    private static string InputTheFileName () {
      Console.WriteLine("Enter your database name (The scheme of your file must have \"Scheme\" after database name): ");
      string input = Console.ReadLine();

      if (input == null) {
        Console.WriteLine("Your input is emty. Try again");
        Console.ReadKey();
        InputTheFileName();
      }
      return input;
    }

    private static void IsFileHere (string databasePath, string schemePath) {
      if (!File.Exists(databasePath) || !File.Exists(schemePath)) {
        Console.WriteLine($"Database on {databasePath} or {schemePath} not found");
        Console.ReadKey();
        throw new Exception($"Database on {databasePath} or {schemePath} not found");
      }
    }
  }
}