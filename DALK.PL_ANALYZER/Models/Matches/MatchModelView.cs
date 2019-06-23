using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchModelView
    {
        public bool IsPlayedMatch { get; private set; }
        public string League { get; private set; }
        public string Season { get; private set; }
        public string DateTime { get; private set; }
        public string HomeIconUrl { get; private set; }
        public string Home { get; private set; }
        public string AwayIconUrl { get; private set; }
        public string Away { get; private set; }
        public string MatchDescription { get; private set; }      
        public string GameTitle { get; private set; }
        public int HomePoints { get; set; }
        public int AwayPoints { get; set; }
        public string WinnerIconUrl { get; private set; }
        public int WinnerPoints { get; private set; }
        public string Winner { get; private set; }
        public string LooserIconUrl { get; private set; }
        public int LooserPoints { get; private set; }
        public string Looser { get; private set; }
        public string MVP { get; set; }

        public MatchModelView(Match m)
        {
            IsPlayedMatch = m is PlayedMatch;
            League = m.League.ToString();
            Season = m.Season.ToString();
            DateTime = m.DateTime.ToString("yyyy-MM-dd HH:mm:ss");
            HomeIconUrl = m.Home.IconUrl;
            AwayIconUrl = m.Away.IconUrl;
            Home = m.Home.ToString();
            Away = m.Away.ToString();
            MatchDescription = m.MatchDescription;

            if (m.Stage is GroupStage)
            {
                GameTitle = m.Group.ToString() + ", " + m.Stage.GetStageName();
            }
            else if (m.Stage is PlayOffStage)
            {
                GameTitle = m.Stage.GetStageName();
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