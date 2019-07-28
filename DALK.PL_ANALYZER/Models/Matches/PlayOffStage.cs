using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class PlayOffStage : Stage
    {
        private PlayOff playOff;
        public PlayOffStage(byte howFarFromFinal)
        {
            this.playOff = new PlayOff(howFarFromFinal);
        }
        public override string GetStageName()
        {
            return "Playoffy - " + playOff.GetName();
        }
    }
}