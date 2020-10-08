using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodingChallengeAsp.Models;
using System.Net.Http;

namespace CodingChallengeAsp.Controllers
{
    public class QuoteController : Controller
    {
        public IActionResult Index()
        {
            IEnumerable<ApiTest> fxRates = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://sheetlabs.com/IND/rv");
                var responseTask = client.GetAsync("");

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readJob = result.Content.ReadAsAsync<IList<ApiTest>>();
                    readJob.Wait();
                    fxRates = readJob.Result;
                }
                else
                {
                    fxRates = Enumerable.Empty<ApiTest>();
                    ModelState.AddModelError(string.Empty, "Server error, you are doomed...");
                }
            }

            return View(fxRates);

        }
    }
}
