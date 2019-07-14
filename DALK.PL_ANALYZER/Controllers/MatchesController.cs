using DALK.PL_ANALYZER.DB.FAKE;
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
            //string json = "{\"Matches\":[{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019 - 03 - 03 17:00:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":2,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg\",\"Away\":\"FireCruda Basketball Team\",\"MatchDescription\":\"Najgorszy mecz w lidze przegrany bardzo wyraźnie.\",\"GameTitle\":\"Grupa C, Kolejka 1/6\",\"HomePoints\":44,\"AwayPoints\":75,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg\",\"WinnerPoints\":75,\"Winner\":\"FireCruda Basketball Team\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":44,\"Looser\":\"WakeTrip\",\"MVP\":\"Paweł Kuriata (9 zbiórek, 10 punktów)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-03-24 15:45:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":3,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg\",\"Away\":\"Sami Swoi\",\"MatchDescription\":\"Wygrywaliśmy mecz przez 3.5 kwarty z najlepszą drużyną ligi.\",\"GameTitle\":\"Grupa C, Kolejka 2/6\",\"HomePoints\":60,\"AwayPoints\":68,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg\",\"WinnerPoints\":68,\"Winner\":\"Sami Swoi\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":60,\"Looser\":\"WakeTrip\",\"MVP\":\"Mateusz Mrozek (26 punktów, 5/9 trójek)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-04-28 18:15:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":4,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg\",\"Away\":\"B-Ball Styl Dzierżoniów\",\"MatchDescription\":\"Totalnie zmiażdżyliśmy przeciwników.\",\"GameTitle\":\"Grupa C, Kolejka 3/6\",\"HomePoints\":70,\"AwayPoints\":26,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"WinnerPoints\":70,\"Winner\":\"WakeTrip\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg\",\"LooserPoints\":26,\"Looser\":\"B-Ball Styl Dzierżoniów\",\"MVP\":\"Szymon Kaczyński (Double-duble, 17 punktów, 10 zbiórek)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-05-12 17:00:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":5,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg\",\"Away\":\"Gwardia Wrocław\",\"MatchDescription\":\"Przeciwnicy ograli nas pressingiem w drugiej połowie.\",\"GameTitle\":\"Grupa C, Kolejka 4/6\",\"HomePoints\":43,\"AwayPoints\":50,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg\",\"WinnerPoints\":50,\"Winner\":\"Gwardia Wrocław\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":43,\"Looser\":\"WakeTrip\",\"MVP\":\"Mateusz Mrozek (16 punktów, 9 zbiórek)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-05-26 15:45:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":6,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg\",\"Away\":\"Whyducki\",\"MatchDescription\":\"Ustawiiśmy się 3 zawodnikami na dole i przeciwnicy rzucili nam 10 trójek.\",\"GameTitle\":\"Grupa C, Kolejka 5/6\",\"HomePoints\":54,\"AwayPoints\":59,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg\",\"WinnerPoints\":59,\"Winner\":\"Whyducki\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":54,\"Looser\":\"WakeTrip\",\"MVP\":\"Marcin Obolewicz (6 punktów (3/5), 12 zbiórek)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":1,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-06-02 14:25:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":7,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg\",\"Away\":\"KSP Gospoda\",\"MatchDescription\":\"Mecz przegrany 1 punktem w dogrywce, Kudłaty i Mrozo zepsuli buzzer-beatery. 50 sekund przed końcem meczu wygrywaliśmy 4 punktami. Przeciwnicy grali w piatkę.\",\"GameTitle\":\"Grupa C, Kolejka 6/6\",\"HomePoints\":53,\"AwayPoints\":54,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg\",\"WinnerPoints\":54,\"Winner\":\"KSP Gospoda\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":53,\"Looser\":\"WakeTrip\",\"MVP\":\"Paweł Kuriata (5 punktów (2/3), 18 zbiórek, 2 asysty, 2 bloki)\",\"Stage\":\"GroupStage\"},{\"IsPlayedMatch\":true,\"GroupId\":0,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-06-15 10:00:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":8,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg\",\"Away\":\"Rosenthal\",\"MatchDescription\":\"Nasi przeciwnicy byli po prostu lepsi demolując nas w drugiej kwarcie 22-4.\",\"GameTitle\":\"Playoffy - 1/16\",\"HomePoints\":51,\"AwayPoints\":69,\"WinnerIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg\",\"WinnerPoints\":69,\"Winner\":\"Rosenthal\",\"LooserIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"LooserPoints\":51,\"Looser\":\"WakeTrip\",\"MVP\":\"Paweł Kuriata (Double-double (10 punktów (63%), 12 zbiórek))\",\"Stage\":\"PlayOff\"},{\"IsPlayedMatch\":false,\"GroupId\":0,\"LeagueId\":1,\"League\":\"2 Liga\",\"SeasonId\":1,\"Season\":\"2019\",\"DateTime\":\"2019-06-15 10:00:00\",\"HomeIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg\",\"FirstTeamId\":1,\"SecondTeamId\":9,\"Home\":\"WakeTrip\",\"AwayIconUrl\":\"http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg\",\"Away\":\"Łobuzersi\",\"MatchDescription\":\"Drużyna beniaminka Waketrip (6-1) zmierzy się z jedną z lepszych drużyn ligowych (7-0).\",\"GameTitle\":\"Playoffy - 1/8\",\"HomePoints\":0,\"AwayPoints\":0,\"WinnerIconUrl\":null,\"WinnerPoints\":0,\"Winner\":null,\"LooserIconUrl\":null,\"LooserPoints\":0,\"Looser\":null,\"MVP\":null,\"Stage\":\"PlayOff\"}],\"MatchesClassName\":\"layer matches\",\"AllFiters\":[{\"items\":[{\"filterData\":{\"Text\":\"2 Liga\",\"Value\":\"1\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"1 Liga\",\"Value\":\"2\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Ekstraliga\",\"Value\":\"3\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Każda liga\",\"Value\":null,\"Icon\":\"mdi mdi-basketball\",\"Selected\":true}}],\"CSSId\":\"js_filter_matchLeagues\"},{\"items\":[{\"filterData\":{\"Text\":\"2019\",\"Value\":\"1\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"2018/2019\",\"Value\":\"2\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Każdy sezon\",\"Value\":null,\"Icon\":\"mdi mdi-basketball\",\"Selected\":true}}],\"CSSId\":\"js_filter_matchSeasons\"},{\"items\":[{\"filterData\":{\"Text\":\"Grupa C\",\"Value\":\"1\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Każda grupa\",\"Value\":null,\"Icon\":\"mdi mdi-basketball\",\"Selected\":true}}],\"CSSId\":\"js_filter_matchGroups\"},{\"items\":[{\"filterData\":{\"Text\":\"WakeTrip\",\"Value\":\"1\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"FireCruda Basketball Team\",\"Value\":\"2\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Sami Swoi\",\"Value\":\"3\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"B-Ball Styl Dzierżoniów\",\"Value\":\"4\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Gwardia Wrocław\",\"Value\":\"5\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Whyducki\",\"Value\":\"6\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"KSP Gospoda\",\"Value\":\"7\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Rosenthal\",\"Value\":\"8\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Łobuzersi\",\"Value\":\"9\",\"Icon\":\"\",\"Selected\":false}},{\"filterData\":{\"Text\":\"Każdy zespół\",\"Value\":null,\"Icon\":\"mdi mdi-basketball\",\"Selected\":true}}],\"CSSId\":\"js_filter_matchTeams\"},{\"items\":[{\"filterData\":{\"Text\":\"Każda faza rozgrywek\",\"Value\":null,\"Icon\":\"mdi mdi-basketball\",\"Selected\":true}},{\"filterData\":{\"Text\":\"Playoff\",\"Value\":\"PlayOff\",\"Icon\":null,\"Selected\":false}},{\"filterData\":{\"Text\":\"Faza zasadnicza\",\"Value\":\"GroupStage\",\"Icon\":null,\"Selected\":false}}],\"CSSId\":\"js_filter_matchStages\"}]}";

            string json = new JavaScriptSerializer().Serialize(matchesMV);
            var j = JsonConvert.DeserializeObject<MatchesModelView>(json);

            return View(matchesMV);
        }

        [HttpPost]
        public ActionResult FilteredIndex(MatchesModelView matchesMV)
        {
            return PartialView("Index", matchesMV);
        }

    }
}