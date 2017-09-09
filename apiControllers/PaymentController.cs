using Microsoft.AspNetCore.Mvc;
using dotnet_core_test.Models;
using System;
using Stripe;

[Route("api/[controller]")]
public class PaymentController : Controller {

    [HttpGet("")] //Matches GET api/admin <-- Would also work with [HttpGet]
    public IActionResult Get() {
        return Ok();
    }

    [HttpGet("{id}")] //Matches GET api/admin/5
    public IActionResult Get(int id) {
        return Ok("value");
    }

    [HttpPost("")]
    public IActionResult Post([FromBody] Payment payment) {
        // your secret key: remember to change this to your live secret key in production
        // See your keys here: https://dashboard.stripe.com/account/apikeys
        // Token is created using Stripe.js or Checkout!
        // Get the payment token submitted by the form:
        var customers = new StripeCustomerService();
    var charges = new StripeChargeService();

    var customer = customers.Create(new StripeCustomerCreateOptions {
      Email = "stripeEmail",
      SourceToken = "stripeToken"
    });

    var charge = charges.Create(new StripeChargeCreateOptions {
      Amount = 500,
      Description = "Sample Charge",
      Currency = "usd",
      CustomerId = customer.Id
    });
        return Ok("hello boys");
    }

    //...other code removed for brevity
}
