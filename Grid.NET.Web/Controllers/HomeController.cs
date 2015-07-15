using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Grid.NET.Infrastructure.Implementations;
using Grid.NET.Web.Infrastructure.Implementations;
using Grid.NET.Web.Infrastructure.Interfaces;
using Grid.NET.Web.Models;

namespace Grid.NET.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomer _customer;

        public HomeController()
        {
            _customer = new CustomerRepo();
        }

        public ActionResult Index()
        {

            HomeViewModel model = new HomeViewModel
            {
                ApplicationName = "Grid Helper",
                Customers = _customer.GetCustomers()
            };


            return View(model);
        }
    }
}