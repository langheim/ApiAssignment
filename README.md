# ApiAssignment
Create a Web API and document it

Goal: By completing this assignment should be able to: 

Create a database with EF Core
Create a ASP.NET Core web API
Document a web API using Swagger/OpenAPI
Instructions: 

Tasks: 

1. Create a ASP.NET Core Web API following the instructions in Assignment 3_CSharp_Web API creation in ASP.NET Core.pdf
2. Create a free trail on Azure.
3. Create a Sql Server instance (lowest tier option)
4. Change connection String in your application.
5. Update database to see if it worked (should be data in the Azure Db)
6. Dockerize your application, build and push the image to Docker Hub.
7. Then deploy your image as an app in Azure.

8. CI workflow
Workflow has been setup to push from VS to GitHub --> Actions in GitHub runs workflow from .github/workflows/linter.yml that runs Super-Linter check on code then Builds and push the code to Docker repository then Azure consumes the Docker image. 
