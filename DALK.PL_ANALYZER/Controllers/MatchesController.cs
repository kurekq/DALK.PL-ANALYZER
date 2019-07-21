using DALK.PL_ANALYZER.DB.FAKE;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;
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
        public ViewResult Index()
        {
            const string DEFAULT_FILTER_ICON = "mdi mdi-basketball";
            MatchesModelView matchesMV = new MatchesModelView();

            if (matchesMV.Matches == null)
            {
                FakeDB db = new FakeDB();
                List<Match> matches = db.GetMatches().ToList<Match>();
                matchesMV = new MatchesModelView(matches);

                List<IFilterData> allLeagues = db.GetLeagues().ToList<IFilterData>();
                EmptyFilterDataItem leagueDefault = new EmptyFilterDataItem("Każda liga", DEFAULT_FILTER_ICON);
                allLeagues.Add(leagueDefault);

                List<IFilterData> allSeasons = db.GetSeasons().ToList<IFilterData>();
                EmptyFilterDataItem seasonDefault = new EmptyFilterDataItem("Każdy sezon", DEFAULT_FILTER_ICON);
                allSeasons.Add(seasonDefault);

                List<IFilterData> allGroups = db.GetGroups().ToList<IFilterData>();
                EmptyFilterDataItem groupDefault = new EmptyFilterDataItem("Każda grupa", DEFAULT_FILTER_ICON);
                allGroups.Add(groupDefault);

                List<IFilterData> allTeams = db.GetTeams().ToList<IFilterData>();
                EmptyFilterDataItem teamDefault = new EmptyFilterDataItem("Każdy zespół", DEFAULT_FILTER_ICON);
                allTeams.Add(teamDefault);

                EmptyFilterDataItem stageDefault = new EmptyFilterDataItem("Każda faza rozgrywek", DEFAULT_FILTER_ICON);
                IEnumerable<IFilterData> stageFilters = new List<IFilterData>()
                {
                    stageDefault,
                    new ConstantFilterData()
                    {
                        Icon = null,
                        Selected  = false,
                        Text = "Playoff",
                        Value = "PlayOff"
                    },
                    new ConstantFilterData()
                    {
                        Icon = null,
                        Selected  = false,
                        Text = "Faza zasadnicza",
                        Value = "GroupStage"
                    }
                };


                GridFilter leagueFilter = new GridFilter(allLeagues, leagueDefault, "matchLeagues");
                GridFilter seasonFilter = new GridFilter(allSeasons, seasonDefault, "matchSeasons");
                GridFilter groupFilter = new GridFilter(allGroups, groupDefault, "matchGroups");
                GridFilter teamFilter = new GridFilter(allTeams, teamDefault, "matchTeams");
                GridFilter stageFilter = new GridFilter(stageFilters, stageDefault, "matchStages");

                List<GridFilter> allFilters = new List<GridFilter>();
                allFilters.Add(leagueFilter);
                allFilters.Add(seasonFilter);
                allFilters.Add(groupFilter);
                allFilters.Add(teamFilter);
                allFilters.Add(stageFilter);

                matchesMV.AllFiters = allFilters;
            }
            return View(matchesMV);
        }

        [HttpPost]
        public ActionResult FilteredIndex(JsonJavascriptAnswer jsonAnswer)
        {
            MatchesModelView matchesMV = new JavaScriptSerializer().Deserialize< MatchesModelView >(jsonAnswer.Json);
            return PartialView("Index", matchesMV);
        }

    }
}