using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace DALK.PL_ANALYZER.Models.Filters
{
    public interface IFilterable
    {
        IEnumerable<IFilterableItem> GetItems();
        IFilterableItem GetDefaultItem();       
        IFilterableItem GetSelectedItem();
        void SetAsSelected(IFilterableItem i);
        void SetAsSelected(string byValue);
        string GetCSSId();
    }
}
