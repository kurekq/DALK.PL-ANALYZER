using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GridFilterFactory
    {
        private List<IFilterData> filterDataset;
        private EmptyFilterDataItem emptyFilter;
        private IFilterData defaultFilter;
        private string gridFilterName;

        public GridFilterFactory(List<IFilterData> filterDataset, string emptyFilterName, string gridFilterName)
        {
            this.filterDataset = filterDataset;
            this.gridFilterName = gridFilterName;
            emptyFilter = new EmptyFilterDataItem(emptyFilterName, Configs.DEFAULT_FILTER_ICON);
            this.defaultFilter = emptyFilter;
        }
        public void SetDefaultFilter(IFilterData defaultFilter)
        {
            this.defaultFilter = defaultFilter;
        }
        public GridFilter GetGridFilter()
        {
            if (!filterDataset.Contains(emptyFilter))
            {
                filterDataset.Add(emptyFilter);
            }
            return new GridFilter(filterDataset, defaultFilter, gridFilterName);
        }
        public void SetIdByDefault(int? value)
        {
            GetGridFilter().SetIdByDefault(ref value);
        }
        public void SetIdByDefault(string value)
        {
            GetGridFilter().SetIdByDefault(ref value);
        }
        public void SetEmptyFilterNotSelected()
        {
            emptyFilter.Selected = false;
        }
    }
}