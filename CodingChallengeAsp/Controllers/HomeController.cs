using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodingChallengeAsp.Models;
using CodingChallengeAsp.Data;

namespace CodingChallengeAsp.Controllers
{
    public class HomeController : Controller
    {
        private readonly FootballContext _context;

        public HomeController(FootballContext context)
        {
            _context = context;
        }

        public IActionResult Index(string search)
        {
            return View(_context.Player.Where(x => x.FirstName.Contains(search) || search == null).ToList());
        }

    }
}
