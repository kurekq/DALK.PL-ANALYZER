using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupStage : Stage
    {
        public byte Round { get; set; }
        public byte MaxRound { get; set; }
        public override string GetStageName()
        {
            return "Kolejka " + Round.ToString() + "/" + MaxRound.ToString();
        }
    }
}