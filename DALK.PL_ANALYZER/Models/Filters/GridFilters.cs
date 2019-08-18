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
        private GridFilter GetGridFilter(string typeOfItem)
        {
            foreach (GridFilter f in Filters)
            {
                foreach (IFilterableItem i in f.GetItems().Where(x => x.GetItemTypeName() != typeof(EmptyFilterDataItem).ToString()).Take(1))
                {
                    if (i.GetItemTypeName() == typeOfItem)
                        return f;
                }
            }
            throw new Exception();
        }
        public void SetFilterSelected(FilterValue fV)
        {
            var grid = GetGridFilter(fV.TypeOfClass);
            grid.SetAsSelected(fV.Value);
        }
        public IEnumerable<IFilterable> GetFiters()
        {
            return Filters;
        }
    }
}