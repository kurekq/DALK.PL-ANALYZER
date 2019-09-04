using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupSeason
    {
        public Guid Id { get; set; }
        public LeagueSeason LeagueSeason { get; set; }
        public string Name { get; set; }
        public GroupSeason() { }
        public GroupSeason (Guid id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return "Grupa " + Name;
        }
        public override int GetHashCode()
        {
            return (this.LeagueSeason.ToString()  + " " + ToString()).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is GroupSeason)
                return GetHashCode() == obj.GetHashCode();
            else
                return false;
        }
    }
}