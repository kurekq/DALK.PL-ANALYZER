using DALK.PL_ANALYZER.Models.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesRawFilterValues : RawFilterValues
    {
        public int? matchSeasonId { get; set; }
        public int? matchLeagueId { get; set; }
        public int? matchTeamId { get; set; }
        //public int? matchGroupId { get; set; }
        public string matchStageId { get; set; }
        
    }
}