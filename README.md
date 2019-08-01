An example of how to using dynamic LINQ expressions so you can use a string name for an entity, or a property, rather than an object

Requires:

- Visual Studio 2017+
- .NET Core v2.2
- SQL Server 2016+

Instructions:

Database:

- Open up SQL Server Management Studio and connect to your SQL Server (must be 2016+ or higher)
- Restore the database supplied in 'LinqExpressions-Example.bak' at root level. Name the database 'LinqExpressions-Example'
- Modify your database settings in 'RoundTheCode.LinqExpressions-Example/appsettings.json' under the 'LinqExpressionsDbContext' key

Web Application:

- Open the web application in Visual Studio and run the application. Visual Studio should open up a new browser and the example should be outputted on the index page.