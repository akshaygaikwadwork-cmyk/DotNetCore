using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;

namespace PRactice3_Swagger.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private Dictionary<string, string> GetAllStudentList()
        {
            Dictionary<string, string> studList = new Dictionary<string, string>();

            studList.Add("Name", "Akshay");
            studList.Add("Age", "21");
            studList.Add("Desgination", "Senior Software Developer");
            studList.Add("Location", "Mumbai");

            return studList;
        }

        [HttpGet]
        public Dictionary<string, string> GetStudentList()
        {
            return GetAllStudentList();
        }


    }
}
