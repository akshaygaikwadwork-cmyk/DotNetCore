using e_commerce_ModelClass.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_ModelClass.Controllers
{
    public class HomeController : Controller
    {

        [Route("/order")]
        public IActionResult Index(Order order)
        {
            //if (!ModelState.IsValid)
            //{
            //    var errors = ModelState.Values
            //                            .SelectMany(v => v.Errors)
            //                            .Select(e => e.ErrorMessage)
            //                            .ToList();

            //    return BadRequest(new { Errors = errors });
            //}

            //// Validate InvoicePrice
            //var totalCost = order.Products.Sum(p => p.Price * p.Quantity);
            //if (order.InvoicePrice != totalCost)
            //{
            //    return BadRequest(new { Errors = new[] { "InvoicePrice doesn't match with the total cost of the specified products in the order." } });
            //}

            //// Generate Order Number
            //order.OrderNo = new Random().Next(1000, 9999);
            //return Json(new { NewOrderNumber = order.OrderNo });

            //OR
            //Udemy-

            //if there are any validation errors (as per data annotations)
            if (!ModelState.IsValid)
            {
                string messages = string.Join("\n", ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));

                //semd HTTP 400 response with error messages
                return BadRequest(messages);
            }

            //generate a random order number between 1 and 99999
            Random random = new Random();
            int randomOrderNumber = random.Next(1, 99999);

            //return HTTP 200 response with order number
            return Json(new { orderNumber = randomOrderNumber });
        }
    }
}
