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
                case StructureWithIcons.PLAYER:
                    throw new NotImplementedException();
                case StructureWithIcons.TEAM:
                    throw new NotImplementedException();
                default:
                    throw new NotImplementedException();

            }
        }
    }
}