using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Match
    {
        public League League { get; set; }

        public IStage Stage { get; set; }

        public DateTime DateTime { get; set; }

        public Team Home { get; set; }
        public int HomePoints { get; set; }

        public Team Away { get; set; }
        public int AwayPoints { get; set; }

        public Team Winner
        {
            get
            {
                return HomePoints > AwayPoints ? Home : Away;
            }
        }

        public Player MVP { get; set; }
        public string MatchDescription { get; set; }
    }
}