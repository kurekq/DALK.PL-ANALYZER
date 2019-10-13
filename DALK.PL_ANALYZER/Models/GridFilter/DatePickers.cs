using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DatePickers
    {
        private readonly List<DatePicker> List;
        public DatePickers()
        {
            List = new List<DatePicker>();
        }
        public void Add(DatePicker filter)
        {
            List.Add(filter);
        }
        public List<DatePicker> GetList()
        {
            return new List<DatePicker>(List);
        }
    }
}