﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public interface IFilterableItem
    {
        bool IsSelected();
        string GetText();
        HtmlString GetHtmlText();
        string GetValue();
        bool IsEmptyValue();
        void Select();
        void Unselect();
        string GetItemTypeName();
    }
}
