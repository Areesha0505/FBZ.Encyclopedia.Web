using Microsoft.AspNetCore.Mvc;
using FBZ.Encyclopedia.Web.Models;

namespace FBZ.Encyclopedia.Web.Controllers
{
    public class ComicsController : Controller
    {
        public IActionResult Index(string search, string sortOrder)
        {
            var comics = new List<ComicRecord>();

            var titlesPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/Data/titles.csv"
            );

            var titleLines = System.IO.File.ReadAllLines(titlesPath).Skip(1).ToList();

            foreach (var line in titleLines)
            {
                var parts = line.Split(',');

                if (parts.Length < 2)
                    continue;

                comics.Add(new ComicRecord
                {
                    Title = parts[1],
                    Character = "Unknown"
                });
            }

            if (!string.IsNullOrEmpty(search))
            {
                comics = comics
                    .Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                comics = comics
                    .Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }


            return View(comics);
        }
    }
}