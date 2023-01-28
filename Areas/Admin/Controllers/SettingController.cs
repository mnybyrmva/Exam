using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Studio.Data;
using System.Data;

namespace Studio.Areas.Admin.Controllers
{
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
            return View();
        }
    }
}
