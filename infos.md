dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries 

dotnet ef migrations add InitialCreate
dotnet ef database update


#H Tutorial howto ASP.Net MVC with VS-Code

https://docs.microsoft.com/de-de/aspnet/core/tutorials/first-mvc-app-xplat/start-mvc


## Gerüstbau für Controller und Views

`dotnet aspnet-codegenerator controller -name MoviesController -m Movie -dc MvcMovieContext --relativeFolderPath Controllers --useDefaultLayout --referenceScriptLibraries`


## ef Befehle

`dotnet ef migrations add InitialCreate`

`dotnet ef database update`

## Deployment:

in .csproj folgenden Part einfügen
  </PropertyGroup>
    <PublishWithAspNetCoreTargetManifest>false</PublishWithAspNetCoreTargetManifest>
  </PropertyGroup>

  dies sorgt dafür das dependecies mit ins Ausgabe-Verzeichnis kopiert werden

  mit 
  
  `dotnet publish -c release` 

  Release erzeugen und auf den Server übertragen

  Auf der Linux Kiste (ubunu) folgenden Aweisungen folgen

  https://docs.microsoft.com/en-us/dotnet/core/linux-prerequisites?tabs=netcore2x

  https://docs.microsoft.com/en-us/aspnet/core/publishing/linuxproduction?tabs=aspnetcore2x
  

  ## Working with the UserManager:
  

Assuming your code is inside an MVC controller:

`public class MyController : Microsoft.AspNetCore.Mvc.Controller`

From the Controller base class, you can get the IClaimsPrincipal from the User property 

`System.Security.Claims.ClaimsPrincipal currentUser = this.User;`

You can check the claims directly (without a round trip to the database):

`bool IsAdmin = currentUser.IsInRole("Admin");`
`var id = _userManager.GetUserId(User); // Get user id:`

Other fields can be fetched from the database's User entity:
Get the user manager using dependency injection

`private UserManager<ApplicationUser> _userManager;`

`//class constructor
public MyController(UserManager<ApplicationUser> userManager)
{
    _userManager = userManager;
}`

And use it:

`var user = await _userManager.GetUserAsync(User);
var email = user.Email;`
