using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_core_test.Models;
using Stripe;
using dotnet_core_test.core;
using System.Collections.Generic;

namespace dotnet_core_test.Controllers
{
    public class HomeController : Controller
    {

        public List<Product> GetProducts()
        {
            return new List<Product>(){
                new Product("1", "Sebastian", "Köp en vän under havet", "~/images/seb.gif"), 
                new Product("2", "Pumba", "köp en ko", "~/images/pumba.png"), 
                new Product("3", "Timon", "köp en surrogat", "~/images/Timon.png")};
        }
        public IActionResult Index()
        {
            var ProductModel = GetProducts();
            return View(ProductModel);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to this awesome stufzz.";

            return View();
        }

        public IActionResult Product(string Id) 
        {
            ViewData["id"] = Id; 
            var products = GetProducts();
            var model = products.Find(p => p.Id == Id);
            return View(model);
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Charge(string  stripeEmail, string stripeToken, string stripePhone)
        {
            var customers = new StripeCustomerService();
            var charges = new StripeChargeService();

            var Basket = new Basket();
            Basket.Amount = 1000;

            var customer = customers.Create(new StripeCustomerCreateOptions {
              Email = stripeEmail,
              SourceToken = stripeToken
            });

            var charge = charges.Create(new StripeChargeCreateOptions {
              Amount = Basket.Amount,
              Description = "Sample Charge",
              Currency = "usd",
              CustomerId = customer.Id
            });

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
