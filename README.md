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
6. Open by browser of your choice :  http://localhost:5000/index.html .

## Specifications:

* Available options for unauthorized guests:

| Method | URI  | Description | Request | Response | Expected response code |
| --- | --- | --- | --- | --- | --- |
| GET | /api/nationalparks/  | Get list of all national parks  | --- | List of national park's objects (JSON) | 200 Success |
| GET | /api/nationalparks?state={state}  | Search national parks by state  | state=CA | National park object (JSON) / Empty object | 200 Success |
| GET | /api/nationalparks?name={name}  | Search national parks by name / part of name  | name=bryce | National park object(JSON) /Empty object | 200 Success |
| GET | /api/nationalparks/{id}  | Get national park by id  | --- | National park object (JSON) | 200 Success, 204 Undocumented |
| GET | /api/nationalparks/random  | Get random national park  | --- | National park object (JSON) | 200 Success |

* To authorize use the next credentials:

| UserName  | Password | Role |
| --- | --- | --- |
| fred  | 123  | Administrator |
| alice  | 456 | Accountant |
| joe  | 789 | Guest |

* Go to /api/account/login/ and enter credentials in the body of request. You will get JW token in response. Copy it.
* Find on the index page Authorize link. Enter your token as "Bearer name_of_token". 
* Available options for authorized users:

| Method | URI  | Permitted User Roles | Description | Response | Expected Response Code |
| --- | --- | --- | --- | --- | --- |
| POST | /api/nationalparks/  | Administrator, Accountant | Add a new national park | --- | 404 Unauthorized, 200 Success, 201 National park was created, 400 If the national park is null |
| PUT | /api/nationalparks/23  | Administrator, Accountant | Edit national park by id  | --- | 404 Unauthorized, 200 Success, 201 Returns the updated national park, 400 If the national park is null |
| DELETE | /api/nationalparks/23 | Administrator | Delete national park by id  | --- | 404 Unauthorized, 200 Success |

## Technologies Used

_C#, .NET, ASP.NET Core MVC, Entity Framework Core, Swagger_

### License

*_Copyright (c) 2020 **Nina Potrebich**_*
