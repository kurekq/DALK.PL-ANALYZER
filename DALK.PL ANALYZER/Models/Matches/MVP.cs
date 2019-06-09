using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MVP
    {
        public Player Player { get; set; }
        public string PerformanceDesciption { get; set; }

        public override string ToString()
        {
            return Player.ToString() + (string.IsNullOrEmpty(PerformanceDesciption) ? string.Empty : (" (" + PerformanceDesciption + ")"));
        }
    }
}