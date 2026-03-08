using Microsoft.AspNetCore.Mvc;
using FBZ.Encyclopedia.Web.Models;

namespace FBZ.Encyclopedia.Web.Controllers
{
    public class ComicsController : Controller
    {
        public IActionResult Index()
        {
            var comics = new List<ComicRecord>();

            var titlesPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/titles.csv");

            var lines = System.IO.File.ReadAllLines(titlesPath).Skip(1);

            foreach (var line in lines)
            {
                var parts = line.Split(',');

                comics.Add(new ComicRecord
                {
                    Title = parts[1]
                });
            }

            return View(comics);
        }
    }
}