# _Parks Lookup_

#### _Version 01/31/2020_

#### By _**Nina Potrebich**_

## Description

_An API for national parks. The API will list national parks._

## Getting Started

These instructions will get you a copy of the project up and running on your local machine for development and testing purposes.

### Prerequisites

* .NET
* MySqlServer

### Installing

1. Clone this repository:
```
$ git clone url-of-this-repo
```
2. Start MySql server by using command:
```
mysql start
```
3. Access MySql by executing the command:
```
mysql -uroot -pepicodus
```
4. Update database using command
```
dotnet ef database update
```
5. Using console of your choice build and run program in Project directory:
```
dotnet run
```
6. Open by browser of your choice :  http://localhost:5000/ .

## Specifications:

* Available options for unauthorized guests:

| Type Of Request | Route  | Result |
| --- | --- | --- |
| GET | /api/nationalparks/  | Get list of all national parks  |
| GET | /api/nationalparks?state=CA  | Search national parks by state  |
| GET | /api/nationalparks?name=bryce  | Search national parks by name / part of name  |
| GET | /api/nationalparks/34  | Get national park by id  |
| GET | /api/nationalparks/random  | Get random national park  |

* To authorize use the next credentials:

| UserName  | Password | Role |
| --- | --- | --- |
| fred  | 123  | Administrator |
| alice  | 456 | Accountant |
| joe  | 789 | Guest |

* Go to /api/account/login/ and enter credentials in the body of request. You will get JW token in response. Copy it.
* Find on the index page Authorize link. Enter your token as "Bearer name_of_token". 
* Available options for authorized users:

| Type Of Request | Route  | Permitted User Roles | Result |
| --- | --- | --- | --- |
| POST | /api/nationalparks/  | Administrator, Accountant | Add a new national park  |
| PUT | /api/nationalparks/23  | Administrator, Accountant | Edit national park by id  |
| DELETE | /api/nationalparks/23 | Administrator | Delete national park by id  |

## Technologies Used

_C#, .NET, ASP.NET Core MVC, Entity Framework Core, Swagger_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*