using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    interface IListOfDropDowns
    {
        void SetFilterSelected(FilterValue fV);
        IEnumerable<IDropDownList> GetList();
    }
}
