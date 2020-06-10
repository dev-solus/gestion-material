using System;
using System.Collections.Generic;
using Bogus;
using Microsoft.EntityFrameworkCore;
namespace Models
{
    public static class DataSeeding
    {
        public static string lang = "fr";

       public static ModelBuilder Departements(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Departement>(DataSeeding.lang)
                            .CustomInstantiator(f => new Departement { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Etage, f => f.Lorem.Word())
;
modelBuilder.Entity<Departement>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Constucteurs(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Constucteur>(DataSeeding.lang)
                            .CustomInstantiator(f => new Constucteur { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Description, f => f.Lorem.Word())
;
modelBuilder.Entity<Constucteur>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Statuts(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Statut>(DataSeeding.lang)
                            .CustomInstantiator(f => new Statut { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Description, f => f.Lorem.Word())
;
modelBuilder.Entity<Statut>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Categories(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Categorie>(DataSeeding.lang)
                            .CustomInstantiator(f => new Categorie { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Description, f => f.Lorem.Word())
;
modelBuilder.Entity<Categorie>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Fournisseurs(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Fournisseur>(DataSeeding.lang)
                            .CustomInstantiator(f => new Fournisseur { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Tel, f => f.Lorem.Word())
.RuleFor(o => o.Fax, f => f.Lorem.Word())
.RuleFor(o => o.Email, f => id - 1 == 1 ? "dj-m2x@hotmail.com" : f.Internet.Email())
;
modelBuilder.Entity<Fournisseur>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder EquipementInfos(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<EquipementInfo>(DataSeeding.lang)
                            .CustomInstantiator(f => new EquipementInfo { Id = id++ })
.RuleFor(o => o.NSerie, f => f.Lorem.Word())
.RuleFor(o => o.Date, f => f.Date.Past())
.RuleFor(o => o.StringInfo, f => f.Lorem.Word())
;
modelBuilder.Entity<EquipementInfo>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Roles(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Role>(DataSeeding.lang)
                            .CustomInstantiator(f => new Role { Id = id++ })
.RuleFor(o => o.Name, f => f.Lorem.Word())
;
modelBuilder.Entity<Role>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Fonctions(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Fonction>(DataSeeding.lang)
                            .CustomInstantiator(f => new Fonction { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
;
modelBuilder.Entity<Fonction>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Services(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Service>(DataSeeding.lang)
                            .CustomInstantiator(f => new Service { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.IdDepartement, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<Service>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder TicketSupports(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<TicketSupport>(DataSeeding.lang)
                            .CustomInstantiator(f => new TicketSupport { Id = id++ })
.RuleFor(o => o.Question, f => f.Lorem.Word())
.RuleFor(o => o.DateCreation, f => f.Date.Past())
.RuleFor(o => o.Priorite, f => f.Lorem.Word())
.RuleFor(o => o.IdCollaborateur, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<TicketSupport>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Chats(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Chat>(DataSeeding.lang)
                            .CustomInstantiator(f => new Chat { Id = id++ })
.RuleFor(o => o.IdSender, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdReceiver, f => f.Random.Number(1, 10))
.RuleFor(o => o.Message, f => f.Lorem.Word())
.RuleFor(o => o.Vu, f => id - 1 == 1 ? true : f.Random.Bool())
.RuleFor(o => o.Date, f => f.Date.Past())
.RuleFor(o => o.IdTicketSupport, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<Chat>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Users(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<User>(DataSeeding.lang)
                            .CustomInstantiator(f => new User { Id = id++ })
.RuleFor(o => o.Nom, f => f.Lorem.Word())
.RuleFor(o => o.Matricule, f => f.Lorem.Word())
.RuleFor(o => o.Prenom, f => f.Lorem.Word())
.RuleFor(o => o.Email, f => id - 1 == 1 ? "dj-m2x@hotmail.com" : f.Internet.Email())
.RuleFor(o => o.Password, f => "123")
.RuleFor(o => o.CodeOfVerification, f => f.Lorem.Word())
.RuleFor(o => o.EmailVerified, f => id - 1 == 1 ? true : f.Random.Bool())
.RuleFor(o => o.IsActive, f => id - 1 == 1 ? true : f.Random.Bool())
.RuleFor(o => o.IdService, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdFonction, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdRole, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<User>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Affectations(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Affectation>(DataSeeding.lang)
                            .CustomInstantiator(f => new Affectation { Id = id++ })
.RuleFor(o => o.Action, f => f.Lorem.Word())
.RuleFor(o => o.Date, f => f.Date.Past())
.RuleFor(o => o.IdEquipement, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdEmplacement, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdCollaborateur, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdAgentSi, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<Affectation>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Equipements(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Equipement>(DataSeeding.lang)
                            .CustomInstantiator(f => new Equipement { Id = id++ })
.RuleFor(o => o.NSerie, f => f.Lorem.Word())
.RuleFor(o => o.Model, f => f.Lorem.Word())
.RuleFor(o => o.DateAchat, f => f.Date.Past())
.RuleFor(o => o.RefAchat, f => f.Lorem.Word())
.RuleFor(o => o.EtatActuel, f => f.Lorem.Word())
.RuleFor(o => o.PrixUnitaireHT, f => f.Random.Number(1, 10))
.RuleFor(o => o.NInventaire, f => f.Lorem.Word())
.RuleFor(o => o.Remarques, f => f.Lorem.Word())
.RuleFor(o => o.IdConstucteur, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdCategorie, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdStatut, f => f.Random.Number(1, 10))
.RuleFor(o => o.IdFournisseur, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<Equipement>().HasData(faker.Generate(10));
return modelBuilder;
}

public static ModelBuilder Emplacements(this ModelBuilder modelBuilder)
                        {
                        int id = 1;
                        var faker = new Faker<Emplacement>(DataSeeding.lang)
                            .CustomInstantiator(f => new Emplacement { Id = id++ })
.RuleFor(o => o.CodeEmplacement, f => f.Lorem.Word())
.RuleFor(o => o.Description, f => f.Lorem.Word())
.RuleFor(o => o.IdDepartement, f => f.Random.Number(1, 10))
;
modelBuilder.Entity<Emplacement>().HasData(faker.Generate(10));
return modelBuilder;
}


    }
}