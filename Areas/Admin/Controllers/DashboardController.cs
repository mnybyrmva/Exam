using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Studio.Data;
using Studio.Models;

namespace Studio.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, DataContext dataContext, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CreateAdmin()
        {

        }
    }
}
