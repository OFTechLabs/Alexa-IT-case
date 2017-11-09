# Assignments

There are several skills here that need an implementation for them to work, the templates are there as are the unit tests to verify whether they work. The skills can be implemented in any way as long as the tests verify the skill works according to the requirements.

The assignments listed below go from easy to more difficult, after finishing all assignments you should be capable of developing and publishing an Alexa Skill.

## HelloWorldSkill

_Goal:_ familiarise yourself with the basics of an Alexa skill.

The _HelloWorldskill_ should simply say Hello World!, that's it. Every skill however should handle certain basics, such as help, stop and cancel, so the HelloWorld skill should also handle those cases well. 

Hints:

* The SkillResponse contains a ResponseBody which contains an OutputSpeech, the OutputSpeech contains a Text field which is a string that Alexa will articulate to the user.
* The SkillRequest contains an IntentRequest which contains an Intent and the Name of that Intent describes what the user intended to do. Several intents need to be handled:
  * HelloWorld the user wants Alexa to say hello world!
  * AMAZON.CancelIntent the user wants Alexa to cancel the current activity, you should end the session here
  * AMAZON.StopIntent the user wants to stop the current activity, again end the session
  * AMAZON.HelpIntent the user wants to know what your skill can do

## ScienceFactsSkill

_Goal:_ create a more usefull skill that actually has value to users.

The _ScienceFactsSkill_ should give the user scientific facts, the skill already has a list of facts but the list can be modified to whatever the developer wants it to be. The skill should simply give a random fact from the list when the user requests it.

Hints:

* Much of the HelloWorldSkill can be re-used, we only need to return a different string than 'Hello World!'

## FinancialPlanningSkill

_Goal:_ have an actual conversation with the user and remember and use the answers of previous questions.

The _FinancialPlanningSkill_ should have a conversation with the user to determine their financial goal, their current savings and their monthly contribution. 
At the end of the conversation Alexa should let the user know what the feasability of their goal is. Although the conversation and the algorithm for the feasability are greatly simplified, this describes the use case of one of our products: OPAL.

Hints:

* The skill is entirely stateless, so every call you should determine what to ask the user next. And if all questions have been answered to return the feasability.
  * The only way to _remember_ answers of a user is to place them in the _Session_ and then set _EndSession_ to false. In the session we can keep track of user answers until we have gathered them all.