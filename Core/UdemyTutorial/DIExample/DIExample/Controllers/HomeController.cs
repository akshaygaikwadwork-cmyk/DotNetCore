using DIExample.Interface;
using DIExample.Model;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace DIExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly TransientGuidGenerator _transient1;
        private readonly TransientGuidGenerator _transient2;
        private readonly ScopedGuidGenerator _scoped1;
        private readonly ScopedGuidGenerator _scoped2;
        private readonly SingletonGuidGenerator _singleton1;
        private readonly SingletonGuidGenerator _singleton2;

        public HomeController(
            TransientGuidGenerator transient1, TransientGuidGenerator transient2,
            ScopedGuidGenerator scoped1, ScopedGuidGenerator scoped2,
            SingletonGuidGenerator singleton1, SingletonGuidGenerator singleton2)
        {
            _transient1 = transient1;
            _transient2 = transient2;
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
        }

        public IActionResult Index()
        {
            var model = new GuidViewModel();

            model.TransientGuid1 = _transient1.GetGuid();
            model.TransientGuid2 = _transient2.GetGuid();
            model.TransientSame = _transient1.GetGuid() == _transient2.GetGuid();

            model.ScopedGuid1 = _scoped1.GetGuid();
            model.ScopedGuid2 = _scoped2.GetGuid();
            model.ScopedSame = _scoped1.GetGuid() == _scoped2.GetGuid();

            model.SingletonGuid1 = _singleton1.GetGuid();
            model.SingletonGuid2 = _singleton2.GetGuid();
            model.SingletonSame = _singleton1.GetGuid() == _singleton2.GetGuid();


            return View(model);
        }
    }
}
