using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identify.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult Profile()
        {
            return View();
        }
    }
}
