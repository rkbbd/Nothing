using System.Reflection;

namespace Nothing
{
    public static class Generate<T> where T : class
    {
       
        public static T Nothing(int noOfItem)
        {
            string[] name = { "Males","Name","James","Robert","John","Michael","David","William","Richard","Joseph","Thomas","Charles","Christopher","Daniel","Matthew","Anthony","Mark","Donald","Steven","Paul","Andrew","Joshua","Kenneth","Kevin","Brian","George","Timothy","Ronald","Edward","Jason","Jeffrey","Ryan","Jacob","Gary","Nicholas","Eric","Jonathan","Stephen","Larry","Justin","Scott","Brandon","Benjamin","Samuel","Gregory","Alexander","Frank","Patrick","Raymond","Jack","Dennis","Jerry","Tyler","Aaron","Jose","Adam","Nathan","Henry","Douglas","Zachary","Peter","Kyle","Ethan","Walter","Noah","Jeremy","Christian","Keith","Roger","Terry","Gerald","Harold","Sean","Austin","Carl","Arthur","Lawrence","Dylan","Jesse","Jordan","Bryan","Billy","Joe","Bruce","Gabriel","Logan","Albert","Willie","Alan","Juan","Wayne","Elijah","Randy","Roy","Vincent","Ralph","Eugene","Russell","Bobby","Mason","Philip","Louis" };
            string[] firstName = { "" };
            string[] lastName = { "" };
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            Random rand = new Random();
            T data = Activator.CreateInstance<T>();


          //  List<PropertyInfo[]> propertyList = new List<PropertyInfo[]>();
            PropertyInfo[] propertyInfos = data.GetType().GetProperties();

            foreach (var propertyInfo in propertyInfos)
            {
                if (propertyInfo.Name.ToLower().Contains("name"))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfo.SetValue(data,name[randomNo], null);
                }
                else if (propertyInfo.Name.ToLower().Contains("firstname") || propertyInfo.Name.ToLower().Contains("first_name") || ( propertyInfo.Name.ToLower().Contains("f") && propertyInfo.Name.ToLower().Contains("name")))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfo.SetValue(data,firstName[randomNo], null);
                }
                else if (propertyInfo.Name.ToLower().Contains("l") && propertyInfo.Name.ToLower().Contains("name"))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfo.SetValue(data, lastName[randomNo], null);
                }
                else if(propertyInfo.Name.ToLower().Contains("age"))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfo.SetValue(data, randomNo, null);
                }
                else if (propertyInfo.Name.ToLower().Contains("phone"))
                {
                    int randomName = rand.Next(0, name.Count());
                    propertyInfo.SetValue(data, randomName, null);
                }
                else
                {
                     if (propertyInfo.GetType() == typeof(int))
                    {
                        int random = rand.Next(0, name.Count());
                        propertyInfo.SetValue(data, random, null);
                    }
                    else if (propertyInfo.GetType() == typeof(decimal))
                    {
                        decimal random = new decimal(rand.NextDouble());
                        propertyInfo.SetValue(data, random, null);
                    }
                    else if (propertyInfo.GetType() == typeof(string))
                    {
                        propertyInfo.SetValue(data, loremIpsum, null);
                    }
                }
            }

            var cv = (T)data;


           // var cv= (T)destination;


            // var m =(T) propertyInfos.GetValue(data);
            // var m = propertyList[0][1].GetValue(data, null);

            // return (TPropertyType)propertyInfo.GetValue(instance);

            // propertyList.Add(propertyInfos);

            // PropertyInfo propertyInfo=  data.GetType().GetProperty("Name");

            // var name = propertyInfo.Name;
            // propertyInfo.SetValue(data, "asdf", null);

            //var m = propertyInfo.GetValue(data, null);


            // string value = "Nmae";
            // if (propertyInfo != null)
            // {
            //     Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            //     object safeValue = (value == null) ? null : Convert.ChangeType(value, t);
            //     propertyInfo.SetValue(t.FullName, safeValue, null);


            //     PropertyInfo fieldPropertyInfo = data.GetType().GetProperties()
            //                      .FirstOrDefault(f => f.Name.ToLower() == "name");

            //     // The result should be stored into another variable here:
            //    var data2 = fieldPropertyInfo.GetValue(data, null);

            //     fieldPropertyInfo.SetValue(data2, safeValue, null);
            // }

            //PropertyInfo propertyInfo =  type.GetProperty("Name");
            //propertyInfo.SetValue(type, Convert.ChangeType("hello", propertyInfo.PropertyType), null);

            //string propertyName = "Age";
            //string value = "Nmae";
            //PropertyInfo propertyInfo = type.GetType().GetProperty(propertyName);
            //if (propertyInfo != null)
            //{
            //    Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
            //    object safeValue = (value == null) ? null : Convert.ChangeType(value, t);
            //    propertyInfo.SetValue(type, safeValue, null);
            //}

            //var f2 = propertyInfo;
            return null ;
        }
    }
}