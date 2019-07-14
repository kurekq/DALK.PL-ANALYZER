using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class ItemInFilter : IFilterableItem
    {
        public ItemInFilterData filterData;
        public Type itemType;

        public ItemInFilter() { }
        public ItemInFilter(IFilterData fD)
        {
            filterData = new ItemInFilterData(fD);
            itemType = fD.GetType();
        }

        public void Select()
        {
            filterData.Selected = true;
        }

        public void Unselect()
        {
            filterData.Selected = false;
        }

        public HtmlString GetHtmlText()
        {
            string text = "";
            if (string.IsNullOrEmpty(filterData.Icon))
                text = filterData.Text;
            else
                text = "<i class='" + filterData.Icon + "'></i> " + filterData.Text;
            return new HtmlString(text);
        }

        public string GetText()
        {
            return filterData.Text;
        }

        public string GetValue()
        {
            return filterData.Text;
        }

        public bool IsSelected()
        {
            return filterData.Selected;
        }

        public Type GetItemType()
        {
            return itemType;
        }
    }
}