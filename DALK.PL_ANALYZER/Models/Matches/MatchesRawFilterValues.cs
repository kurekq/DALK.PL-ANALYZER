using DALK.PL_ANALYZER.Models.GridFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesRawFilterValues : RawFilterValues
    {
        public string matchSeasonId { get; set; }
        public string matchLeagueId { get; set; }
        public string matchTeamId { get; set; }
        public string matchGroupId { get; set; }
        public string matchStageId { get; set; }
        public string matchFromDate { get; set; }
        public string matchToDate { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}