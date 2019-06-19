using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Group
    {
        public League League { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return "Grupa " + Name;
        }
        public override int GetHashCode()
        {
            return (this.League.ToString()  + " " + ToString()).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is Group)
                return GetHashCode() == obj.GetHashCode();
            else
                return false;
        }
    }
}