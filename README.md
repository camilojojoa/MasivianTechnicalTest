# MasivianTechnicalTest
Technical tests to Masivian

This solution has five projects. Three projects are back-end components and two projects are web apps. 
One web app is the Web Api and the other is a MVC Web App that consumes the web api.

After loading the solution in Visual Studio 2017, and Before running the solution, you have to do some configuration:
Right click on Solution -> Properties, and there, in "Startup Project" section, you have to select 
"Multiple startup projects", then, to select "Start for projects "RouletteBetting.WebApi" and "RouletteBetting.Client".

In the web.congif of the "RouletteBetting.Client" project, there are keys, in the AppSettings, to set the url of the apis.
