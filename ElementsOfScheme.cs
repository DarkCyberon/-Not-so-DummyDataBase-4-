using System;
using Newtonsoft.Json; 

namespace Database {
  class ElementOfScheme {
    [JsonProperty(PropertyName = "name")]
    public string Name { get; private set;}

    [JsonProperty(PropertyName = "type")]
    public string Type { get; private set;}
  }
}