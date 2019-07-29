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
        public MatchesFiltersValues(int? matchSeasonsId = null, int? matchLeaguesId = null, int? matchTeamsId = null, int? matchGroupId = null, string matchStagesId = null)
        {
            filterValues = new List<FilterValue>();
            if (matchSeasonsId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(SeasonFilterData).ToString(),
                        Value = matchSeasonsId.ToString()
                    });                              
            }
            if (matchLeaguesId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(LeagueFilterData).ToString(),
                        Value = matchLeaguesId.ToString()
                    });
            }
            if (matchTeamsId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(TeamFilterData).ToString(),
                        Value = matchTeamsId.ToString()
                    });
            }
            if (matchGroupId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(GroupFilterData).ToString(),
                        Value = matchGroupId.ToString()
                    });
            }
            if (matchStagesId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(ConstantFilterData).ToString(),
                        Value = matchStagesId.ToString()
                    });
            }
        }
    }
}