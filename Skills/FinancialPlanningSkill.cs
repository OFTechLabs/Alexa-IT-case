using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinancialPlanningSkill
{
    public class FinancialPlanningSkill
    {

        public static string GOAL_AMOUNT_KEY = "GoalAmount";
        public static string INITIAL_SAVINGS_KEY = "InitialSavings";
        public static string MONTHLY_CONTRIBUTION_KEY = "MonthlyContribution";
        public static string GOAL_PERIOD_KEY = "GoalPeriod";

        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            return null;
        }
    }
}
