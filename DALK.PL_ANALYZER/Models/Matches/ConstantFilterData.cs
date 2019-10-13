﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.GridFilter;
using DALK.PL_ANALYZER.Models.Matches;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class ConstantFilterData : IDropDownItemData
    {
        public string Text { get; set; }
        public string Value { get; set; }
        public string Icon { get; set; }
        public bool Selected { get; set; }

        public ConstantFilterData(){ }

    }
}