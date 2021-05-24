## Barbeque Weather

### The Task
Based on the upcoming weather, create an application to decide if it is a good idea to begin
a barbeque or not.
##### Requirements
- use model-view-controller design pattern (if possible)
- apply sufficient logging
- if temp is equal or above 20 Celsius and rain is less than 2 mm -> barbecue time.
- if temp is below than 20 Celsius or rain is equal or above than 2 mm -> no barbecue
party
- create basic tests
---
#### Unfinished tasks and improvement ideas:
 - Could not reach 100% test coverage within the given timeframe (3 hours)
 - Configuration should be file based
 - It would be nice to use DI
 - It would be nice to introduce an AOP tool (e.g. Postsharp) for proper logging and error handling
 - It would be better if the user could add the location's name, like Budapest, instead of the coordinates
 - It would be nice to implement retry logic for the OpenWeatherAPI call
 - It would be nice to cache the API responses for a short amount of time
 - Switch between logging methods (console/file/api) through options would be nice
 ---
#### Suggestions regarding the testing possibilities about the application:
 - First of all increase unit test coverage to 100%
 - Next step would be Component tests, where the integration between at least 2 interacting classes would be tested in each case
 - Next step would be Integration tests, where complete user flows would be tested, without mocking - this could be behaviour driven, using some tool with Gherkin support
 ---
#### Installation and execution guideline:
##### How to run the app
 1. [Download](https://visualstudio.microsoft.com/downloads/) and install Visual Studio 2019 Community edition.
 2. [Download](https://dotnet.microsoft.com/download/dotnet/3.1) latest .Net Core 3.1 package. There is a high chance that VS2019 installation already installed it, you may check it by opening cmd/terminal and type in *dotnet --info*.
 3. Open BarbequeWeather.sln with Visual Studio and click on start button (green play button with BarbequeWeather title next to it)
 ##### How to run tests
 1. After opened the solution in Visual Studio, in the top menu bar click on View -> Test Explorer
 2. Test Explorer opens, listing all the tests found in the solution.
 3. From here you can navigate to the code of a test by double clicking on it's name.
