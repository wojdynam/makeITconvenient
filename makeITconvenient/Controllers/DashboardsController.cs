using Microsoft.AspNetCore.Mvc;

namespace makeITconvenient.Controllers
{
    public class DashboardsController : Controller
    {
        public IActionResult AdminDashboard() => View();
        public IActionResult HRDashboard() => View();
        public IActionResult UserDashboard() => View();
    }
}
