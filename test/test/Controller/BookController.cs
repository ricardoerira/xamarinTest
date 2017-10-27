using System;
using System.Collections.Generic;
using System.Linq;
using test.Data;
using test.Model;

namespace test.Controller
{
    public class BookController
    {
        RepositoryList repositoryList;

        public BookController(RepositoryList repositoryList)
        {
            this.repositoryList = repositoryList;
        }

        public bool availableBook(Flight flight, string name, string age, string identification)
        {
            List<Flight> flights = repositoryList.flights.Where(i => i.from.name == (flight.from.name))
                                                  .Where(i => i.to.name == (flight.to.name))
                                                 .Where(i => i.dateTime == (flight.dateTime)).ToList();
            if(flights.Count()>3){
                return false;

            }
            else{
                return true;
            }
        }

        public bool validateAge ( string age)
        {
            if (int.Parse(age)> 18)
            {
                return false;

            }
            else
            {
                return true;
            }
        }

        public void createBook(Flight flight, string name, string age, string identification)
        {
            Client client;
            List<Client> clientList = this.repositoryList.clients.Where(i => i.identification == (int.Parse(identification))).ToList();
                                
            if(clientList.Count() > 0)
            {
                client = clientList[0];
            }
            else{
                client = new Client(int.Parse(identification), name, int.Parse(age));
                this.repositoryList.clients.Add(client);
            }

            Book book = new Book(repositoryList.books.Count(), flight, client);
            this.repositoryList.books.Add(book);
            
        }
    }
}
