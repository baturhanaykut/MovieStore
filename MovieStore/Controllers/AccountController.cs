using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieStore_Application.Models.DTOs.AppUserDTOS;
using MovieStore_Application.Services.AppUserServices;

namespace MovieStore_Presentation.Controllers
{

    [Authorize] // Bu controller'daki Action'lara yetkisiz kişilerin istekte bulunmasını engellemiş olduruz.
    public class AccountController : Controller
    {
        private readonly IAppUserService _appUserService;

        public AccountController(IAppUserService appuserService)
        {
            _appUserService = appuserService;
        }


        [AllowAnonymous] //Actiona erişime izin verir.(Authorize ezip)
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) // Hali hazırda sistemde Authenticate olmuş bir kullanıcı varsa Register sayafını görünmesini engeller.
            {
                return RedirectToAction("Index", "");
            }
            //Eğer kullanıcı giriş yapmamış ise.
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Register(RegisterDTO registerDTO)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Register(registerDTO);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "");
                }

                foreach (var item in result.Errors)
                {
                    // Kayıt için bir model gönderdiğimiz hatalar var ise göstermek için kullanırız.
                    ModelState.AddModelError(string.Empty, item.Description);
                    TempData["Error"] = "Something went wrong ";
                }

            }
            return View();
        }

        [AllowAnonymous]
        public IActionResult Login(string returnUrl = "/")
        {   // Hali hazırda sistemde Authenticate olmuş bir kullanıcı varsa Login sayafını görünmesini engeller.
            if (User.Identity.IsAuthenticated)
            {
                //return RedirectToAction("Index", nameof(Areas.Member.Controllers.HomeController));
                return RedirectToAction("Index", "Admin/Movie");
                //"return RedirectToAction("Index", "");
            }
            ViewData["ReturnUrl"] = returnUrl;

            //Eğer kullanıcı giriş yapmamış ise
            return View();
        }

        [HttpPost, AllowAnonymous]
        public async Task<IActionResult> Login(LoginDTO loginDTO, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _appUserService.Login(loginDTO);

                if (result.Succeeded)
                {
                    //return RedirectToLocal(ReturnUrl);
                    return RedirectToAction("Index", "Admin/Movie");
                }
            }
            return View(loginDTO);
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                //return RedirectToAction("Index", nameof(Areas.Member.Controllers.HomeController));
                return RedirectToAction("Index", "");
            }

        }

        public async Task<IActionResult> LogOut()
        {
            await _appUserService.LogOut();
            return RedirectToAction("Index", "Home"); // Aynı dizindeki Home Controller'daki Index Actiona'a git
        }

        public async Task<IActionResult> Edit(string username)
        {
            if (username != null)
            {
                UpdateProfileDTO user = await _appUserService.GetByUserName(username);
                return View(user);
            }
            else if (username == "")
            {
                username = HttpContext.User.Identity.Name;
                UpdateProfileDTO user = await _appUserService.GetByUserName(username);
                return View(user);
            }
            else
            {
                //return RedirectToAction("Index", nameof(Areas.Member.Controllers.HomeController));
                return RedirectToAction("Index", "");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Edit(UpdateProfileDTO model)
        {


            if (ModelState.IsValid)
            {
                try
                {
                    await _appUserService.UpdateUser(model);

                }
                catch (Exception)
                {
                    TempData["Error"] = "Something went rong";

                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                TempData["Error"] = "Your profile hasn't been updated";
                return View();
            }

        }
        // To Do View Profile Page (ProfileDetails Action ve View)

    }


}
