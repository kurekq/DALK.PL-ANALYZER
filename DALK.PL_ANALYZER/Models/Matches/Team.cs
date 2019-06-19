using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Team
    {
        public string Name { get; set; }
        public string URL { get; set; }
        public string IconUrl
        {
            get
            {
                if (string.IsNullOrEmpty(URL))
                {
                    DefaultIcons di = new DefaultIcons();
                    return di.GetDefaultIcon(StructureWithIcons.TEAM);
                }
                else
                {
                    return URL;
                }
            }
        }
        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}