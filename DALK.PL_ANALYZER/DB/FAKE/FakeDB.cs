using DALK.PL_ANALYZER.Models.Filters;
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
                MatchDescription = "Najgorszy mecz w lidze przegrany bardzo wyraźnie.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "9 zbiórek, 10 punktów" },
                Stage = stages[0]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[2],
                HomePoints = 60,
                AwayPoints = 68,
                DateTime = new DateTime(2019, 3, 24, 15, 45, 0),
                MatchDescription = "Wygrywaliśmy mecz przez 3.5 kwarty z najlepszą drużyną ligi.",
                MVP = new MVP() { Player = Mrozo, PerformanceDesciption = "26 punktów, 5/9 trójek" },
                Stage = stages[1]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[3],
                HomePoints = 70,
                AwayPoints = 26,
                DateTime = new DateTime(2019, 4, 28, 18, 15, 0),
                MatchDescription = "Totalnie zmiażdżyliśmy przeciwników.",
                MVP = new MVP() { Player = Kaczor, PerformanceDesciption = "Double-duble, 17 punktów, 10 zbiórek" },
                Stage = stages[2]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[4],
                HomePoints = 43,
                AwayPoints = 50,
                DateTime = new DateTime(2019, 5, 12, 17, 0, 0),
                MatchDescription = "Przeciwnicy ograli nas pressingiem w drugiej połowie.",
                MVP = new MVP() { Player = Mrozo, PerformanceDesciption = "16 punktów, 9 zbiórek" },
                Stage = stages[3]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[5],
                HomePoints = 54,
                AwayPoints = 59,
                DateTime = new DateTime(2019, 5, 26, 15, 45, 0),
                MatchDescription = "Ustawiiśmy się 3 zawodnikami na dole i przeciwnicy rzucili nam 10 trójek.",
                MVP = new MVP() { Player = Obol, PerformanceDesciption = "6 punktów (3/5), 12 zbiórek" },
                Stage = stages[4]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[6],
                HomePoints = 53,
                AwayPoints = 54,
                DateTime = new DateTime(2019, 6, 2, 14, 25, 0),
                MatchDescription = "Mecz przegrany 1 punktem w dogrywce, Kudłaty i Mrozo zepsuli buzzer-beatery. 50 sekund przed końcem meczu wygrywaliśmy 4 punktami. Przeciwnicy grali w piatkę.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "5 punktów (2/3), 18 zbiórek, 2 asysty, 2 bloki" },
                Stage = stages[5]
            };

            yield return new PlayedMatch()
            {
                Home = teams[0],
                Away = teams[7],
                HomePoints = 51,
                AwayPoints = 69,
                DateTime = new DateTime(2019, 6, 15, 10, 00, 0),
                MatchDescription = "Nasi przeciwnicy byli po prostu lepsi demolując nas w drugiej kwarcie 22-4.",
                MVP = new MVP() { Player = Kurek, PerformanceDesciption = "Double-double (10 punktów (63%), 12 zbiórek)" },
                Stage = stages[6]
            };


            foreach (TeamFilterData home in GetTeams())
            {
                TeamFilterData HomeRandom = home;

                List<TeamFilterData> AwayRandoms = GetTeams().Where(x => x.GroupSeason.Id == home.GroupSeason.Id && x.Id != home.Id).Take(5).ToList<TeamFilterData>();
                foreach (TeamFilterData away in AwayRandoms)
                {
                    TeamFilterData AwayRandom = away;
                    int randomYear = new Random().Next(2018, 2019 + 1);
                    int randomMonth = new Random().Next(1, 12 + 1);
                    int randomDay = new Random().Next(1, 30 + 1);
                    int randomHour = new Random().Next(10, 18 + 1);
                    DateTime randomDate = new DateTime(randomYear, randomMonth, randomDay, randomHour, 0, 0);

                    int stageRandomIndex = new Random().Next(0, GetStages().Take(6).ToList<IStage>().Count);
                    IStage StageRandom = GetStages().ToList<IStage>()[stageRandomIndex];

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
                        MatchDescription = "Tego nie będziemy randomizować...",
                        Stage = StageRandom,
                        MVP = PlayerRandom,
                    };
                }
            }
        }

        public IEnumerable<LeagueFilterData> GetLeagues()
        {
            League League2 = GetPureLeagues().ToList<League>()[0];
            League League1 = GetPureLeagues().ToList<League>()[1];
            League ExtraLeague = GetPureLeagues().ToList<League>()[2];

            Season season2019 = GetSeasons().ToList<Season>()[0];
            Season season2018_2019 = GetSeasons().ToList<Season>()[1];

            yield return new LeagueFilterData(1)
            {
                League = League2, 
                Season = season2019
            };
            yield return new LeagueFilterData(1)
            {
                League = League2,
                Season = season2018_2019
            };
            yield return new LeagueFilterData(1)
            {
                League = League1,
                Season = season2019
            };
            yield return new LeagueFilterData(1)
            {
                League = ExtraLeague,
                Season = season2019
            };
        }

        public IEnumerable<League> GetPureLeagues()
        {
            yield return new League(1) { Name = "2 Liga" };
            yield return new League(2) { Name = "1 Liga" };
            yield return new League(3) { Name = "Ekstraliga" };
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
            //LEAGUE 2, SEASON2019
            //GROUP C
            yield return new TeamFilterData(1)
            {
                Team = new Team(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(2)
            {
                Team = new Team(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(3)
            {
                Team = new Team(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(5)
            {
                Team = new Team(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(6)
            {
                Team = new Team(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(7)
            {
                Team = new Team(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(8)
            {
                Team = new Team(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(10)
            {
                Team = new Team(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamFilterData(11)
            {
                Team = new Team(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            //GROUP A
            yield return new TeamFilterData(12)
            {
                Team = new Team(10) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamFilterData(13)
            {
                Team = new Team(11) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamFilterData(14)
            {
                Team = new Team(12) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamFilterData(15)
            {
                Team = new Team(13) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            //GROUP B
            yield return new TeamFilterData(16)
            {
                Team = new Team(14) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamFilterData(17)
            {
                Team = new Team(15) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamFilterData(18)
            {
                Team = new Team(16) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamFilterData(25)
            {
                Team = new Team(17) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            //GROUP D
            yield return new TeamFilterData(19)
            {
                Team = new Team(18) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };           
            yield return new TeamFilterData(20)
            {
                Team = new Team(19) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamFilterData(21)
            {
                Team = new Team(20) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamFilterData(22)
            {
                Team = new Team(21) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            //LEAGUE 2, SEASON2018_2019
            //GROUP C
            yield return new TeamFilterData(23)
            {
                Team = new Team(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(24)
            {
                Team = new Team(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(25)
            {
                Team = new Team(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(26)
            {
                Team = new Team(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(27)
            {
                Team = new Team(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(29)
            {
                Team = new Team(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(32)
            {
                Team = new Team(10) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamFilterData(33)
            {
                Team = new Team(11) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };

            yield return new TeamFilterData(40)
            {
                Team = new Team(18) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            //GROUP A
            yield return new TeamFilterData(30)
            {
                Team = new Team(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamFilterData(31)
            {
                Team = new Team(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamFilterData(34)
            {
                Team = new Team(12) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamFilterData(35)
            {
                Team = new Team(13) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            //GROUP B
            yield return new TeamFilterData(42)
            {
                Team = new Team(21) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamFilterData(37)
            {
                Team = new Team(15) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamFilterData(38)
            {
                Team = new Team(16) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamFilterData(39)
            {
                Team = new Team(17) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            //GROUP D
            yield return new TeamFilterData(36)
            {
                Team = new Team(14) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamFilterData(28)
            {
                Team = new Team(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamFilterData(40)
            {
                Team = new Team(19) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamFilterData(41)
            {
                Team = new Team(20) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            //LEAGUE 1, SEASON2019
            //GROUP A
            yield return new TeamFilterData(45)
            {
                Team = new Team(55) { Name = "Jagiellonia Białystok", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamFilterData(46)
            {
                Team = new Team(56) { Name = "Wigry Suwałki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamFilterData(47)
            {
                Team = new Team(57) { Name = "Żartownisie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamFilterData(48)
            {
                Team = new Team(58) { Name = "Jastrzębie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            //GROUP B
            yield return new TeamFilterData(49)
            {
                Team = new Team(77) { Name = "Wisła Kraków", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamFilterData(50)
            {
                Team = new Team(78) { Name = "Warchoły", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamFilterData(51)
            {
                Team = new Team(79) { Name = "Wentlacja team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamFilterData(52)
            {
                Team = new Team(80) { Name = "Wielmożni Państwo", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };

            //EXTRA LEAGUE, SEASON2019
            //GROUP A
            yield return new TeamFilterData(53)
            {
                Team = new Team(81) { Name = "Wisła Płock", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamFilterData(54)
            {
                Team = new Team(85) { Name = "Los Dos Santos", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamFilterData(55)
            {
                Team = new Team(96) { Name = "UFC basketball's", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamFilterData(58)
            {
                Team = new Team(86) { Name = "Winni się tłumaczą", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            //GROUP B
            yield return new TeamFilterData(59)
            {
                Team = new Team(94) { Name = "Pozdrowienia dla więzienia", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamFilterData(60)
            {
                Team = new Team(87) { Name = "Czytelnicy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamFilterData(61)
            {
                Team = new Team(88) { Name = "Masz problem", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamFilterData(63)
            {
                Team = new Team(89) { Name = "Informatycy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
        }

        public IEnumerable<Player> GetPlayers()
        {
            List<TeamFilterData> teams = GetTeams().ToList<TeamFilterData>();
            yield return new Player() { FirstName = "Mateusz", Surname = "Mrozek", Team = teams[0].Team };
            yield return new Player() { FirstName = "Paweł", Surname = "Kuriata", Team = teams[0].Team };
            yield return new Player() { FirstName = "Szymon", Surname = "Kaczyński", Team = teams[0].Team };
            yield return new Player() { FirstName = "Kajetan", Surname = "Panas", Team = teams[0].Team };
            yield return new Player() { FirstName = "Łukasz", Surname = "Dawidowicz", Team = teams[0].Team };
            yield return new Player() { FirstName = "Marcin", Surname = "Obolewicz", Team = teams[0].Team };
            yield return new Player() { FirstName = "John", Surname = "Smith Jr.", Team = teams[1].Team };
            yield return new Player() { FirstName = "Paweł", Surname = "Lis", Team = teams[1].Team };
            yield return new Player() { FirstName = "Piotr", Surname = "Kernel", Team = teams[2].Team };
            yield return new Player() { FirstName = "Jarosław", Surname = "Wieteska", Team = teams[3].Team };
            yield return new Player() { FirstName = "Bartosz", Surname = "Waloń", Team = teams[4].Team };
            yield return new Player() { FirstName = "Marcin", Surname = "Pryć", Team = teams[5].Team };
        }
        public IEnumerable<GroupFilterData> GetGroups()
        {
            LeagueSeason League2Season2019 = GetLeagues().ToList<LeagueFilterData>()[0];
            LeagueSeason League2Season2018_2019 = GetLeagues().ToList<LeagueFilterData>()[1];
            LeagueSeason League1Season2019 = GetLeagues().ToList<LeagueFilterData>()[2];
            LeagueSeason ExtraLeagueSeason2019 = GetLeagues().ToList<LeagueFilterData>()[3];


            yield return new GroupFilterData(1) { LeagueSeason = League2Season2019, Name = "A" };
            yield return new GroupFilterData(2) { LeagueSeason = League2Season2019, Name = "B" };
            yield return new GroupFilterData(3) { LeagueSeason = League2Season2019, Name = "C" };
            yield return new GroupFilterData(4) { LeagueSeason = League2Season2019, Name = "D" };

            yield return new GroupFilterData(5) { LeagueSeason = League2Season2018_2019, Name = "A" };
            yield return new GroupFilterData(6) { LeagueSeason = League2Season2018_2019, Name = "B" };
            yield return new GroupFilterData(7) { LeagueSeason = League2Season2018_2019, Name = "C" };
            yield return new GroupFilterData(8) { LeagueSeason = League2Season2018_2019, Name = "D" };

            yield return new GroupFilterData(9) { LeagueSeason = League1Season2019, Name = "A" };
            yield return new GroupFilterData(10) { LeagueSeason = League1Season2019, Name = "B" };

            yield return new GroupFilterData(11) { LeagueSeason = ExtraLeagueSeason2019, Name = "A" };
            yield return new GroupFilterData(12) { LeagueSeason = ExtraLeagueSeason2019, Name = "B" };
        }
    }
}