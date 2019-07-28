using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchModelView
    {
        public bool IsPlayedMatch { get; set; }
        public int GroupId { get; set; }
        public int LeagueId { get; set; }
        public string League { get; set; }
        public int SeasonId { get; set; }
        public string Season { get; set; }
        public string DateTime { get; set; }
        public string HomeIconUrl { get; set; }
        public int FirstTeamId { get; set; }
        public int SecondTeamId { get; set; }
        public string Home { get; set; }
        public string AwayIconUrl { get; set; }
        public string Away { get; set; }
        public string MatchDescription { get; set; }      
        public string GameTitle { get; set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        public string WinnerIconUrl { get; set; }
        public int WinnerPoints { get; set; }
        public string Winner { get; set; }
        public string LooserIconUrl { get; set; }
        public int LooserPoints { get; set; }
        public string Looser { get; set; }
        public string MVP { get; set; }
        public string Stage { get; set; }
        
        public MatchModelView()
        {

        }
        public MatchModelView(Match m)
        {
            IsPlayedMatch = m is PlayedMatch;
            League = m.Home.GroupSeason.LeagueSeason.League.ToString();
            LeagueId = m.Home.GroupSeason.LeagueSeason.League.Id;
            Season = m.Home.GroupSeason.LeagueSeason.Season.ToString();
            SeasonId = m.Home.GroupSeason.LeagueSeason.Season.Id;
            DateTime = m.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            HomeIconUrl = m.Home.Team.IconUrl;
            AwayIconUrl = m.Away.Team.IconUrl;
            FirstTeamId = m.Home.Id;
            SecondTeamId = m.Away.Id;
            Home = m.Home.Team.ToString();
            Away = m.Away.Team.ToString();
            MatchDescription = m.MatchDescription;

            if (m.Stage.StageName == "GroupStage")
            {
                GameTitle = m.Home.GroupSeason.ToString() + ", " + m.Stage.GetDisplayStageName();
                GroupId = m.Home.GroupSeason.Id;
                Stage = m.Stage.StageName;
            }
            else if (m.Stage.StageName == "PlayOff")
            {
                GameTitle = m.Stage.GetDisplayStageName();
                Stage = m.Stage.StageName;
            }
            else
            {
                throw new NotImplementedException();
            }

            if (IsPlayedMatch)
            {
                PlayedMatch pm = (PlayedMatch)m;
                HomePoints = pm.HomePoints;
                AwayPoints = pm.AwayPoints;
                WinnerPoints = pm.WinnerPoints;
                Winner = pm.Winner.ToString();
                WinnerIconUrl = pm.Winner.Team.IconUrl;
                LooserPoints = pm.LooserPoints;
                Looser = pm.Looser.ToString();
                LooserIconUrl = pm.Looser.Team.IconUrl;
                MVP = pm.MVP.ToString();
            }
        }
    }
}