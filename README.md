# PhoneSeller_WebAPI Application

![Swagger](https://camo.githubusercontent.com/96e43701d83561899724a89d71187445b7b8f4fe84518a3ea5bec8f85bd207bf/68747470733a2f2f63646e2e737667706f726e2e636f6d2f6c6f676f732f737761676765722e737667)    ![.NETCore](https://assets-global.website-files.com/6097e0eca1e875de53031ff6/61b810d93fd9cbaf68ba2e4b_net%20core%20logo.png)

This application is a basic Swagger-powered application that provides a REST-API to a phone seller.

Install MS-SQL on your computer. Then create the database in the `PhoneSellerDB.txt` file.

## Packages to Install from PackageManager in Visual Studio 

`MediatR` - Version(11.1.0)
`MadiatR.Extensions.Microsoft.DependencyInjection` - Version(11.1.0)
`Microsoft.AspNetCore.Authentication.JwtBearer` - Version(6.0.0)
`Microsoft.EntityFrameworkCore.SqlServer` - Version(6.0.0)
`Microsoft.EntityFrameworkCore.Tools` - Version(6.0.0)
`Swashbuckle.AspNetCore` - Version(6.2.3)

## Configuration

Edit the `Server` part in the `ConnectionString` from `appsetting.json`. Then,

Run the following command in Package Manager Console:
```console
Scaffold-DbContext -Connection Name=DefaultConnection Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -force
```

## Run the App

After the app runs, a `localhost/swagger/index.html` similar to the image below will open.

![Swagger Page Example](https://static1.smartbear.co/swagger/media/images/tools/opensource/swagger_ui.png)
