using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Match
    {
        public int Id { get; set; }
        public League League { get; set; }
        public Season Season { get; set; }
        public Group Group { get; set; }
        public IStage Stage { get; set; }
        public DateTime DateTime { get; set; }
        public Team Home { get; set; }       
        public Team Away { get; set; }
        public string MatchDescription { get; set; }

    }
}