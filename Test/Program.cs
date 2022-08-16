using Newtonsoft.Json;
using Nothing;
using System.Reflection;
using System.Text.Json;
using Test;
string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\seed.txt");
var personList = Generate<Person>.Anything(10,path);


var json = JsonConvert.SerializeObject(personList, Formatting.Indented);

Console.WriteLine(json);