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
        public string GetMatchesJson()
        {
            string textFile = @"C:\Users\p.kuriata\Documents\DALK.PL_ANALYZER\DALK.PL_ANALYZER\DB\FAKE\Matches.JSON";
            string matchesJson;
            if (File.Exists(textFile))
            {
                return File.ReadAllText(textFile, System.Text.Encoding.Default);
            }
            throw new FileNotFoundException();
        }
        public IEnumerable<Match> GetMatches()
        {
            return new JavaScriptSerializer().Deserialize<List<Match>>(GetMatchesJson());
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