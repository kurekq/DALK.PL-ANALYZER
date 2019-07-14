﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class SeasonFilterData : Season, IFilterData
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

        public SeasonFilterData(int id) : base(id) { }
    }
}