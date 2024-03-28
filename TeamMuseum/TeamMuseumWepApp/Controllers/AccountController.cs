using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Globalization;
using System.Text;
using TeamMuseum.Services.Dtos;
using TeamMuseum.Services.Services;

namespace TeamMuseumWepApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IUserService _userService;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (HttpClient client = new HttpClient())
                {
                    string jsonTicket = JsonConvert.SerializeObject(userRegister);
                    var content = new StringContent(jsonTicket, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(_configuration.GetValue<string>("ApiUrl:BaseUrl") + "Authorization/Register", content);

                    if (response.IsSuccessStatusCode)
                    {                        
                        return View("Login");
                    }
                    return View();
                }                
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLogin userLogin)
        {
            ValidateUserResult loginresult = new ValidateUserResult();
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                if (!ModelState.IsValid)
                {
                    return View();
                }
                using (HttpClient client = new HttpClient())
                {
                    string jsonTicket = JsonConvert.SerializeObject(userLogin);
                    var content = new StringContent(jsonTicket, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await client.PostAsync(_configuration.GetValue<string>("ApiUrl:BaseUrl") + "Authorization/Login", content);

                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();                        
                        loginresult = JsonConvert.DeserializeObject<ValidateUserResult>(data);
                        Response.Cookies.Append("access_token", loginresult.UserInfo.Token);
                        return Ok(loginresult);
                    }
                }
                return RedirectToAction("Index", "Home",loginresult);
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
                return View();
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();
            Response.Cookies.Delete("access_token");
            return View(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return RedirectToAction("Login");
        }
    }
}
