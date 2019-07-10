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
            League = m.League.ToString();
            LeagueId = m.League.Id;
            Season = m.Season.ToString();
            SeasonId = m.Season.Id;              
            DateTime = m.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            HomeIconUrl = m.Home.IconUrl;
            AwayIconUrl = m.Away.IconUrl;
            FirstTeamId = m.Home.Id;
            SecondTeamId = m.Away.Id;
            Home = m.Home.ToString();
            Away = m.Away.ToString();
            MatchDescription = m.MatchDescription;

            if (m.Stage is GroupStage)
            {
                GameTitle = m.Group.ToString() + ", " + m.Stage.GetStageName();
                GroupId = m.Group.Id;
                Stage = "GroupStage";
            }
            else if (m.Stage is PlayOffStage)
            {
                GameTitle = m.Stage.GetStageName();
                Stage = "PlayOff";
            }

            if (IsPlayedMatch)
            {
                PlayedMatch pm = (PlayedMatch)m;
                HomePoints = pm.HomePoints;
                AwayPoints = pm.AwayPoints;
                WinnerPoints = pm.WinnerPoints;
                Winner = pm.Winner.ToString();
                WinnerIconUrl = pm.Winner.IconUrl;
                LooserPoints = pm.LooserPoints;
                Looser = pm.Looser.ToString();
                LooserIconUrl = pm.Looser.IconUrl;
                MVP = pm.MVP.ToString();
            }
        }
    }
}