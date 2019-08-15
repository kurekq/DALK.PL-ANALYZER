using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public class FilterValue
    {
        public string TypeOfClass { get; set; }   
        public string Value { get; set; }
        public FilterValue(int? value)
        {
            if (value != null)
                Value = value.ToString();
        }
        public FilterValue(string value)
        {
            Value = value;
        }
    }
}