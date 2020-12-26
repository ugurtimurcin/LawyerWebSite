using LawyerWebSite.Business.Interfaces;
using LawyerWebSite.WebUI.Areas.Admin.Models;
using LawyerWebSite.WebUI.EmailService;
using LawyerWebSite.WebUI.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LawyerWebSite.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IEmailReceiver _emailReceiver;
        private readonly ICustomLogger _customLogger;
        public HomeController(IEmailReceiver emailReceiver, ICustomLogger customLogger)
        {
            _emailReceiver = emailReceiver;
            _customLogger = customLogger;
        }
        public IActionResult Index()
        {
            ViewBag.Title = "Anasayfa";
            TempData["Active"] = "home";
            return View();
        }
        [Route("/iletisim")]
        public IActionResult Contact()
        {
            ViewBag.Title = "İletişim";
            TempData["Active"] = "contact";
            return View();
        }
        
        [HttpPost]
        [Route("/iletisim")]
        public async Task<IActionResult> Contact(ContactModel model)
        {
            
            if (ModelState.IsValid)
            {
                var htmlBody = $"<strong>İsim Soyisim:</strong> {model.Name} {model.SurName} <br/><strong>E-Posta:</strong> {model.Email} <br/><br/> <strong>İçerik:</strong> {model.Content}";
                await _emailReceiver.EmailReceiverAsync("mailreceiver@example.com", model.Topic, htmlBody);
                TempData["Mail"] = "Mesajınız başarılı bir şekilde gönderilmiştir. Tarafınıza en kısa zamanda dönüş yapılacaktır.";
                return RedirectToAction("Contact", "Home");
            }
            return View(model);
        }

        public IActionResult Error()
        {
            ViewBag.Title = "Hata";
            var exceptionHandler = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _customLogger.LogError($"Hatanın oluştuğu yer: {exceptionHandler.Path}" +
                $"\nHatanın mesajı: {exceptionHandler.Error.Message}" +
                $"\nStack Trace: {exceptionHandler.Error.StackTrace}");
            return View();
        }
    }
}
