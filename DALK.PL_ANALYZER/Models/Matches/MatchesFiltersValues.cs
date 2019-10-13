using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.GridFilter;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesFiltersValues 
    {
        public readonly List<FilterValue> filterValues;
        public MatchesFiltersValues(MatchesRawFilterValues parameters)
        {
            filterValues = new List<FilterValue>();
            filterValues.Add(
                new FilterValue(parameters.matchSeasonId)
                {
                    TypeOfClass = typeof(SeasonFilterData).ToString(),
                    Name = nameof(parameters.matchSeasonId)
                });

            filterValues.Add(
                new FilterValue(parameters.matchLeagueId)
                {
                    TypeOfClass = typeof(LeagueFilterData).ToString(),
                    Name = nameof(parameters.matchLeagueId)
                });

            filterValues.Add(
                new FilterValue(parameters.matchTeamId)
                {
                    TypeOfClass = typeof(TeamFilterData).ToString(),
                    Name = nameof(parameters.matchTeamId)
                });

            filterValues.Add(
                new FilterValue(parameters.matchGroupId)
                {
                    TypeOfClass = typeof(GroupFilterData).ToString(),
                    Name = nameof(parameters.matchGroupId),
                    Visible = parameters.matchLeagueId != null && parameters.matchSeasonId != null                  
                });
    
            filterValues.Add(
                new FilterValue(parameters.matchStageId)
                {
                    TypeOfClass = typeof(ConstantFilterData).ToString(),
                    Name = nameof(parameters.matchStageId)
                });
        }
    }
}