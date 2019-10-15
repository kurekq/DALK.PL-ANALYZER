using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class DropDownItemModelView
    {
        public HtmlString HtmlText { get; set; }
        public string HtmlTextBetweenQuotes { get; set; }
        public string Value { get; set; }
        public DropDownItemModelView(IDropDownListItem item)
        {
            Value = item.GetValue();
            HtmlText = item.GetHtmlText();
            HtmlTextBetweenQuotes = string.Concat("\"", HtmlText, "\"");
        }
    }
}