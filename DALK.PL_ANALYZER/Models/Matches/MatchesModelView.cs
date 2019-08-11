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
            foreach (FilterValue fV in filterValues.filterValues)
            {
                GridFilters.SetFilterSelected(fV);
            }
        }
        //public IEnumerable<MatchModelView> GetFiltredMatches()
        //{
        //    int seasonId = 0;
        //    int groupId = 0;
        //    int leagueId = 0;
        //    int teamId = 0;
        //    string stage = null;
            
        //    foreach (IFilterable f in GridFilters)
        //    {
        //        string filterType = f.GetItems().First(x => x.GetItemTypeName() != typeof(EmptyFilterDataItem).ToString()).GetItemTypeName();
        //        string value = f.GetSelectedItem().GetValue();

        //        if (filterType == typeof(SeasonFilterData).ToString())
        //        {
        //            int.TryParse(value, out seasonId);
        //        }
        //        else if (filterType == typeof(GroupFilterData).ToString())
        //        {
        //            int.TryParse(value, out groupId);
        //        }
        //        else if (filterType == typeof(LeagueFilterData).ToString())
        //        {
        //            int.TryParse(value, out leagueId);
        //        }
        //        else if (filterType == typeof(TeamFilterData).ToString())
        //        {
        //            int.TryParse(value, out teamId);
        //        }
        //        else if (filterType == typeof(ConstantFilterData).ToString())
        //        {
        //            stage = value;
        //        }
        //        else
        //        {
        //            throw new NotImplementedException();
        //        } 
        //    }

        //    return Matches.Where(x =>
        //     (x.SeasonId == seasonId || seasonId == 0) &&
        //     (x.GroupId == groupId || groupId == 0) &&
        //     (x.LeagueId == leagueId || leagueId == 0) &&
        //     (x.FirstTeamId == teamId || x.SecondTeamId == teamId || teamId == 0) &&
        //     (x.Stage == stage || stage == null));
        //}

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