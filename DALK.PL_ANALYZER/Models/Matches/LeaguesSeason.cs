using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class LeaguesSeason
    {
        private IEnumerable<LeagueSeason> leagueSeasons;
        public LeaguesSeason()
        {
            leagueSeasons = new List<LeagueSeason>();
        }
        public LeaguesSeason(IEnumerable<LeagueSeason> ls = null)
        {
            if (ls == null)
            {
                leagueSeasons = new List<LeagueSeason>();
            }
            else
            {
                leagueSeasons = ls;
            }          
        }
        public void Add(LeagueSeason ls)
        {
            leagueSeasons.ToList<LeagueSeason>().Add(ls);
        }
        public IEnumerable<LeagueFilterData> GetLeagueFilterData(Season season = null)
        {
            return leagueSeasons
                .Where(x => x.Season.Equals(season) || season == null)
                .Select(x => x.League).Distinct().ToList<LeagueFilterData>();
        }
    }
}