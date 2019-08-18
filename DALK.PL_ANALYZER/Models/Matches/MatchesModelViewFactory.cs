using DALK.PL_ANALYZER.DB.FAKE;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesModelViewFactory
    {
        private FakeDB db;
        public MatchesModelView matchesMV;
        public MatchesModelViewFactory(MatchesRawFilterValues rawParameters)
        {
            db = new FakeDB();
            MatchesDataFilterContainer allDataFilter = new MatchesDataFilterContainer(rawParameters);
            MatchesFilterCohesionData cohensionData = new MatchesFilterCohesionData(rawParameters, allDataFilter);
            MatchesRawFilterValues cohensionParameters = (MatchesRawFilterValues)cohensionData.GetCohesionableData();
            allDataFilter.FilterDataByCohensionable(cohensionParameters);
            MatchesFiltersValues filterValues = new MatchesFiltersValues(cohensionParameters);                    
            List<Match> matches = db.GetMatches(cohensionParameters).ToList<Match>();
            matchesMV = new MatchesModelView(matches);
            matchesMV.GridFilters = getAllFilters(cohensionParameters, allDataFilter);
            matchesMV.SetFilters(filterValues);
        }
        private GridFilters getAllFilters(MatchesRawFilterValues cohensionParameters, MatchesDataFilterContainer allDataFilter)
        {            
            List<GridFilter> allFilters = new List<GridFilter>();
            GridFilterFactory gFilterFactory = new GridFilterFactory();

            SeasonFilterData defaultSeason = allDataFilter.Seasons.GetDefaultSeason();
            GridFilter seasonGridFilter = gFilterFactory.GetGridFilter(allDataFilter.Seasons.GetSeasonFilterData().ToList<IFilterData>(), "Każdy sezon", nameof(cohensionParameters.matchSeasonId), defaultSeason, cohensionParameters.SetDefaultFilters);
            cohensionParameters.matchSeasonId = seasonGridFilter.SetIdByDefault(cohensionParameters.matchSeasonId);
            allFilters.Add(seasonGridFilter);

            GridFilter leagueGridFilter = gFilterFactory.GetGridFilter(allDataFilter.LeaguesSeason.GetLeagueFilterData().ToList<IFilterData>(), "Każda liga", nameof(cohensionParameters.matchLeagueId));
            cohensionParameters.matchLeagueId = leagueGridFilter.SetIdByDefault(cohensionParameters.matchLeagueId);
            allFilters.Add(leagueGridFilter);

            if (allDataFilter.GroupsSeason != null)
            {
                GridFilter groupFilter = gFilterFactory.GetGridFilter(allDataFilter.GroupsSeason.GetGroupFilterData().ToList<IFilterData>(), "Każda grupa", nameof(cohensionParameters.matchGroupId));
                cohensionParameters.matchGroupId = groupFilter.SetIdByDefault(cohensionParameters.matchGroupId);
                allFilters.Add(groupFilter);
            }

            GridFilter teamGridFilter = gFilterFactory.GetGridFilter(allDataFilter.TeamsSeason.GetTeamFilterData().ToList<IFilterData>(), "Każdy zespół", nameof(cohensionParameters.matchTeamId));
            cohensionParameters.matchTeamId = leagueGridFilter.SetIdByDefault(cohensionParameters.matchTeamId);
            allFilters.Add(teamGridFilter);

            GridFilter stageGridFilter = gFilterFactory.GetGridFilter(allDataFilter.Stages, "Każda faza rozgrywek", nameof(cohensionParameters.matchStageId));
            cohensionParameters.matchStageId = stageGridFilter.SetIdByDefault(cohensionParameters.matchStageId);
            allFilters.Add(stageGridFilter);       
            return new GridFilters(allFilters);
        }
    }
}