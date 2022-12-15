using Microsoft.AspNetCore.Mvc;

namespace LybraryManagementSystem.WebAPI.Controllers
{
    public class BookInstanceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
