# Comic Book Network
This is a repository for Comic Book Network - site for comic book readers and collectors.
This repository consists of 2 projects: frontend (client-app folder) and backend (API folder).

## How to contribute
Clone the repository to your computer.
Pull and checkout dev branch.
After adding your changes, push them to your origin remote repository
Create a new merge request of your code to dev upstream. As merge request's name add number of your task, name of feature (or area) and description of changes e.g. "1234 - Registration - fix wrong password error". Assign person responsible for code review and accepting merge requests.


## Frontend
Frontend is written in Vue.js. Official documentation: 
https://vuejs.org/guide/introduction.html

Bulma is used as css library. Official documentation: 
https://bulma.io/documentation/

### How to setup locally
Clone repository and navigate to client-app folder.
A recommended code editor for development of the front-end app is Visual Studio Code with Vuetur extension.
Use npm install before starting developing changes to make sure all the dependencies are installed and are up to date.

### Project commands:
#### Project setup
```
npm install
```

##### Compiles and hot-reloads for development
```
npm run serve
```

##### Compiles and minifies for production
```
npm run build
```

##### Lints and fixes files
```
npm run lint
```

#### Customize configuration
See [Configuration Reference](https://cli.vuejs.org/config/).

### Structure of the project:
Front end app is located in client-app folder.

root folder - contains various configuration files e.g. package.json, vue.config.js

dist - contains production build project (generated automatically by running 'npm run build')

node_modules - dependencies (external libraries, components, etc.)

src - contains main content of the app:

src/assets - images, logos, icons, pdfs, etc.

src/components - components which build the app. Similar types of components are grouped together. 'UI' folder contains visual elements with little or no logic (e.g buttons, loading spinner, comment box). 'Pages' contains views of the application.

src/router - definition of URL paths, and auth guards

src/store - code for state management pattern (Vuex). Official documentation: https://vuex.vuejs.org/


## Backend
Backed is written in ASP.NET Core 6. Official documentation: 
https://docs.microsoft.com/en-us/aspnet/core/?WT.mc_id=dotnet-35129-website&view=aspnetcore-6.0

Entity framework is used for generating and operating on database. Official documentation: 
https://docs.microsoft.com/en-us/ef/
#### Entity framework basic commands:
##### Adding a migration.
```
dotnet ef migrations add MyFirstMigration
```
This will create three files in the Migrations folder of your project, as shown below. MyFirstMigration is the name of a migration.
![ef-core-migration2](https://user-images.githubusercontent.com/39297454/155602189-55a2312f-73e5-4c3b-b263-1917a6bddae5.png)

##### Create or update the database schema.
```
dotnet ef database update
```
The Update command will create the database based on the context and domain classes and the migration snapshot, which is created using the add-migration or add command.

If this is the first migration, then it will also create a table called __EFMigrationsHistory, which will store the name of all migrations, as and when they will be applied to the database.

![ef-core-migration3](https://user-images.githubusercontent.com/39297454/155602690-a2aee23f-adac-4684-bff5-3df20b9dae30.png)

##### Drop local database
```
dotnet ef database drop
```


Posgres is used as database system. Official documentation: 
https://www.postgresql.org/

Cloudinary is used as repository of images. Official documentation: 
https://cloudinary.com/

Heroku is app's hosting provider. Official documentation: 
https://www.heroku.com/

### How to setup locally
Clone repository and navigate to api folder.
For developing the app you can use Visual Studio.
Use npm install before starting developing changes to make sure the dependencies installed and are up to date.

### Endpoints
The link to swagger API documentation:
https://lukaszuczkiewicz.github.io/swagger-docs/

### Structure of the project:
Back end app is located in api folder.

Controlers - classes with methods that intercept fetch API requests from  front-end

Data - Entity Framework's Migrations, Repository classes, test data (SeedData).

DTOs - Data Transfer Objects

Entities - Database Data objects

Extensions - helping classes e.g for converting datatypes

Interfaces - repository interfaces

wwwroot - the folder where static production frontend files are copied to



