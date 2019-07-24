using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class LeagueSeason
    {
        public int Id { get; set; }
        public League League { get; set; }
        public Season Season { get; set; }
        public LeagueSeason(int id)
        {
            Id = id;
        }
    }
}