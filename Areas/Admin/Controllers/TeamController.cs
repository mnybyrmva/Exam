using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.Data;
using Studio.Helpers;
using Studio.Models;
using System.Data;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]

    public class TeamController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _env;

        public TeamController(DataContext dataContext, IWebHostEnvironment env)
        {
            _dataContext = dataContext;
            _env = env;
        }
        public IActionResult Index()
        {
            var query = _dataContext.teams.AsQueryable().Include(x => x.Profession);
            return View(query.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.Profession = _dataContext.professions.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            ViewBag.Profession = _dataContext.professions.ToList();
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType == "image/jpeg" && team.ImageFile.ContentType == "image/png")
                {
                    ModelState.AddModelError("ImageFile", "you can upload jpeg or png files");
                    return View();
                }
                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "you can upload lower than 2Mb");
                    return View();
                }
                team.ImageUrl = FileManager.SaveFile(team.ImageFile, _env.WebRootPath, "uploads/teams");

            }
            else
            {
                ModelState.AddModelError("ImageFile", "Required");

            }
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            _dataContext.teams.Add(team);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            ViewBag.Profession = _dataContext.professions.ToList();
            Team team = _dataContext.teams.Find(id);
            if (team == null)
            {
                return NotFound();
            }
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            ViewBag.Profession = _dataContext.professions.ToList();
            Team existteam = _dataContext.teams.Find(team.Id);
            if (existteam == null)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                return View(team);
            }
            if (team.ImageFile != null)
            {
                if (team.ImageFile.ContentType == "image/jpeg" && team.ImageFile.ContentType == "image/png")
                {
                    ModelState.AddModelError("ImageFile", "you can upload jpeg or png files");
                    return View();
                }
                if (team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "you can upload lower than 2Mb");
                    return View();
                }
                string deletepath = Path.Combine(_env.WebRootPath, "uploads/teams", existteam.ImageUrl);
                if (System.IO.File.Exists(deletepath))
                {
                    System.IO.File.Delete(deletepath);
                }
                existteam.ImageUrl = FileManager.SaveFile(team.ImageFile, _env.WebRootPath, "uploads/teams");

            }
            existteam.ProfessionId = team.ProfessionId;
            existteam.FullName = team.FullName;
            existteam.Twitter = team.Twitter;
            existteam.Linkedin = team.Linkedin;
            existteam.Facebook = team.Facebook;
            _dataContext.SaveChanges();
            return RedirectToAction("index");


        }
        public IActionResult Delete(int id)
        {
            Team team = _dataContext.teams.Find(id);
            if (team is null) return NotFound();

            string deletepath = Path.Combine(_env.WebRootPath, "uploads/teams", team.ImageUrl);
            if (System.IO.File.Exists(deletepath))
            {
                System.IO.File.Delete(deletepath);
            }
            _dataContext.teams.Remove(team);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
