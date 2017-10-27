using System;
namespace test.Model
{
    public class Flight
    {

        public City from { get; set; }
        public City to { get; set; }
        public DateTime dateTime { get; set; }
        public int price { get; set; }


        public Flight(City from, City to, DateTime dateTime,int price)
        {
            this.from = from;
            this.to = to;
            this.dateTime = dateTime;
            this.price = price;
        }
        public override string ToString()
        {
            return string.Format("{0} - {1} {2}", from, to, dateTime);
        }
    }
}
