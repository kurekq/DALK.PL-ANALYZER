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
        [HttpGet]
        public ViewResult Index(MatchesRawFilterValues parameters)
        {          
            MatchesModelView matchesMV = new MatchesModelViewFactory(parameters).matchesMV;
            return View(matchesMV);
        }
    }
}