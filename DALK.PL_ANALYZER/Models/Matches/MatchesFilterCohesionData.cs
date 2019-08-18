using DALK.PL_ANALYZER.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesFilterCohesionData : FilterDataCohesion
    {
        private MatchesRawFilterValues matchesParameters;
        private MatchesDataFilterContainer filterData;
        public MatchesFilterCohesionData(MatchesRawFilterValues matchesParameters, MatchesDataFilterContainer filterData)
        {
            this.matchesParameters = (MatchesRawFilterValues)matchesParameters.Clone();
            this.filterData = filterData;
        }
        public RawFiltarableValues GetCohesionableData()
        {
            bool IsLeagueCohensionable = IsLeagueIdCohensionable();
            bool IsTeamCohensionable = IsTeamIdCohensionable();
            bool IsGroupCohensionable = filterData.GroupsSeason != null ? 
                    IsGroupIdCohensionable() : false;

            if (!IsLeagueCohensionable)
            {
                matchesParameters.matchLeagueId = null;
            }
            if (!IsTeamCohensionable)
            {
                matchesParameters.matchTeamId = null;
            }
            if (!IsGroupCohensionable)
            {
                matchesParameters.matchGroupId = null;
            }
            return matchesParameters;
        }
        private bool IsLeagueIdCohensionable()
        {
            return filterData.LeaguesSeason.Get()
                .Any(x => (x.League.Id == matchesParameters.matchLeagueId) && 
                          (x.Season.Id == matchesParameters.matchSeasonId || matchesParameters.matchSeasonId == null));
        }
        private bool IsTeamIdCohensionable()
        {
            return filterData.TeamsSeason.Get()
                .Any(x => (x.GroupSeason.Id == matchesParameters.matchGroupId || matchesParameters.matchGroupId == null) &&
                            (x.GroupSeason.LeagueSeason.League.Id == matchesParameters.matchLeagueId || matchesParameters.matchLeagueId == null) &&
                            (x.GroupSeason.LeagueSeason.Season.Id == matchesParameters.matchSeasonId || matchesParameters.matchSeasonId == null) &&
                            (x.Team.Id == matchesParameters.matchTeamId));
        }
        private bool IsGroupIdCohensionable()
        {
            return filterData.GroupsSeason.Get()
                .Any(x => (x.LeagueSeason.League.Id == matchesParameters.matchLeagueId) &&
                            (x.LeagueSeason.Season.Id == matchesParameters.matchSeasonId) &&
                            (x.Id == matchesParameters.matchGroupId));
        }
    }
}