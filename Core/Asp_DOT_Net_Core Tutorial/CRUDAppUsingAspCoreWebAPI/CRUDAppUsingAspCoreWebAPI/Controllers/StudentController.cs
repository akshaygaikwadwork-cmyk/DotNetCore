using CRUDAppUsingAspCoreWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CRUDAppUsingAspCoreWebAPI.Controllers
{
    public class StudentController : Controller
    {
        private readonly IConfiguration _configuration;

        public StudentController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        private string GetAPIURL()
        {
            string URL = _configuration.GetValue<string>("URL");
            return URL;
        }

        private HttpClient client = new HttpClient();

        public IActionResult Index()
        {
            string URL = GetAPIURL();

            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(URL).Result;
            if (response.IsSuccessStatusCode)
            {
                //Getting JSON value in string variable
                string result = response.Content.ReadAsStringAsync().Result;
                //Converting JSON to List<Student> using Newtonsoft.Json package with DeserializeObject method
                var data = JsonConvert.DeserializeObject<List<Student>>(result);
                if (data != null)
                {
                    students = data;
                }

            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student StudmodelObj)
        {
            string url = GetAPIURL();
            //serializeobject from Student to Json and stroe in string and passing to WebAPI with json request body
            string data = JsonConvert.SerializeObject(StudmodelObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //In HttpResponse it accept Json/XML format content so use the StringContent 
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["InsertMessage"] = "Student added successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            string url = GetAPIURL();

            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                //Getting JSON value in string variable
                string result = response.Content.ReadAsStringAsync().Result;
                //Converting JSON to List<Student> using Newtonsoft.Json package with DeserializeObject method
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost]
        public IActionResult Edit(Student StudmodelObj)
        {
            string url = GetAPIURL();
            //serializeobject from Student to Json and stroe in string and passing to WebAPI with json request body
            string data = JsonConvert.SerializeObject(StudmodelObj);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            //In HttpResponse it accept Json/XML format content so use the StringContent 
            HttpResponseMessage response = client.PutAsync(url + StudmodelObj.id, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["UpdateMessage"] = "Student upated successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            string url = GetAPIURL();

            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                //Getting JSON value in string variable
                string result = response.Content.ReadAsStringAsync().Result;
                //Converting JSON to List<Student> using Newtonsoft.Json package with DeserializeObject method
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            string url = GetAPIURL();

            Student student = new Student();
            HttpResponseMessage response = client.GetAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                //Getting JSON value in string variable
                string result = response.Content.ReadAsStringAsync().Result;
                //Converting JSON to List<Student> using Newtonsoft.Json package with DeserializeObject method
                var data = JsonConvert.DeserializeObject<Student>(result);
                if (data != null)
                {
                    student = data;
                }
            }
            return View(student);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfimed(int id)
        {
            string url = GetAPIURL();
            //In HttpResponse it accept Json/XML format content so use the StringContent 
            HttpResponseMessage response = client.DeleteAsync(url + id).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["DeleteMessage"] = "Student deleted successfully!!!";
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
