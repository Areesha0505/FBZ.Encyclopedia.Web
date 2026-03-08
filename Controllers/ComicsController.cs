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
            var recordsPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Data/records.csv");

            var titleLines = System.IO.File.ReadAllLines(titlesPath).Skip(1).ToList();
            var recordLines = System.IO.File.ReadAllLines(recordsPath).Skip(1).ToList();

            for (int i = 0; i < titleLines.Count && i < recordLines.Count; i++)
            {
                var titleParts = titleLines[i].Split(',');
                var recordParts = recordLines[i].Split(',');

                comics.Add(new ComicRecord
                {
                    Title = titleParts[1],
                    Year = int.TryParse(recordParts[2], out int year) ? year : 0
                });
            }

            return View(comics);
        }
    }
}