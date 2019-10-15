using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DatePickerModelView
    {
        public string LabelName { get; set; }
        public string ParameterName { get; set; }
        public string Date { get; set; }
        public DatePickerModelView(IFilter filter)
        {
            DatePicker datePicker = (DatePicker)filter;
            LabelName = datePicker.GetLabelName();
            ParameterName = datePicker.GetParameterName();
            Date = datePicker.GetTextDate();
        }

    }
}