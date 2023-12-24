using Demo.BL.Helper;
using Demo.BL.Models;
using Demo.DAL.Extend;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser>userManager,SignInManager<ApplicationUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        #region Registration (sign up)

        [HttpGet]
        public IActionResult Registration()
        {

            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Registration(RegistrationVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new ApplicationUser() {

                        UserName = model.Email,
                        Email = model.Email,
                        IsAgree=model.IsAgree
                    
                    };

                   var result= await userManager.CreateAsync(user,model.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Login");
                    } else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("",item.Description);
                        }
                    }

                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }
            
        }
        #endregion


        #region login (sign in)


        [HttpGet]
        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult>  Login(LoginVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);
                   var result=  await signInManager.PasswordSignInAsync(user,model.Password,model.RememberMe,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError("","Invalid usename and Password");
                    }
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        #endregion


        #region Logoff(sign out)


        [HttpPost]
        public async Task<IActionResult> Logoff()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login","Account");
        }


        #endregion

        #region forget password


        [HttpGet]
        public IActionResult ForgetPassword()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPasswordAsync(ForgetPassswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);

                        var passwordResetLink = Url.Action("RestPassword", "Account", new { Email = model.Email, Token = token }, Request.Scheme);

                        MailSender.MailSend(new MailVM() {Mail=model.Email,Title= "ResetPassword",Message= passwordResetLink });

                        //logger.Log(LogLevel.Warning, passwordResetLink);

                        return RedirectToAction("ConfirmForgetPassword");
                    }

                    return RedirectToAction("ConfirmForgetPassword");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [HttpGet]
        public IActionResult ConfirmForgetPassword()
        {

            return View();
        }



        #endregion

        #region Rest Password

        [HttpGet]

        public IActionResult RestPassword(string Email,string Token)
        {

            return View();
        
        }


        [HttpPost]
        public async Task<IActionResult> RestPasswordAsync(RestPasswordVM model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(model.Email);

                    if (user != null)
                    {
                        var result = await userManager.ResetPasswordAsync(user, model.Token, model.Password);

                        if (result.Succeeded)
                        {
                            return RedirectToAction("ConfirmRestPassword");
                        }

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }

                    return RedirectToAction("ConfirmRestPassword");
                }
                return View(model);
            }
            catch (Exception ex)
            {
                return View(model);
            }

        }

        [HttpGet]

        public IActionResult ConfirmRestPassword()
        {

            return View();

        }

        #endregion
    }
}
