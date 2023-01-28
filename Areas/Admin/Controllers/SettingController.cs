using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.Data;
using Studio.Models;
using System.Data;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "SuperAdmin")]

    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;

        public SettingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View(_dataContext.settings.ToList());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Setting setting)
        {

            if (!ModelState.IsValid) { return NotFound(); }
            _dataContext.settings.Add(setting);
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {

            Setting setting = _dataContext.settings.FirstOrDefault(x => x.Id == id);
            if (setting == null) { return NotFound(); }
            return View(setting);
        }
        [HttpPost]
        public IActionResult Update(Setting setting)
        {
            Setting existsetting = _dataContext.settings.FirstOrDefault(x => x.Id == setting.Id);
            if (existsetting == null) return NotFound();
            existsetting.Key = setting.Key;
            _dataContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
