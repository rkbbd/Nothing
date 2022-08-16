using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Nothing.data;
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
        internal static T getData(int count, string dataPath = "", string prifix = "")
        {
            try
            {
                string path = dataPath.Length > 2 ? dataPath : Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"data\seed.txt");
                var jsonText = File.ReadAllText(path);
                var data = JsonConvert.DeserializeObject<JToken>(jsonText).ToList();

                var item = Activator.CreateInstance<T>();

                if (data != null)
                {
                    Random rand = new Random();
                    PropertyInfo[] propertyInfos = item.GetType().GetProperties();

                    for (int i = 0; i < propertyInfos.Length; i++)
                    {
                        var propertyNeme = propertyInfos[i].Name.ToLower();
                        var propertyType = propertyInfos[i].PropertyType;

                        var matchedData = data.FirstOrDefault(f => propertyNeme.Equals(f.Path));
                        var containsData = data.FirstOrDefault(f => propertyNeme.Contains(f.Path));

                        if ((matchedData != null && matchedData.HasValues) || (containsData != null && containsData.HasValues))
                        {
                            var foundData = matchedData != null ? matchedData : containsData != null ? containsData : null;
                            var value = foundData.Children().Children().ToList();
                            int randomNo = rand.Next(0, value.Count());
                            var selectedValue = value[randomNo];

                            var dataType = selectedValue.Type.ToString();
                            if (propertyType.Name == dataType)
                            {
                                var convertedValue = Convert.ChangeType(selectedValue, propertyType);
                                propertyInfos[i].SetValue(item, convertedValue, null);
                            }
                            else
                            {
                                //var convertedValue = Convert.ChangeType(selectedValue, propertyType);
                                //propertyInfos[i].SetValue(item, convertedValue, null);
                            }
                            
                        }
                        

                        
                    }
                }

                //if (data != null)
                //{
                //    Random rand = new Random();
                //    PropertyInfo[] propertyInfos = item.GetType().GetProperties();

                //    for (int i = 0; i < propertyInfos.Length; i++)
                //    {
                //        var propertyNeme = propertyInfos[i].Name.ToLower();
                //        if (propertyNeme.Equals("id"))
                //        {
                //            propertyInfos[i].SetValue(item, count+1, null);
                //            continue;
                //        }
                //        else if (propertyNeme.Contains("id") && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            propertyInfos[i].SetValue(item, string.Concat(prifix, count.ToString()), null);
                //            continue;
                //        }
                //        else if (propertyNeme.Contains("id"))
                //        {
                //            propertyInfos[i].SetValue(item, rand.Next(1000, 9000), null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("f") && propertyNeme.Contains("name")))
                //        {
                //            int randomNo = rand.Next(0, data.firstName.Count());
                //            propertyInfos[i].SetValue(item, data.firstName[randomNo], null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("m") && propertyNeme.Contains("name")))
                //        {
                //            int randomNo = rand.Next(0, data.name.Count());
                //            propertyInfos[i].SetValue(item, data.name[randomNo], null);
                //            continue;
                //        }
                //        else if (propertyNeme.Contains("l") && propertyNeme.Contains("name"))
                //        {
                //            int randomNo = rand.Next(0, data.lastName.Count());
                //            propertyInfos[i].SetValue(item, data.lastName[randomNo], null);
                //            continue;
                //        }
                //        else if (propertyNeme.Contains("name"))
                //        {
                //            int randomNo = rand.Next(0, data.name.Count());
                //            propertyInfos[i].SetValue(item, data.name[randomNo], null);
                //            continue;
                //        }
                //        else if (propertyNeme.Contains("age"))
                //        {
                //            int randomNo = rand.Next(0, 100);
                //            propertyInfos[i].SetValue(item, randomNo, null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("phone") || propertyNeme.Contains("mobile") || propertyNeme.Contains("contact")) && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            int randomName = rand.Next(0, data.phoneNo.Count());
                //            propertyInfos[i].SetValue(item, data.phoneNo[randomName], null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("address")) && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            int randomName = rand.Next(0, data.address.Count());
                //            propertyInfos[i].SetValue(item, data.address[randomName], null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("city")) && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            int randomName = rand.Next(0, data.city.Count());
                //            propertyInfos[i].SetValue(item, data.city[randomName], null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("state")) && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            int randomName = rand.Next(0, data.state.Count());
                //            propertyInfos[i].SetValue(item, data.state[randomName], null);
                //            continue;
                //        }
                //        else if ((propertyNeme.Contains("zipcode")) && propertyInfos[i].GetType() == typeof(string))
                //        {
                //            int randomName = rand.Next(0, data.zipcode.Count());
                //            propertyInfos[i].SetValue(item, data.zipcode[randomName], null);
                //            continue;
                //        }
                //        else
                //        {
                //            var propertyType = propertyInfos[i].GetType();
                //            if (propertyInfos[i].GetType() == typeof(int))
                //            {
                //                int random = rand.Next(0, data.name.Count());
                //                propertyInfos[i].SetValue(item, random, null);
                //                continue;
                //            }
                //            else if (propertyType == typeof(decimal))
                //            {
                //                decimal random = new decimal(rand.NextDouble());
                //                propertyInfos[i].SetValue(item, random, null);
                //                continue;
                //            }
                //            else if (propertyType == typeof(string))
                //            {
                //                propertyInfos[i].SetValue(item, data.loremIpsum, null);
                //                continue;
                //            }
                //            else
                //            {
                //                propertyInfos[i].SetValue(item, null, null);
                //                continue;
                //            }
                //        }
                //    }
                //}
                return (T)item;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
