using Newtonsoft.Json;
using Nothing;
using System.Text.Json;
using Test;

var personList = Generate<Person>.Anything(10);


var PresonList = new List<Person>(){
  new Person(){
      Id = 1,
    Name ="Mr x",
    Age =100,
  },
   new Person(){
      Id = 2,
    Name ="Mr y",
    Age =50,
  },
    new Person(){
      Id = 3,
    Name ="Mr z",
    Age =30,
  },
     new Person(){
      Id = 3,
    Name ="Mr m",
    Age =15,
  }
};

var json = JsonConvert.SerializeObject(personList, Formatting.Indented);

Console.WriteLine(json);