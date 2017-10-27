using System;
namespace test.Model
{
    public class Client
    {
        public int identification { get; set; }
        public string name { get; set; }
        public int age { get; set; }

        public Client(int identification,string name,int age)
        {
            this.identification = identification;
            this.name = name;
            this.age = age;
        }
    }
}
