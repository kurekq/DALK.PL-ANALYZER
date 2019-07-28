using DALK.PL_ANALYZER.DB.FAKE;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;
using DALK.PL_ANALYZER.Models.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DALK.PL_ANALYZER.Controllers
{
    public class MatchesController : Controller
    {

        // GET: Matches
        [HttpGet]
        public ViewResult Index(int? seasonId = null, int? seasonLeagueId = null, int? teamLeagueId = null, int? groupSeasonId = null, string stage = null)
        {
            MatchesModelView matchesMV = new MatchesModelViewFactory(seasonId, seasonLeagueId, teamLeagueId, groupSeasonId, stage).matchesMV;
            return View(matchesMV);
        }
    }
}