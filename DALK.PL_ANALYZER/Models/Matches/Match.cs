using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Match
    {
        public League League { get; set; }
        public Season Season { get; set; }
        public Group Group { get; set; }

        public IStage Stage { get; set; }

        public DateTime DateTime { get; set; }

        public Team Home { get; set; }
        public int HomePoints { get; set; }

        public Team Away { get; set; }
        public int AwayPoints { get; set; }

        public int WinnerPoints
        {
            get
            {
                return Math.Max(HomePoints, AwayPoints);
            }
        }
        public Team Winner
        {
            get
            {
                return HomePoints > AwayPoints ? Home : Away;
            }
        }

        public int LooserPoints
        {
            get
            {
                return Math.Min(HomePoints, AwayPoints);
            }
        }
        public Team Looser
        {
            get
            {
                return HomePoints > AwayPoints ? Away : Home;
            }
        }



        public MVP MVP { get; set; }
        public string MatchDescription { get; set; }
    }
}