using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Northwind.Domain.Models;
using NorthwindContracts.Dto.Authentication;
using System.Threading.Tasks;

namespace Northwind.Web.Controllers
{
    
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto, string returnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View(userLoginDto);
            }

            //check valid email & password
            var result = await _signInManager.PasswordSignInAsync(
                userLoginDto.Email,
                userLoginDto.Password,
                userLoginDto.RememberMe,
                false
                );

            if (result.Succeeded)
            {
                return RedirectToLocal(returnUrl);
            }
            else
            {
                ModelState.AddModelError("","Invalid username or password");
                return View();
            }

        }

        private IActionResult RedirectToLocal (string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);

            }
            else
            {
                return RedirectToAction(nameof(HomeController.Index));
            }
        }

        [HttpGet] // get:mengirim data ke browser
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] // post:mengirim data ke server
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Register(UserRegistrationDto userRegistrationDto)
        {
            if(!ModelState.IsValid)
            {
                return View(userRegistrationDto);
            }

            // mapping user & dto
            var userModel = _mapper.Map<User>(userRegistrationDto);

            // insert user to db via identity
            var result = await _userManager.CreateAsync(userModel,userRegistrationDto.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.TryAddModelError(error.Code, error.Description);
                }

                return View(userRegistrationDto);
            }
            else
            {
                await _userManager.AddToRoleAsync(userModel, "Manager");
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }
    }
}
