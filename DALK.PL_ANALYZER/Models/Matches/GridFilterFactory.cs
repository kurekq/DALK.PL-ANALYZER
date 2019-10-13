using DALK.PL_ANALYZER.Models.GridFilter;
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
        private IDropDownItemData defaultFilter;
        private DropDownFilter gridFilter;

        public DropDownFilter GetGridFilter(List<IDropDownItemData> filterDataset, string emptyFilterName, string gridFilterName)
        {
            SetEmptyFilter(emptyFilterName);
            SetDefaultFilterAsEmptyFilter();
            SetUpGridFilter(filterDataset, gridFilterName);
            return gridFilter;
        }
        public DropDownFilter GetGridFilter(List<IDropDownItemData> filterDataset, string emptyFilterName, string gridFilterName, IDropDownItemData defaultFilter, bool setDefaultFilter)
        {
            SetEmptyFilter(emptyFilterName);
            if (setDefaultFilter)
            {
                SetDefaultFilter(defaultFilter);
                SetEmptyFilterNotSelected();
            }             
            else
                SetDefaultFilterAsEmptyFilter();
            
            SetUpGridFilter(filterDataset, gridFilterName);
            return gridFilter;
        }
        private void SetUpGridFilter(List<IDropDownItemData> filterDataset, string gridFilterName)
        {                      
            if (!filterDataset.Contains(emptyFilter))
            {
                filterDataset.Add(emptyFilter);
            }
            gridFilter = new DropDownFilter(filterDataset, defaultFilter, gridFilterName);
        }
        private void SetEmptyFilterNotSelected()
        {
            emptyFilter.Selected = false;
        }
        private void SetDefaultFilterAsEmptyFilter()
        {            
            this.defaultFilter = emptyFilter;
        }
        private void SetDefaultFilter(IDropDownItemData defaultFilter)
        {
            this.defaultFilter = defaultFilter;
        }
        private void SetEmptyFilter(string emptyFilterName)
        {
            emptyFilter = new EmptyFilterDataItem(emptyFilterName, Configs.DEFAULT_FILTER_ICON);
        }
    }
}