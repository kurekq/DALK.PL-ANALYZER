using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class League
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public League() { }
        public League (int id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
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