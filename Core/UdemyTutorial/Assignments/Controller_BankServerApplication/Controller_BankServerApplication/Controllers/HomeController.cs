using Microsoft.AspNetCore.Mvc;

namespace Controller_BankServerApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor _httpContext;
        public HomeController(IHttpContextAccessor httpContext)
        {
            _httpContext = httpContext;
        }

        [Route("/")]
        public string Index()
        {
            if (_httpContext?.HttpContext?.Request.Method == "GET")
            {
                return "Welcome to the Best Bank";

            }
            else
            {
                return "";
            }
        }
        [Route("/account-details")]
        public JsonResult BankAccountDetails()
        {
            if (_httpContext?.HttpContext?.Request.Method == "GET")
            {
                object Req = "{accountNumber = 1001, accountHolderName = \"Example Name\", currentBalance = 5000}";

                return Json(Req);

            }
            else
            {
                return Json(null);
            }
        }

        [Route("/account-statement")]
        public VirtualFileResult? BankSatetment()
        {
            if (_httpContext?.HttpContext?.Request.Method == "GET")
            {
                return File("/docs/Aniket_BioData.pdf", "application/pdf");
            }
            else
            {
                return null;
            }
        }

        [Route("get-current-balance/{accountNumber:int}")]
        public IActionResult? BankBalance()
        {
            if (_httpContext?.HttpContext?.Request.Method == "GET")
            {
                if (!_httpContext.HttpContext.Request.RouteValues.ContainsKey("accountNumber"))
                {
                    _httpContext.HttpContext.Response.StatusCode = 404;
                    return BadRequest("Account Number should be supplied");
                }
                else
                {
                    int accountNum = Convert.ToInt32(_httpContext.HttpContext.Request.RouteValues["accountNumber"]);
                    if (accountNum == 1001)
                    {
                        return Ok("5000");
                    }
                    else
                    {
                        _httpContext.HttpContext.Response.StatusCode = 400;
                        return BadRequest("Account Number should be 1001");
                    }
                }
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
