using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Season
    {
        public Guid Id { get; set; }
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }
        public bool IsSummerSeason { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public Season() { }
        public Season(Guid id)
        {
            Id = id;
        }
        public string GetName()
        {
            string name = FirstYear.ToString();
            if (SecondYear > 0)
                name += "/" + SecondYear;
            if (IsSummerSeason)
                name += " Letnia";
            return name;
        }
        public override string ToString()
        {
            return GetName();
        }
        public override bool Equals(object obj)
        {
            if (obj is Season)
            {
                return ((Season)obj).Id == this.Id;
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