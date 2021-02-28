using AutoMapper;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles =("Admin"))]
    public class ProfileController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public ProfileController(IMapper mapper, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            TempData["Active"] = "profile";

            return View(_mapper.Map<AppUserEditDto>(await _userManager.FindByNameAsync(User.Identity.Name)));
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserEditDto model)
        { 
            if (ModelState.IsValid)
            {
                await _userManager.UpdateAsync(_mapper.Map<AppUser>(await _userManager.FindByEmailAsync(model.Email)));
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
                   var result =  await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Şifreniz <strong>başarılı</strong> bir şekilde güncellenmiştir.";
                        return RedirectToAction("Index", "Profile", new { area = "Admin" });
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
