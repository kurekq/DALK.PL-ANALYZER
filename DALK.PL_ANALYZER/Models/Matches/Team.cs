using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string URL { get; set; }
        public Team() { }
        public Team(Guid id)
        {
            Id = id;
        }
        public string IconUrl
        {
            get
            {
                if (string.IsNullOrEmpty(URL))
                {
                    DefaultIcons di = new DefaultIcons();
                    return di.GetDefaultIcon(StructureWithIcons.TEAM);
                }
                else
                {
                    return URL;
                }
            }
        }
        public override bool Equals(object obj)
        {
            if (obj is Team)
            {
                return this.Id == ((Team)obj).Id;
            }
            else
            {
                return base.Equals(obj);
            }
            
        }
        public override string ToString()
        {
            return Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}