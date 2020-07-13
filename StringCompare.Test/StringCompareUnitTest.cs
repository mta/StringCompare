using NUnit.Framework;
using StringCompare.Controllers;
using StringCompare.Models;

namespace StringCompare.Test
{
    public class StringCompareUnitTest
    {
        StringComparisonController StringCompareController = new StringComparisonController();
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void NoMatches()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "No Matches Here";
            model.SubText = "ab";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == false);
        }

        [Test]
        public void OneMatch()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "We should find one match here";
            model.SubText = "one";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == true && testResult.Positions.Count == 1);
        }

        [Test]
        public void TwoMatches()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "We should find two matches here because this is a test for two";
            model.SubText = "two";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == true && testResult.Positions.Count == 2);
        }

        [Test]
        public void TwoMatchesCaseInSensitive()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "We should find Two matches here because this is a test for TWO";
            model.SubText = "two";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == true && testResult.Positions.Count == 2);
        }

        [Test]
        public void ThreeMatchesMixedCase()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "We should find three matches here because this is a test for Three, this extra text so we can get THrEe matches";
            model.SubText = "tHrEe";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == true && testResult.Positions.Count == 3);
        }

        [Test]
        public void NoMatchesWithSubTextLongerThanMainText()
        {
            CompareStringsModel model = new CompareStringsModel();
            model.MainText = "MainText";
            model.SubText = "Short Text is Longer";
            PositionResultModel testResult = StringCompareController.CompareStrings(model);
            Assert.IsTrue(testResult.MatchesFound == false && testResult.Positions.Count == 0);
        }

        //UnComment this if you want to see a failed test
        //[Test]
        //public void IWantThisTestToFail()
        //{
        //    CompareStringsModel model = new CompareStringsModel();
        //    model.MainText = "MainText";
        //    model.SubText = "Short Text is Longer";
        //    PositionResult testResult = StringCompareController.CompareStrings(model);
        //    Assert.IsTrue(testResult.MatchesFound == true && testResult.Positions.Count > 0);
        //}
    }
}