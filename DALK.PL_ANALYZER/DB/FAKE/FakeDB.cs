using DALK.PL_ANALYZER.DB.JSONs;
using DALK.PL_ANALYZER.Models;
using DALK.PL_ANALYZER.Models.GridFilter;
using DALK.PL_ANALYZER.Models.Matches;
using DALK.PL_ANALYZER.Models.Shared;
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

        public IEnumerable<Match> GetMatches(MatchesRawFilterValues parameters)
        {
            List<Match> notPlayedMatches = new JavaScriptSerializer().Deserialize<List<Match>>(GetNotPlayedMatchesJson());
            List<PlayedMatch> playedMatches = new JavaScriptSerializer().Deserialize<List<PlayedMatch>>(GetPlayedMatchesJson());
            List<Match> allMatches = notPlayedMatches.Concat(playedMatches).ToList<Match>();

            DateTime? fromDate = DateTimeFormatter.GetDateTime(parameters.matchFromDate);
            DateTime? toDate = DateTimeFormatter.GetDateTime(parameters.matchToDate);
            allMatches = allMatches.Where(x =>
                (x.Home.GroupSeason.LeagueSeason.Season.Id.ToString() == parameters.matchSeasonId || parameters.matchSeasonId == null) &&
                (x.Home.GroupSeason.LeagueSeason.League.Id.ToString() == parameters.matchLeagueId || parameters.matchLeagueId == null) &&
                (x.Home.Team.Id.ToString() == parameters.matchTeamId || parameters.matchTeamId == null) &&
                (x.Home.GroupSeason.Id.ToString() == parameters.matchGroupId || parameters.matchGroupId == null) &&
                (x.Stage.StageName == parameters.matchStageId || parameters.matchStageId == null) && 
                (x.DateTime.Date >= fromDate || fromDate == null) &&
                (x.DateTime.Date <= toDate || toDate == null)
            ).ToList<Match>();

            return allMatches; 

            /*
            string notPlayedMatches = new JavaScriptSerializer().Serialize(GetNotPlayedMatches());
            string playedMatches = new JavaScriptSerializer().Serialize(GetPlayedMatches());

            return null;
            */
        }

        public IEnumerable<Match> GetNotPlayedMatches()
        {
            yield return new Match()
            {
                Home = GetListOfTeamSeason().ToList<TeamSeason>()[0],
                Away = GetListOfTeamSeason().ToList<TeamSeason>()[10],
                DateTime = new DateTime(2019, 6, 25),
                Id = new Guid("bb346c95-6942-43e5-808e-d46bb20847ae"),
                MatchDescription = "Mecz o wszystko, który dopiero zostanie rozegrany!",
                Stage = new PlayOffStage(1)
            };
            yield return new Match()
            {
                Home = GetListOfTeamSeason().ToList<TeamSeason>()[3],
                Away = GetListOfTeamSeason().ToList<TeamSeason>()[7],
                DateTime = new DateTime(2019, 6, 25),
                Id = new Guid("375404a0-ee08-4938-82b4-781d4fb7b358"),
                MatchDescription = "Ten mecz jeszcze nie jest rozegrany, ależ tam będą emocje, ależ tam będą nerwy!",
                Stage = new PlayOffStage(0)
            };
        }
        public IEnumerable<PlayedMatch> GetPlayedMatches()
        {
            List<TeamSeason> teams = GetListOfTeamSeason().Take(9).ToList<TeamSeason>();
            LeagueFilterData ourLeague = GetPureLeagues().ToList<LeagueFilterData>()[0];
            SeasonFilterData ourSeason = GetSeasons().GetSeasonFilterData().ToList<SeasonFilterData>()[0];
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

                List<TeamSeason> AwayRandoms = GetListOfTeamSeason().Where(x => x.GroupSeason.Id.ToString() == home.GroupSeason.Id.ToString() && x.Id.ToString() != home.Id.ToString()).Take(5).ToList<TeamSeason>();
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

            Season season2019 = GetSeasons().GetSeasonFilterData().ToList<Season>()[0];
            Season season2018_2019 = GetSeasons().GetSeasonFilterData().ToList<Season>()[1];
            yield return new LeagueSeason(new Guid("31deaf59-f4d1-4a2a-8b30-fcefe4eb7f33"))
            {
                League = League2,
                Season = season2019
            };
            yield return new LeagueSeason(new Guid("931eb164-b2db-4069-902b-7f0cff85d416"))
            {
                League = League2,
                Season = season2018_2019
            };
            yield return new LeagueSeason(new Guid("6bf4f5bd-2f2f-4486-9eb5-04bfe2516a80"))
            {
                League = League1,
                Season = season2019
            };
            yield return new LeagueSeason(new Guid("bef4a9ac-753d-4a0e-bb44-73df16502725"))
            {
                League = ExtraLeague,
                Season = season2019
            };
        }
        public IEnumerable<LeagueFilterData> GetPureLeagues()
        {
            yield return new LeagueFilterData(new Guid("eb0a08f9-fb46-49ff-a637-5d892ec65510")) { Name = "2 Liga" };
            yield return new LeagueFilterData(new Guid("94a947b4-06cd-455c-8ad4-a71f5ef0cd86")) { Name = "1 Liga" };
            yield return new LeagueFilterData(new Guid("f02c7310-1d75-4e3b-a4e8-37a524270273")) { Name = "Ekstraliga" };
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
        public Seasons GetSeasons(string seasonId = null)
        {
            List<SeasonFilterData> season = new List<SeasonFilterData>();
            season.Add(new SeasonFilterData(new Guid("7d41d754-dc61-48f0-bfc2-3dd0b9d08411")) { FirstYear = 2019, FromDate = new DateTime(2019, 3, 1), ToDate = new DateTime(2019, 6, 30) });
            season.Add(new SeasonFilterData(new Guid("446b556e-6e3d-42c2-8ae6-772d6f753952")) { FirstYear = 2018, SecondYear = 2019, FromDate = new DateTime(2018, 9, 1), ToDate = new DateTime(2019, 1, 31) });
            return new Seasons(season.Where(x => x.Id.ToString() == seasonId || seasonId == null));
        }
        public IEnumerable<TeamSeason> GetListOfTeamSeason()
        {
            //LEAGUE 2, SEASON2019
            //GROUP C
            yield return new TeamSeason(new Guid("c55f7ce4-7f98-4ae4-82e4-20305b373ba4"))
            {
                Team = new TeamFilterData(new Guid("f8170232-a45e-4478-8df5-05138701c4a9")) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("fd21184f-451d-43a9-b9e7-216dae2c0b1d"))
            {
                Team = new TeamFilterData(new Guid("6d9720a6-5073-4a5d-afce-f0235fae9c74")) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("c6df6282-36e4-4048-8d1a-6d4271824c09"))
            {
                Team = new TeamFilterData(new Guid("1089ec0c-99c2-4b06-aebb-815f9fccbe7d")) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("08ceada5-aef2-4fd8-aaad-2faf8362719f"))
            {
                Team = new TeamFilterData(new Guid("108dd7c9-03ff-4f07-8cfc-af7a8c3ccb49")) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("261c1f0a-e200-427d-b69a-a0aa1d00c719"))
            {
                Team = new TeamFilterData(new Guid("fd934812-2cf5-434e-b88d-7c6ee15d9c03")) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("ba0194b8-10a9-4fca-82ba-015cff97c172"))
            {
                Team = new TeamFilterData(new Guid("ba02c6bf-72e3-4d94-8445-0c61b58371fe")) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("7ef34daf-0aed-43c3-a26d-9fa21e59270c"))
            {
                Team = new TeamFilterData(new Guid("d69b5e13-b8cb-4381-b042-4dbbc68f10c8")) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("fd6d6731-9a9b-41c3-bb39-53092476be7f"))
            {
                Team = new TeamFilterData(new Guid("ccdd1e89-7b87-4f89-b8c3-3a0bb9782f8a")) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            yield return new TeamSeason(new Guid("3cefc575-b4d7-489d-877f-fa5a4f4b747c"))
            {
                Team = new TeamFilterData(new Guid("b61b3012-f9b7-4046-bde5-4fd0727773b0")) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[2]
            };
            //GRUPA A
            yield return new TeamSeason(new Guid("80edbd42-9de4-4f63-8a76-5d1d4ec0cfd2"))
            {
                Team = new TeamFilterData(new Guid("2ae2eb86-1659-45fd-ad26-7b6f3c14365a")) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(new Guid("3a91a2b2-53c1-4773-9906-565fc678a09f"))
            {
                Team = new TeamFilterData(new Guid("adcb80a3-fc8d-4a58-9378-161fcf8374e3")) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(new Guid("7c5746f6-3ffb-4d5f-a276-1fb6536b5774"))
            {
                Team = new TeamFilterData(new Guid("c19051c8-0158-49e2-8de5-4069838db515")) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            yield return new TeamSeason(new Guid("61166359-7d8e-4ae7-9f4f-0a8a533bcbc5"))
            {
                Team = new TeamFilterData(new Guid("f2d3ca71-d688-4842-a13b-8e95e356b7f9")) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[0]
            };
            //GROUP B
            yield return new TeamSeason(new Guid("d4a4ac04-b952-4f6a-8473-2ccec24aaa49"))
            {
                Team = new TeamFilterData(new Guid("bce7548a-72fd-4a2f-a693-231ec7ef6030")) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(new Guid("46ffe24d-d699-4d44-b8c4-4833579ba1a3"))
            {
                Team = new TeamFilterData(new Guid("6b13da9f-e1fb-4675-998c-faed85094254")) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(new Guid("b1ca950c-79d7-497c-9ae2-823b17e8e714"))
            {
                Team = new TeamFilterData(new Guid("cabba6fc-7fb7-467c-8c24-41618dbccaea")) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            yield return new TeamSeason(new Guid("27c5eaa0-6083-444f-9e75-c6b3bec29f4a"))
            {
                Team = new TeamFilterData(new Guid("9a28f7cd-f235-4732-a946-2744a7b7a7d3")) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[1]
            };
            //GROUP D
            yield return new TeamSeason(new Guid("ce18b242-57cb-4b1f-bae1-9381cd26f969"))
            {
                Team = new TeamFilterData(new Guid("ee8bccfb-cda2-4154-a178-e2d56fc6d38f")) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(new Guid("0594f4b0-0687-401a-a636-d38507aa4740"))
            {
                Team = new TeamFilterData(new Guid("835e96cf-625a-42ff-8802-4b77355a989b")) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(new Guid("ead7fdc6-a99a-4129-8827-f383770a30df"))
            {
                Team = new TeamFilterData(new Guid("002031b4-f9bd-4444-b418-eabb17480476")) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            yield return new TeamSeason(new Guid("7a570bba-5b16-4de2-bcbc-e057136d116e"))
            {
                Team = new TeamFilterData(new Guid("9773d46f-2130-4522-9651-9eee6bd00708")) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[3]
            };
            //LEAGUE 2, SEASON2018_2019
            //GROUP C
            yield return new TeamSeason(new Guid("36e356fc-2858-42a9-b536-c2a9616f2fdf"))
            {
                Team = new TeamFilterData(new Guid("f8170232-a45e-4478-8df5-05138701c4a9")) { Name = "WakeTrip", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/LAL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("eb039392-3466-4e44-b20c-4db4e5886b4e"))
            {
                Team = new TeamFilterData(new Guid("6d9720a6-5073-4a5d-afce-f0235fae9c74")) { Name = "FireCruda Basketball Team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/POR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("1130519d-3728-4ec5-9864-7dcfb8bb4d35"))
            {
                Team = new TeamFilterData(new Guid("1089ec0c-99c2-4b06-aebb-815f9fccbe7d")) { Name = "Sami Swoi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/UTA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("be4f08ed-148a-44d5-abc4-6568a3dc100e"))
            {
                Team = new TeamFilterData(new Guid("108dd7c9-03ff-4f07-8cfc-af7a8c3ccb49")) { Name = "B-Ball Styl Dzierżoniów", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("fc3544c7-b10d-484e-925b-d75235a64f66"))
            {
                Team = new TeamFilterData(new Guid("fd934812-2cf5-434e-b88d-7c6ee15d9c03")) { Name = "Gwardia Wrocław", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/MIL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("2e8260c0-c93e-44de-9e28-339db6d136ae"))
            {
                Team = new TeamFilterData(new Guid("d69b5e13-b8cb-4381-b042-4dbbc68f10c8")) { Name = "KSP Gospoda", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/ORL.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("75116935-3a43-4369-b075-2697d6cf2bf9"))
            {
                Team = new TeamFilterData(new Guid("2ae2eb86-1659-45fd-ad26-7b6f3c14365a")) { Name = "Giganci", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            yield return new TeamSeason(new Guid("21e51f86-f6d2-404d-a05c-ba1353366e7f"))
            {
                Team = new TeamFilterData(new Guid("adcb80a3-fc8d-4a58-9378-161fcf8374e3")) { Name = "Avengers", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };

            yield return new TeamSeason(new Guid("b544bf52-3b1f-402b-b58d-f2041cc16dd0"))
            {
                Team = new TeamFilterData(new Guid("ee8bccfb-cda2-4154-a178-e2d56fc6d38f")) { Name = "Myszki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[6]
            };
            //GROUP A
            yield return new TeamSeason(new Guid("042691ac-ffbe-4d3e-955f-2c01df4a611b"))
            {
                Team = new TeamFilterData(new Guid("ccdd1e89-7b87-4f89-b8c3-3a0bb9782f8a")) { Name = "Rosenthal", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/TOR.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(new Guid("137c1163-c0ec-419e-b748-073dd84977b5"))
            {
                Team = new TeamFilterData(new Guid("b61b3012-f9b7-4046-bde5-4fd0727773b0")) { Name = "Łobuzersi", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/OKC.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(new Guid("b6b82ccb-580b-463c-86fa-4ecedbd40cc0"))
            {
                Team = new TeamFilterData(new Guid("c19051c8-0158-49e2-8de5-4069838db515")) { Name = "Parafianie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            yield return new TeamSeason(new Guid("b4376f94-9adf-48bb-b988-55f0cf8433e9"))
            {
                Team = new TeamFilterData(new Guid("f2d3ca71-d688-4842-a13b-8e95e356b7f9")) { Name = "Bracia z Zakonu", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[4]
            };
            //GROUP B
            yield return new TeamSeason(new Guid("36838b91-e21b-434e-a98c-1f7ec8261903"))
            {
                Team = new TeamFilterData(new Guid("9773d46f-2130-4522-9651-9eee6bd00708")) { Name = "West Side", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(new Guid("82ab7c13-5cca-40b7-add8-50bc8203115e"))
            {
                Team = new TeamFilterData(new Guid("6b13da9f-e1fb-4675-998c-faed85094254")) { Name = "Byki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(new Guid("a0284b81-10c6-4532-9f70-844e0a7dd211"))
            {
                Team = new TeamFilterData(new Guid("cabba6fc-7fb7-467c-8c24-41618dbccaea")) { Name = "Mocarze", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            yield return new TeamSeason(new Guid("0cf1d7d2-dc0a-4319-bbcb-1e43991bf1e5"))
            {
                Team = new TeamFilterData(new Guid("9a28f7cd-f235-4732-a946-2744a7b7a7d3")) { Name = "Zwierzaki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[5]
            };
            //GROUP D
            yield return new TeamSeason(new Guid("e251ce1f-eb94-4b18-9b39-48a5b1da6665"))
            {
                Team = new TeamFilterData(new Guid("bce7548a-72fd-4a2f-a693-231ec7ef6030")) { Name = "Małpy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(new Guid("29238d10-6d81-445a-ae51-c88c03790522"))
            {
                Team = new TeamFilterData(new Guid("ba02c6bf-72e3-4d94-8445-0c61b58371fe")) { Name = "Whyducki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(new Guid("a6718fb7-7ccd-437e-86a3-cbeee0f0f6a2"))
            {
                Team = new TeamFilterData(new Guid("835e96cf-625a-42ff-8802-4b77355a989b")) { Name = "Tylko rzuty za trzy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            yield return new TeamSeason(new Guid("46cfdd1f-09e5-4e7f-b0f7-d52960b9e327"))
            {
                Team = new TeamFilterData(new Guid("002031b4-f9bd-4444-b418-eabb17480476")) { Name = "Przetrwali Czarnobyl", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[7]
            };
            //LEAGUE 1, SEASON2019
            //GROUP A
            yield return new TeamSeason(new Guid("43e370ed-5173-407d-863e-4e4693ffef96"))
            {
                Team = new TeamFilterData(new Guid("133ee2f8-03b6-44ec-9eb0-85a326449da2")) { Name = "Jagiellonia Białystok", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(new Guid("c4a5cae0-f099-4e72-93a1-89d8c25cb3cf"))
            {
                Team = new TeamFilterData(new Guid("759f3690-fce5-4fa6-bd92-6e648abda648")) { Name = "Wigry Suwałki", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(new Guid("c8a003e7-73df-4ef8-8368-9bed5937f59c"))
            {
                Team = new TeamFilterData(new Guid("4f421276-8635-4c35-8997-40d3b989b061")) { Name = "Żartownisie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            yield return new TeamSeason(new Guid("e268d7b0-0889-4715-90fa-88dae8a34e79"))
            {
                Team = new TeamFilterData(new Guid("f348e5a5-e5f7-4cb6-b9d9-1fb460a42f07")) { Name = "Jastrzębie", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[8]
            };
            //GROUP B
            yield return new TeamSeason(new Guid("7876d82f-bfb1-4204-9422-64eae72aa14d"))
            {
                Team = new TeamFilterData(new Guid("dc74dfeb-9a7f-4da1-8a61-e0c532a60678")) { Name = "Wisła Kraków", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(new Guid("6ed45ce5-0011-4999-9b63-5394c26532b3"))
            {
                Team = new TeamFilterData(new Guid("0573b925-478f-4ef0-bfb2-a7661f4ec222")) { Name = "Warchoły", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(new Guid("7ba20fd6-4a63-48e4-a7fd-1cf62cad65b3"))
            {
                Team = new TeamFilterData(new Guid("42547979-81c4-44ea-9ffb-cf4bc3ec50ba")) { Name = "Wentlacja team", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            yield return new TeamSeason(new Guid("1fca9d3b-66dd-466e-b1a9-75478eff980b"))
            {
                Team = new TeamFilterData(new Guid("06b7ddf8-ddda-41f9-93b1-8d53d76564cf")) { Name = "Wielmożni Państwo", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[9]
            };
            //EXTRA LEAGUE, SEASON2019
            //GROUP A
            yield return new TeamSeason(new Guid("ef76d7c8-ea65-4c2d-a84e-4b34656c5f67"))
            {
                Team = new TeamFilterData(new Guid("910198f4-0525-4d41-9c1f-296390508a4c")) { Name = "Wisła Płock", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(new Guid("5dbad6d7-3e60-4685-b9ed-a5020306e6a6"))
            {
                Team = new TeamFilterData(new Guid("f176799a-f4f5-4a06-8e49-c797b7f2324f")) { Name = "Los Dos Santos", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(new Guid("189195c1-955c-4fb7-870f-b078f401b9fe"))
            {
                Team = new TeamFilterData(new Guid("5cfa377d-a8ba-4adc-9b4c-e6c1c74ae2e6")) { Name = "UFC basketball's", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            yield return new TeamSeason(new Guid("4d8101de-5f50-46dc-acbf-73b11b1bc44b"))
            {
                Team = new TeamFilterData(new Guid("d7d05049-2c08-44d6-bf5c-516de571f88c")) { Name = "Winni się tłumaczą", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[10]
            };
            //GROUP B
            yield return new TeamSeason(new Guid("027b9381-225a-40a9-950b-5e0c95f4fb3f"))
            {
                Team = new TeamFilterData(new Guid("11c108e6-b11f-4a9d-843d-ac4d68f17d6d")) { Name = "Pozdrowienia dla więzienia", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(new Guid("05bd68e3-5fee-4a3d-a1a0-6f9227195eca"))
            {
                Team = new TeamFilterData(new Guid("e8a95e88-6f02-4c07-859c-927819bacd18")) { Name = "Czytelnicy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/BOS.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(new Guid("0d0bba39-a8f3-44de-b31e-ee427979183e"))
            {
                Team = new TeamFilterData(new Guid("5b47982e-386e-4de6-9a1d-754cccc6c1e6")) { Name = "Masz problem", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
                GroupSeason = GetGroups().ToList<GroupFilterData>()[11]
            };
            yield return new TeamSeason(new Guid("7f035b23-870d-44d9-8736-d0be98972568"))
            {
                Team = new TeamFilterData(new Guid("558d5257-545a-4303-a413-24af55d567fc")) { Name = "Informatycy", URL = "http://cdn.nba.net/assets/logos/teams/secondary/web/NBA.svg" },
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

            yield return new GroupFilterData(new Guid("26caa413-bfaa-4eae-830b-05bd0fd9e698")) { LeagueSeason = League2Season2019, Name = "A" };
            yield return new GroupFilterData(new Guid("40fcf44f-17d1-4595-97be-50d0401e4e50")) { LeagueSeason = League2Season2019, Name = "B" };
            yield return new GroupFilterData(new Guid("b0008ccd-0bf5-44cf-b2bf-3bd1e978984c")) { LeagueSeason = League2Season2019, Name = "C" };
            yield return new GroupFilterData(new Guid("ab863d09-3a7e-467c-b8e5-5d60b16f2089")) { LeagueSeason = League2Season2019, Name = "D" };

            yield return new GroupFilterData(new Guid("860225e9-5422-42b2-98a3-b5f7c986c08e")) { LeagueSeason = League2Season2018_2019, Name = "A" };
            yield return new GroupFilterData(new Guid("8b79833c-076e-4bc3-919e-bd1ffda582fb")) { LeagueSeason = League2Season2018_2019, Name = "B" };
            yield return new GroupFilterData(new Guid("413fe648-301f-4a1f-a9b2-4abfca31cf68")) { LeagueSeason = League2Season2018_2019, Name = "C" };
            yield return new GroupFilterData(new Guid("3e204f6b-d421-4b5e-9ff7-e7cd62ba277c")) { LeagueSeason = League2Season2018_2019, Name = "D" };

            yield return new GroupFilterData(new Guid("05cc66c4-c2c2-4ea4-a0a4-abab76239c57")) { LeagueSeason = League1Season2019, Name = "A" };
            yield return new GroupFilterData(new Guid("3ebfb79c-b77c-4390-a1fe-fb12f0fa0e48")) { LeagueSeason = League1Season2019, Name = "B" };

            yield return new GroupFilterData(new Guid("8741f955-6298-424b-b3f3-3e233bc6f91a")) { LeagueSeason = ExtraLeagueSeason2019, Name = "A" };
            yield return new GroupFilterData(new Guid("14131d0e-6959-4e63-ac0c-5acddedf79b4")) { LeagueSeason = ExtraLeagueSeason2019, Name = "B" };
        }
        public LeaguesSeason GetLeaguesSeason(string seasonId = null)
        {
            return new LeaguesSeason(GetListOfLeagueSeason().Where(x => x.Season.Id.ToString() == seasonId || seasonId == null));
        }
        public TeamsSeason GetTeamsSeason(string seasonId = null, string leagueId = null, string groupId = null)
        {
            return new TeamsSeason(GetListOfTeamSeason().
                Where(x => (x.GroupSeason.LeagueSeason.League.Id.ToString() == leagueId || leagueId == null) &&
                           (x.GroupSeason.LeagueSeason.Season.Id.ToString() == seasonId || seasonId == null) &&
                           (x.GroupSeason.Id.ToString() == groupId || groupId == null)
            ));
        }
        public GroupsSeason GetGroupsSeason(string seasonId = null, string leagueId = null)
        {
            return new GroupsSeason(
                GetGroups().Where(x => (x.LeagueSeason.League.Id.ToString() == leagueId || leagueId == null) &&
                                       (x.LeagueSeason.Season.Id.ToString() == seasonId || seasonId == null)));
        }
    }
}