using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesModelView
    {
        public List<MatchModelView> Matches { get; set; }
        public string MatchesClassName { get; set; }
        public MatchesModelView() { }
        public MatchesModelView(List<Match> matches)
        {
            Matches = new List<MatchModelView>();
            foreach (Match m in matches)
            {
                Matches.Add(new MatchModelView(m)); 
            }
            MatchesClassName = Matches.Count == 1 ? "layer singleMatch" : "layer matches";
        }
        public void SetFilters(MatchesFiltersValues filterValues)
        {
            foreach (FilterValue fV in filterValues.filterValues.Where(x => x.Visible))
            {
                GridFilters.SetFilterSelected(fV);
            }
        }
        public GridFilters GridFilters
        {
            get;
            set;
        } 

        public string GetJson()
        {          
            string data = new JavaScriptSerializer().Serialize(this);
            return "?";
        }
    }
}