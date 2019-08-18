using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALK.PL_ANALYZER.Models.Filters
{
    interface FilterDataCohesion
    {
        RawFiltarableValues GetCohesionableData();
    }
}
