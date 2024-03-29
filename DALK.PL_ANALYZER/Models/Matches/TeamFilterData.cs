﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class TeamFilterData : Team, IFilterData
    {
        public string Text
        {
            get
            {
                return Name;
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
        public TeamFilterData() { }
        public TeamFilterData(int id) : base(id) { }
        public override string ToString()
        {
            return base.ToString();
        }
    }

}