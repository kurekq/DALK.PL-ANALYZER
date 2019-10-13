using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class FilterValue
    {
        public string TypeOfClass { get; set; }   
        public string Value { get; set; }
        public bool Visible { get; set; }
        public string Name { get; set; }
        public FilterValue(int? value)
        {
            if (value != null)
                Value = value.ToString();
            Visible = true;
        }
        public FilterValue(string value)
        {
            Value = value;
            Visible = true;
        }
    }
}