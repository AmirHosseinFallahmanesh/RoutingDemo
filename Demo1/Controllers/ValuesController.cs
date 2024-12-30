using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        [Route("info/{id:int}")]
        public int Get(int id)
        {
            return id;
        }

        [HttpGet]
        [Route("user/{phoneNumber:regex(^09\\d{{9}})}/{mail:regex(^[[a-z A-Z 0-9 . _ % + -]]+@[[a-z A-Z 0-9 . -]]+\\.[[a-z A-Z]]{{2,}}$)}")]
        public IActionResult Info(string phoneNumber,string mail)
        {
            //var regex = new Regex(@"^[a-z A-Z 0-9 . _ % + -]+@[a-z A-Z 0-9 . -]+\.[a-z A-Z]{2,}$");
            //if (!regex.IsMatch(mail))
            //{
            //    return NotFound();
            //}
            return Content("phone : " + phoneNumber + " mail " + mail);
;        }
    }
}
