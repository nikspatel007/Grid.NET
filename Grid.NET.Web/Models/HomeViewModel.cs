using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Infrastructure.Interfaces;

namespace Grid.NET.Web.Models
{
    public class HomeViewModel
    {
        public string ApplicationName { get; set; }

        public List<Customer> Customers { get; set; }
    }
}