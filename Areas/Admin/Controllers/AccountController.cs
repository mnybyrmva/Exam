using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Studio.Areas.Admin.ViewModels;
using Studio.Data;
using Studio.Models;

namespace Studio.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly DataContext _dataContext;

        public AccountController(SignInManager<AppUser> signInManager, IHttpContextAccessor httpContextAccessor, DataContext dataContext)
        {
            _signInManager = signInManager;
            _httpContextAccessor = httpContextAccessor;
            _dataContext = dataContext;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(AdminLoginViewModel adminLoginVM)
        {
            return View();
        }
    }
}
