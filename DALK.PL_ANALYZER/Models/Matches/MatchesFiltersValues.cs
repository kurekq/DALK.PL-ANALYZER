using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.Filters;

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
                    TypeOfClass = typeof(SeasonFilterData).ToString()
                });

            filterValues.Add(
                new FilterValue(parameters.matchLeagueId)
                {
                    TypeOfClass = typeof(LeagueFilterData).ToString()
                });

            filterValues.Add(
                new FilterValue(parameters.matchTeamId)
                {
                    TypeOfClass = typeof(TeamFilterData).ToString()
                });

            /*filterValues.Add(
                new FilterValue(parameters.matchGroupId)
                {
                    TypeOfClass = typeof(GroupFilterData).ToString()
                });*/
    
            filterValues.Add(
                new FilterValue(parameters.matchStageId)
                {
                    TypeOfClass = typeof(ConstantFilterData).ToString()
                });
        }
    }
}