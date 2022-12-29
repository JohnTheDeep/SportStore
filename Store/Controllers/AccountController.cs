using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Models.ViewModels;
using System.Threading.Tasks;

namespace Store.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> usrMngr,SignInManager<IdentityUser> sginMngr)
        {
            this.userManager = usrMngr;
            this.signInManager = sginMngr;
            ViewBag.Count = userManager.
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View(new LoginModel {ReturnUrl = returnUrl});
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel _lmodel)
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(_lmodel.Name);
                if(user != null)
                {
                    await signInManager.SignOutAsync();
                    if((await signInManager.PasswordSignInAsync(user,_lmodel.Password,false,false)).Succeeded)
                    {
                        
                        return Redirect(_lmodel?.ReturnUrl ?? "/Admin/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid login or password!");
            return View(_lmodel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
    }
}
