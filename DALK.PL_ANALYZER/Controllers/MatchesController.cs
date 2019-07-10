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
            MatchesModelView matchesMV = new MatchesModelView();

            if (matchesMV.Matches == null)
            {
                FakeDB db = new FakeDB();
                List<Match> matches = db.GetMatches().ToList<Match>();
                matchesMV = new MatchesModelView(matches);

                matchesMV.Seasons = new List<SelectListItem>();
                matchesMV.Seasons.Add(new SelectListItem() { Text = "Wybierz sezon", Value = null, Selected = true });
                foreach (Season s in db.GetSeasons())
                {
                    matchesMV.Seasons.Add(new SelectListItem() { Text = s.ToString(), Value = s.Id.ToString() });
                }

                matchesMV.Leagues = new List<SelectListItem>();
                matchesMV.Leagues.Add(new SelectListItem() { Text = "Wybierz ligę", Value = null, Selected = true });
                foreach (League l in db.GetLeagues())
                {
                    matchesMV.Leagues.Add(new SelectListItem() { Text = l.ToString(), Value = l.Id.ToString() });
                }

                matchesMV.Groups = new List<SelectListItem>();
                matchesMV.Groups.Add(new SelectListItem() { Text = "Wybierz grupę", Value = null, Selected = true });
                foreach (Group g in db.GetGroups())
                {
                    matchesMV.Groups.Add(new SelectListItem() { Text = g.ToString(), Value = g.Id.ToString() });
                }

                matchesMV.Teams = new List<SelectListItem>();
                matchesMV.Teams.Add(new SelectListItem() { Text = "Wybierz zespół", Value = null, Selected = true });
                foreach (Team t in db.GetTeams())
                {
                    matchesMV.Teams.Add(new SelectListItem() { Text = t.Name, Value = t.Id.ToString() });
                }

                matchesMV.Stages = new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Wybierz fazę rozgrywek", Value = null, Selected = true },
                    new SelectListItem(){ Text = "Playoffs", Value = "PlayOff" },
                    new SelectListItem(){ Text = "GroupStage", Value = "GroupStage" }

                };
            }
            return View(matchesMV);
        }

        [HttpPost]
        public ActionResult FilteredIndex(MatchesModelView matchesMV)
        {
            return PartialView("Index", matchesMV);
        }

    }
}