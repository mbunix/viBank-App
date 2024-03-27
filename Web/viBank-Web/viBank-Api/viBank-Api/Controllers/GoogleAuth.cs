using Microsoft.AspNetCore.Mvc;

namespace viBank_Api.Controllers
{
    public class GoogleAuth : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
