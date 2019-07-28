using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALK.PL_ANALYZER.Models.Filters
{
    interface IFilterableList
    {
        void SetFilterSelected(FilterValue fV);
        IEnumerable<IFilterable> GetFiters();
    }
}
