using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class GridFilters : IFilterableList
    {
        private readonly List<GridFilter> Fiters;

        public GridFilters() { }
        public GridFilters(List<GridFilter> f)
        {
            Fiters = new List<GridFilter>(f);
        }
        private GridFilter GetGridFilter(string typeOfItem)
        {
            return Fiters
                .Where(x => x.GetItems().First(y => y.GetItemTypeName() != typeof(EmptyFilterDataItem).ToString()).GetItemTypeName() == typeOfItem)
                .First();
        }
        public void SetFilterSelected(FilterValue fV)
        {
            var grid = GetGridFilter(fV.TypeOfClass);
            grid.SetAsSelected(fV.Value);
        }

        public IEnumerable<IFilterable> GetFiters()
        {
            return Fiters;
        }
    }
}