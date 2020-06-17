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
                    IdReceiver = table.Column<int>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    Vu = table.Column<bool>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    IdTicketSupport = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Chats_Users_IdReceiver",
                        column: x => x.IdReceiver,
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
                values: new object[] { 20, "LG", "LG" });

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
                values: new object[] { 12, "BROTHER", "BROTHER" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 11, "EPSON", "EPSON" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 13, "UNO", "UNO" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 9, "SONY", "SONY" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "Hewlett-Packard", "HP" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 10, "ORAY", "ORAY" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 3, "TOSHIBA", "TOSHIBA" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 4, "SHARP", "SHARP" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "DELL", "DELL" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 6, "CISCO", "CISCO" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 7, "FORTIGATE", "FORTIGATE" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 8, "APPLE", "APPLE" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 5, "CANON", "CANON" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 1, "E1", "DIPA-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 2, "E4", "DIPE-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 3, "E4", "DRSI-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 4, "E4", "CENTRE" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 7, new DateTime(2020, 5, 23, 3, 57, 50, 357, DateTimeKind.Local).AddTicks(7474), "soluta", "dolor", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 9, new DateTime(2020, 1, 14, 12, 52, 1, 867, DateTimeKind.Local).AddTicks(8443), "ut", "et", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 8, new DateTime(2019, 12, 18, 5, 44, 9, 65, DateTimeKind.Local).AddTicks(9825), "facere", "molestias", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 6, new DateTime(2020, 6, 6, 9, 20, 9, 863, DateTimeKind.Local).AddTicks(3969), "quo", "laborum", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 10, new DateTime(2020, 2, 14, 7, 15, 44, 525, DateTimeKind.Local).AddTicks(9424), "velit", "voluptatum", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 4, new DateTime(2020, 1, 2, 1, 36, 30, 284, DateTimeKind.Local).AddTicks(6427), "exercitationem", "iusto", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 3, new DateTime(2020, 4, 15, 11, 57, 26, 946, DateTimeKind.Local).AddTicks(4656), "aut", "dolor", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 2, new DateTime(2020, 4, 28, 3, 34, 32, 179, DateTimeKind.Local).AddTicks(9542), "voluptas", "cumque", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 1, new DateTime(2020, 6, 10, 4, 13, 5, 269, DateTimeKind.Local).AddTicks(2554), "consectetur", "quibusdam", null });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "InfoSystemeHtml", "NSerie", "SoftwareHtml" },
                values: new object[] { 5, new DateTime(2019, 10, 6, 16, 49, 32, 934, DateTimeKind.Local).AddTicks(4588), "cumque", "sunt", null });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 10, "VIRTUAL" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 9, "Trésorier " });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 8, "DIRECTRICE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 7, "CHEF DE SERVICE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 6, "CHEF DE DEPARTEMENT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 4, "CADRE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 3, "ASSISTANTE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "ASSISTANT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 1, "ASSISTANCE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 5, "CHAUFFEUR" });

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
                values: new object[] { 6, "email6@angular.io", "null", "UFP MAROC", "null" });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[] { 7, "email7@angular.io", "null", "ADN SYSTEM", "null" });

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
                values: new object[] { 8, "email8@angular.io", "null", "ETCE INFO", "null" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "user" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "agentSi" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "admin" });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "null", "Déplacement " });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "null", "Local" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 9, new DateTime(2020, 3, 10, 11, 47, 5, 718, DateTimeKind.Local).AddTicks(8154), 4, true, "eaque", "praesentium" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 3, new DateTime(2019, 7, 3, 6, 59, 55, 499, DateTimeKind.Local).AddTicks(3543), 5, false, "dolor", "impedit" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 4, new DateTime(2019, 8, 5, 21, 52, 43, 343, DateTimeKind.Local).AddTicks(8910), 9, true, "et", "natus" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 5, new DateTime(2019, 7, 20, 17, 29, 35, 444, DateTimeKind.Local).AddTicks(6486), 7, true, "hic", "neque" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 6, new DateTime(2019, 12, 9, 0, 25, 27, 205, DateTimeKind.Local).AddTicks(1589), 8, false, "odio", "quis" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 10, new DateTime(2020, 2, 17, 4, 23, 18, 829, DateTimeKind.Local).AddTicks(2339), 6, true, "quidem", "est" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 1, new DateTime(2019, 12, 17, 1, 28, 21, 987, DateTimeKind.Local).AddTicks(2584), 5, 6, 3, "voluptate", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 4, new DateTime(2019, 9, 23, 4, 58, 0, 744, DateTimeKind.Local).AddTicks(6674), 8, 5, 9, "sit", true });

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
                values: new object[] { 1, 1, "ANDA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 2, 2, "DG/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 3, 3, "DIPA/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 7, 4, "DIPE/" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 1, "", "admin@hotmail.com", true, 7, 1, 14, true, "730533", "Mourabit", "123", "mohamed" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 2, "", "agentSI@angular.io", true, 1, 2, 14, true, "1042706", "Hicham", "123", "Amakhlouf" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 3, "", "user@angular.io", true, 5, 2, 11, true, "1059644", "mehdi", "123", "tamika" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 9, new DateTime(2019, 8, 14, 4, 54, 56, 20, DateTimeKind.Local).AddTicks(4354), 1, 1, 9, "sapiente", false });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 2, new DateTime(2019, 8, 2, 19, 50, 17, 562, DateTimeKind.Local).AddTicks(4801), 3, 5, 10, "quisquam", true });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 2, new DateTime(2020, 4, 22, 12, 29, 54, 311, DateTimeKind.Local).AddTicks(9331), 1, false, "omnis", "occaecati" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 7, new DateTime(2020, 2, 25, 14, 2, 32, 144, DateTimeKind.Local).AddTicks(3397), 1, false, "fugiat", "eos" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 1, new DateTime(2020, 4, 11, 11, 7, 42, 389, DateTimeKind.Local).AddTicks(7064), 2, false, "at", "consequatur" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "IsClosed", "Priorite", "Question" },
                values: new object[] { 8, new DateTime(2020, 1, 6, 18, 7, 51, 683, DateTimeKind.Local).AddTicks(6607), 2, false, "magni", "ad" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 3, new DateTime(2020, 1, 22, 13, 30, 48, 261, DateTimeKind.Local).AddTicks(359), 2, 8, 2, "sapiente", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 6, new DateTime(2020, 4, 30, 18, 17, 16, 485, DateTimeKind.Local).AddTicks(1438), 10, 9, 2, "rerum", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 8, new DateTime(2019, 9, 17, 6, 37, 45, 794, DateTimeKind.Local).AddTicks(4141), 8, 8, 2, "distinctio", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 10, new DateTime(2019, 12, 9, 18, 33, 31, 834, DateTimeKind.Local).AddTicks(3195), 4, 2, 2, "dolorem", false });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 7, new DateTime(2019, 11, 8, 19, 9, 51, 100, DateTimeKind.Local).AddTicks(5054), 9, 4, 1, "sit", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 5, new DateTime(2019, 9, 5, 20, 38, 21, 144, DateTimeKind.Local).AddTicks(404), 4, 9, 8, "saepe", false });

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
                name: "IX_Chats_IdReceiver",
                table: "Chats",
                column: "IdReceiver");

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
