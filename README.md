# Nothing (something from nothing)

#### Initializing Instance Variables
An instance variable is assigned an initial value with dummy data in its declaration.
```c#
var personList = Generate<Person>.Anything(3);
```

Without nothing: 
```c#
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

```
#### set your own dummy data:
create a json file like below:
```json
{
   "name":[
      "Males",
      "Name",
      "James",
   ],
   "firstName":[
      "Mr.",
      "John",
      ""
   ],
   "lastName":[
      "Stoll",
      "Verlice",
      "Adler",
      "Huxley",
      "Ledger",
      "Hayes",
      "Ford"
   ],
   "loremIpsum":["Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupiitemt non proident, sunt in culpa qui officia deserunt mollit anim id est laborum"],
   "phoneNo":[
      "+8801910010011",
      " (555) 555-1234",
      "0854141404"
   ],
   "address":[
      "3014 Union Street"
   ],
   "city":[
      "Seattle"
   ],
   "state":[
      "Washington"
   ],
   "zipcode":[
      "98116"
   ]
}
```
Set json file path:
```c#
string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\seed.txt");
var personList = Generate<Person>.Anything(10,path);
```

 
### For Contributors
If you want to help and provide a patch for a bugfix or new feature, please take a few minutes and e-mail us rakib424@gmail.com. In particular check out the Coding standards and Commit Message Style Guide.

In general, fork the project, create a branch for a specific change and send a pull request for that branch. Don't mix unrelated changes. You can use the commit message as the description for the pull request.
