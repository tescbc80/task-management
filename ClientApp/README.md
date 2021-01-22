[![MIT license](https://cdn.rawgit.com/emonney/tempa/7e9d69ad/MITLicense.png)](https://github.com/emonney/QuickApp/blob/master/LICENSE)

# CBC Task Management
This a simple TODO / Task Management SPA - Angular with the Net Core (3.x) which  was build by  with [Angular CLI](https://github.com/angular/angular-cli) version 6.0.0.

## Development server 

Run `dotnet ef database update` to update your database. Then, run  `dotnet restore` & `dotnet run`. The app will automatically reload if you change any of the source files.

### Development only client side

Run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. The app will automatically reload if you change any of the source files.

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

Run `ng build` to build the project. The build artifacts will be stored in the `dist/` directory. Use the `--prod` flag for a production build.

## Data Migration
Run `dotnet ef migrations add yourchanges -o WebApi/TodoTasksApi/Data/Migrations`, then `dotnet ef database update`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
