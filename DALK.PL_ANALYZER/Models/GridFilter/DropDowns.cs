using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DropDowns : IListOfDropDowns
    {
        private readonly List<DropDownFilter> Filters;
        public DropDowns() { }
        public DropDowns(List<DropDownFilter> f)
        {
            Filters = new List<DropDownFilter>(f);
        }
        private DropDownFilter GetDropDown(string dropDownName)
        {
            return Filters.FirstOrDefault(x => x.name == dropDownName);
        }
        public void SetFilterSelected(FilterValue fV)
        {
            var grid = GetDropDown(fV.Name);
            grid.SetAsSelected(fV.Value);
        }
        public IEnumerable<IDropDownList> GetList()
        {
            return Filters;
        }
    }
}