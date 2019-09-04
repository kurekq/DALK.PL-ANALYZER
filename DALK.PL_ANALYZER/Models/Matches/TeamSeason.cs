﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class TeamSeason
    {
        public Guid Id { get; set; }
        public GroupSeason GroupSeason { get; set; }
        public TeamFilterData Team { get; set; }
        public TeamSeason() { }
        public TeamSeason(Guid id)
        {
            Id = id;
        }
        public override string ToString()
        {
            return Team.ToString();
        }
    }
}