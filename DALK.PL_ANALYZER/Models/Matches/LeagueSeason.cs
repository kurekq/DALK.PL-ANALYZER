using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class LeagueSeason
    {
        public Guid Id { get; set; }
        public LeagueFilterData League { get; set; }
        public Season Season { get; set; }
        public LeagueSeason() { }
        public LeagueSeason(Guid id)
        {
            Id = id;
        }
        public override bool Equals(object obj)
        {
            if (obj is LeagueSeason)
            {
                return ((LeagueSeason)obj).Id.Equals(this.Id);
            }
            else
            {
                return base.Equals(obj);
            }           
        }
        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }
    }
}