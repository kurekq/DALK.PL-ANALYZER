using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class GridFilter : IFilterable
    {
        public List<ItemInFilter> items;
        public ItemInFilter defaultItem;
        public string name;
        public string CSSId;

        public GridFilter() { }
        
        public GridFilter(IEnumerable<IFilterData> fD, IFilterData defaultFilterItem, string name)
        {
            var items = new List<ItemInFilter>();
            foreach (IFilterData f in fD)
            {
                if (f.Equals(defaultFilterItem))
                    f.Selected = true;
                items.Add(new ItemInFilter(f));
            }
            this.items = items;
            this.name = name;
            this.defaultItem = new ItemInFilter(defaultFilterItem);
            CSSId = "js_filter_" + name;
        }

        public string GetCSSId()
        {
            return CSSId;
        }

        public IFilterableItem GetDefaultItem()
        {
            return defaultItem;
        }

        public IEnumerable<IFilterableItem> GetItems()
        {
            return new List<ItemInFilter>(items).OrderBy(x => x.GetText()).OrderByDescending(x => x.Equals(defaultItem));
        }

        public IFilterableItem GetSelectedItem()
        {
            foreach (ItemInFilter i in items)
            {
                if (i.IsSelected())
                    return i;
            }
            throw new Exception();
        }

        public void SetAsSelected(IFilterableItem i)
        {
            UnselectSelected();
            items.First(x => x == i).Select();
        }

        public void SetAsSelected(string byValue)
        {
            UnselectSelected();
            items.First(x => x.GetValue() == byValue).Select();
        }

        private void UnselectSelected()
        {
            IFilterableItem actualSelected = GetSelectedItem();
            actualSelected.Unselect();
        }
    }
}