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
        private FakeDB db;
        private MatchesModelView matchesMV;
        private JsonJavascriptAnswer jsonAnswer;

        public MatchesController()
        {
            db = new FakeDB();
            List<Match> matches = db.GetMatches().ToList<Match>();
            matchesMV = new MatchesModelView(matches);

            LeaguesSeason leaguesSeason = db.GetLeaguesSeason();
            TeamsSeason teamSeason = db.GetTeamsSeason();
            Seasons seasons = db.GetSeasons();
            SeasonFilterData defaultSeason = seasons.GetDefaultSeason();

            List<IFilterData> allSeasons = seasons.GetSeasons().ToList<IFilterData>();
            EmptyFilterDataItem allSeasonFilter = new EmptyFilterDataItem("Każdy sezon", Configs.DEFAULT_FILTER_ICON, false);
            allSeasons.Add(allSeasonFilter);

            List<IFilterData> allLeagues = leaguesSeason.GetLeagueFilterData(defaultSeason).ToList<IFilterData>();
            EmptyFilterDataItem leagueDefault = new EmptyFilterDataItem("Każda liga", Configs.DEFAULT_FILTER_ICON);
            allLeagues.Add(leagueDefault);

            //List<IFilterData> allGroups = db.GetGroups().ToList<IFilterData>();
            //EmptyFilterDataItem groupDefault = new EmptyFilterDataItem("Każda grupa", Configs.DEFAULT_FILTER_ICON);
            //allGroups.Add(groupDefault);

            List<IFilterData> allTeams = teamSeason.GetTeamFilterData(defaultSeason).ToList<IFilterData>();
            EmptyFilterDataItem teamDefault = new EmptyFilterDataItem("Każdy zespół", Configs.DEFAULT_FILTER_ICON);
            allTeams.Add(teamDefault);

            EmptyFilterDataItem stageDefault = new EmptyFilterDataItem("Każda faza rozgrywek", Configs.DEFAULT_FILTER_ICON);
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
            GridFilter seasonFilter = new GridFilter(allSeasons, defaultSeason, "matchSeasons");
            //GridFilter groupFilter = new GridFilter(allGroups, groupDefault, "matchGroups");
            GridFilter teamFilter = new GridFilter(allTeams, teamDefault, "matchTeams");
            GridFilter stageFilter = new GridFilter(stageFilters, stageDefault, "matchStages");

            List<GridFilter> allFilters = new List<GridFilter>();
            allFilters.Add(seasonFilter);
            allFilters.Add(leagueFilter);
            //allFilters.Add(groupFilter);
            allFilters.Add(teamFilter);
            allFilters.Add(stageFilter);

            matchesMV.AllFiters = allFilters;

            this.jsonAnswer = new JsonJavascriptAnswer() { Json = new JavaScriptSerializer().Serialize(matchesMV) };
        }

        // GET: Matches
        [HttpGet]
        public ViewResult Index(MatchesModelView jsonAnswer = null)
        {
            //MatchesModelView matchesMV = new MatchesModelView();  

            return View(matchesMV);
        }
        [HttpGet]
        public JsonResult GetMatchesJson()
        {
            return Json(matchesMV, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult FilteredIndex(JsonJavascriptAnswer jsonAnswer)
        {
            matchesMV = new JavaScriptSerializer().Deserialize<MatchesModelView>(jsonAnswer.Json);
            return PartialView("Index", matchesMV);
        }
    }
}