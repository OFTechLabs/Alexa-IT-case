using System.Collections.Generic;
using Amazon.Lambda.Core;
using Amazon.Lambda.Serialization;
using Alexa.NET.Response;
using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Newtonsoft.Json;

// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializerAttribute(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace FinancialPlanningSkill
{
    public class FinancialPlanningSkill
    {

        public static string GOAL_AMOUNT_KEY = "GoalAmount";
        public static string INITIAL_SAVINGS_KEY = "InitialSavings";
        public static string MONTHLY_CONTRIBUTION_KEY = "MonthlyContribution";
        public static string GOAL_PERIOD_KEY = "GoalPeriod";
        public static string DYNAMIC_NUMBER_KEY = "Dynamic";

        public static string WELCOME_MESSAGE = "Welcome to financial planning. I can help you determine whether your current financial goals are feasable. What is the amount you need to achieve your financial goal?";
        public static string HELP_MESSAGE = "I can help you achieve your financial goals, to start, tell me how much is necessary to achieve your goal?";

        public static string GOAL_AMOUNT_QUESTION = "What is the amount you need to achieve your financial goal?";
        public static string INITIAL_SAVINGS_QUESTION = "How much have you currently saved?";
        public static string MONTHLY_CONTRIBUTION_QUESTION = "What will your monthly contribution be?";
        public static string AMOUNT_OF_MONTHS_QUESTION = "How many months are left until the goal is achieved?";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            return null;
        }
    }

    public class FeasabilityCalculator
    {

        private static double AVERAGE_ANNUAL_RETURN = 0.114122;
        private static double AVERAGE_MONTHLY_RETURN = AVERAGE_ANNUAL_RETURN / 12.0;

        public static string Calculate(double initialSavings, double monthlyContribution, double numberOfMonths, double target)
        {
            return "High";
        }
    } 
}
