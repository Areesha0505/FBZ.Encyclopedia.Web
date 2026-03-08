using Microsoft.AspNetCore.Mvc;
using FBZ.Encyclopedia.Web.Models;
using System.IO;

namespace FBZ.Encyclopedia.Web.Controllers
{
    public class ComicsController : Controller
    {
        public IActionResult Index()
        {
            var comics = new List<ComicRecord>();

            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/titles.csv");

            var lines = System.IO.File.ReadAllLines(path).Skip(1);

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