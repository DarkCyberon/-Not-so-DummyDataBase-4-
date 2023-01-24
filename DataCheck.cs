using System;

namespace Database {
  class DataCheck {
    private static void IsCorrectType (string[] lines, Scheme scheme) {
      for (int i = 0; i < lines.Length; i++) {
        string[] elements = lines[i].Split(';');
        for (int j = 0; j < elements.Length; j++) {
          string element = elements[j];
          string type = scheme.Elements[j].Type;
          bool result = true;

          switch (type) {
            case "int": 
              result = Int32.TryParse(element, out _);
              break;
            case "bool":
              result = bool.TryParse(element, out _);
              break;
          }
          if (!result)
            throw new Exception($"There is an error in {i+1} row and {j+1} column: Cannot convert \"{element}\" to \"{type}\".");
        }
      }
    }
    private static void IsColumnsRight (string[] lines, Scheme scheme) {
      for (int i = 0; i < lines.Length; i++) {
        string[] elements = lines[i].Split(';');
        int elementsCount = elements.Length;
        int rightCount = scheme.Elements.Count;

        if (elementsCount != rightCount)
          throw new Exception($"There is an error in {i+1} row:  The count of elements must be {rightCount} but it was {elementsCount}.");
      }
    }
    public static void IsLinesCorrespondToScheme (string[] lines, Scheme scheme) {
      IsCorrectType(lines, scheme);
      IsColumnsRight(lines, scheme);
    }
  }
}