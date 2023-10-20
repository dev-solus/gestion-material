using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace apps.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Constucteurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Constucteurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Departements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Etage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipementInfos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NSerie = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    InfoSystemeHtml = table.Column<string>(nullable: true),
                    SoftwareHtml = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipementInfos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fonctions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fonctions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Tel = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Statuts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Emplacements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CodeEmplacement = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IdDepartement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Emplacements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Emplacements_Departements_IdDepartement",
                        column: x => x.IdDepartement,
                        principalTable: "Departements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    IdDepartement = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Services_Departements_IdDepartement",
                        column: x => x.IdDepartement,
                        principalTable: "Departements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Equipements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    NSerie = table.Column<string>(nullable: true),
                    Model = table.Column<string>(nullable: true),
                    DateAchat = table.Column<DateTime>(nullable: false),
                    RefAchat = table.Column<string>(nullable: true),
                    EtatActuel = table.Column<string>(nullable: true),
                    PrixUnitaireHT = table.Column<int>(nullable: false),
                    NInventaire = table.Column<string>(nullable: true),
                    Remarques = table.Column<string>(nullable: true),
                    IdConstucteur = table.Column<int>(nullable: false),
                    IdCategorie = table.Column<int>(nullable: false),
                    IdStatut = table.Column<int>(nullable: false),
                    IdFournisseur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipements_Categories_IdCategorie",
                        column: x => x.IdCategorie,
                        principalTable: "Categories",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipements_Constucteurs_IdConstucteur",
                        column: x => x.IdConstucteur,
                        principalTable: "Constucteurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipements_Fournisseurs_IdFournisseur",
                        column: x => x.IdFournisseur,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Equipements_Statuts_IdStatut",
                        column: x => x.IdStatut,
                        principalTable: "Statuts",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Matricule = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    CodeOfVerification = table.Column<string>(nullable: true),
                    EmailVerified = table.Column<bool>(nullable: false),
                    IsActive = table.Column<bool>(nullable: false),
                    IdService = table.Column<int>(nullable: true),
                    IdFonction = table.Column<int>(nullable: true),
                    IdRole = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Fonctions_IdFonction",
                        column: x => x.IdFonction,
                        principalTable: "Fonctions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Roles_IdRole",
                        column: x => x.IdRole,
                        principalTable: "Roles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Users_Services_IdService",
                        column: x => x.IdService,
                        principalTable: "Services",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Affectations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Action = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    IdEquipement = table.Column<int>(nullable: false),
                    IdEmplacement = table.Column<int>(nullable: false),
                    IdCollaborateur = table.Column<int>(nullable: false),
                    IdAgentSi = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Affectations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Affectations_Users_IdAgentSi",
                        column: x => x.IdAgentSi,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Affectations_Users_IdCollaborateur",
                        column: x => x.IdCollaborateur,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Affectations_Emplacements_IdEmplacement",
                        column: x => x.IdEmplacement,
                        principalTable: "Emplacements",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Affectations_Equipements_IdEquipement",
                        column: x => x.IdEquipement,
                        principalTable: "Equipements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketSupports",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Question = table.Column<string>(nullable: true),
                    DateCreation = table.Column<DateTime>(nullable: false),
                    Priorite = table.Column<string>(nullable: true),
                    IsClosed = table.Column<bool>(nullable: false),
                    IdCollaborateur = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketSupports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketSupports_Users_IdCollaborateur",
                        column: x => x.IdCollaborateur,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Chats",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdSender = table.Column<int>(nullable: false),
                    SenderName = table.Column<string>(nullable: true),
                    IdCollaboratteur = table.Column<int>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Vu = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IdTicketSupport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_IdCollaboratteur",
                        column: x => x.IdCollaboratteur,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_Users_IdSender",
                        column: x => x.IdSender,
                        principalTable: "Users",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Chats_TicketSupports_IdTicketSupport",
                        column: x => x.IdTicketSupport,
                        principalTable: "TicketSupports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "Ordinateur", "DESKTOP" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "Ordinateur", "LAPTOP" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 19, "HONEYWELL", "HONEYWELL" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 18, "ZEBRA", "ZEBRA" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 17, "POLYCOM", "POLYCOM" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 16, "SAMSUNG", "SAMSUNG" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 15, "APC", "APC" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 14, "IBM", "IBM" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 13, "UNO", "UNO" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 12, "BROTHER", "BROTHER" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 11, "EPSON", "EPSON" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 10, "ORAY", "ORAY" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 9, "SONY", "SONY" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 8, "APPLE", "APPLE" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 7, "FORTIGATE", "FORTIGATE" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 6, "CISCO", "CISCO" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 5, "CANON", "CANON" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 4, "SHARP", "SHARP" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 3, "TOSHIBA", "TOSHIBA" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "DELL", "DELL" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "Hewlett-Packard", "HP" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 20, "LG", "LG" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 3, "E4", "DRSI-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 4, "E4", "CENTRE" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 1, "E1", "DIPA-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 2, "E4", "DIPE-RABAT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 1, "CHEF DE DEPARTEMENT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "CHEF DE SERVICE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 3, "ASSISTANT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 4, "CADRE" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 15, "email15@angular.io", "null", "SHOP BUSINESS AND TECHNOLOGIE", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 14, "email14@angular.io", "null", "TOP INVEST RYAD", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 13, "email13@angular.io", "null", "SESA", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 12, "email12@angular.io", "null", "LATCO", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 11, "email11@angular.io", "null", "PLANET TV SAT", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 10, "email10@angular.io", "null", "ALPHA BUREAU", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 9, "email9@angular.io", "null", "CBI", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 8, "email8@angular.io", "null", "ETCE INFO", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 6, "email6@angular.io", "null", "UFP MAROC", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 5, "email5@angular.io", "null", "REPER", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 4, "email4@angular.io", "null", "COD2I", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 3, "email3@angular.io", "null", "BESTMARK", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 2, "email2@angular.io", "null", "PC MEMORIA", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 1, "email1@angular.io", "null", "BUCLINTEC", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 7, "email7@angular.io", "null", "ADN SYSTEM", "null" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "agentSi" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "user" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "financier" });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "null", "Déplacement " });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "null", "Local" });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 6, "ANDA/R/E4/OS5", "PLATEAU SBC", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 7, "ANDA/R/E4/OS2", "PLATEAU SRH", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 1, "ANDA/R/E4/B01", "BUREAU DIRECTION E4", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 2, "ANDA/R/E4/B02", "BUREAU ASSISTANAT DE DIRECTION", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 3, "ANDA/R/E4/B03", "BUREAU ASSISTANAT TRESORIER PAYEUR", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 5, "ANDA/R/E4/OS4", "PLATEAU SAMG", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 4, "ANDA/R/E4/OS6", "PLATEAU SSI", 4 });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 1, 1, "DG/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 2, 2, "ANDA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 3, 3, "DIPA/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 4, 4, "DIPE/" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 1, "", "admin@angular.io", true, 1, 1, 1, true, "730533", "Mourabit", "123", "mohamed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 2, "", "agentSI@angular.io", true, 2, 2, 2, true, "1042706", "Hicham", "123", "Amakhlouf" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 3, "", "user@angular.io", true, 3, 3, 3, true, "1059644", "mehdi", "123", "tamika" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 4, "", "financier@angular.io", true, 4, 2, 4, true, "1059683", "yassin", "123", "fathi" });

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_IdAgentSi",
                table: "Affectations",
                column: "IdAgentSi");

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_IdCollaborateur",
                table: "Affectations",
                column: "IdCollaborateur");

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_IdEmplacement",
                table: "Affectations",
                column: "IdEmplacement");

            migrationBuilder.CreateIndex(
                name: "IX_Affectations_IdEquipement",
                table: "Affectations",
                column: "IdEquipement");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdCollaboratteur",
                table: "Chats",
                column: "IdCollaboratteur");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdSender",
                table: "Chats",
                column: "IdSender");

            migrationBuilder.CreateIndex(
                name: "IX_Chats_IdTicketSupport",
                table: "Chats",
                column: "IdTicketSupport");

            migrationBuilder.CreateIndex(
                name: "IX_Emplacements_IdDepartement",
                table: "Emplacements",
                column: "IdDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_IdCategorie",
                table: "Equipements",
                column: "IdCategorie");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_IdConstucteur",
                table: "Equipements",
                column: "IdConstucteur");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_IdFournisseur",
                table: "Equipements",
                column: "IdFournisseur");

            migrationBuilder.CreateIndex(
                name: "IX_Equipements_IdStatut",
                table: "Equipements",
                column: "IdStatut");

            migrationBuilder.CreateIndex(
                name: "IX_Fournisseurs_Email",
                table: "Fournisseurs",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Services_IdDepartement",
                table: "Services",
                column: "IdDepartement");

            migrationBuilder.CreateIndex(
                name: "IX_TicketSupports_IdCollaborateur",
                table: "TicketSupports",
                column: "IdCollaborateur");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdFonction",
                table: "Users",
                column: "IdFonction");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdRole",
                table: "Users",
                column: "IdRole");

            migrationBuilder.CreateIndex(
                name: "IX_Users_IdService",
                table: "Users",
                column: "IdService");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Affectations");

            migrationBuilder.DropTable(
                name: "Chats");

            migrationBuilder.DropTable(
                name: "EquipementInfos");

            migrationBuilder.DropTable(
                name: "Emplacements");

            migrationBuilder.DropTable(
                name: "Equipements");

            migrationBuilder.DropTable(
                name: "TicketSupports");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Constucteurs");

            migrationBuilder.DropTable(
                name: "Fournisseurs");

            migrationBuilder.DropTable(
                name: "Statuts");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Fonctions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Departements");
        }
    }
}
