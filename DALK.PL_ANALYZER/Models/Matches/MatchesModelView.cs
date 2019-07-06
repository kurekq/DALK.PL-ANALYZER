using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

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

        public List<SelectListItem> Seasons
        {
            get;
            set;
        }

        public List<SelectListItem> Leagues
        {
            get;
            set;
        }

        public List<SelectListItem> Groups
        {
            get;
            set;
        }

        public List<SelectListItem> Teams
        {
            get;
            set;
        }

        public List<SelectListItem> Stages
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){ Text = "Wybierz fazę rozgrywek", Value = null },
                    new SelectListItem(){ Text = "Playoffs", Value = "PlayOff" },
                    new SelectListItem(){ Text = "GroupStage", Value = "GroupStage" }
                    
                };
            }
        }

        public string GetJson()
        {          
            return new JavaScriptSerializer().Serialize(this);
        }
    }
}