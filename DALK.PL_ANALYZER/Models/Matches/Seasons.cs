using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Seasons
    {
        private IEnumerable<SeasonFilterData> seasons;
        public Seasons()
        {
            this.seasons = new List<SeasonFilterData>();
        }
        public Seasons(IEnumerable<SeasonFilterData> seasons)
        {
            this.seasons = seasons;
        }
        public void Add(Season season)
        {
            seasons.ToList<Season>().Add(season);
        }
        public IEnumerable<SeasonFilterData> GetSeasons()
        {
            return new List<SeasonFilterData>(seasons);
        }
        public SeasonFilterData GetDefaultSeason()
        {
            SeasonFilterData defaultSeason = seasons.Where(x => x.FromDate <= DateTime.Now && x.ToDate >= DateTime.Now).SingleOrDefault();
            if (defaultSeason == null)
                return defaultSeason = GetNewestSeason();
            defaultSeason.Selected = true;
            return defaultSeason;
        }
        private SeasonFilterData GetNewestSeason()
        {
            return seasons.OrderByDescending(x => x.FromDate).First();
        }
    }
}