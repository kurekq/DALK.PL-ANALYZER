using DALK.PL_ANALYZER.DB.FAKE;
using DALK.PL_ANALYZER.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesDataFilterContainer
    {
        public Seasons Seasons { get; set; }
        public LeaguesSeason LeaguesSeason { get; set; }
        public GroupsSeason GroupsSeason { get; set; }
        public TeamsSeason TeamsSeason { get; set; }
        public List<IFilterData> Stages { get; set; }

        public MatchesDataFilterContainer(MatchesRawFilterValues rawParameters)
        {
            FakeDB db = new FakeDB();
            Seasons = db.GetSeasons();
            LeaguesSeason = db.GetLeaguesSeason();
            if (rawParameters.matchSeasonId != null && rawParameters.matchLeagueId != null)
            {
                GroupsSeason = db.GetGroupsSeason(rawParameters.matchSeasonId, rawParameters.matchLeagueId);
            }            
            TeamsSeason = db.GetTeamsSeason();
            Stages = getStageFilters();
        }
        public void FilterDataByCohensionable(MatchesRawFilterValues cohensionableParameters)
        {
            List<LeagueSeason> lS = LeaguesSeason.Get().ToList<LeagueSeason>();
            if (cohensionableParameters.matchSeasonId != null)
            {               
                LeaguesSeason = new LeaguesSeason(LeaguesSeason.Get().Where(x => x.Season.Id.ToString() == cohensionableParameters.matchSeasonId));
            }

            List<LeagueSeason> list = LeaguesSeason.Get().ToList<LeagueSeason>();           
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