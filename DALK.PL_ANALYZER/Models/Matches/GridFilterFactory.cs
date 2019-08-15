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
        private EmptyFilterDataItem emptyFilter;
        private IFilterData defaultFilter;
        private GridFilter gridFilter;

        public GridFilter GetGridFilter(List<IFilterData> filterDataset, string emptyFilterName, string gridFilterName)
        {
            setEmptyFilter(emptyFilterName);
            SetDefaultFilter();
            SetUpGridFilter(filterDataset, gridFilterName);
            return gridFilter;
        }
        public GridFilter GetGridFilter(List<IFilterData> filterDataset, string emptyFilterName, string gridFilterName, IFilterData defaultFilter)
        {
            setEmptyFilter(emptyFilterName);
            SetDefaultFilter(defaultFilter);
            SetEmptyFilterNotSelected();
            SetUpGridFilter(filterDataset, gridFilterName);
            return gridFilter;
        }
        private void SetUpGridFilter(List<IFilterData> filterDataset, string gridFilterName)
        {                      
            if (!filterDataset.Contains(emptyFilter))
            {
                filterDataset.Add(emptyFilter);
            }
            gridFilter = new GridFilter(filterDataset, defaultFilter, gridFilterName);
        }
        private void SetEmptyFilterNotSelected()
        {
            emptyFilter.Selected = false;
        }
        private void SetDefaultFilter()
        {            
            this.defaultFilter = emptyFilter;
        }
        private void SetDefaultFilter(IFilterData defaultFilter)
        {
            this.defaultFilter = defaultFilter;
        }
        private void setEmptyFilter(string emptyFilterName)
        {
            emptyFilter = new EmptyFilterDataItem(emptyFilterName, Configs.DEFAULT_FILTER_ICON);
        }
    }
}