using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class ItemInFilter : IFilterableItem
    {
        public ItemInFilterData filterData;
        public string itemType;

        public ItemInFilter() { }
        public ItemInFilter(IFilterData fD)
        {
            filterData = new ItemInFilterData(fD);
            itemType = fD.GetType().ToString();
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
            return filterData.Value;
        }

        public bool IsSelected()
        {
            return filterData.Selected;
        }

        public string GetItemTypeName()
        {
            return itemType;
        }

        public override bool Equals(object obj)
        {
            ItemInFilter fd = obj as ItemInFilter;             
            if (fd != null)
            {
                return fd.filterData.Text == this.filterData.Text &&
                    fd.filterData.Value == this.filterData.Value;
            }
            else
            {
                return base.Equals(obj);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}