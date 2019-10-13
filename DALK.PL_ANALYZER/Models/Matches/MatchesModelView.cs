using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using DALK.PL_ANALYZER.Models.GridFilter;
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
                DropDowns.SetFilterSelected(fV);
            }
        }
        public DropDowns DropDowns
        {
            get;
            set;
        } 
        public DatePickers DatePickers
        {
            get;
            set;
        }
        public Filters GetFilters()
        {
            Filters filters = new Filters();

            foreach (IFilter f in DropDowns.GetList())
            {
                filters.Add(f);
            }
            foreach (IFilter f in DatePickers.GetList())
            {
                filters.Add(f);
            }
            return filters;
        }
        public string GetJson()
        {          
            string data = new JavaScriptSerializer().Serialize(this);
            return "?";
        }
    }
}