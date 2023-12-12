# London Stock API
Welcome to London Stock Web API

# About The Project
The project contains implementation of a REST API called LondonStockApi and its underlying database. 

The solution has 2 controllers Stocks and Transactions with secured endpoints. 
All endpoints are more secure and a user/password pair should be added for all brokers. 

# Interface
Access token for authoized broker <br>
__POST /security/createToken__  generate access tocken for authorized user<br>

Stocks <br>
__GET /api/Stocks/getAll__ Query all stock values.<br>
__GET /api/Stocks/{tickerSymbol}__ Query stock value by single ticker symbols.<br>
__GET /api/Stocks/{tickerSymbols}__ Query stock value by list of ticker symbols.<br>

Tranactions<br>
__POST /api/Tranactions/Create__ Query the average price of the stock through all transactions
# Technologies
-	.NET 7.0 
-	ASP.NET Core Web API.  
-	Swagger, 
-	CQRS with MediatR 
-	Fluent Validation 
-	Redis 
-	AutoMapper
-	Xunit
-	FluentAssertion
-	AspNetCore.Authentication.JwtBearer

# Architecture
-	Clean Architecture
-	Full architecture with responsibility separation of concerns
-	Repository pattern
-	Domain Driven Design (Layers and Domain Model Pattern)

# Code first generate EF cli commands:
```ps
1.	dotnet ef migrations add InitAPIMigration --context ExchangeDbContext  -o Data/Migrations 
2.	dotnet ef database update --context ExchangeDbContext
```
# Structure of solution
Repository include layers divided by 5 project;

*	Core
    *	Entities
*	Application
    *	Interfaces
    *	Services
    *	Models
    *	Mapping
    *	Extensions
*	Infrastructure
    * Data
*	Repository
    *	Migrations
*	WebAPI
    *	Features
    *	Controllers 
    *	ViewModels
    *	Extensions
*	UnitTesting
    *	Calculator
    *	Controllers
