using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class TeamsSeason
    {
        private readonly IEnumerable<TeamSeason> teamSeasons;
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
        public IEnumerable<TeamSeason> Get()
        {
            return teamSeasons;
        }
        public IEnumerable<TeamFilterData> GetTeamFilterData()
        {
            return teamSeasons.Select(x => x.Team).Distinct();
        }
    }
}