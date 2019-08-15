using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.DB.JSONs
{
    public static class FileDataPaths
    {
        public static string PlayedMatchesPath
        {
            get { return @"C:\Users\p.kuriata\Documents\DALK.PL_ANALYZER\DALK.PL_ANALYZER\DB\JSONs\PlayedMatches.JSON"; }
        }

        public static string NotPlayedMatchesPath
        {
            get { return @"C:\Users\p.kuriata\Documents\DALK.PL_ANALYZER\DALK.PL_ANALYZER\DB\JSONs\NotPlayedMatches.JSON"; }
        }
    }
}