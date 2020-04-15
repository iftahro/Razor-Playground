using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Playground.Controllers
{
    public class ImageController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ImageController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertImage(IFormFile image)
        {
            if (image == null)
                return Redirect("/Image/Index");

            string folder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            if (TryValidateModel(!Directory.Exists(folder)))
            {
                Directory.CreateDirectory(folder);
            }

            string path = Path.Combine(folder, image.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                image.CopyTo(fileStream);
            }

            ViewBag.Image = image.FileName;

            return View();
        }
    }
}