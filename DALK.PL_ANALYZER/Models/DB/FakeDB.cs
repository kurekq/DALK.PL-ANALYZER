﻿using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.Models.DB
{
    public class FakeDB
    {
        public IEnumerable<Match> GetMatches()
        {
            List<Team> teams = GetTeams().ToList<Team>();
            //Group ourGroup = 
            League ourLeague = GetLeagues().ToList<League>()[0];
            Season ourSeason = GetSeasons().ToList<Season>()[0];
            Group ourGroup = GetGroups().ToList<Group>()[0];
            List<IStage> stages = GetStages().ToList<IStage>();

            Player Mrozo = GetPlayers().ToList<Player>()[0];
            Player Kurek = GetPlayers().ToList<Player>()[1];
            Player Kaczor = GetPlayers().ToList<Player>()[2];
            Player Obol = GetPlayers().ToList<Player>()[5];

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[1],
                HomePoints = 44,
                AwayPoints = 75,
                DateTime = new DateTime(2019, 3, 3, 17, 0, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Najgorszy mecz w lidze przegrany bardzo wyraźnie.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "9 zbiórek, 10 punktów" },
                Season = ourSeason,
                Stage = stages[0]
            };

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[2],
                HomePoints = 60,
                AwayPoints = 68,
                DateTime = new DateTime(2019, 3, 24, 15, 45, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Wygrywaliśmy mecz przez 3.5 kwarty z najlepszą drużyną ligi.",
                MVP = new MVP() { Player = Mrozo, PerformanceDesciption = "26 punktów, 5/9 trójek" },
                Season = ourSeason,
                Stage = stages[1]
            };

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[3],
                HomePoints = 70,
                AwayPoints = 26,
                DateTime = new DateTime(2019, 4, 28, 18, 15, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Totalnie zmiażdżyliśmy przeciwników.",
                MVP = new MVP() { Player = Kaczor, PerformanceDesciption = "Double-duble, 17 punktów, 10 zbiórek" },
                Season = ourSeason,
                Stage = stages[2]
            };

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[4],
                HomePoints = 43,
                AwayPoints = 50,
                DateTime = new DateTime(2019, 5, 12, 17, 0, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Przeciwnicy ograli nas pressingiem w drugiej połowie.",
                MVP = new MVP() { Player = Mrozo, PerformanceDesciption = "16 punktów, 9 zbiórek" },
                Season = ourSeason,
                Stage = stages[3]
            };

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[5],
                HomePoints = 54,
                AwayPoints = 59,
                DateTime = new DateTime(2019, 5, 26, 15, 45, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Ustawiiśmy się 3 zawodnikami \"na dole\" i przeciwnicy rzucili nam 10 trójek.",
                MVP = new MVP() { Player = Obol, PerformanceDesciption = "6 punktów (3/5), 12 zbiórek" },
                Season = ourSeason,
                Stage = stages[4]
            };

            yield return new Match()
            {
                Home = teams[0],
                Away = teams[6],
                HomePoints = 53,
                AwayPoints = 54,
                DateTime = new DateTime(2019, 6, 2, 14, 25, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Mecz przegrany 1 punktem w dogrywce, Kudłaty i Mrozo zepsuli buzzer-beatery. 50 sekund przed końcem meczu wygrywaliśmy 4 punktami. Przeciwnicy grali w piatkę.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "5 punktów (2/3), 18 zbiórek, 2 asysty, 2 bloki" },
                Season = ourSeason,
                Stage = stages[5]
            };
        }

        public IEnumerable<League> GetLeagues()
        {
            yield return new League("2 Liga");
            yield return new League("1 Liga");
            yield return new League("Ekstraliga");
        }

        public IEnumerable<IStage> GetStages()
        {
            yield return new GroupStage(1, 6);
            yield return new GroupStage(2, 6);
            yield return new GroupStage(3, 6);
            yield return new GroupStage(4, 6);
            yield return new GroupStage(5, 6);
            yield return new GroupStage(6, 6);
            yield return new PlayOffStage(2);
            yield return new PlayOffStage(3);
            yield return new PlayOffStage(5);
            yield return new PlayOffStage(0);
        }

        public IEnumerable<Season> GetSeasons()
        {
            yield return new Season() { FirstYear = 2019 };
            yield return new Season() { FirstYear = 2018, SecondYear = 2019 };
        }

        public IEnumerable<Team> GetTeams()
        {
            yield return new Team("WakeTrip", "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg");
            yield return new Team("FireCruda Basketball Team", "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg");
            yield return new Team("Sami Swoi", "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg");
            yield return new Team("B-Ball Styl Dzierżoniów", "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg");
            yield return new Team("Gwardia Wrocław", "http://cdn.nba.net/assets/logos/teams/secondary/web/GSW.svg");
            yield return new Team("Whyducki", "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg");
            yield return new Team("KSP Gospoda", "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg");
        }

        public IEnumerable<Player> GetPlayers()
        {
            List<Team> teams = GetTeams().ToList<Team>();
            yield return new Player("Mateusz", "Mrozek", teams[0]);
            yield return new Player("Paweł", "Kuriata", teams[0]);
            yield return new Player("Szymon", "Kaczyński", teams[0]);
            yield return new Player("Kajetan", "Panas", teams[0]);
            yield return new Player("Łukasz", "Dawidowicz", teams[0]);
            yield return new Player("Marcin", "Obolewicz", teams[0]);
        }

        public IEnumerable<Group> GetGroups()
        {
            yield return new Group() { League = GetLeagues().ToList<League>()[0], Name = "C" };

        }
    }
}