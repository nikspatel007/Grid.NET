using System;
using System.Collections.Generic;
using Grid.NET.Web.Models;

namespace Grid.NET.Web.Infrastructure
{
    public static class StaticData
    {
        public static List<Customer> GetCustomers()
        {
            List<Customer> list = new List<Customer>();

            Random random = new Random();
            int listSize = random.Next(15, 150);

            for(int i=1 ; i<= listSize ; i++)
            {
              Customer customer = new Customer()
              {
                  Id = i,
                  FirstName = GetRandomFirstName(random.Next(1 , 100) % 5),
                  LastName = GetRandomLastName(random.Next(1, 100) % 5),
                  DateOfBirth = DateTime.Today.AddDays(i *  listSize),
                  CurrentBalance = random.Next(-500 , 50000000),
                  IsActive =  (random.Next(1 , 10) % 2 == 0)
              };   

              list.Add(customer);
            }

            return list;
        }


        public static string GetRandomFirstName(int i)
        {
            List<string> namesList = new List<string>()
            {
                "Joey",
                "Darth",
                "Nik",
                "John",
                "Jane"
            };

            return namesList[i];
        }

        public static string GetRandomLastName(int i)
        {
            List<string> namesList = new List<string>()
            {
                "Tribbiani",
                "Vador",
                "Patel",
                "Smith",
                "Black"
            };

            return namesList[i];
        }
    }
}