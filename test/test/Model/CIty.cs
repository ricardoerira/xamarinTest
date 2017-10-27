using System;
namespace test.Model
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }

        public City(int id, string name)
        {
            this.id = id;
            this.name = name;
        }
        public override string ToString()
        {
            return string.Format("{0}", name);

        }
    }
}
