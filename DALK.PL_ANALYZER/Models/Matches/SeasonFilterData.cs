﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.GridFilter;
using DALK.PL_ANALYZER.Models.Matches;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class SeasonFilterData : Season, IDropDownItemData
    {
        public string Text
        {
            get
            {
                return GetName();
            }
        }
        public string Value
        {
            get
            {
                return Id.ToString();
            }
        }
        public string Icon
        {
            get
            {
                return string.Empty;
            }
        }
        public bool Selected { get; set; }

        public SeasonFilterData(Guid id) : base(id) { }
    }
}