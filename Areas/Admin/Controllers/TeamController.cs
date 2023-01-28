using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.Data;
using Studio.Models;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeamController : Controller
    {
        private readonly DataContext _dataContext;

        public TeamController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.teams.AsQueryable();
            return View(query.ToList());
        }
        public IActionResult Create()
        {
            ViewBag.team=_dataContext.teams;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Team team)
        {
            if (team.ImageFile != null)
            {
                if(team.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "You can only download files smaller than 2 MB");
                    return View();
                }
                if (team.ImageFile.ContentType=="image/jpeg"&& team.ImageFile.ContentType == "image/png")
                {
                    ModelState.AddModelError("ImageFile", "you can only download files in jpeg and png format");
                    return View();
                }
                
            }
            if (!ModelState.IsValid) return NotFound(); 
            _dataContext.teams.Add(team);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            Team team = _dataContext.teams.FirstOrDefault(x => x.Id == id);
            if (team == null) { return NotFound(); }
            return View(team);
        }
        [HttpPost]
        public IActionResult Update(Team team)
        {
            Team existteam = _dataContext.teams.FirstOrDefault(x => x.Id == team.Id);
            if (existteam == null) return NotFound();
            if (existteam.ImageFile != null)
            {
                if (existteam.ImageFile.Length > 2097152)
                {
                    ModelState.AddModelError("ImageFile", "You can only download files smaller than 2 MB");
                    return View();
                }
                if (existteam.ImageFile.ContentType == "image/jpeg" && existteam.ImageFile.ContentType == "image/png")
                {
                    ModelState.AddModelError("ImageFile", "you can only download files in jpeg and png format");
                    return View();
                }

            }
            
            existteam.Profession.Id = team.Profession.Id;
            existteam.FullName = team.FullName;
            existteam.Linkedin = team.Linkedin;
            existteam.Twitter = team.Twitter;
            existteam.Facebook = team.Facebook;

            if (!ModelState.IsValid) return NotFound();
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {

            Team team = _dataContext.teams.FirstOrDefault(x => x.Id == id);
            if (team == null) return NotFound();
            _dataContext.Remove(team.Id);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
