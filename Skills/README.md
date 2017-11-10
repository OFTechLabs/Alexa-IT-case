# Assignments

There are several skills here that need an implementation for them to work, the templates are there as are the unit tests to verify whether they work. The skills can be implemented in any way as long as the tests verify the skill works according to the requirements.

The assignments listed below go from easy to more difficult, after finishing all assignments you should be capable of developing and publishing an Alexa Skill.

## Function handler

When your skill is invoked the FunctionHandler will be called:

```csharp
public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
```

The context can be safely ignored for the assignments, the input includes everything you need to create a response. Keep in mind that skills are suppose to be _stateless_, you can not save variables in your skill to use in future requests.

## Request API

The Skill needs to handle every request type `{LaunchRequest, IntentRequest, SessionEndedRequest}`, you can test what kind of request you are dealing with in the following way:

```csharp
input.GetRequestType() == typeof(LaunchRequest)
input.GetRequestType() == typeof(IntentRequest)
input.GetRequestType() == typeof(SessionEndedRequest)
```

Where input is the `SkillRequest`.

### Working with intents

The skill does not receive the sentence the user said, instead it receives the _intent_ of the user. See the _intents.json_ in the SpeechAssets directory to see the different intents of the skills in the assignment. You have to handle all intents in your skill, you can check which intent the user meant in the following way:

```csharp
switch (intentRequest.Intent.Name)
{
    case "AMAZON.CancelIntent":
    case "AMAZON.StopIntent":
		...
    default:
        ...
}
```

Note that the input has to be of type `IntentRequest`, because only `IntentRequest` has an Intent. So you might have to cast the input to `IntentRequest`:

```csharp
public SkillResponse FunctionHandler(SkillRequest input, ILambdaContext context)
{
	IntentRequest intentRequest = (IntentRequest) input;
}
```

### User variables

The user might include variables in their request, these are stored in the request in _slots_, to obtain variables from _slots_ you can do the following:

```csharp
var userInputVariable = intentRequest.Intent.Slots[KEY].Value;
```

The `KEY` is the name of the slot in the _intents.json_

## Response API

To create a simple text response the following objects are required:

```csharp
PlainTextOutputSpeech innerResponse = new PlainTextOutputSpeech();
ResponseBody responseBody = new ResponseBody();
SkillResponse response = new SkillResponse();

response.Response = responseBody;
response.Response.OutputSpeech = innerResponse;
innerResponse.Text = "Your text response here";
```

So you need to create a `PlainTextOutputSpeech`, a `ResponseBody` and finally a `SkillResponse`.


### Session

If you want to store variables during the conversation, they have to be stored in the _session_:

```csharp
SkillResponse response = new SkillResponse();
response.SessionAttributes[KEY] = VALUE;
```

Keep in mind that you have to set `ShouldEndSession` to false if you want to store variables in the _session_:

```csharp
ResponseBody responseBody = new ResponseBody();
SkillResponse response = new SkillResponse();

response.Response = responseBody;
response.Response.ShouldEndSession = endSession;
```

Storing variables in the _session_ is the only way to store variables during a conversation, they can _not_ be stored on the skill itself because skills have to be stateless.

## HelloWorldSkill

_Goal:_ familiarise yourself with the basics of an Alexa skill.

The _HelloWorldskill_ should simply say Hello World!, that's it. Every skill however should handle certain basics, such as help, stop and cancel, so the HelloWorld skill should also handle those cases well. 

Hints:

* The OutputSpeech contains a Text field which is a string that Alexa will articulate to the user.
* Several intents need to be handled:
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