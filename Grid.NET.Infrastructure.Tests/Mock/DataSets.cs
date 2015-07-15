using System;
using System.Collections.Generic;
using Grid.NET_Infrastructure.Tests.Models;

namespace Grid.NET_Infrastructure.Tests.Mock
{
    public static class DataSets
    {
        public static List<Customer> GetCustomers(int listSize = 100)
        {
            List<Customer> list = new List<Customer>();

            Random random = new Random();

            for(int i=1 ; i<= listSize ; i++)
            {
              Customer customer = new Customer()
              {
                  Id = i,
                  FirstName = GetRandomFirstName(i % 5),
                  LastName = GetRandomLastName(i % 5),
                  DateOfBirth = DateTime.Today.AddDays(i *  listSize),
                  CurrentBalance = random.Next(-500 , 50000000),
                  IsActive =  (random.Next(1 , 10) % 2 == 0)
              };   

              list.Add(customer);
            }

            return list;
        }

        #region Private functions.

        private static string GetRandomFirstName(int i)
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

        private static string GetRandomLastName(int i)
        {
            List<string> namesList = new List<string>()
            {
                "Tribbiani",
                "Vador",
                "Pate",
                "Smith",
                "Black"
            };

            return namesList[i];
        }
    }

    #endregion
   
}