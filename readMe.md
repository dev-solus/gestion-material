# App web Gestion material

## Le projet à éte developpé par les technologies suivantes : 
[ASP.net Core 3.1 SDK](https://dotnet.microsoft.com/download)

[Node js](https://nodejs.org/en/download/) & [Angular 9](https://cli.angular.io/) : 

## Etape d'instalation : 

### la commande pour récuperer le repository du git est : 
```
get clone  https://github.com/djm2x/gestion-material.git
```

### Pour installer les dependences éxécuter la commande suivante : 
```
npm run install
```

### pour le lancer le back-end asp.net core restful api :
```
npm run b
```

### pour lancer le projet front-end angular : 
```
npm run f 
```

### configurer heroku pour deploye l'application

    - cree un compte [Heroku](https://www.heroku.com/)
    - dans le dashborad clicke sur new => create a new app
    - donner un nom a l'aaplication et choisie un la region proche a vous => create app
    - dans l'ongle Settings -> add Buildpacks : https://github.com/anuraj/dotnetcore-buildpack (pour qui heroku supprt ASP.NET Core)
    - dans l'ongle deploy, choisie comme `Deployment method` GitHub, connectez-vous apres choisie votre repo est clicke sur connect -> enable Automatic Deploy

### pour deployer le projet sur heroku.com : 
cette commande (plus de detail dans package.json -> scripts) va pushe les changement dans votre repo, puis Heroku ecoute les action faite sur votre repo alors ila copy et builder votre app , et le site sera actualiser
npm run ci 

