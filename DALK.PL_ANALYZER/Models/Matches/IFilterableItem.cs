using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public interface IFilterableItem
    {
        bool IsSelected();
        string GetText();
        HtmlString GetHtmlText();
        string GetValue();
        void Select();
        void Unselect();
        Type GetItemType();
    }
}
