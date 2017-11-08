using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorldTests
{
    using System;

    using Alexa.NET.Request;
    using Alexa.NET.Request.Type;
    using HelloWorldSkill;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Alexa.NET.Response;

    [TestClass]
    public class HelloWorldTest
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
            intent.Name = "HelloWorld";
        }

        [TestMethod]
        public void ShouldSayHelloWorld()
        {
            var skill = new HelloWorldSkill();
            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Hello World!");
        }

        [TestMethod]
        public void ShouldHandleCancelCorrectlyInHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "AMAZON.CancelIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
        }

        [TestMethod]
        public void ShouldHandleStopCorrectlyInHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "AMAZON.StopIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
        }

        [TestMethod]
        public void ShouldHandleHelpCorrectlyInHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "AMAZON.HelpIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "I know nothing...");
        }

        [TestMethod]
        public void ShouldHandleUnknownIntentInHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "SomethingElse";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;


            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "I know nothing...");
        }

        [TestMethod]
        public void ShouldEndSessionOnCancelIntentForHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "AMAZON.CancelIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldEndSessionOnStopIntentForHelloWorld()
        {
            var skill = new HelloWorldSkill();

            intent.Name = "AMAZON.StopIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }
    }
}
