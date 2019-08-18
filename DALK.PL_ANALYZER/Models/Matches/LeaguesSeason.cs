using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class LeaguesSeason
    {
        private readonly IEnumerable<LeagueSeason> leagueSeasons;
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
        public IEnumerable<LeagueSeason> Get()
        {
            return leagueSeasons;
        }
        public LeagueSeason GetLeagueSeason(int seasonId, int leagueId)
        {
            return leagueSeasons.Where(x => x.League.Id == leagueId && x.Season.Id == seasonId).First();
        }
        public IEnumerable<LeagueFilterData> GetLeagueFilterData()
        {
            return leagueSeasons.Select(x => x.League).Distinct().ToList<LeagueFilterData>();
        }
    }
}