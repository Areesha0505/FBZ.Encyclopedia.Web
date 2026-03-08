using FBZ.Encyclopedia.Web.Models;
using Microsoft.AspNetCore.Mvc;

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
            Year = int.Parse(recordParts[2])
        });
    }

    return View(comics);
}