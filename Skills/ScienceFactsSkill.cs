using Alexa.NET.Request;
using Alexa.NET.Request.Type;
using Alexa.NET.Response;
using Amazon.Lambda.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ScienceFactsSkill
{

    public class Facts
    {
        public static List<string> GetFacts()
        {
            List<string> facts = new List<string>();
            facts.Add("There is enough DNA in an average person’s body to stretch from the sun to Pluto and back — 17 times");
            facts.Add("The average human body carries ten times more bacterial cells than human cells");
            facts.Add("It can take a photon 40,000 years to travel from the core of the sun to its surface, but only 8 minutes to travel the rest of the way to Earth");
            facts.Add("At over 2000 kilometers long, The Great Barrier Reef is the largest living structure on Earth");
            facts.Add("There are 8 times as many atoms in a teaspoonful of water as there are teaspoonfuls of water in the Atlantic ocean");
            facts.Add("The average person walks the equivalent of five times around the world in a lifetime");
            facts.Add("When Helium is cooled to almost absolute zero (-460°F or -273°C), the lowest temperature possible, it becomes a liquid with surprising properties: it flows against gravity and will start running up and over the lip of a glass container!");
            facts.Add("If Betelgeuse would explode transiting from the red supergiant stage to supernova then our sky would light continuously for two months. It can happen anytime, within a couple of thousand years, tomorrow or even now");
            facts.Add("An individual blood cell takes about 60 seconds to make a complete circuit of the body");
            facts.Add("The known universe is made up of 50,000,000,000 galaxies. There are between 100,000,000,000 and 1,000,000,000,000 stars in a normal galaxy. In the Milky Way alone there might be as many 100 billion Earth-like planets. Still think you’re alone?");
            return facts;
        }
    }

    public class ScienceFactsSkill
    {
        public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
        {
            return null;
        }
    }
}
