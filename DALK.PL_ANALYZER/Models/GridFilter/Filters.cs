using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.GridFilter
{
    public class Filters 
    {
        public readonly List<IFilter> List;
        public Filters()
        {
            List = new List<IFilter>();
        }
        public void Add(IFilter filter)
        {
            List.Add(filter);
        }
        public void Add(List<IFilter> filters)
        {
            List.AddRange(filters);
        }
    }
}