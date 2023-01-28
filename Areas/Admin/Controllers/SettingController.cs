using Microsoft.AspNetCore.Mvc;
using Studio.Data;

namespace Studio.Areas.Admin.Controllers
{
    public class SettingController : Controller
    {
        private readonly DataContext _dataContext;

        public SettingController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
