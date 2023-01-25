using System;
using System.Collections.Generic;
using System.Text;

namespace Database {
  class DrawTheTable {
    public void CollectTheTableToDraw (Table table) {
      var rows = new StringBuilder();
      rows.Append(DrawTheTableHead(table));

      foreach (TableRow row in table.Rows)
        rows.Append(AdjustLengthInRow(row, table.Scheme, table.ColumnsLength));
      
      Console.WriteLine(rows);
    }
    
    private StringBuilder AdjustLengthInRow (TableRow row, Scheme scheme, List<int> columnsLength) {
      var rowElements = new List<string> ();

      for (int i = 0; i < scheme.Elements.Count; i++)
        rowElements.Add(row.Conteiment[scheme.Elements[i]].ToString().PadRight(columnsLength[i]));

      return CollectTheLine(rowElements);
    }
    
    private StringBuilder DrawTheTableHead(Table table){
      var headOfTable = new StringBuilder();
      var separators = new List<string>();
      var headElements = new List<string>();

      Scheme scheme = table.Scheme;
      List<int> columnsLength = table.ColumnsLength;

      for (int i = 0; i < scheme.Elements.Count; i++) 
        headElements.Add(scheme.Elements[i].Name.PadRight(columnsLength[i]));

      foreach (var element in headElements) 
        separators.Add(new string('-', element.Length));
      headOfTable.Append(CollectTheLine(headElements));
      headOfTable.Append(CollectTheLine(separators));

      return headOfTable;
    }

    private StringBuilder CollectTheLine(List<string> elements){
      var line = new StringBuilder();

      foreach (string element in elements)
        line.Append($"|{element}");
      line.Append("|\n");
      return line;
    }
  }
}