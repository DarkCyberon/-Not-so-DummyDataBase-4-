using System.Collections.Generic;
using System;

namespace Database {
  class TableRow {
    public Dictionary<ElementOfScheme, object> Conteiment { get; private set; } = new();

    public List<TableRow> CollectTheRows(string[] databaseLines, Scheme scheme){
      var rows = new List<TableRow>();

      for (int i = 0; i < databaseLines.Length; i++) {
        string[] lineElements = databaseLines[i].Split(";");

        var row = new TableRow();

        for (int j = 0; j < lineElements.Length; j++) {
          row.Conteiment.Add(scheme.Elements[j], IdentifyTheValue(lineElements[j], scheme.Elements[j]));
        }
        rows.Add(row);
      }
      return rows;
    }

    private object IdentifyTheValue (string identifiable, ElementOfScheme place){
      string type = place.Type;

      switch(type) {
        case "int":
          return Int32.Parse(identifiable);
        case "float":
          return float.Parse(identifiable);
        case "bool":
          return bool.Parse(identifiable);
        default:
          return identifiable;
      }
    }
  }
}