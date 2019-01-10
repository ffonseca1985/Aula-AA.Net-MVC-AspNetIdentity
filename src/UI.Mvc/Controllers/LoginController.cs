using Microsoft.Owin.Security;
using Services.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UI.Mvc.Models;

namespace UI.Mvc.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private AppSignInManager _AppSignInManager;
        private IAuthenticationManager _autenticationManager;
        public LoginController()
        {
            _autenticationManager = System.Web.HttpContext.Current.GetOwinContext().Authentication;
            _AppSignInManager = new AppSignInManager(_autenticationManager);
        }

        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Index(LoginViewModel login, string returnUrl)
        {
            var user = await _AppSignInManager.UserManager.FindAsync(login.UserName, login.Password);

            if (user != null)
            {
                await _AppSignInManager.SignInAsync(user, true, login.RememberMe);

                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction("Index", "Home");
                else
                    if (returnUrl == "/")
                        return RedirectToAction("Index", "Home");
                    else
                        return RedirectToAction("Index", returnUrl.Replace("/", ""));
            }

            ViewBag.erro = "Usuário não encontrado";

            return View();
        }

        [HttpGet]
        public ActionResult Loggof()
        {
            _autenticationManager.SignOut();
            return new RedirectResult("Index");
        }
    }
}