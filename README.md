# CentralizedLogging-Backend
 DotNet Core with c#
 
 Steps to be followed for setting up in local:
 1) Database needs to be setup with the backup file for database or with SQL query
 2) Once Database is setup, open the solution in VS2019
 3) Open package manager console and execute the below line

Scaffold-DbContext -Connection Name=DatabaseConnection Microsoft.EntityFrameworkCore.SqlServer -Project CentralizedLogging.DB.EF -   OutputDir Models -force
 
4) Set CentralizedLoggingSystem project as startup project
5) Run the application to run it in local IISExpress
