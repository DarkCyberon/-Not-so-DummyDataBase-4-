using System.Collections.Generic;

namespace Database {
  class Table {
    public string Name { get; private set; }
    public List<TableRow> Rows { get; private set; }
    public Scheme Scheme { get; private set; }
    public List<int> ColumnsLength {get; private set; } = new ();

    public Table (string[] databaseLines, Scheme scheme) {
      Name = scheme.Name;
      Rows = TableRow.CollectTheRows(databaseLines, scheme);
      Scheme = scheme;

      SetColumnsLength();
    }
    
    private static void SetColumnsLength() {
      SetMinColumnsLength();

      foreach (TableRow row in Rows) {
        for (int i = 0; i < row.Conteiment.Count; i++) {
          int elementLength = Scheme.Elements[i].ToString().Length;
          if (elementLength > ColumnsLength[i])
            ColumnsLength[i] = elementLength;
        }
      }
    }
    
    private static void SetMinColumnsLength() {
      foreach (ElementOfScheme element in Scheme.Elements)
        ColumnsLength.Add(element.Name.Length);
    }
  }
}