using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlanningTests
{
    using System;

    using Alexa.NET.Request;
    using Alexa.NET.Request.Type;
    using FinancialPlanningSkill;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Alexa.NET.Response;

    [TestClass]
    public class FinancialPlanningTest
    {
        private SkillRequest basicRequest;
        private IntentRequest basicIntent;
        private Intent intent;
        private Dictionary<String, Slot> slots;
        private Session session;

        [TestInitialize]
        public void SetUp()
        {
            basicRequest = new SkillRequest();
            basicIntent = new IntentRequest();
            intent = new Intent();
            session = new Session();
            session.Attributes = new Dictionary<string, object>();
            slots = new Dictionary<string, Slot>();
            intent.Slots = slots;

            basicRequest.Session = session;
            basicRequest.Request = basicIntent;
            basicIntent.Intent = intent;
            intent.Name = "FinancialPlanning";
        }

        [TestMethod]
        public void ShouldBeAbleToDetermineHighFeasability()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "FinancialPlanning";
            var result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.GOAL_AMOUNT_QUESTION);

            intent.Name = "SetGoalAmount";
            var slot = new Slot();
            slot.Value = "25000";
            slots[FinancialPlanningSkill.GOAL_AMOUNT_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_AMOUNT_KEY], 25000.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.GOAL_AMOUNT_KEY], 25000.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.INITIAL_SAVINGS_QUESTION);
            slots.Remove(FinancialPlanningSkill.GOAL_AMOUNT_KEY);

            intent.Name = "SetIntialSavings";
            slot = new Slot();
            slot.Value = "12000";
            slots[FinancialPlanningSkill.INITIAL_SAVINGS_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.INITIAL_SAVINGS_KEY], 12000.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.INITIAL_SAVINGS_KEY], 12000.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.MONTHLY_CONTRIBUTION_QUESTION);
            slots.Remove(FinancialPlanningSkill.INITIAL_SAVINGS_KEY);

            intent.Name = "SetMonthlyContribution";
            slot = new Slot();
            slot.Value = "275";
            slots[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY], 275.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY], 275.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.AMOUNT_OF_MONTHS_QUESTION);
            slots.Remove(FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY);

            intent.Name = "SetGoalPeriod";
            slot = new Slot();
            slot.Value = "48";
            slots[FinancialPlanningSkill.GOAL_PERIOD_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, true);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_PERIOD_KEY], 48.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.GOAL_PERIOD_KEY], 48.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, "The feasability of your goal is High");
        }

        [TestMethod]
        public void ShouldBeAbleToDetermineLowFeasability()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "FinancialPlanning";
            var result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.GOAL_AMOUNT_QUESTION);

            intent.Name = "SetGoalAmount";
            var slot = new Slot();
            slot.Value = "26000";
            slots[FinancialPlanningSkill.GOAL_AMOUNT_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_AMOUNT_KEY], 26000.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.GOAL_AMOUNT_KEY], 26000.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.INITIAL_SAVINGS_QUESTION);
            slots.Remove(FinancialPlanningSkill.GOAL_AMOUNT_KEY);

            intent.Name = "SetIntialSavings";
            slot = new Slot();
            slot.Value = "11000";
            slots[FinancialPlanningSkill.INITIAL_SAVINGS_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.INITIAL_SAVINGS_KEY], 11000.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.INITIAL_SAVINGS_KEY], 11000.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.MONTHLY_CONTRIBUTION_QUESTION);
            slots.Remove(FinancialPlanningSkill.INITIAL_SAVINGS_KEY);

            intent.Name = "SetMonthlyContribution";
            slot = new Slot();
            slot.Value = "150";
            slots[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY], 150.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY], 150.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, FinancialPlanningSkill.AMOUNT_OF_MONTHS_QUESTION);
            slots.Remove(FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY);

            intent.Name = "SetGoalPeriod";
            slot = new Slot();
            slot.Value = "12";
            slots[FinancialPlanningSkill.GOAL_PERIOD_KEY] = slot;
            result = skill.FunctionHandler(basicRequest, null);
            Assert.AreEqual(result.Response.ShouldEndSession, true);
            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_PERIOD_KEY], 12.0);
            Assert.AreEqual(result.SessionAttributes[FinancialPlanningSkill.GOAL_PERIOD_KEY], 12.0);
            Assert.AreEqual((result.Response.OutputSpeech as PlainTextOutputSpeech).Text, "The feasability of your goal is Low");
        }

        [TestMethod]
        public void ShouldBeAbleToSetGoalAmount()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "SetGoalAmount";
            var slot = new Slot();
            slot.Value = "25000";
     
            slots[FinancialPlanningSkill.GOAL_AMOUNT_KEY] = slot;

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_AMOUNT_KEY], 25000.0);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
        }

        [TestMethod]
        public void ShouldBeAbleToSetInitialSavings()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "SetIntialSavings";
            var slot = new Slot();
            slot.Value = "10000";

            slots[FinancialPlanningSkill.INITIAL_SAVINGS_KEY] = slot;

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.INITIAL_SAVINGS_KEY], 10000.0);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
        }

        [TestMethod]
        public void ShouldBeAbleToSetMonthlyContributions()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "SetMonthlyContribution";
            var slot = new Slot();
            slot.Value = "500";

            slots[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY] = slot;

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.MONTHLY_CONTRIBUTION_KEY], 500.0);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
        }

        [TestMethod]
        public void ShouldBeAbleToSetGoalPeriod()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "SetGoalPeriod";
            var slot = new Slot();
            slot.Value = "36";

            slots[FinancialPlanningSkill.GOAL_PERIOD_KEY] = slot;

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(session.Attributes[FinancialPlanningSkill.GOAL_PERIOD_KEY], 36.0);
            Assert.AreEqual(result.Response.ShouldEndSession, false);
        }

        [TestMethod]
        public void ShouldHandleCancelCorrectlyInFinancialPlanningSkill()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "AMAZON.CancelIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleStopCorrectlyInFinancialPlanningSkill()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "AMAZON.StopIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, "Bye!");
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleHelpCorrectlyInFinancialPlanningSkill()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "AMAZON.HelpIntent";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, FinancialPlanningSkill.HELP_MESSAGE);
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleUnknownIntentInFinancialPlanningSkill()
        {
            var skill = new FinancialPlanningSkill();

            intent.Name = "SomethingElse";

            var result = skill.FunctionHandler(basicRequest, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual((output as PlainTextOutputSpeech).Text, FinancialPlanningSkill.GOAL_AMOUNT_QUESTION);
            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldHandleLaunchRequest()
        {
            var skill = new FinancialPlanningSkill();

            var request = new SkillRequest();
            var launch = new LaunchRequest();
            request.Request = launch;


            var result = skill.FunctionHandler(request, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(result.Response.ShouldEndSession, false);
        }

        [TestMethod]
        public void ShouldHandleSessionEnded()
        {
            var skill = new FinancialPlanningSkill();

            var request = new SkillRequest();
            var sessionEnded = new SessionEndedRequest();
            request.Request = sessionEnded;


            var result = skill.FunctionHandler(request, null);
            var output = result.Response.OutputSpeech;

            Assert.AreEqual(result.Response.ShouldEndSession, true);
        }

        [TestMethod]
        public void ShouldBeHighIfInitialSavingsAreHigherThanGoal()
        {
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 250.0, 12.0, 8000.0), "High");
            Assert.AreEqual(FeasabilityCalculator.Calculate(8000.0, 250.0, 12.0, 8000.0), "High");
            Assert.AreEqual(FeasabilityCalculator.Calculate(8000.1, 250.0, 12.0, 8000.0), "High");
        }

        [TestMethod]
        public void ShouldBeHighIfAverageReturnIsSufficientToAchieveTarget()
        {
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 300.0, 44.0, 30_000.0), "High");
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 250.0, 50.0, 30_000.0), "High");
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 500.0, 720, 1000000), "High");
        }

        [TestMethod]
        public void ShouldBeLowIfAverageReturnIsSufficientToAchieveTarget()
        {
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 300.0, 30.0, 30_000.0), "Low");
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 250.0, 20.0, 30_000.0), "Low");
            Assert.AreEqual(FeasabilityCalculator.Calculate(10_000.0, 300.0, 620, 1000000), "Low");
        }
    }
}
