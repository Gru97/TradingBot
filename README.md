### This is a test to get the hang of .Net Core web api.  
Steps:  
* Install .Net Core pre-requisits  
* Install Mono runtime envirenment  
* Install Mono development (Documentation not working on it's own)  
* mono complete installation  
https://www.mono-project.com/download/stable/#download-lin  

Useful Links:  
1.https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-2.2  
2.https://doc.ubuntu-fr.org/monodevelop  
3.https://tutorialforlinux.com/2017/12/09/monodevelop-ubuntu-18-04-installation-guide/  
4.https://www.mono-project.com/download/stable/#download-lin-ubuntu  
5.https://www.c-sharpcorner.com/article/create-net-core-web-api-c-sharp-in-monodevelop-on-ubuntu-18-04/  
6.http://sushihangover.github.io/mono-ubuntu-broken/  
7.https://www.monodevelop.com/download/  
8.https://www.monodevelop.com/documentation/creating-a-simple-solution/  



#### Problems you will face:  
* Cors problem (apart from official documents, use complete https://localhost when setting url for ajax requests)  
Useful Links:  
1.https://stackoverflow.com/questions/52204183/cant-enable-cors-in-asp-net-core-web-api  
2.https://docs.microsoft.com/en-us/aspnet/core/security/cors?view=aspnetcore-2.2  
3.https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio#call-the-api-with-jquery  
4.https://www.toptal.com/asp-dot-net/asp-net-web-api-tutorial  
5.https://stackoverflow.com/questions/46297242/asp-net-core-no-access-control-allow-origin-header-is-present-on-the-request  
6.https://stackoverflow.com/questions/40908949/asp-net-core-cors-webapi-no-access-control-allow-origin-header  
7.https://stackoverflow.com/questions/20035101/why-does-my-javascript-get-a-no-access-control-allow-origin-header-is-present  
8.https://stackoverflow.com/questions/44379560/how-to-enable-cors-in-asp-net-core-webapi  
9.https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?  view=aspnetcore-2.2&tabs=visual-studio  
10.https://docs.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-2.2  
11.http://hamidmosalla.com/2017/03/29/asp-net-core-action-results-explained/  
12.http://www.compilemode.com/2015/12/emptyresult-return-type-in-aspnet-mvc.html  



* Mono debugger not working (yet to be solved)  
* Don't forget to add index.html page in wwwroot directory  
* These are static files and you need to set configurations for them accourding to official documentations.  


To read/write files:  
1. https://docs.microsoft.com/en-us/dotnet/api/system.io.filestream?view=netcore-2.2  
2. https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-2.2https://docs.microsoft.com/en-us/dotnet/api/system.io.streamreader?view=netcore-2.2  



#### Day9  
* add reference of FrameWork class library to my project  
dotnet add app/app.csproj reference lib/lib.csproj  
ref: https://docs.microsoft.com/en-us/dotnet/core/tools/dotnet-add-reference  



* linux multiple command  
1.https://stackoverflow.com/questions/13077241/execute-combine-multiple-linux-commands-in-one-line  
2.https://loune.net/2017/06/running-shell-bash-commands-in-net-core/  

* custom routing in dot net  
https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-2.2  

* processes in dot net  
https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process?view=netcore-2.2  

#### Day 10  
* Installing docker with it's official document won't work, so I followed the hints in terminal and it seems ok.  
I used this link to get over "permission denied" for exec docker commands:  
https://techoverflow.net/2017/03/01/solving-docker-permission-denied-while-trying-to-connect-to-the-docker-daemon-socket/  


* working with jquery  
https://stackoverflow.com/questions/1828924/array-inside-a-javascript-object  


#### Day 11  
I have written a simple program via .Net Core that runs on Ubuntu. Using System.Diagnostics.Process, I run a command in terminal and I want to get the results (normally shown in terminal) as a string. But this command is an ever running command(unless forceably stopped). Is there a way to return partial results while the command is still running?  
Answer:  
https://stackoverflow.com/questions/4291912/process-start-how-to-get-the-output (not working because we are talking about web api)  
https://forums.asp.net/t/2136629.aspx?Event+listener+in+Web+API  

#### Day 12:  

1. Kill a process by it's id  
* https://docs.microsoft.com/en-us/dotnet/api/system.diagnostics.process.id?view=netframework-4.7.2  
* https://stackoverflow.com/questions/50896621/net-core-how-to-properly-kill-started-process  

2. Using "top" command in bash to see the processes  
* https://www.howtogeek.com/107217/how-to-manage-processes-from-the-linux-terminal-10-commands-you-need-to-know/  

3. Writing output of an always running command asynchronously to a file  
(no success)  

