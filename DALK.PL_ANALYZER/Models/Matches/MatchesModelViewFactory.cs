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
            List<GridFilter> allFilters = new List<GridFilter>();
            MatchesFiltersValues filterValues = new MatchesFiltersValues(rawParameters);
            db = new FakeDB();

            Seasons seasons = db.GetSeasons();
            SeasonFilterData defaultSeason = seasons.GetDefaultSeason();
            GridFilterFactory factory = new GridFilterFactory(seasons.GetSeasons().ToList<IFilterData>(), "Każdy sezon", "matchSeason");
            factory.SetDefaultFilter(defaultSeason);
            factory.SetEmptyFilterNotSelected();
            factory.SetIdByDefault(rawParameters.matchSeasonsId);
            allFilters.Add(factory.GetGridFilter());

            LeaguesSeason leaguesSeason = db.GetLeaguesSeason();
            factory = new GridFilterFactory(leaguesSeason.GetLeagueFilterData(defaultSeason).ToList<IFilterData>(), "Każda liga", "matchLeague");
            factory.SetIdByDefault(rawParameters.matchLeaguesId);
            allFilters.Add(factory.GetGridFilter());

            TeamsSeason teamSeason = db.GetTeamsSeason();
            factory = new GridFilterFactory(teamSeason.GetTeamFilterData(defaultSeason).ToList<IFilterData>(), "Każdy zespół", "matchTeam");
            factory.SetIdByDefault(rawParameters.matchTeamsId);
            allFilters.Add(factory.GetGridFilter());

            factory = new GridFilterFactory(getStageFilters(), "Każda faza rozgrywek", "matchStage");
            factory.SetIdByDefault(rawParameters.matchTeamsId);
            allFilters.Add(factory.GetGridFilter());

            /*
            List<IFilterData> allGroups = db.GetGroups().ToList<IFilterData>();
            EmptyFilterDataItem groupDefault = new EmptyFilterDataItem("Każda grupa", Configs.DEFAULT_FILTER_ICON);
            allGroups.Add(groupDefault);
            GridFilter groupFilter = new GridFilter(allGroups, groupDefault, "matchGroup");          
            matchGroupId = groupFilter.SetIdByDefault(ref matchGroupId);
            allFilters.Add(groupFilter)
            */

            List<Match> matches = db.GetMatches(rawParameters).ToList<Match>();
            matchesMV = new MatchesModelView(matches);
            matchesMV.GridFilters = new GridFilters(allFilters);
            matchesMV.SetFilters(filterValues);
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