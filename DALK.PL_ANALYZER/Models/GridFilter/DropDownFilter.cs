using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DropDownFilter : IDropDownList, IFilter
    {
        public List<DropDownItem> items;
        public DropDownItem defaultItem;
        public string name;
        public string CSSId;

        public DropDownFilter() { }     
        public DropDownFilter(IEnumerable<IDropDownItemData> fD, IDropDownItemData defaultFilterItem, string name)
        {
            var items = new List<DropDownItem>();
            foreach (IDropDownItemData f in fD)
            {
                if (f.Equals(defaultFilterItem))
                    f.Selected = true;
                items.Add(new DropDownItem(f));
            }
            this.items = items;
            this.name = name;
            this.defaultItem = new DropDownItem(defaultFilterItem);
            CSSId = "js_filter_" + name;
        }
        public string GetCSSId()
        {
            return CSSId;
        }
        public IDropDownListItem GetDefaultItem()
        {
            return defaultItem;
        }
        public IEnumerable<IDropDownListItem> GetItems()
        {
            return new List<DropDownItem>(items).OrderBy(x => x.GetText()).OrderByDescending(x => x.IsEmptyValue());
        }

        public string GetParameterName()
        {
            return name;
        }

        public IDropDownListItem GetSelectedItem()
        {
            foreach (DropDownItem i in items)
            {
                if (i.IsSelected())
                    return i;
            }
            throw new Exception();
        }
        public void SetAsSelected(IDropDownListItem i)
        {
            UnselectSelected();
            items.First(x => x == i).Select();
        }
        public void SetAsSelected(string byValue)
        {
            if (!string.IsNullOrEmpty(byValue))
            {
                UnselectSelected();
                items.First(x => x.GetValue() == byValue).Select();
            }
        }
        public int? SetIdByDefault(int? id)
        {
            if (!GetDefaultItem().IsEmptyValue() && id == null)
            {
                id = int.Parse(GetDefaultItem().GetValue());
            }
            return id;
        }
        public string SetIdByDefault(string id)
        {
            if (!GetDefaultItem().IsEmptyValue() && string.IsNullOrEmpty(id))
            {
                id = GetDefaultItem().GetValue();
            }
            return id;
        }
        private void UnselectSelected()
        {
            IDropDownListItem actualSelected = GetSelectedItem();
            actualSelected.Unselect();
        }
    }
}