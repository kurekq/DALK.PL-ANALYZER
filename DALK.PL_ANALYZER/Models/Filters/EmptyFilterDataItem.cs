using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class EmptyFilterDataItem : IFilterData
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public bool Selected { get; set; }

        public EmptyFilterDataItem(string name, string icon = "", bool selected = true)
        {
            Text = name;
            Value = null;
            Icon = icon;
            Selected = selected;
        }
    }
}