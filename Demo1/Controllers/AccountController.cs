using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return Content("login page");
        }

        public IActionResult GetUserInfo(int id)
        {
            return Content("user info  id = " + id);
        }
    }
}
