using System;
using System.Collections.Generic;
using System.Text;

namespace ScienceFactsTests
{
    using System;

    using Alexa.NET.Request;
    using Alexa.NET.Request.Type;
    using ScienceFactsSkill;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Alexa.NET.Response;

    [TestClass]
    public class ScienceFactsTest
    {
        private SkillRequest basicRequest;
        private IntentRequest basicIntent;
        private Intent intent;

        [TestInitialize]
        public void SetUp()
        {
            basicRequest = new SkillRequest();
            basicIntent = new IntentRequest();
            intent = new Intent();


            basicRequest.Request = basicIntent;
            basicIntent.Intent = intent;
            intent.Name = "GiveScienceFact";
        }

        [TestMethod]
        public void ShouldGiveRandomScienceFact()
        {
            var skill = new ScienceFactsSkill();

            intent.Name = "GiveScienceFact";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            CollectionAssert.Contains(Facts.GetFacts(), (output as PlainTextOutputSpeech).Text);
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleCancelCorrectlyInScienceSkill()
        {
            var skill = new ScienceFactsSkill();

            intent.Name = "AMAZON.CancelIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleStopCorrectlyInScienceSkill()
        {
            var skill = new ScienceFactsSkill();

            intent.Name = "AMAZON.StopIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleHelpCorrectlyInScienceSkill()
        {
            var skill = new ScienceFactsSkill();

            intent.Name = "AMAZON.HelpIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "To get a science fact say: 'ask ScienceFacts for a fact'");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleUnknownIntentInScienceSkill()
        {
            var skill = new ScienceFactsSkill();

            intent.Name = "SomethingElse";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "To get a science fact say: 'ask ScienceFacts for a fact'");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }
    }
}
