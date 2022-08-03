using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Nothing
{
    internal static class Helper<T>
    {
        internal static T getData(int count,string prifix = "")
        {
            string[] name = { "Males", "Name", "James", "Robert", "John", "Michael", "David", "William", "Richard", "Joseph", "Thomas", "Charles", "Christopher", "Daniel", "Matthew", "Anthony", "Mark", "Donald", "Steven", "Paul", "Andrew", "Joshua", "Kenneth", "Kevin", "Brian", "George", "Timothy", "Ronald", "Edward", "Jason", "Jeffrey", "Ryan", "Jacob", "Gary", "Nicholas", "Eric", "Jonathan", "Stephen", "Larry", "Justin", "Scott", "Brandon", "Benjamin", "Samuel", "Gregory", "Alexander", "Frank", "Patrick", "Raymond", "Jack", "Dennis", "Jerry", "Tyler", "Aaron", "Jose", "Adam", "Nathan", "Henry", "Douglas", "Zachary", "Peter", "Kyle", "Ethan", "Walter", "Noah", "Jeremy", "Christian", "Keith", "Roger", "Terry", "Gerald", "Harold", "Sean", "Austin", "Carl", "Arthur", "Lawrence", "Dylan", "Jesse", "Jordan", "Bryan", "Billy", "Joe", "Bruce", "Gabriel", "Logan", "Albert", "Willie", "Alan", "Juan", "Wayne", "Elijah", "Randy", "Roy", "Vincent", "Ralph", "Eugene", "Russell", "Bobby", "Mason", "Philip", "Louis" };
            string[] firstName = { "Mr.", "John", "" };
            string[] lastName = { "Stoll","Verlice", "Adler", "Huxley", "Ledger", "Hayes", "Ford" };
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupiitemt non proident, sunt in culpa qui officia deserunt mollit anim id est laborum";
            string[] phoneNo = { "+8801910010011", " (555) 555-1234" , "0854141404" };
            string[] address = { "3014 Union Street" };
            string[] city = { "Seattle" };
            string[] state = { "Washington" };
            string[] zipcode = { "98116" };

            Random rand = new Random();
            var item = Activator.CreateInstance<T>();
            PropertyInfo[] propertyInfos = item.GetType().GetProperties();

            for (int i = 0; i < propertyInfos.Length; i++)
            {
                var propertyNeme = propertyInfos[i].Name.ToLower();
                if (propertyNeme.Equals("id"))
                {
                    propertyInfos[i].SetValue(item, count.ToString(), null);
                    continue;
                }
                else if (propertyNeme.Contains("id") && propertyInfos[i].GetType() == typeof(string))
                {
                    propertyInfos[i].SetValue(item,  string.Concat(prifix, count.ToString()), null);
                    continue;
                }
                else if (propertyNeme.Contains("id"))
                {
                    propertyInfos[i].SetValue(item, rand.Next(1000,9000), null);
                    continue;
                }
                else if ((propertyNeme.Contains("f") && propertyNeme.Contains("name")))
                {
                    int randomNo = rand.Next(0, firstName.Count());
                    propertyInfos[i].SetValue(item, firstName[randomNo], null);
                    continue;
                }
                else if ((propertyNeme.Contains("m") && propertyNeme.Contains("name")))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfos[i].SetValue(item, name[randomNo], null);
                    continue;
                }
                else if (propertyNeme.Contains("l") && propertyNeme.Contains("name"))
                {
                    int randomNo = rand.Next(0, lastName.Count());
                    propertyInfos[i].SetValue(item, lastName[randomNo], null);
                    continue;
                }
                else if (propertyNeme.Contains("name"))
                {
                    int randomNo = rand.Next(0, name.Count());
                    propertyInfos[i].SetValue(item, name[randomNo], null);
                    continue;
                }
                else if (propertyNeme.Contains("age"))
                {
                    int randomNo = rand.Next(0, 100);
                    propertyInfos[i].SetValue(item, randomNo.ToString(), null);
                    continue;
                }
                else if ((propertyNeme.Contains("phone") || propertyNeme.Contains("mobile") || propertyNeme.Contains("contact")) && propertyInfos[i].GetType() == typeof(string))
                {
                    int randomName = rand.Next(0, phoneNo.Count());
                    propertyInfos[i].SetValue(item, phoneNo[randomName], null);
                    continue;
                }
                else if ((propertyNeme.Contains("address")) && propertyInfos[i].GetType() == typeof(string))
                {
                    int randomName = rand.Next(0, address.Count());
                    propertyInfos[i].SetValue(item, address[randomName], null);
                    continue;
                }
                else if ((propertyNeme.Contains("city")) && propertyInfos[i].GetType() == typeof(string))
                {
                    int randomName = rand.Next(0, city.Count());
                    propertyInfos[i].SetValue(item, city[randomName], null);
                    continue;
                }
                else if ((propertyNeme.Contains("state")) && propertyInfos[i].GetType() == typeof(string))
                {
                    int randomName = rand.Next(0, state.Count());
                    propertyInfos[i].SetValue(item, state[randomName], null);
                    continue;
                }
                else if ((propertyNeme.Contains("zipcode")) && propertyInfos[i].GetType() == typeof(string))
                {
                    int randomName = rand.Next(0, zipcode.Count());
                    propertyInfos[i].SetValue(item, zipcode[randomName], null);
                    continue;
                }
                else
                {
                    var propertyType = propertyInfos[i].GetType();
                    if (propertyInfos[i].GetType() == typeof(int))
                    {
                        int random = rand.Next(0, name.Count());
                        propertyInfos[i].SetValue(item, random, null);
                        continue;
                    }
                    else if (propertyType == typeof(decimal))
                    {
                        decimal random = new decimal(rand.NextDouble());
                        propertyInfos[i].SetValue(item, random, null);
                        continue;
                    }
                    else if (propertyType == typeof(string))
                    {
                        propertyInfos[i].SetValue(item, loremIpsum, null);
                        continue;
                    }
                    else
                    {
                        propertyInfos[i].SetValue(item, null, null);
                        continue;
                    }
                }
            }
           
            return (T)item;
        }
    }
}
