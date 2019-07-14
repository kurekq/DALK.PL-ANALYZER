using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models
{
    public class ItemInFilterData : IFilterData
    {
        public string Text { get; }
        public string Value { get; }
        public string Icon { get; }
        public bool Selected
        {
            get; set;
        }

        public ItemInFilterData() { }
        public ItemInFilterData(IFilterData fD)
        {
            this.Text = fD.Text;
            this.Value = fD.Value;
            this.Icon = fD.Icon;
            this.Selected = fD.Selected;
        }


    }
}