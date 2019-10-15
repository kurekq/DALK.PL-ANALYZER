using DALK.PL_ANALYZER.Models.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DatePicker : IDatePicker, IFilter
    {
        private string parameterName;
        private string labelName;
        private DateTime? date;

        public object StandardDateFormatting { get; private set; }

        public DatePicker(string parameterName, string labelName, DateTime? date)
        {
            this.parameterName = parameterName;
            this.labelName = labelName;
            this.date = date;       
        }

        public string GetLabelName()
        {
            return labelName;
        }
        public string GetParameterName()
        {
            return parameterName;
        }
        public DateTime? GetDate()
        {
            return date;
        }
        public string GetTextDate()
        {
            return date == null ? string.Empty : ((DateTime)date).ToString(DateTimeFormatter.StandardDateFormatting);
        }
    }
}