using Microsoft.AspNetCore.Mvc;

namespace FBZ.Encyclopedia.Web.Controllers
{
    public class ComicsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
