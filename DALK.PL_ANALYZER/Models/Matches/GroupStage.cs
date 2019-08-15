using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupStage : Stage
    {
        public GroupStage(byte Round, byte MaxRound)
        {
            DisplayStageName = "Kolejka " + Round.ToString() + "/" + MaxRound.ToString();
            StageName = "GroupStage";
        }
    }
}