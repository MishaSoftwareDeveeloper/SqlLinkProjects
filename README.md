Run Instructions. <br />

1)Download project <br />
2)Open SqlLinkProjects directory and run "npm install" using comand line or PowerShell -> node modules installed <br />
3)Open WebApi.sln with Visual Studio <br />
4)Open WebConfig in WebApi and open AppConfig in DAL and change user connection properties in the connection string <br />
5)In the solution folder there is SqlQueries file. Run all queries in your DB <br />
6)Set as StartUp project "WebApi" and run-> browser was opened <br />
7)Copy url path for example: http://localhost:56902/ <br />
8)Go to src/proxy.conf.json and replace your url with old url <br />
(This very important because angularjs run on port 4200 and api run on different port -> "CorsPlatform") <br />
9)Open comand line/ powershell in Client directory and run "npm start" -> project and proxy was started <br />
10)Open browser and paste  http://localhost:4200 -> project run <br />

If something is not clear please call me.