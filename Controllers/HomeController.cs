using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetCore_FileUpload.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using System.Threading.Tasks;
using Firebase.Auth;
using System.Threading;
using Firebase.Storage;
using System;

namespace AspNetCore_FileUpload.Controllers
{
    public class HomeController : Controller
    {
        // Firebasestoragenet packed install 
        // FirebaseAuthentication.net packed install
        // Configure Firebase
        private readonly ILogger<HomeController> _logger;
        private readonly IHostEnvironment _env;
        private string _dir;
        public HomeController(ILogger<HomeController> logger, IHostEnvironment env)
        {
            _logger = logger;
            _env = env;
            _dir = _env.ContentRootPath;
        }
        public IActionResult Index() => View();
        public IActionResult SingleFile(IFormFile file)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"uploads/file.png"), FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(fileStream);
                TempData["UploadFile"] = "Success";
            }
            return RedirectToAction("Index");
        }
        public IActionResult MultipleFiles(IEnumerable<IFormFile> files)
        {
            int i = 0;
            foreach (var file in files)
            {
                using (var fileStream = new FileStream(Path.Combine(_dir, $"uploads/file{i}.png"), FileMode.Create, FileAccess.Write))
                {
                    file.CopyTo(fileStream);
                    TempData["UploadFile"] = "Success";
                }
                i++;
            }
            return RedirectToAction("Index");
        }
        public IActionResult FileInModel(SomeForm someForm)
        {
            using (var fileStream = new FileStream(Path.Combine(_dir, $"uploads/{someForm.Name}.png"), FileMode.Create, FileAccess.Write))
            {
                someForm.File.CopyTo(fileStream);
                TempData["UploadFile"] = "Success";
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
