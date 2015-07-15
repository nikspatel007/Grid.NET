using System.Collections.Generic;
using Grid.NET.Web.Infrastructure.Interfaces;
using Grid.NET.Web.Models;

namespace Grid.NET.Web.Infrastructure.Implementations
{
    public class CustomerRepo : ICustomer
    {
        public List<Customer> GetCustomers()
        {
            return StaticData.GetCustomers();
        }
    }
}