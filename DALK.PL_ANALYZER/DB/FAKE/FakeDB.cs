﻿using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DALK.PL_ANALYZER.DB.FAKE
{
    public class FakeDB
    {
        public IEnumerable<Match> GetMatches()
        {
            
            List<TeamFilterData> teams = GetTeams().ToList<TeamFilterData>();
            LeagueFilterData ourLeague = GetLeagues().ToList<LeagueFilterData>()[0];
            SeasonFilterData ourSeason = GetSeasons().ToList<SeasonFilterData>()[0];
            GroupFilterData ourGroup = GetGroups().ToList<GroupFilterData>()[0];
            List<IStage> stages = GetStages().ToList<IStage>();

            Player Mrozo = GetPlayers().ToList<Player>()[0];
            Player Kurek = GetPlayers().ToList<Player>()[1];
            Player Kaczor = GetPlayers().ToList<Player>()[2];
            Player Obol = GetPlayers().ToList<Player>()[5];

            yield return new PlayedMatch()
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

            yield return new PlayedMatch()
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

            yield return new PlayedMatch()
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

            yield return new PlayedMatch()
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

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[5],
                HomePoints = 54,
                AwayPoints = 59,
                DateTime = new DateTime(2019, 5, 26, 15, 45, 0),
                League = ourLeague,
                Group = ourGroup,
                MatchDescription = "Ustawiiśmy się 3 zawodnikami na dole i przeciwnicy rzucili nam 10 trójek.",
                MVP = new MVP() { Player = Obol, PerformanceDesciption = "6 punktów (3/5), 12 zbiórek" },
                Season = ourSeason,
                Stage = stages[4]
            };

            yield return new PlayedMatch()
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

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[7],
                HomePoints = 51,
                AwayPoints = 69,
                DateTime = new DateTime(2019, 6, 15, 10, 00, 0),
                League = ourLeague,
                MatchDescription = "Nasi przeciwnicy byli po prostu lepsi demolując nas w drugiej kwarcie 22-4.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "Double-double (10 punktów (63%), 12 zbiórek)" },
                Season = ourSeason,
                Stage = stages[6]
            };


            for (int i = 0; i < 50; i++)
            {
                int homeRandomIndex = new Random().Next(0, GetTeams().ToList<TeamFilterData>().Count);
                TeamFilterData HomeRandom = GetTeams().ToList< TeamFilterData>()[homeRandomIndex];

                TeamFilterData AwayRandom;
                int awayRandomIndex = -1;
                do
                {
                    awayRandomIndex = new Random().Next(0, GetTeams().ToList<TeamFilterData>().Count);
                    AwayRandom = GetTeams().ToList<TeamFilterData>()[awayRandomIndex];
                } while (homeRandomIndex == awayRandomIndex);

                int randomYear = new Random().Next(2018, 2019 + 1);
                int randomMonth = new Random().Next(1, 12 + 1);
                int randomDay = new Random().Next(1, 30 + 1);
                int randomHour = new Random().Next(10, 18 + 1);
                DateTime randomDate = new DateTime(randomYear, randomMonth, randomDay, randomHour, 0, 0);

                int leagueRandomIndex = new Random().Next(0, GetLeagues().ToList<LeagueFilterData>().Count);
                LeagueFilterData LeagueRandom = GetLeagues().ToList<LeagueFilterData>()[leagueRandomIndex];

                int seasonRandomIndex = new Random().Next(0, GetSeasons().ToList<SeasonFilterData>().Count);
                SeasonFilterData SeasonRandom = GetSeasons().ToList<SeasonFilterData>()[seasonRandomIndex];

                int stageRandomIndex = new Random().Next(0, GetStages().ToList<IStage>().Count);
                IStage StageRandom = GetStages().ToList<IStage>()[stageRandomIndex];

                GroupFilterData RandomGroup = null;
                if (StageRandom is GroupStage)
                {
                    int groupRandomIndex = new Random().Next(0, GetGroups().ToList<GroupFilterData>().Count);
                    RandomGroup = GetGroups().ToList<GroupFilterData>()[groupRandomIndex];
                }

                int mvpRandomIndex = new Random().Next(0, GetPlayers().ToList<Player>().Count);
                MVP PlayerRandom = new MVP() { Player = GetPlayers().ToList<Player>()[mvpRandomIndex], PerformanceDesciption = "Opis występu... opis występu... " };

                int randomHomePoints = new Random().Next(50, 151);
                int randomAwayPoints = 0;
                do
                {
                    randomAwayPoints = new Random().Next(50, 151);
                } while (randomAwayPoints == randomHomePoints);

                yield return new PlayedMatch()
                {
                    Home = HomeRandom,
                    Away = AwayRandom,
                    HomePoints = randomHomePoints,
                    AwayPoints = randomAwayPoints,
                    DateTime = randomDate,
                    League = LeagueRandom,
                    MatchDescription = "Tego nie będziemy randomizować...",
                    Season = SeasonRandom,
                    Stage = StageRandom,
                    MVP = PlayerRandom,
                    Group = RandomGroup
                };

            }

        }

        public IEnumerable<LeagueFilterData> GetLeagues()
        {
            yield return new LeagueFilterData(1) { Name = "2 Liga" };
            yield return new LeagueFilterData(2) { Name = "1 Liga" };
            yield return new LeagueFilterData(3) { Name = "Ekstraliga" } ;
        }

        public IEnumerable<IStage> GetStages()
        {
            yield return new GroupStage() { Round = 1, MaxRound = 6 };
            yield return new GroupStage() { Round = 2, MaxRound = 6 };
            yield return new GroupStage() { Round = 3, MaxRound = 6 };
            yield return new GroupStage() { Round = 4, MaxRound = 6 };
            yield return new GroupStage() { Round = 5, MaxRound = 6 };
            yield return new GroupStage() { Round = 6, MaxRound = 6 };
            yield return new PlayOffStage(4);
            yield return new PlayOffStage(3);
            yield return new PlayOffStage(5);
            yield return new PlayOffStage(0);
        }

        public IEnumerable<SeasonFilterData> GetSeasons()
        {
            yield return new SeasonFilterData(1) { FirstYear = 2019 };
            yield return new SeasonFilterData(2) { FirstYear = 2018, SecondYear = 2019 };
        }

        public IEnumerable<TeamFilterData> GetTeams()
        {
            yield return new TeamFilterData(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" };
            yield return new TeamFilterData(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" };
            yield return new TeamFilterData(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" };
            yield return new TeamFilterData(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" };
            yield return new TeamFilterData(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" };
            yield return new TeamFilterData(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" };
            yield return new TeamFilterData(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" };
            yield return new TeamFilterData(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" };
            yield return new TeamFilterData(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" };

            yield return new TeamFilterData(10) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(11) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(12) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(13) { Name = "Ludzie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(14) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(15) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(16) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(17) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(18) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };
            yield return new TeamFilterData(19) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" };

        }

        public IEnumerable<Player> GetPlayers()
        {
            List<Team> teams = GetTeams().ToList<Team>();
            yield return new Player() { FirstName = "Mateusz", Surname = "Mrozek", Team = teams[0] };
            yield return new Player() { FirstName = "Paweł", Surname = "Kuriata", Team = teams[0] };
            yield return new Player() { FirstName = "Szymon", Surname = "Kaczyński", Team = teams[0] };
            yield return new Player() { FirstName = "Kajetan", Surname = "Panas", Team = teams[0] };
            yield return new Player() { FirstName = "Łukasz", Surname = "Dawidowicz", Team = teams[0] };
            yield return new Player() { FirstName = "Marcin", Surname = "Obolewicz", Team = teams[0] };
            yield return new Player() { FirstName = "John", Surname = "Smith Jr.", Team = teams[0] };
            yield return new Player() { FirstName = "Paweł", Surname = "Lis", Team = teams[0] };
            yield return new Player() { FirstName = "Piotr", Surname = "Kernel", Team = teams[0] };
            yield return new Player() { FirstName = "Jarosław", Surname = "Wieteska", Team = teams[0] };
            yield return new Player() { FirstName = "Bartosz", Surname = "Waloń", Team = teams[0] };
            yield return new Player() { FirstName = "Marcin", Surname = "Pryć", Team = teams[0] };
        }
        public IEnumerable<GroupFilterData> GetGroups()
        {
            yield return new GroupFilterData(1) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "C" };
            yield return new GroupFilterData(2) { League = GetLeagues().ToList<LeagueFilterData>()[1], Name = "C" };
            yield return new GroupFilterData(3) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "A" };
            yield return new GroupFilterData(4) { League = GetLeagues().ToList<LeagueFilterData>()[1], Name = "A" };
            yield return new GroupFilterData(5) { League = GetLeagues().ToList<LeagueFilterData>()[2], Name = "A" };
            yield return new GroupFilterData(6) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "B" };
            yield return new GroupFilterData(7) { League = GetLeagues().ToList<LeagueFilterData>()[1], Name = "B" };
            yield return new GroupFilterData(8) { League = GetLeagues().ToList<LeagueFilterData>()[2], Name = "B" };
            yield return new GroupFilterData(9) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "D" };
            yield return new GroupFilterData(10) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "E" };
            yield return new GroupFilterData(11) { League = GetLeagues().ToList<LeagueFilterData>()[0], Name = "F" };
        }
    }
}