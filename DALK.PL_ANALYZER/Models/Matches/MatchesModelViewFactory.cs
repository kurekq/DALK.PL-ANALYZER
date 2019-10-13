using DALK.PL_ANALYZER.DB.FAKE;
using DALK.PL_ANALYZER.Models.GridFilter;
using DALK.PL_ANALYZER.Models.Shared;
using System.Collections.Generic;
using System.Linq;

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
            matchesMV.DropDowns = getAllDropDowns(cohensionParameters, allDataFilter);
            matchesMV.SetFilters(filterValues);

            matchesMV.DatePickers = getAllDatePicker(cohensionParameters);
        }
        private DropDowns getAllDropDowns(MatchesRawFilterValues cohensionParameters, MatchesDataFilterContainer allDataFilter)
        {            
            List<DropDownFilter> allFilters = new List<DropDownFilter>();
            GridFilterFactory gFilterFactory = new GridFilterFactory();

            SeasonFilterData defaultSeason = allDataFilter.Seasons.GetDefaultSeason();
            DropDownFilter seasonGridFilter = gFilterFactory.GetGridFilter(allDataFilter.Seasons.GetSeasonFilterData().ToList<IDropDownItemData>(), "Każdy sezon", nameof(cohensionParameters.matchSeasonId), defaultSeason, cohensionParameters.SetDefaultFilters);
            cohensionParameters.matchSeasonId = seasonGridFilter.SetIdByDefault(cohensionParameters.matchSeasonId);
            allFilters.Add(seasonGridFilter);

            DropDownFilter leagueGridFilter = gFilterFactory.GetGridFilter(allDataFilter.LeaguesSeason.GetLeagueFilterData().ToList<IDropDownItemData>(), "Każda liga", nameof(cohensionParameters.matchLeagueId));
            cohensionParameters.matchLeagueId = leagueGridFilter.SetIdByDefault(cohensionParameters.matchLeagueId);
            allFilters.Add(leagueGridFilter);

            if (allDataFilter.GroupsSeason != null)
            {
                DropDownFilter groupFilter = gFilterFactory.GetGridFilter(allDataFilter.GroupsSeason.GetGroupFilterData().ToList<IDropDownItemData>(), "Każda grupa", nameof(cohensionParameters.matchGroupId));
                cohensionParameters.matchGroupId = groupFilter.SetIdByDefault(cohensionParameters.matchGroupId);
                allFilters.Add(groupFilter);
            }

            DropDownFilter teamGridFilter = gFilterFactory.GetGridFilter(allDataFilter.TeamsSeason.GetTeamFilterData().ToList<IDropDownItemData>(), "Każdy zespół", nameof(cohensionParameters.matchTeamId));
            cohensionParameters.matchTeamId = leagueGridFilter.SetIdByDefault(cohensionParameters.matchTeamId);
            allFilters.Add(teamGridFilter);

            DropDownFilter stageGridFilter = gFilterFactory.GetGridFilter(allDataFilter.Stages, "Każda faza rozgrywek", nameof(cohensionParameters.matchStageId));
            cohensionParameters.matchStageId = stageGridFilter.SetIdByDefault(cohensionParameters.matchStageId);
            allFilters.Add(stageGridFilter);       
            return new DropDowns(allFilters);
        }
        private DatePickers getAllDatePicker(MatchesRawFilterValues rawParameters)
        {
            DatePickers dp = new DatePickers();
            dp.Add(new DatePicker(nameof(rawParameters.matchFromDate), "Data od", DateTimeFormatter.GetDateTime(rawParameters.matchFromDate)));
            dp.Add(new DatePicker(nameof(rawParameters.matchToDate), "Data do", DateTimeFormatter.GetDateTime(rawParameters.matchToDate)));
            return dp;
        }
    }
}