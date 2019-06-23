using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class MatchesModelView
    {
        public List<MatchModelView> Matches { get; private set; }
        public string MatchesClassName { get; private set; }

        public MatchesModelView(List<Match> matches)
        {
            Matches = new List<MatchModelView>();
            foreach (Match m in matches)
            {
                Matches.Add(new MatchModelView(m));
            }
            MatchesClassName = Matches.Count == 1 ? "layer singleMatch" : "layer matches";
        }
    }
}