using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PuzzleGame.Business.Abstract;
using PuzzleGame.Entities.Concrate;
using PuzzleGame.WebUI.Models;
using static System.Net.Mime.MediaTypeNames;

namespace PuzzleGame.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private static byte[] setImage;
        private readonly ILogger<HomeController> _logger;

        private readonly IPuzzleService _puzzleService;


        public HomeController(ILogger<HomeController> logger, IPuzzleService puzzleService)
        {
            _puzzleService = puzzleService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var returnData = await _puzzleService.GetAllAsync();
            return View(returnData);
        }

        [HttpGet]
        public async Task<IActionResult> SavePuzzle(string id = null)
        {
            if (id != null)
            {

                ViewData["isDataCome"] = true;
                var datas = await _puzzleService.GetByIdAsync(id);
                setImage = datas.puzzlepicture;
                return View(datas);
            }
            ViewData["isDataCome"] = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SavePuzzle(Puzzless model, IFormFile formImage)
        {

            if (model.id != null)
            {
                if (formImage != null)
                {
                    var path = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot\\img",
                                formImage.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formImage.CopyToAsync(stream);
                    }

                    var image = SixLabors.ImageSharp.Image.Load(path);

                    model.puzzlepicture = ImageProp.ImageToByteArray(image);
                }
                else
                {
                    model.puzzlepicture = setImage;
                }
                await _puzzleService.UpdateAsync(model, model.id);
                return RedirectToAction("Index");
            }
            else
            {
                if (formImage != null)
                {
                    var path = Path.Combine(
                                Directory.GetCurrentDirectory(), "wwwroot\\img",
                                formImage.FileName);
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await formImage.CopyToAsync(stream);
                    }

                    var image = SixLabors.ImageSharp.Image.Load(path);

                    model.puzzlepicture = ImageProp.ImageToByteArray(image);
                    await _puzzleService.CreateAsync(model);
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Lütfen resim alanini boş geçmeyiniz");
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> DeleteImages(string id)
        {
            await _puzzleService.DeleteAsync(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
