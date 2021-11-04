# Off the Pool
_____________________________________________________

Are you an entrepreneur trying to find out just what consumers are after? Maybe you are a college student in need of creating a basic survey to collect data for a school project. Even if its just to vote which friends home will host Super Bowl Sunday, we have the app for you. Off the pool is the perfect application if you are in need of collecting data. Efficiently create a poll for any of your data collecting needs.

_____________________________________________________

# Interested in trying this out?

- Clone from GitHub into Visual Studio by using the green button in this repository that says Code
- In order to get the project, open your Command Prompt and type git clone https://github.com/amyjprogrammer/BlueBadge.git into the folder you want this project to reside
- Once downloaded, you can now open the project by clicking on the BlueBadge.sln file
- The goal of this project was to build out the backend so in order to test the API endpoints, you will need to utilize Postman (download- https://www.postman.com/downloads/)
- In order to test in Postman, make sure that you have started the project in Visual Studio. (You can use Ctrl + F5)
- Make note of the localhost number that will show up on the ASP.NET page that just came up.
- To test POST, GET, PUT and DELETE, please first register an account with Postman with your localhost/api/Account/Register
- In order to register, you must enter firstname, lastname, email, password and confirmpassword. 
- Now you need a token, which is your localhost/api/token
- Once you have the token, you can add that in any of the POST, GET, PUT or DELETE options you test by clicking Headers.  You will type Authorization in the Key area and Bearer followed by your token in the value line.

 The app has five tables with full CRUD capabilities.

______________________________________________________________________________________________________________


# Eleven Fifty Academy- Blue Badge Final Project

_____________________________________________________

Eleven Fifty Academy is a 501(c)(3) nonprofit code academy and was the first coding 
bootcamp in Indiana. They believe in impacting the lives of students by providing relevant coding 
skills for the most in-demand jobs in today's tech ecosystem. Check out the website: <https://elevenfifty.org/>

______________________________________________________________________________________________________________

This project utilizes and shows skills with :
* C#
* Agile Methodoligies
* Github
* Repository Patterns
	- Repository Libraries
	- Repository Tests
	- Repository Consoles
* Visual Studio
* Unit Tests
* .NET Framework
* Foreign Keys
* Postman

______________________________________________________________________________________________________________

# Goals for the Project
1. To gain a better understanding of Foreign Keys within C# and how they interact accross mutliple tables.
2. To work alongside a team and utilize the functionality within GitHub to push, pull and merge code.  
3. Expand our knowledge beyond the lessons already provided by Eleven Fifty Academy and utilize all our resources such as Google, Stack Overflow and each other.

_____________________________________________________________________________________________________

## Additional Insights into the Project
1. Remembering to have fun coding even when everything is breaking.  When you have resolved the issue, that is usually when you aquire the most useful insights.  
2. Do **NOT** ever name your console app a name.Console.  That will stop Console.Clear, Console.Write and other Console commands from working.
3. Postman really will give you great feedback on how to solve the issue most of the time.  

_________________________________________________________________________________________________________

## Proud Moments in this App
1. Using Identity Models to add FirstName and LastName as a requirement for a User.
2. Learning how to grab a token so the customer can login into the app.
3. Fixing database migration issues when working with multiple people making migrations and downloading the code to GitHub.  
4. Configuring PollChoiceService when not using Guid.  
