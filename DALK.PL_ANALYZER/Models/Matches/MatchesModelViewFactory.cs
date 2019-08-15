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
        public MatchesModelViewFactory(RawFilterValues rawParameters)
        {
            db = new FakeDB();
            MatchesFiltersValues filterValues = new MatchesFiltersValues(rawParameters);                    
            List<Match> matches = db.GetMatches(rawParameters).ToList<Match>();
            matchesMV = new MatchesModelView(matches);
            matchesMV.GridFilters = getAllFilters(rawParameters);
            matchesMV.SetFilters(filterValues);
        }
        private GridFilters getAllFilters(RawFilterValues rawParameters)
        {            
            List<GridFilter> allFilters = new List<GridFilter>();
            GridFilterFactory gFilterFactory = new GridFilterFactory();

            Seasons seasons = db.GetSeasons();
            SeasonFilterData defaultSeason = seasons.GetDefaultSeason();
            GridFilter seasonGridFilter = gFilterFactory.GetGridFilter(seasons.GetSeasons().ToList<IFilterData>(), "Każdy sezon", nameof(rawParameters.matchSeasonId), defaultSeason);
            rawParameters.matchSeasonId = seasonGridFilter.SetIdByDefault(rawParameters.matchSeasonId);
            allFilters.Add(seasonGridFilter);

            LeaguesSeason leaguesSeason = db.GetLeaguesSeason();
            GridFilter leagueGridFilter = gFilterFactory.GetGridFilter(leaguesSeason.GetLeagueFilterData(defaultSeason).ToList<IFilterData>(), "Każda liga", nameof(rawParameters.matchLeagueId));
            rawParameters.matchLeagueId = leagueGridFilter.SetIdByDefault(rawParameters.matchLeagueId);
            allFilters.Add(leagueGridFilter);

            TeamsSeason teamSeason = db.GetTeamsSeason();
            GridFilter teamGridFilter = gFilterFactory.GetGridFilter(teamSeason.GetTeamFilterData(defaultSeason).ToList<IFilterData>(), "Każdy zespół", nameof(rawParameters.matchTeamId));
            rawParameters.matchTeamId = leagueGridFilter.SetIdByDefault(rawParameters.matchTeamId);
            allFilters.Add(teamGridFilter);

            GridFilter stageGridFilter = gFilterFactory.GetGridFilter(getStageFilters(), "Każda faza rozgrywek", nameof(rawParameters.matchStageId));
            rawParameters.matchStageId = stageGridFilter.SetIdByDefault(rawParameters.matchStageId);
            allFilters.Add(stageGridFilter);

            /*
            List<IFilterData> allGroups = db.GetGroups().ToList<IFilterData>();
            EmptyFilterDataItem groupDefault = new EmptyFilterDataItem("Każda grupa", Configs.DEFAULT_FILTER_ICON);
            allGroups.Add(groupDefault);
            GridFilter groupFilter = new GridFilter(allGroups, groupDefault, "matchGroup");          
            matchGroupId = groupFilter.SetIdByDefault(ref matchGroupId);
            allFilters.Add(groupFilter)
            */
            return new GridFilters(allFilters);
        }
        private List<IFilterData> getStageFilters()
        {
            return new List<IFilterData>()
            {
                    new ConstantFilterData()
                    {
                        Icon = null,
                        Selected  = false,
                        Text = "Playoff",
                        Value = "PlayOff"
                    },
                    new ConstantFilterData()
                    {
                        Icon = null,
                        Selected  = false,
                        Text = "Faza zasadnicza",
                        Value = "GroupStage"
                    }
            };
        }
    }
}