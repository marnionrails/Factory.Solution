# Dr. Sillystringz's Factory

#### _A tracking program for engineers and machines at a factory._

#### By **Marni Sucher**

#### Table of Contents

1. [Technologies Used](#technologies)
2. [Description](#description)
3. [Setup/Installation Requirements](#setup)
4. [Known Bugs](#bugs)
5. [License](#license)
6. [Contact Information](#contact)

## Technologies Used <a id="technologies"></a>

* _C#_
* _.NET 5.0.100_
* _ASP.NET Core MVC_
* _dotnet ef 3.0.0_
* _Microsoft.NET.Sdk.Web_
* _Microsoft.EntityFrameworkCore 5.0.0_
* _Microsoft.EntityFrameworkCore.Design -v 5.0.0_
* _Pomelo.EntityFrameworkCore.MySql 5.0.0-alpha.2_

## Description <a id="description"></a>

This web-based application tracks all the machines and Engineers at a fictional factory. Users may add/remove engineers licensed to fix a machine or add/remove machines an engineer is licensed to fix. 

## Setup/Installation Requirements <a id="setup"></a>

### Install C#, .NET, MySQL Community Server and MySQL Workbench
* Open the terminal on your local machine
* If [C#](https://docs.microsoft.com/en-us/dotnet/csharp/) and [.NET](https://docs.microsoft.com/en-us/dotnet/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time-c-and-react-track/getting-started-with-c/installing-c-and-net)
* If [MySQL Community Server](https://dev.mysql.com/downloads/mysql/) and [MySQL Workbench](https://www.mysql.com/products/workbench/) are not installed on your local device, follow the instructions [here](https://www.learnhowtoprogram.com/c-and-net-part-time-c-and-react-track/getting-started-with-c/installing-and-configuring-mysql)

### Clone the project
* Navigate to the directory inside of which you wish to house this project
* Clone this project with the command `$ git clone https://github.com/marnionrails/Factory.Solution`

### Import and connect the database
* In your terminal, navigate to the production project directory with the command `$ cd Factory.Solution/Factory`
* In your terminal, create a file within the project in which to store your connection string for connecting the project to the database with the command `touch appsettings.json`
* In your text editor add the following code to the newly created appsettings.json file. *Note that uid and pwd may vary depending on your local MySql configurations.
```
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;database=[Name];uid=root;pwd=[YOUR-PASSWORD-HERE];"
  }
}
```
* Update the database with this command: `$ dotnet ef database update`

### Run the project
* Recreate project environment and install required dependencies with terminal command `$ dotnet restore`
* Run the program in the console with the command `$ dotnet run`

## Known Bugs <a id="bugs"></a>

* No known bugs.

## License <a id="license"></a>
*[MIT](https://choosealicense.com/licenses/mit/)*

Copyright (c) **2021 Marni Sucher**

## Contact Information <a id="contact"></a>
**[Marni Sucher](mailto:suchermarni@gmail.com)**