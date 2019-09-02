using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class GridFilters : IFilterableList
    {
        private readonly List<GridFilter> Filters;
        public GridFilters() { }
        public GridFilters(List<GridFilter> f)
        {
            Filters = new List<GridFilter>(f);
        }
        private GridFilter GetGridFilter(string gridFilterName)
        {
            return Filters.FirstOrDefault(x => x.name == gridFilterName);
        }
        public void SetFilterSelected(FilterValue fV)
        {
            var grid = GetGridFilter(fV.Name);
            grid.SetAsSelected(fV.Value);
        }
        public IEnumerable<IFilterable> GetFiters()
        {
            return Filters;
        }
    }
}