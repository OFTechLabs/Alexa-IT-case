# Alexa IT-case

The assignments help illustrate how Amazon Alexa skills are developed, after doing the assignments you should be able to create Amazon Alexa skills of your own.

## Setup

The case requires C# and several C# packages, any IDE can be used though Visual Studio 2017 was used to create the case. The following steps are required to setup the environment:

1. Download / clone this repository
2. Install packages using NuGet
    * The easiest method is to install using NuGet by restoring packages with NuGet, you can do it through the IDE or by running `nuget restore` in the console in the root directory of the project.
        * Download the NuGet executable to use it from the command line: `https://www.nuget.org/downloads`  
    * Manually installing the dependencies is more difficult, but in that case open `.\Skills\Skills.csproj` and `.\Tests\Tests.csproj` to see which packages are required in the `<ItemGroup>` list  
3. Run the tests in the `Tests` project, the assignment is to make sure all unit tests succeed.

If you are able to run the unit tests the setup is finished and you are good to go.

### Visual Studio 2015 and older

If Visual Studio 2017 can not be used create your own new project in Visual Studio 2015.

`Skills` requires the following packages:
* Alexa.NET
* Amazon.Lambda.Core
* Amazon.Lambda.Serialization.Json


`Tests` requires the following packages:
* Alexa.NET
* Amazon.Lambda.Core
* Microsoft.NET.Test.Sdk
* MSTest.TestAdapter
* MSTest.TestFramework

The `Tests` project requires code from the `Skills` project so include a reference to the `Skills` project in the `Tests` project.

After the project is created simply add the source-files from the 2017-project to your own project:

* .\Skills\FinancialPlanningSkill.cs
* .\Skills\HelloWorldSkill.cs
* .\Skills\ScienceFactsSkill.cs
* .\Tests\FinancialPlanningSkillTests.cs
* .\Tests\HelloWorldTests.cs
* .\Tests\ScienceFactsTests.cs

## Assignment

The .\Skills\README.md file gives all the required instructions for the case, open that README to get started with the assignments.

## Testing
_Amazon accounts are required to deploy and test skills_

To test whether the skills would work on Alexa itself the skill will have to be deployed to Amazon Lambda and an Emulator can be used to see if it works.

### Deployment
_Please note that an Amazon Lambda account is required_

The following tutorial by Matthias Shapiro perfectly explains how to deploy a C# Amazon Alexa skill to Amazon Lambda: 

```
http://matthiasshapiro.com/2017/02/10/tutorial-alexa-skills-in-c-setup/
```
 
### Emulation
_Please note that an Amazon account is required_

 
To emulate whether a skill works without using an actual Amazon Echo or other hardware, the following online emulator can be used:

```
https://echosim.io/
``` 
 
 