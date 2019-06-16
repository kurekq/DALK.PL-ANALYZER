using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class DuelsInPlayOffStage
    {
        private byte howFarFromFinal;
        public DuelsInPlayOffStage(byte howFarFromFinal)
        {
            this.howFarFromFinal = howFarFromFinal;
        }

        public int HowManyDuels()
        {
            return (int)Math.Pow(2, (int)howFarFromFinal);
        }
    }
}