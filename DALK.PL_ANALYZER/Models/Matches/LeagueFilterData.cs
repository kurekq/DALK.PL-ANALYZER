using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class LeagueFilterData : LeagueSeason, IFilterData
    {
        public string Text
        {
            get
            {
                return League.Name;
            }
        }
        public string Value
        {
            get
            {
                return League.Id.ToString();
            }
        }
        public string Icon
        {
            get
            {
                return string.Empty;
            }
        }
        public bool Selected { get; set; }
        public LeagueFilterData(int id) : base(id) { }
    }
}