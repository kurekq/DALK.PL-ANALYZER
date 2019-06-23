using DALK.PL_ANALYZER.Models.Matches;
using NUnit.Framework;

namespace Tests
{
    public class DalkMatchTests
    {
        [TestCase(2, 4)]
        [TestCase(1, 2)]
        [TestCase(0, 1)]
        [TestCase(8, 256)]
        public void DuelsInPlayOffStageCounterTest(byte howFar, int duelsExpected)
        {
            DuelsInPlayOffStageCounter dc = new DuelsInPlayOffStageCounter(howFar);
            Assert.AreEqual(duelsExpected, dc.HowManyDuels());
        }
        [TestCase(2, "Playoffy - Æwieræfina³")]
        [TestCase(1, "Playoffy - Pó³fina³")]
        [TestCase(0, "Playoffy - Fina³")]
        [TestCase(7, "Playoffy - 1/128")]
        public void PlayOffStageTest(byte howFar, string nameExpected)
        {
            PlayOffStage pS = new PlayOffStage(howFar);
            Assert.AreEqual(nameExpected, pS.GetStageName());
        }
        [TestCase(2018, true, "2018 Letnia")]
        [TestCase(2010, false, "2010")]
        public void SeasonOneYearTest(int FirstYear, bool IsSummerSeason, string nameExpected)
        {
            Season s = new Season() { FirstYear = FirstYear, IsSummerSeason = IsSummerSeason};
            Assert.AreEqual(nameExpected, s.GetName());
        }

        [TestCase(2018, 2019, true, "2018/2019 Letnia")]
        [TestCase(2010, 2011, false, "2010/2011")]
        public void SeasonTwoYearsTest(int FirstYear, int SecondYear, bool IsSummerSeason, string nameExpected)
        {
            Season s = new Season() { FirstYear = FirstYear, SecondYear = SecondYear, IsSummerSeason = IsSummerSeason };
            Assert.AreEqual(nameExpected, s.GetName());
        }
        [TestCase("C", 1, 7, "Grupa C, Kolejka 1/7")]
        [TestCase("A", 7, 7, "Grupa A, Kolejka 7/7")]
        [TestCase("E", 2, 4, "Grupa E, Kolejka 2/4")]
        public void GroupMatchTitleTest(string groupName, byte roundOf, byte maxRounds, string expectedTitle)
        {
            Group g = new Group() { Name = groupName };
            GroupStage gs = new GroupStage() { Round = roundOf, MaxRound = maxRounds };
            MatchModelView m = new MatchModelView(new Match() { Group = g, Stage = gs });
            Assert.AreEqual(expectedTitle, m.GameTitle);
        }
        [TestCase(2)]
        [TestCase(0)]
        [TestCase(11)]
        [TestCase(5)]
        [TestCase(1)]
        [TestCase(4)]
        public void PlayoffMatchTitleTest(byte howFarFromFinal)
        {
            PlayOffStage gs = new PlayOffStage(howFarFromFinal);
            MatchModelView m = new MatchModelView(new Match() { Stage = gs });
            //I tested GetStageName in other Metod, so i assume, that gs.GetStageName is correct
            Assert.AreEqual(gs.GetStageName(), m.GameTitle);
        }
    }
}