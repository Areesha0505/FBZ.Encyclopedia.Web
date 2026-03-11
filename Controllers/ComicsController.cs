using Microsoft.AspNetCore.Mvc;
using FBZ.Encyclopedia.Web.Models;

namespace FBZ.Encyclopedia.Web.Controllers
{
    public class ComicsController : Controller
    {
        public IActionResult Index(string search, string sortOrder, string genre)
        {
            var comics = new List<ComicRecord>();

            var titlesPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/Data/titles.csv"
            );

            var recordsPath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot/Data/records.csv"
            );

            var titleLines = System.IO.File.ReadAllLines(titlesPath).Skip(1).ToList();
            var recordLines = System.IO.File.ReadAllLines(recordsPath).Skip(1).ToList();

            for (int i = 0; i < titleLines.Count && i < recordLines.Count; i++)
            {
                var titleParts = titleLines[i].Split(',');
                var recordParts = recordLines[i].Split(',');

                if (titleParts.Length < 2)
                    continue;

                comics.Add(new ComicRecord
                {
                    Title = titleParts[1],
                    Character = "Unknown",
                    Genre = recordParts.Length > 3 ? recordParts[3] : "Unknown"
                });
            }

            if (!string.IsNullOrEmpty(search))
            {
                comics = comics
                    .Where(c => c.Title.Contains(search, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrEmpty(genre))
            {
                comics = comics
                    .Where(c => c.Genre == genre)
                    .ToList();
            }

            if (sortOrder == "desc")
            {
                comics = comics.OrderByDescending(c => c.Title).ToList();
            }
            else
            {
                comics = comics.OrderBy(c => c.Title).ToList();
            }

            return View(comics);
        }
    }
}