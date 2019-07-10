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
            
            List<Team> teams = GetTeams().ToList<Team>();
            League ourLeague = GetLeagues().ToList<League>()[0];
            Season ourSeason = GetSeasons().ToList<Season>()[0];
            Group ourGroup = GetGroups().ToList<Group>()[0];
            List<IStage> stages = GetStages().ToList<IStage>();

            Player Mrozo = GetPlayers().ToList<Player>()[0];
            Player Kurek = GetPlayers().ToList<Player>()[1];
            Player Kaczor = GetPlayers().ToList<Player>()[2];
            Player Obol = GetPlayers().ToList<Player>()[5];
            if (1 == 1)
            {
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

                yield return new Match()
                {
                    Home = teams[0],
                    Away = teams[8],
                    DateTime = new DateTime(2019, 6, 15, 10, 00, 0),
                    League = ourLeague,
                    MatchDescription = "Drużyna beniaminka Waketrip (6-1) zmierzy się z jedną z lepszych drużyn ligowych (7-0).",
                    Season = ourSeason,
                    Stage = stages[7]
                };
            }

        }

        public IEnumerable<League> GetLeagues()
        {
            yield return new League(1) { Name = "2 Liga" };
            yield return new League(2) { Name = "1 Liga" };
            yield return new League(3) { Name = "Ekstraliga" } ;
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

        public IEnumerable<Season> GetSeasons()
        {
            yield return new Season(1) { FirstYear = 2019 };
            yield return new Season(2) { FirstYear = 2018, SecondYear = 2019 };
        }

        public IEnumerable<Team> GetTeams()
        {
            yield return new Team(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" };
            yield return new Team(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" };
            yield return new Team(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" };
            yield return new Team(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" };
            yield return new Team(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" };
            yield return new Team(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" };
            yield return new Team(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" };
            yield return new Team(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" };
            yield return new Team(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" };
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
        }
        public IEnumerable<Group> GetGroups()
        {
            yield return new Group(1) { League = GetLeagues().ToList<League>()[0], Name = "C" };

        }
    }
}