using System;
using System.Collections.Generic;
using test.Model;

namespace test.Data
{
    public class RepositoryList
    {
        public  List<Client> clients { get; set; } 
        public  List<City> cities { get; set; }
        public  List<Flight> flights { get; set; }
        public  List<Book> books { get; set; }

        public RepositoryList()
        {
            clients = new List<Client>();
            cities = new List<City>();
            flights = new List<Flight>();
            books = new List<Book>();
            clients.Add(new Client(1, "andres gomez", 21));
            clients.Add(new Client(2, "felipe lopez", 31));
            clients.Add(new Client(3, "jaime pineda", 35));

            cities.Add(new City(1, "New York"));
            cities.Add(new City(2, "Miami"));
            cities.Add(new City(3, "Medellin"));
            cities.Add(new City(4, "Bogota"));
            cities.Add(new City(5, "Buenos Aires"));
            cities.Add(new City(6, "Madrid"));

            flights.Add(new Flight(cities[0], cities[1], new DateTime(2017, 10, 27, 10, 30, 0), 150));
            flights.Add(new Flight(cities[0], cities[1], new DateTime(2017, 10, 27, 05, 30, 0), 100));
            flights.Add(new Flight(cities[0], cities[1], new DateTime(2017, 10, 27, 06, 30, 0), 100));
            flights.Add(new Flight(cities[0], cities[2], new DateTime(2017, 11, 27, 12, 30, 0), 200));
            flights.Add(new Flight(cities[0], cities[3], new DateTime(2017, 11, 27, 01, 00, 0), 200));
            flights.Add(new Flight(cities[2], cities[1], new DateTime(2017, 12, 27, 09, 30, 0), 100));
            flights.Add(new Flight(cities[1], cities[5], new DateTime(2017, 12, 27, 07, 00, 0), 300));
            flights.Add(new Flight(cities[1], cities[4], new DateTime(2017, 12, 27, 17, 30, 0), 400));

            books.Add(new Book(1, flights[0], clients[0]));
            books.Add(new Book(2, flights[0], clients[1]));
            books.Add(new Book(1, flights[1], clients[2]));
            books.Add(new Book(1, flights[3], clients[2]));
            books.Add(new Book(1, flights[2], clients[2]));
            
        }
      
    }
}
