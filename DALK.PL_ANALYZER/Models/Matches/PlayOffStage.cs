using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class PlayOffStage : Stage
    {
        private PlayOff playOff;
        public PlayOffStage() { }
        public PlayOffStage(byte howFarFromFinal)
        {
            this.playOff = new PlayOff(howFarFromFinal);
            DisplayStageName = "Playoffy - " + playOff.GetName();
            StageName = "PlayOff";
        }
        public override string GetStageName()
        {
            return DisplayStageName;
        }
    }
}