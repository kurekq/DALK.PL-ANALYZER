using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesModelView
    {
        public List<MatchModelView> Matches { get; set; }
        public string MatchesClassName { get; set; }
        public MatchesModelView()
        {

        }
        public MatchesModelView(List<Match> matches)
        {
            Matches = new List<MatchModelView>();
            foreach (Match m in matches)
            {
                Matches.Add(new MatchModelView(m));
            }
            MatchesClassName = Matches.Count == 1 ? "layer singleMatch" : "layer matches";
        }

        public IEnumerable<MatchModelView> GetFiltredMatches()
        {
            int seasonId = 0;
            int.TryParse(Seasons.Single(x => x.Selected == true).Value, out seasonId);

            int groupId = 0;
            int.TryParse(Groups.Single(x => x.Selected == true).Value, out groupId);

            int leagueId = 0;
            int.TryParse(Leagues.Single(x => x.Selected == true).Value, out leagueId);

            int teamId = 0;
            int.TryParse(Teams.Single(x => x.Selected == true).Value, out teamId);

            string stage = Stages.Single(x => x.Selected == true).Value;

            IEnumerable<MatchModelView> ie = Matches.Where(x =>
             (x.SeasonId == seasonId || seasonId == 0) &&
             (x.GroupId == groupId || groupId == 0) &&
             (x.LeagueId == leagueId || leagueId == 0) &&
             (x.FirstTeamId == teamId || x.SecondTeamId == teamId || teamId == 0) &&
             (x.Stage == stage || stage == null));

            List < MatchModelView > list = ie.ToList<MatchModelView>();

            return ie;
        }

        public List<SelectListItem> Seasons
        {
            get;
            set;
        }

        public List<SelectListItem> Leagues
        {
            get;
            set;
        }

        public List<SelectListItem> Groups
        {
            get;
            set;
        }

        public List<SelectListItem> Teams
        {
            get;
            set;
        }

        public List<SelectListItem> Stages
        {
            get;
            set;
        }

        public string GetJson()
        {          
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}