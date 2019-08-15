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
        public ViewResult Index(int? matchSeasonsId = null, int? matchLeaguesId = null, int? matchTeamsId = null, int? matchGroupId = null, string matchStagesId = null)
        {          
            MatchesModelView matchesMV = new MatchesModelViewFactory(matchSeasonsId, matchLeaguesId, matchTeamsId, matchGroupId, matchStagesId).matchesMV;
            return View(matchesMV);
        }
    }
}