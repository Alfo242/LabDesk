using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabDeskData.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LabDeskData.Controllers
{
    public class LoginController : Controller
    {
        private LabDeskDbContext db = new LabDeskDbContext();
        // GET: /<controller>/
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(int digit1,int digit2,int digit3)
        {
            var passkey = digit1*100 + digit2*10 + digit3;
            var teacher = db.Teachers.Where(x => x.Passkey == passkey).FirstOrDefault();
            if (teacher != null)
            {
                return RedirectToAction("Admin","Admin");
            }
            return View();
        }
    }
}

