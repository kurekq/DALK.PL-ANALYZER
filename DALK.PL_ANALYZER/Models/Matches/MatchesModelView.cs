using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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

        public List<SelectListItem> Sexes
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Opcja numer 1", Value = "1" },
                    new SelectListItem(){ Text = "Opcja numer 2", Value = "2" },
                    new SelectListItem(){ Text = "Opcja numer 3", Value = "3" }
                };
            }
            set
            {
                int a = 1;
            }
        }
    }
}