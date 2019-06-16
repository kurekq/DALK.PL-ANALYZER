using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.Matches
{
    public class Player
    {
        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
        }

        private string _surname;
        public string Surname
        {
            get
            {
                return _surname;
            }
        }

        private Team _team;
        public Team Team
        {
            get
            {
                return _team;
            }
        }

        public Player(string firstName, string surName, Team team)
        {
            this._firstName = firstName;
            this._surname = surName;
            this._team = team;
        }

        public override string ToString()
        {
            return this.FirstName + " " + this.Surname;
        }
    }
}