using System.Reflection;

namespace Nothing
{
    public static class Generate<T> where T : class
    {
        public static List<T> Anything(int noOfItem)
        {
            List<T> items = new List<T>();

            for (int i = 0; i < noOfItem; i++)
            {
                var item = Helper<T>.getData(i);
                items.Add(item);
            }
            return items;
        }  
    }
}