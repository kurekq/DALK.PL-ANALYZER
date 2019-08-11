using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class RawFilterValues
    {
        public int? matchSeasonsId { get; set; }
        public int? matchLeaguesId { get; set; }
        public int? matchTeamsId { get; set; }
        //public int? matchGroupId { get; set; }
        public string matchStagesId { get; set; }
    }
}