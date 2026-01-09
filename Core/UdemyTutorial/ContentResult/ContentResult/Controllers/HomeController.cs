using Microsoft.AspNetCore.Mvc;

namespace ContentResult.Controllers
{
    public class HomeController : Controller
    {
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
        }

        //VirtualFileResult
        //This is only use when your files present in wwwroot folder. it will by default consider that your files location is in wwwroot folder.
        //This is good
        //[Route("file-download")]
        public VirtualFileResult downloadFile()
        {
            return new VirtualFileResult("/images/Aniket_BioData.pdf", "application/pdf");
            //OR
            //return File("/images/Aniket_BioData.pdf", "application/pdf");
        }

        //PhysicalFileResult
        //Use this when your files present outside the wwwroot folder.

        //[Route("file-download2")]
        public PhysicalFileResult downloadFile2()
        {
            return new PhysicalFileResult(@"G:\Study\AspDotNet\UdemyTutorial\ContentResult\ContentResult\wwwroot\images\Aniket_BioData.pdf", "application/pdf");
            //OR
            //return PhysicalFile(@"G:\Study\AspDotNet\UdemyTutorial\ContentResult\ContentResult\wwwroot\images\Aniket_BioData.pdf", "application/pdf");
        }

        //FileContenResult
        //Represent the file from the byte[]
        //used this when your file is is byte in response body.
        [Route("file-download3")]
        public IActionResult downloadFile3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"G:\Study\AspDotNet\UdemyTutorial\ContentResult\ContentResult\wwwroot\images\Aniket_BioData.pdf");
            return new FileContentResult(bytes, "application/pdf");
            //OR
            //return File(bytes, "application/pdf");
        }

    }
}
