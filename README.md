# About

This is a sample application demonstrating my coding skills. The application is about maintaing employee information about the company using Microsoft .net 7.0 framework. The application is divided into 3 projects as explained below. Frontend and backend are completelty two different projects where backend uses entity framework and In memory database. Front end is using .net razor pages and bootstrap JS. 

# EMS.API

Clone the repository
Open EMS.API project in VS 2022
Build to ensure nuget denendancies are installed
Hit F5 
This should launch the swagger

![image](https://github.com/nikskhubani/EMS.API/assets/29400321/9b651141-c90c-41ef-b58a-de0a404211fd)

# EMS.Web

Go to command prompt
Navigate to EMS.Web folder
Run `dotnet watch`
![image](https://github.com/nikskhubani/EMS.API/assets/29400321/b23f13b6-fc64-4ef5-bde8-5a3a481baf44)

you will see landing page something like

![image](https://github.com/nikskhubani/EMS.API/assets/29400321/4bbe9d55-f159-46ae-bab3-9f0e44bdcda4)

# Notes
- .net 7.0 and VS 2022 has some issues while running the project hence I proceeded with creating one in VS Code and command line
- Test cases can be many more but it is just to show the skills of test cases
- I detached the backend (CRUD APIs) from front-end that will allow us to have better scaling options of backend or front and easily manage better front end technology such as REACT, NextJS etc..
- The host name of API is referred in app settings json file in front end app 
![image](https://github.com/nikskhubani/EMS.API/assets/29400321/8bf44589-71fb-4054-8221-5f6504323e69)


