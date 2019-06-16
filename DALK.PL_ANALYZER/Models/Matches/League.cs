using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class League
    {
        private string name { get; set; }

        public League(string name)
        {
            this.name = name;
        }

        public override string ToString()
        {
            return name;
        }

        public override int GetHashCode()
        {
            return name.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if (obj is League)
                return ToString() == obj.ToString();
            else
                return false;
        }
    }
}