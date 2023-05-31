using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Google_ToDo.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
