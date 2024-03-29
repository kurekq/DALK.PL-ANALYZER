﻿using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class ItemInFilterData : IFilterData
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public bool Selected { get; set; }

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