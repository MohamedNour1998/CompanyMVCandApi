using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Demo.BL.Models;
using Demo.BL.Helper;

namespace Demo.Controllers
{
    public class MailController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(MailVM model)
        {
            try {
                
                TempData["Msg"] = MailSender.MailSend(model);
                return View();
            } catch(Exception ex)
            {
                TempData["Msg"] = MailSender.MailSend(model);
                return View();
            }
           
        }
    }
}
