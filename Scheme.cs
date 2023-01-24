using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Database {
  class Scheme {
    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set;}

    [JsonProperty(PropertyName = "columns")]
    public List<ElementOfScheme> Elements = new List<ElementOfScheme>();

    public static Scheme ReadScheme (string path) {
      return JsonConvert.DeserializeObject<Scheme>(File.ReadAllText(path));
    }
  }
}