using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Studio.Data;
using Studio.Models;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProfessionController : Controller
    {
        private readonly DataContext _dataContext;

        public ProfessionController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            var query = _dataContext.professions.AsQueryable();
            return View(query.ToList());
        }
        public IActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult Create(Profession profession)
        {
            
            if (!ModelState.IsValid){ return NotFound(); }
            _dataContext.professions.Add(profession);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            
            Profession profession = _dataContext.professions.FirstOrDefault(x => x.Id == id);
            if (profession == null) { return NotFound(); }
            return View(profession);
        }
        [HttpPost]
        public IActionResult Update(Profession profession)
        {
            Profession existprofession = _dataContext.professions.FirstOrDefault(x => x.Id == profession.Id);
            if (existprofession == null) return NotFound();
            existprofession.Name = profession.Name;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Delete(int id)
        {
            Profession profession = _dataContext.professions.FirstOrDefault(x => x.Id == id);
            if (profession == null) return NotFound(); 
            _dataContext.Remove(profession);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
