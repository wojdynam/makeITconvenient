using makeITconvenient.Models;
using Microsoft.AspNetCore.Mvc;

namespace makeITconvenient.Controllers
{
    public class ContactDetailsController : Controller
    {
       public IActionResult Update(ContactDetailsDto contactDto)
        {
            return View();
        }
    }
}
