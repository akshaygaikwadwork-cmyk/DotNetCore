using Microsoft.AspNetCore.Mvc;
using ModelState_Example.Models;

namespace ModelState_Example.Controllers
{
    public class HomeController : Controller
    {

        //FromRoute - /index/{age}/{name}
        //FromQuery - /index?age=21&name=23
        //FromForm - Pass Data into Body but select Form-Data 
        //If only pass as class then still it will work when you select Form-Data
        //FromBody - Use when you want json/xml data binding into our modelclass (byDefault Json is there)
        // If data come into xml then how to bind that xml into our modelclass - builder.Services.AddControllers().AddXmlSerializerFormatters();

        [Route("index")] // [Route("index/{age}/{name}")] 
        public IActionResult Index(/*[FromRoute]int? age,*//*[FromForm] */Person person)
        {
            if(!ModelState.IsValid)
            {
                string errrors = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).Select(err => err.ErrorMessage));
                //OR
                //string errrorsList = string.Join("\n", ModelState.Values.SelectMany(x => x.Errors).Select(err => err.ErrorMessage).ToList());
                //OR
                //List<string> errors = new List<string>();
                //foreach (var value in ModelState.Values)
                //{
                //    foreach (var error in value.Errors)
                //    {
                //        errors.Add(error.ErrorMessage);
                //    }
                //}
                //string errorList = string.Join("\n", errors);
                return BadRequest(errrors);
            }    
            return Content($"{person}");
        }
    }
}
