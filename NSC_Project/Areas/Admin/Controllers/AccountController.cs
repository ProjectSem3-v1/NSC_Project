using Microsoft.AspNetCore.Mvc;

namespace NSC_Project.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
