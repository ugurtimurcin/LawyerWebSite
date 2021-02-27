using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Member.Controllers
{
    [Area("Member")]
    [Authorize(Roles =("Member"))]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            
            return View(user.Adapt<AppUserEditDto>());
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(user.Adapt<AppUser>());
                TempData["Success"] = "Bilgileriniz <strong>başarılı</strong> bir şekilde güncellenmiştir."; 
                return View();
            }
            return View();
        }

        public IActionResult UpdatePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePassword(AppUserUpdatePasswordDto model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Şifreniz <strong>başarılı</strong> bir şekilde güncellenmiştir.";
                        return RedirectToAction("Index", "Profile", new { area = "Member" });
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View();
        }
    }
}
