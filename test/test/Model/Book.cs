using System;
namespace test.Model
{
    public class Book
    {
        public int id { get; set; }
        public Flight flight { get; set; }
        public Client client { get; set; }


        public Book(int id, Flight flight,Client client)
        {
            this.id = id;
            this.flight = flight;
            this.client = client;
        }
        public override string ToString()
        {
            return string.Format("{0} ",flight);
        }
    }
}
