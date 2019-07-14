using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupFilterData : Group, IFilterData
    {
        public string Text
        {
            get
            {
                return ToString();
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

        public GroupFilterData(int id) : base(id) { }
    }
}