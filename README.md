# SCRABBLE SCOREKEEPER WEB APPLICATION

<!-- ABOUT THE PROJECT -->
## About The Project

* Scrabble Scorekeeper is a family app that uses a database to keep track of scores and winners! 
* In more technical terms, it is a CRUD web application developed in ASP.NET Core Razor Pages that targets .NET 5

![Homepage](AppScreenshots/homepage1.jpg)

## Built With
* Visual Studio 2019 and 2022
* C#
* ASP.NET Core
* xUnit for Unit Testing
* Entity Framework Core 
* SQL Server
* Bootstrap 4
* LINQ queries
* CSS
* HTML

## Overview

* ### Add players and their scores during each round. Tally the results and display them in the scoreboard

![Main Functionality](AppGifs/RazorPagesScorekeeper.gif)

* ### Edit players' names
##### (Editing scores without playing would be cheating so it is not allowed)

![Edit Player](AppGifs/edit.gif)

* ### Delete a player from the database

![Delete Player](AppGifs/delete.gif)

## Data Validation

* ### The app doesn't accept the same name twice

![Same-name-entered-twice validation](AppGifs/SameUserValidation.gif)

* ### The same user can't be selected twice during the same game

![Same-user-selected-twice validation](AppGifs/SelectingSameUserVal.gif)

* ### Users can't enter null/empty data to the database

![Force user to enter scores validation](AppGifs/NoStartVal.gif)

* ### Negative scores are not allowed

![No-negative-numbers validation](AppGifs/NegativeNumVal.gif)

