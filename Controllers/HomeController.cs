using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet_core_test.Models;
using Stripe;
using dotnet_core_test.core;

namespace dotnet_core_test.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Welcome to this awesome stufzz.";

            return View();
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
