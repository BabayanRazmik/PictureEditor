using Microsoft.AspNetCore.Mvc;
using PictureEditor.Models;

namespace PictureEditor.Controllers
{
    public class TransformController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
