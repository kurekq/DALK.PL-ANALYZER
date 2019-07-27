using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class GroupsSeason
    {
        private IEnumerable<GroupFilterData> groupSeason;
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
        public IEnumerable<GroupFilterData> GetGroupFilterData(LeagueSeason leagueSeason)
        {
            return groupSeason.Where(x => x.LeagueSeason == leagueSeason);
        }
    }
}