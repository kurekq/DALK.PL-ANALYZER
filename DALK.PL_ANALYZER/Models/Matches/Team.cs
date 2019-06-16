using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Team
    {
        private string name;

        private string _url;
        public string IconUrl
        {
            get
            {
                if (string.IsNullOrEmpty(_url))
                {
                    DefaultIcons di = new DefaultIcons();
                    return di.GetDefaultIcon(StructureWithIcons.TEAM);
                }
                else
                {
                    return _url;
                }
            }
        }

        public Team (string name, string url = "")
        {
            this.name = name;
            this._url = url;
        }

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }
    }
}