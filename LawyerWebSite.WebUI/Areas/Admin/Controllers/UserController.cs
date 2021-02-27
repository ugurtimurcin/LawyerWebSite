using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.Entities.Concrete.DTOs;
using LawyerWebSite.Entities.Concrete.Entities;
using LawyerWebSite.WebUI.EmailService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles ="Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly IAppUserService _userService;
        private readonly IEmailSender _emailSender;
        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IEmailSender emailSender, IAppUserService userService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _emailSender = emailSender;
            _userService = userService;
        }
        public IActionResult Index()
        {
            TempData["Active"] = "user";
            ViewBag.Title = "Kişiler";
            var users = _userService.GetUsersNonAdmin();
            var model = new List<AppUserListDto>();
            foreach (var user in users)
            {
                var userModel = new AppUserListDto()
                {
                    Id = user.Id,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    UserName = user.UserName,
                    Email = user.Email,
                    IsConfirmed = user.EmailConfirmed
                };
                model.Add(userModel);
            }
            return View(model);
        }

        public IActionResult Register()
        {
            TempData["Active"] = "user";
            ViewBag.Title = "Kişi Ekle";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserRegisterDto model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.UserName
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Member");
                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    var url = Url.Action("ConfirmAccount", "Dashboard", new { Area = "", userId = user.Id, token = code });
                    await _emailSender.EmailSenderAsycn(model.Email, $"Hesap Doğrulama", $"Lütfen hesabınızı onaylamak için <a href='websiteadress{url}'>buraya</a> tıklayınız!");
                    

                    return RedirectToAction("Index", "User", new { area = "Admin" });
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = _userManager.Users.FirstOrDefault(a => a.Id == id);
            await _userManager.DeleteAsync(user);

            return Json(null);
        }
    }
}
