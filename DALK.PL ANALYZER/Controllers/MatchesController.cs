using DALK.PL_ANALYZER.Models.DB;
using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DALK.PL_ANALYZER.Controllers
{
    public class MatchesController : Controller
    {
        // GET: Matches
        public ViewResult Index()
        {
            List<Match> matches = new FakeDB().GetMatches().ToList<Match>();
            return View(matches);
        }
    }
}