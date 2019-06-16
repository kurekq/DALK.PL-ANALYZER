using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Season
    {
        public int FirstYear { get; set; }
        public int SecondYear { get; set; }
        public bool IsSummerSeason { get; set; }
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

    }
}