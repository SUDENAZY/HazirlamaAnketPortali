using Ankethazirlama.Models;
using Ankethazirlama.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace Ankethazirlama.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly ISurveyRepository _surveyRepository;

        public AdminController(ISurveyRepository surveyRepository)
        {
            _surveyRepository = surveyRepository;
        }

        // --------------------------
        // COOKIE LOGIN METODLARI
        // --------------------------

        // Login sayfası
        public IActionResult Login()
        {
            return View();
        }

        // Login işlemi
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Basit admin kontrol: kullanıcı adı "admin", şifre "1234"
            if (username == "admin" && password == "1234")
            {
                // Cookie oluştur
                HttpContext.Response.Cookies.Append("AdminLoggedIn", "true");
                return RedirectToAction("Index");
            }

            ViewBag.Error = "Hatalı kullanıcı adı veya şifre";
            return View();
        }

        // Logout işlemi
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("AdminLoggedIn");
            return RedirectToAction("Login");
        }

        // --------------------------
        // ADMIN SAYFALARI CRUD
        // --------------------------

        // 1) ANKET LİSTE
        public async Task<IActionResult> Index()
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            var surveys = await _surveyRepository.GetAllAsync();
            return View(surveys);
        }

        // 2) ANKET EKLE (GET)
        public IActionResult Create()
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            return View();
        }

        // 3) ANKET EKLE (POST)
        [HttpPost]
        public async Task<IActionResult> Create(Survey model)
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            model.CreatedDate = DateTime.Now;
            await _surveyRepository.AddAsync(model);
            await _surveyRepository.SaveAsync();

            return RedirectToAction("Index");
        }

        // 4) ANKET DÜZENLE (GET)
        public async Task<IActionResult> Edit(int id)
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null) return NotFound();

            return View(survey);
        }

        // 5) ANKET DÜZENLE (POST)
        [HttpPost]
        public async Task<IActionResult> Edit(Survey model)
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            _surveyRepository.Update(model);
            await _surveyRepository.SaveAsync();
            return RedirectToAction("Index");
        }

        // 6) ANKET SİL (AJAX ile kullanılacak)
        [HttpPost]
        public async Task<IActionResult> Delete(int id)
        {
            if (!Request.Cookies.ContainsKey("AdminLoggedIn"))
                return RedirectToAction("Login");

            var survey = await _surveyRepository.GetByIdAsync(id);
            if (survey == null) return NotFound();

            _surveyRepository.Delete(survey);
            await _surveyRepository.SaveAsync();

            return Ok(); // AJAX için
        }
    }
}
