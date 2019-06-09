using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Team
    {
        private string name;
        public string IconUrl { get; }

        public Team (string name, string url = "")
        {
            this.name = name;
            this.IconUrl = url;
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