using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Match
    {
        public int Id { get; set; }
        public LeagueFilterData League { get; set; }
        public SeasonFilterData Season { get; set; }
        public GroupFilterData Group { get; set; }
        public IStage Stage { get; set; }
        public DateTime DateTime { get; set; }
        public TeamFilterData Home { get; set; }       
        public TeamFilterData Away { get; set; }
        public string MatchDescription { get; set; }

    }
}