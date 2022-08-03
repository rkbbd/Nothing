using Newtonsoft.Json;
using Nothing;
using System.Text.Json;
using Test;

var personList = Generate<Person>.Anything(10);
var json = JsonConvert.SerializeObject(personList, Formatting.Indented);

Console.WriteLine(json);