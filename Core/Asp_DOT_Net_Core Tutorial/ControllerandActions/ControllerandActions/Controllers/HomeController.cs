using Microsoft.AspNetCore.Mvc;

namespace ControllerandActions.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // you can return here ViewResult,PartialResult,JsonResult etc...
        }

        public ActionResult About()
        {
            return View(); // you can return here ViewResult,PartialResult,JsonResult etc...
        }

        /*Note - IActionResult and ActionResult -  returns all ViewResult,PartialResult,JsonResult etc...
                 this are the child class and IActionResult and ActionResult are the parent class*/

        public ContentResult Msg()
        {
            return Content("This msg comming from ContentResult method");
        }

        public JsonResult MsgJson()
        {
            string Fname = "Akshay";
            string Lname = "Gaikwad";
            return Json(new { Fname = Fname, Lname = Lname });
        }

        public ViewResult ViewResultMethod()
        {
            return View("ViewMethod","Home"); // or you can use any of view index/about/contact
        }
        public EmptyResult Empty()
        {
            return new EmptyResult();
        }

        public PartialViewResult PartialViewResult()
        {
            return PartialView("_par");
        }

        public string DisplayMsg()
        {
            return "Welcome to Akshay Application";
        }

        public int DisplayVal(int id)
        {
            return id;
        }
    }
}
