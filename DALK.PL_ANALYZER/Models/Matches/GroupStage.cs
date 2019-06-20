using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupStage : IStage
    {
        public byte Round { get; set; }
        public byte MaxRound { get; set; }
        public string GetStageName()
        {
            return "Kolejka " + Round.ToString() + "/" + MaxRound.ToString();
        }
    }
}