using System;
namespace test.Util
{
    public class Validates
    {
        public Validates()
        {
        }
        public static bool validateBook(string name, string age, string identification )
        {
            if(name == null || age == null || identification == null)
            {
                return false;
            }
            else{
                return true;
            }
            
        }
        public static bool validateSearch(string from, string to)
        {
            if (from == null || to == null )
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
