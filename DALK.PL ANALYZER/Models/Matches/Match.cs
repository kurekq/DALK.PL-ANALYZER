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



    }
}