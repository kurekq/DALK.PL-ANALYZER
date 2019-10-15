using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DropDownModelView
    {
        public DropDownFilter DropDown { get; set; }
        public readonly List<DropDownItemModelView> items;
        public DropDownModelView(IFilter filter)
        {
            DropDown = (DropDownFilter)filter;

            items = new List<DropDownItemModelView>();
            foreach (IDropDownListItem i in DropDown.GetItems())
            {
                items.Add(new DropDownItemModelView(i));
            }
        }
    }
}