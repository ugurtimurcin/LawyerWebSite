using LawyerWebSite.Entities.Concretes;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using LawyerWebSite.WebUI.EmailService;
using LawyerWebSite.WebUI.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Controllers
{
    [AutoValidateAntiforgeryToken]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IEmailSender _emailSender;
        public DashboardController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
        }
        public IActionResult Index()
        {
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    if (await _userManager.IsEmailConfirmedAsync(user))
                    {
                        var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (result.Succeeded)
                        {
                            var role = await _userManager.GetRolesAsync(user);
                            if (role.Contains("Admin"))
                            {
                                return RedirectToAction("Index", "Home", new { area = "Admin" });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Home", new { area = "Member" });
                            }
                        }
                    }
                    else
                    {
                        ViewBag.Unconfirm = "Hesabınızı onaylıyınız!";
                    }
                    
                }
            }
            return View();
        }

        public IActionResult Logout()
        {
            _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Dashboard");
        }

        public IActionResult ForgotPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var code = await _userManager.GeneratePasswordResetTokenAsync(user);
                    var url = Url.Action("ResetPassword", "Dashboard", new
                    {
                        userId = user.Id,
                        token = code
                    });


                    await _emailSender.EmailSenderAsycn(model.Email, "Şifre Sıfırlama", $"Şifrenizi sıfırlamak için <a href='websiteadress{url}'>buraya</a> tıklayınız!");
                    ViewBag.Success = "İşlem başarılı bir şekilde gerçekleşti. E-postanızı kontrol ediniz!";
                    return View();
                }
            }
            ModelState.AddModelError("", "Bir sorun oluştu. Girdiğiniz e-posta adresinin doğru olduğundan emin olunuz!");
            return View(model);
        }

        public async Task<IActionResult> ConfirmAccount(int userId, string token)
        {
            if (token != null)
            {
                var user = _userManager.Users.FirstOrDefault(a => a.Id == userId);
                var result = await _userManager.ConfirmEmailAsync(user, token);
                if (result.Succeeded)
                {
                    ViewBag.Success = "Hesabınız başarılı bir şekilde doğrulanmıştır.";
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ViewBag.Error = $"{error.Description}";
                    }
                }
            }
            return View();
        }


        public IActionResult ResetPassword(string token)
        {
            if (token == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }
            var model = new ResetPasswordViewModel() { Token = token };

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Dashboard");
                    }
                }
            }
            ModelState.AddModelError("", "Bir hata oluştu!");
            return View(model);
        }
    }
}
