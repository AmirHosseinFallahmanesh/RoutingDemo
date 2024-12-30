using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    public class BlogController : Controller
    {
        
        public IActionResult Index(int year,string month,int day)
        {
            return Content($"news for {year}/{month}/{day}");
        }
    }
}
