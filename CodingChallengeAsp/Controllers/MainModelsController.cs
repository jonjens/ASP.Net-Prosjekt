using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingChallengeAsp.Models;
using CodingChallengeAsp.Data;
using Microsoft.EntityFrameworkCore;

namespace CodingChallengeAsp.Controllers
{
    public class MainModelsController : Controller
    {
        public IActionResult Index()
        {

            return View();
        }
    }
}
