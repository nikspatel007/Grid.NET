using System.Collections.Generic;
using Grid.NET.Web.Models;

namespace Grid.NET.Web.Infrastructure.Interfaces
{
    public interface ICustomer
    {
        List<Customer> GetCustomers();
    }
}