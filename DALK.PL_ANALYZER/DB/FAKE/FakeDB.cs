using DALK.PL_ANALYZER.DB.JSONs;
using DALK.PL_ANALYZER.Models;
using DALK.PL_ANALYZER.Models.Filters;
using DALK.PL_ANALYZER.Models.Matches;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace DALK.PL_ANALYZER.DB.FAKE
{
    public class FakeDB
    {
        public string GetDataFromFile(string filePath)
        {;
            if (File.Exists(filePath))
            {
                return File.ReadAllText(filePath, System.Text.Encoding.Default);
            }
            throw new FileNotFoundException();
        }
        public string GetPlayedMatchesJson()
        {
            return GetDataFromFile(FileDataPaths.PlayedMatchesPath);
        }
        public string GetNotPlayedMatchesJson()
        {
            return GetDataFromFile(FileDataPaths.NotPlayedMatchesPath);
        }

        public IEnumerable<Match> GetMatches(RawFilterValues parameters)
        {
            List<Match> notPlayedMatches = new JavaScriptSerializer().Deserialize<List<Match>>(GetNotPlayedMatchesJson());
            List<PlayedMatch> playedMatches = new JavaScriptSerializer().Deserialize<List<PlayedMatch>>(GetPlayedMatchesJson());
            List<Match> allMatches = notPlayedMatches.Concat(playedMatches).ToList<Match>();

            allMatches = allMatches.Where(x =>
                (x.Home.GroupSeason.LeagueSeason.Season.Id == parameters.matchSeasonId || parameters.matchSeasonId == null) &&
                (x.Home.GroupSeason.LeagueSeason.Id == parameters.matchLeagueId || parameters.matchLeagueId == null) &&
                (x.Home.Team.Id == parameters.matchTeamId || parameters.matchTeamId == null) &&
                //(x.Home.GroupSeason.Id == parameters.matchGroupId || parameters.matchGroupId == null) &&
                (x.Stage.StageName == parameters.matchStageId || parameters.matchStageId == null)
            ).ToList<Match>();

            //List<PlayedMatch> playedM = GetPlayedMatches().ToList<PlayedMatch>();
            //string js = new JavaScriptSerializer().Serialize(playedM);

            return allMatches;
        }

        public IEnumerable<Match> GetNotPlayedMatches()
        {
            yield return new Match()
            {
                Home = GetListOfTeamSeason().ToList<TeamSeason>()[0],
                Away = GetListOfTeamSeason().ToList<TeamSeason>()[10],
                DateTime = new DateTime(2019, 6, 25),
                Id = 111,
                MatchDescription = "Mecz o wszystko, który dopiero zostanie rozegrany!",
                Stage = new PlayOffStage(1)
            };
            yield return new Match()
            {
                Home = GetListOfTeamSeason().ToList<TeamSeason>()[3],
                Away = GetListOfTeamSeason().ToList<TeamSeason>()[7],
                DateTime = new DateTime(2019, 6, 25),
                Id = 115,
                MatchDescription = "Ten mecz jeszcze nie jest rozegrany, ależ tam będą emocje, ależ tam będą nerwy!",
                Stage = new PlayOffStage(0)
            };
        }
        public IEnumerable<PlayedMatch> GetPlayedMatches()
        {
            List<TeamSeason> teams = GetListOfTeamSeason().Take(9).ToList<TeamSeason>();
            LeagueFilterData ourLeague = GetPureLeagues().ToList<LeagueFilterData>()[0];
            SeasonFilterData ourSeason = GetSeasons().GetSeasons().ToList<SeasonFilterData>()[0];
            GroupFilterData ourGroup = GetGroups().ToList<GroupFilterData>()[0];
            List<Stage> stages = GetStages().ToList<Stage>();
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
            
            foreach (TeamSeason home in GetListOfTeamSeason())
            {
                TeamFilterData HomeRandom = home.Team;

                List<TeamSeason> AwayRandoms = GetListOfTeamSeason().Where(x => x.GroupSeason.Id == home.GroupSeason.Id && x.Id != home.Id).Take(5).ToList<TeamSeason>();
                foreach (TeamSeason away in AwayRandoms)
                {
                    TeamFilterData AwayRandom = away.Team;
                    int randomYear = new Random().Next(2018, 2019 + 1);
                    int randomMonth = new Random().Next(1, 12 + 1);
                    int randomDay = new Random().Next(1, 30 + 1);
                    int randomHour = new Random().Next(10, 18 + 1);
                    DateTime randomDate = new DateTime(randomYear, randomMonth, randomDay, randomHour, 0, 0);

                    int stageRandomIndex = new Random().Next(0, GetStages().Take(6).ToList<IStage>().Count);
                    Stage StageRandom = GetStages().ToList<Stage>()[stageRandomIndex];

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
                        Home = home,
                        Away = away,
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
        public IEnumerable<LeagueSeason> GetListOfLeagueSeason()
        {
            LeagueFilterData League2 = GetPureLeagues().ToList<LeagueFilterData>()[0];
            LeagueFilterData League1 = GetPureLeagues().ToList<LeagueFilterData>()[1];
            LeagueFilterData ExtraLeague = GetPureLeagues().ToList<LeagueFilterData>()[2];

            Season season2019 = GetSeasons().GetSeasons().ToList<Season>()[0];
            Season season2018_2019 = GetSeasons().GetSeasons().ToList<Season>()[1];
            yield return new LeagueSeason(1)
            {
                League = League2, 
                Season = season2019
            };
            yield return new LeagueSeason(1)
            {
                League = League2,
                Season = season2018_2019
            };
            yield return new LeagueSeason(1)
            {
                League = League1,
                Season = season2019
            };
            yield return new LeagueSeason(1)
            {
                League = ExtraLeague,
                Season = season2019
            };
        }
        public IEnumerable<LeagueFilterData> GetPureLeagues()
        {
            yield return new LeagueFilterData(1) { Name = "2 Liga" };
            yield return new LeagueFilterData(2) { Name = "1 Liga" };
            yield return new LeagueFilterData(3) { Name = "Ekstraliga" };
        }
        public IEnumerable<Stage> GetStages()
        {
            yield return new GroupStage(1, 6);
            yield return new GroupStage(2, 6);
            yield return new GroupStage(3, 6);
            yield return new GroupStage(4, 6);
            yield return new GroupStage(5, 6);
            yield return new GroupStage(6, 6);
            yield return new PlayOffStage(4);
            yield return new PlayOffStage(3);
            yield return new PlayOffStage(5);
            yield return new PlayOffStage(0);
        }
        public Seasons GetSeasons()
        {
            List<SeasonFilterData> season = new List<SeasonFilterData>();
            season.Add(new SeasonFilterData(1) { FirstYear = 2019, FromDate = new DateTime(2019, 3, 1), ToDate = new DateTime(2019, 6, 30) });
            season.Add(new SeasonFilterData(2) { FirstYear = 2018, SecondYear = 2019, FromDate = new DateTime(2018, 9, 1), ToDate = new DateTime(2019, 1, 31) });
            return new Seasons(season);
        }
        public IEnumerable<TeamSeason> GetListOfTeamSeason()
        {
            //LEAGUE 2, SEASON2019
            //GROUP C
            yield return new TeamSeason(1)
            {
                Team = new TeamFilterData(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(2)
            {
                Team = new TeamFilterData(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(3)
            {
                Team = new TeamFilterData(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(5)
            {
                Team = new TeamFilterData(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(6)
            {
                Team = new TeamFilterData(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(7)
            {
                Team = new TeamFilterData(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(8)
            {
                Team = new TeamFilterData(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(10)
            {
                Team = new TeamFilterData(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(11)
            {
                Team = new TeamFilterData(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            //GRUPA A
            yield return new TeamSeason(12)
            {
                Team = new TeamFilterData(10) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(13)
            {
                Team = new TeamFilterData(11) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(14)
            {
                Team = new TeamFilterData(12) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(15)
            {
                Team = new TeamFilterData(13) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            //GROUP B
            yield return new TeamSeason(16)
            {
                Team = new TeamFilterData(14) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(17)
            {
                Team = new TeamFilterData(15) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(18)
            {
                Team = new TeamFilterData(16) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(25)
            {
                Team = new TeamFilterData(17) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            //GROUP D
            yield return new TeamSeason(19)
            {
                Team = new TeamFilterData(18) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(20)
            {
                Team = new TeamFilterData(19) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(21)
            {
                Team = new TeamFilterData(20) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(22)
            {
                Team = new TeamFilterData(21) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            //LEAGUE 2, SEASON2018_2019
            //GROUP C
            yield return new TeamSeason(23)
            {
                Team = new TeamFilterData(1) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(24)
            {
                Team = new TeamFilterData(2) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(25)
            {
                Team = new TeamFilterData(3) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(26)
            {
                Team = new TeamFilterData(4) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(27)
            {
                Team = new TeamFilterData(5) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(29)
            {
                Team = new TeamFilterData(7) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(32)
            {
                Team = new TeamFilterData(10) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(33)
            {
                Team = new TeamFilterData(11) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };

            yield return new TeamSeason(40)
            {
                Team = new TeamFilterData(18) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            //GROUP A
            yield return new TeamSeason(30)
            {
                Team = new TeamFilterData(8) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(31)
            {
                Team = new TeamFilterData(9) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(34)
            {
                Team = new TeamFilterData(12) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(35)
            {
                Team = new TeamFilterData(13) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            //GROUP B
            yield return new TeamSeason(42)
            {
                Team = new TeamFilterData(21) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(37)
            {
                Team = new TeamFilterData(15) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(38)
            {
                Team = new TeamFilterData(16) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(39)
            {
                Team = new TeamFilterData(17) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            //GROUP D
            yield return new TeamSeason(36)
            {
                Team = new TeamFilterData(14) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(28)
            {
                Team = new TeamFilterData(6) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(40)
            {
                Team = new TeamFilterData(19) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(41)
            {
                Team = new TeamFilterData(20) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            //LEAGUE 1, SEASON2019
            //GROUP A
            yield return new TeamSeason(45)
            {
                Team = new TeamFilterData(55) { Name = "Jagiellonia Białystok", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(46)
            {
                Team = new TeamFilterData(56) { Name = "Wigry Suwałki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(47)
            {
                Team = new TeamFilterData(57) { Name = "Żartownisie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(48)
            {
                Team = new TeamFilterData(58) { Name = "Jastrzębie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            //GROUP B
            yield return new TeamSeason(49)
            {
                Team = new TeamFilterData(77) { Name = "Wisła Kraków", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(50)
            {
                Team = new TeamFilterData(78) { Name = "Warchoły", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(51)
            {
                Team = new TeamFilterData(79) { Name = "Wentlacja team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(52)
            {
                Team = new TeamFilterData(80) { Name = "Wielmożni Państwo", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };

            //EXTRA LEAGUE, SEASON2019
            //GROUP A
            yield return new TeamSeason(53)
            {
                Team = new TeamFilterData(81) { Name = "Wisła Płock", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(54)
            {
                Team = new TeamFilterData(85) { Name = "Los Dos Santos", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(55)
            {
                Team = new TeamFilterData(96) { Name = "UFC basketball's", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(58)
            {
                Team = new TeamFilterData(86) { Name = "Winni się tłumaczą", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            //GROUP B
            yield return new TeamSeason(59)
            {
                Team = new TeamFilterData(94) { Name = "Pozdrowienia dla więzienia", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(60)
            {
                Team = new TeamFilterData(87) { Name = "Czytelnicy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(61)
            {
                Team = new TeamFilterData(88) { Name = "Masz problem", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(63)
            {
                Team = new TeamFilterData(89) { Name = "Informatycy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
        }
        public IEnumerable<Player> GetPlayers()
        {
            List<TeamSeason> teams = GetListOfTeamSeason().ToList<TeamSeason>();
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
            LeagueSeason League2Season2019 = GetListOfLeagueSeason().ToList<LeagueSeason>()[0];
            LeagueSeason League2Season2018_2019 = GetListOfLeagueSeason().ToList<LeagueSeason>()[1];
            LeagueSeason League1Season2019 = GetListOfLeagueSeason().ToList<LeagueSeason>()[2];
            LeagueSeason ExtraLeagueSeason2019 = GetListOfLeagueSeason().ToList<LeagueSeason>()[3];


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
        public LeaguesSeason GetLeaguesSeason()
        {
            return new LeaguesSeason(GetListOfLeagueSeason());
        }
        public TeamsSeason GetTeamsSeason()
        {
            return new TeamsSeason(GetListOfTeamSeason());
        }
    }
}