using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public interface IDropDownList
    {
        IEnumerable<IDropDownListItem> GetItems();
        IDropDownListItem GetDefaultItem();       
        IDropDownListItem GetSelectedItem();
        void SetAsSelected(IDropDownListItem i);
        void SetAsSelected(string byValue);
        string GetCSSId();
        int? SetIdByDefault(int? id);
        string SetIdByDefault(string id);
    }
}
