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
        public MatchesFiltersValues(int? seasonId = null, int? seasonLeagueId = null, int? teamLeagueId = null, int? groupSeasonId = null, string stage = null)
        {
            filterValues = new List<FilterValue>();
            if (seasonId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(SeasonFilterData).ToString(),
                        Value = seasonId.ToString()
                    });                              
            }
            if (seasonLeagueId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(LeagueFilterData).ToString(),
                        Value = seasonLeagueId.ToString()
                    });
            }
            if (teamLeagueId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(TeamFilterData).ToString(),
                        Value = teamLeagueId.ToString()
                    });
            }
            if (groupSeasonId != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(GroupFilterData).ToString(),
                        Value = groupSeasonId.ToString()
                    });
            }
            if (stage != null)
            {
                filterValues.Add(
                    new FilterValue()
                    {
                        TypeOfClass = typeof(ConstantFilterData).ToString(),
                        Value = stage.ToString()
                    });
            }
        }
    }
}