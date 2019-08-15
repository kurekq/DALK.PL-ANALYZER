using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models
{
    public class Stage : IStage
    {
        public string DisplayStageName;
        public string StageName;
        public virtual string GetDisplayStageName()
        {
            return DisplayStageName;
        }
        public virtual string GetStageName()
        {
            return StageName;
        }
    }
}