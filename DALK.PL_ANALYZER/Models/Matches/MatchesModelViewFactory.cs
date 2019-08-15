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
        public MatchesModelViewFactory(int? matchSeasonsId = null, int? matchLeaguesId = null, int? matchTeamsId = null, int? matchGroupId = null, string matchStagesId = null)
        {
            db = new FakeDB();

            LeaguesSeason leaguesSeason = db.GetLeaguesSeason();
            TeamsSeason teamSeason = db.GetTeamsSeason();
            Seasons seasons = db.GetSeasons();
            SeasonFilterData defaultSeason = seasons.GetDefaultSeason();

            List<IFilterData> allSeasons = seasons.GetSeasons().ToList<IFilterData>();
            EmptyFilterDataItem allSeasonFilter = new EmptyFilterDataItem("Każdy sezon", Configs.DEFAULT_FILTER_ICON, false);
            allSeasons.Add(allSeasonFilter);

            List<IFilterData> allLeagues = leaguesSeason.GetLeagueFilterData(defaultSeason).ToList<IFilterData>();
            EmptyFilterDataItem leagueDefault = new EmptyFilterDataItem("Każda liga", Configs.DEFAULT_FILTER_ICON);
            allLeagues.Add(leagueDefault);

            //List<IFilterData> allGroups = db.GetGroups().ToList<IFilterData>();
            //EmptyFilterDataItem groupDefault = new EmptyFilterDataItem("Każda grupa", Configs.DEFAULT_FILTER_ICON);
            //allGroups.Add(groupDefault);

            List<IFilterData> allTeams = teamSeason.GetTeamFilterData(defaultSeason).ToList<IFilterData>();
            EmptyFilterDataItem teamDefault = new EmptyFilterDataItem("Każdy zespół", Configs.DEFAULT_FILTER_ICON);
            allTeams.Add(teamDefault);

            EmptyFilterDataItem stageDefault = new EmptyFilterDataItem("Każda faza rozgrywek", Configs.DEFAULT_FILTER_ICON);
            IEnumerable<IFilterData> stageFilters = new List<IFilterData>()
                {
                    stageDefault,
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
            GridFilter leagueFilter = new GridFilter(allLeagues, leagueDefault, "matchLeague");
            if (matchLeaguesId == null)
            {
                matchLeaguesId = leagueFilter.SetIdByDefault(matchLeaguesId);
            }
            GridFilter seasonFilter = new GridFilter(allSeasons, defaultSeason, "matchSeason");
            if (matchSeasonsId == null)
            {
                matchSeasonsId = seasonFilter.SetIdByDefault(matchSeasonsId);
            }
            /*GridFilter groupFilter = new GridFilter(allGroups, groupDefault, "matchGroup");          
            if (matchGroupId == null)
            {
                matchGroupId = groupFilter.SetIdByDefault(matchGroupId);
            } */
            GridFilter teamFilter = new GridFilter(allTeams, teamDefault, "matchTeam");
            if (matchTeamsId == null)
            {
                matchTeamsId = teamFilter.SetIdByDefault(matchTeamsId);
            }
            GridFilter stageFilter = new GridFilter(stageFilters, stageDefault, "matchStage");
            if (string.IsNullOrEmpty(matchStagesId))
            {
                matchStagesId = stageFilter.SetIdByDefault(matchStagesId);
            }

            List<GridFilter> allFilters = new List<GridFilter>();
            allFilters.Add(seasonFilter);
            allFilters.Add(leagueFilter);
            //allFilters.Add(groupFilter);
            allFilters.Add(teamFilter);
            allFilters.Add(stageFilter);

            List<Match> matches = db.GetMatches(matchSeasonsId, matchLeaguesId, matchTeamsId, matchGroupId, matchStagesId).ToList<Match>();
            matchesMV = new MatchesModelView(matches);

            matchesMV.GridFilters = new GridFilters(allFilters);
            matchesMV.SetFilters(matchSeasonsId, matchLeaguesId, matchTeamsId, matchGroupId, matchStagesId);
        }
    }
}