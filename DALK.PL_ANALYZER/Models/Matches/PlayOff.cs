using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class PlayOff
    {
        private readonly int MAX_HOW_FAR_FOR_SPECIAL_NAME = 2;
        private byte howFarFromFinal;
        public PlayOff(byte howFarFromFinal)
        {
            this.howFarFromFinal = howFarFromFinal;
        }
        public string GetName()
        {
            if (howFarFromFinal <= MAX_HOW_FAR_FOR_SPECIAL_NAME)
            {
                PlayOffsSpecialNames specialName = (PlayOffsSpecialNames)howFarFromFinal;
                return GetSpecialName(specialName);
            }
            else
            {           
                return GetNonSpecialName();
            }
        }
        private string GetSpecialName(PlayOffsSpecialNames specialName)
        {
            switch (specialName)
            {
                case PlayOffsSpecialNames.FINAL:
                    return "Finał";
                case PlayOffsSpecialNames.HALF_FINAL:
                    return "Półfinał";
                case PlayOffsSpecialNames.QUARTER_FINAL:
                    return "Ćwierćfinał";
                default:
                    throw new NotImplementedException(); 
            }
        }
        private string GetNonSpecialName()
        {
            DuelsInPlayOffStageCounter d = new DuelsInPlayOffStageCounter(howFarFromFinal);
            int duelsInStage = d.HowManyDuels();
            return "1/" + duelsInStage;
        }
    }
}