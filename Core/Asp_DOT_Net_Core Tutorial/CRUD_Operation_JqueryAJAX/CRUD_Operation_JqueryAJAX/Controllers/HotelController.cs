using CRUD_Operation_JqueryAJAX.Attribute;
using CRUD_Operation_JqueryAJAX.Models;
using CRUD_Operation_JqueryAJAX.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using CRUD_Operation_JqueryAJAX.Attribute;

namespace CRUD_Operation_JqueryAJAX.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotel_Service _service;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HotelController(IHotel_Service service, IWebHostEnvironment webHostEnvironment)
        {
            _service = service;
            _webHostEnvironment = webHostEnvironment;
        }

        public async Task<IActionResult> GetHotelData()
        {
            var hotelDataList = await _service.getHotelDataList();
            if (hotelDataList != null)
            {
                return View(hotelDataList);
            }
            else
            {
                throw new Exception("failed to load hotel data");
            }

        }

        [HttpGet]
        public IActionResult CustomersOrders()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CustomersOrders(HotelModel modelObj)
        {
            if (ModelState.IsValid)
            {
                string fileName = UploadedFile(modelObj);
                int result = await _service.AddOrderItems(modelObj);
                if (result > 0)
                {
                    TempData["msg"] = "Data Inserted Succsessfully";
                    return RedirectToAction("GetHotelData", "Hotel");
                }
                else
                {
                    TempData["msg"] = "Data Inserted Failed";
                    return RedirectToAction("GetHotelData", "Hotel");
                }
            }
            else
            {
                return View();
            }
            
        }

        private string UploadedFile(HotelModel modelObj)
        {
            string uniqueFileName = string.Empty;

            if (modelObj.DishImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + modelObj.DishImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    modelObj.DishImage.CopyTo(fileStream);
                }
            }
            else
            {
                uniqueFileName = modelObj.DishImageName;
            }
            return uniqueFileName;
            throw new Exception("some thing went wrong with file upload");
        }


        [HttpGet]
        public async Task<IActionResult> EditCustomersOrderData(int custId)
        {
            if (custId > 0)
            {
                HotelModel model = new HotelModel();

                model = await _service.getOrderDetailsByCustId(custId);
                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return RedirectToAction("GetHotelData", "Hotel");
            }
            throw new Exception("Failed to get customer data");
        }


        [HttpPost]
        public async Task<IActionResult> EditCustomersOrderData(HotelModel modelObj)
        {
            if (ModelState.IsValid)
            {
                string fileName = UploadedFile(modelObj);
                modelObj.DishImageName = fileName;
                int result = await _service.UpdateOrderItems(modelObj);
                if (result > 0)
                {
                    TempData["msg"] = "Data Updated Succsessfully";
                    return RedirectToAction("GetHotelData", "Hotel");
                }
                else
                {
                    TempData["msg"] = "Data Updated Failed";
                    return RedirectToAction("GetHotelData", "Hotel");
                }
            }
            else
            {
                return View();
            }
            throw new Exception("Failed to data update");
        }

        public async Task<IActionResult> ViewOrderDetails(int custId)
        {
            if (custId > 0)
            {
                HotelModel model = new HotelModel();
                model = await _service.ViewOrderDetailsById(custId);
                if (model != null)
                {
                    return View(model);
                }
                else
                {
                    return NotFound();
                }
            }
            else
            {
                return NotFound();
            }
            throw new Exception("Failed to view customer order details");
        }

        public async Task<IActionResult> DeleteOrderItem(int custId)
        {
            int result = await _service.DeleteOrderItem(custId);
            if (result > 0)
            {
                TempData["msg"] = "Data Deleted Successfully";
                return RedirectToAction("GetHotelData", "Hotel");
            }
            else
            {
                TempData["msg"] = "Data has been already Deleted";
                return RedirectToAction("GetHotelData", "Hotel");
            }
            throw new Exception("Failed to delete customer order details");
        }
    }
}
