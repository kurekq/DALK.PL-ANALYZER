using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class DefaultIcons
    {

        public string GetDefaultIcon(StructureWithIcons forWho)
        {
            switch(forWho)
            {
                //DO ZAIMPLEMENTOWANIA
                case StructureWithIcons.PLAYER:
                    return "xxx";
                case StructureWithIcons.TEAM:
                    return "yyy";
                default:
                    throw new NotImplementedException();

            }
        }
    }
}