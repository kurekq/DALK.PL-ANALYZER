using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupsSeason
    {
        private readonly IEnumerable<GroupFilterData> groupSeason;
        public GroupsSeason(IEnumerable<GroupFilterData> gs = null)
        {
            if (gs == null)
            {
                groupSeason = new List<GroupFilterData>();
            }
            else
            {
                groupSeason = gs;
            }
        }
        public void Add(GroupFilterData gs)
        {
            groupSeason.ToList<GroupFilterData>().Add(gs);
        }
        public IEnumerable<GroupFilterData> Get()
        {
            return groupSeason;
        }
        public IEnumerable<GroupFilterData> GetGroupFilterData()
        {
            return groupSeason;
        }
    }
}