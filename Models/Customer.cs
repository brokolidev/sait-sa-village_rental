using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VillageRentalsPrototype.Models
{
    class Customer
    {
        public Customer()
        {
            
        }

        public int Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public Customer(int id, string lastName, string firstName, string phone, string email)
        {
            Id = id;
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
            Email = email;
        }


        // for creating 
        public Customer(string lastName, string firstName, string phone, string email)
        {
            LastName = lastName;
            FirstName = firstName;
            Phone = phone;
            Email = email;
        }

    }
}
