using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class TeamsSeason
    {
        private IEnumerable<TeamSeason> teamSeasons;
        public TeamsSeason()
        {
            teamSeasons = new List<TeamSeason>();
        }
        public TeamsSeason(IEnumerable<TeamSeason> ts = null)
        {
            if (ts == null)
            {
                teamSeasons = new List<TeamSeason>();
            }
            else
            {
                teamSeasons = ts;
            }
        }
        public void Add(TeamSeason ts)
        {
            teamSeasons.ToList<TeamSeason>().Add(ts);
        }
        public IEnumerable<TeamFilterData> GetTeamFilterData(Season season = null, GroupSeason group = null)
        {
            return teamSeasons
                 .Where(x => (x.GroupSeason.LeagueSeason.Season.Equals(season) || season == null) && (x.GroupSeason.Equals(group) || group == null))
                 .Select(x => x.Team).Distinct();
        }
    }
}