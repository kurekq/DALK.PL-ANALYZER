using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models
{
    public class Stage : IStage
    {
        public virtual string GetStageName()
        {
            return "Stage";
        }
    }
}