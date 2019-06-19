using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupStage : IStage
    {
        private byte round;
        private byte maxRound;
        public GroupStage(byte round, byte maxRound)
        {
            this.round = round;
            this.maxRound = maxRound;
        }
        public string GetStageName()
        {
            return "Kolejka " + round.ToString() + "/" + maxRound.ToString();
        }
    }
}