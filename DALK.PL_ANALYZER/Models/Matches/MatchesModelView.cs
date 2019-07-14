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
            int groupId = 0;
            int leagueId = 0;
            int teamId = 0;
            string stage = null;

            foreach (IFilterable f in AllFiters)
            {
                Type filterType = f.GetItems().First(x => x.GetItemType() != typeof(EmptyFilterDataItem)).GetItemType();
                string value = f.GetSelectedItem().GetValue();

                if (filterType == typeof(SeasonFilterData))
                {
                    int.TryParse(value, out seasonId);
                }
                else if (filterType == typeof(GroupFilterData))
                {
                    int.TryParse(value, out groupId);
                }
                else if (filterType == typeof(LeagueFilterData))
                {
                    int.TryParse(value, out leagueId);
                }
                else if (filterType == typeof(TeamFilterData))
                {
                    int.TryParse(value, out teamId);
                }
                else if (filterType == typeof(ConstantFilterData))
                {
                    stage = value;
                }
                else
                {
                    throw new NotImplementedException();
                }
            }

            return Matches.Where(x =>
             (x.SeasonId == seasonId || seasonId == 0) &&
             (x.GroupId == groupId || groupId == 0) &&
             (x.LeagueId == leagueId || leagueId == 0) &&
             (x.FirstTeamId == teamId || x.SecondTeamId == teamId || teamId == 0) &&
             (x.Stage == stage || stage == null));
        }

        public IEnumerable<GridFilter> AllFiters
        {
            get;
            set;
        }

        public string GetJson()
        {          
            string s = new JavaScriptSerializer().Serialize(this);
            return s;
        }
    }
}