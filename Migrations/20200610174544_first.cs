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
                    StringInfo = table.Column<string>(nullable: true)
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
                    IdService = table.Column<int>(nullable: false),
                    IdFonction = table.Column<int>(nullable: false),
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
                    IdReceiver = table.Column<int>(nullable: false),
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
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "Ordinateur", "DESKTOP" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 29, "Communication", "LOAD BALANCER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 28, "Aquisition Images", "LECTEUR CODE A BARRE" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 27, "Impression", "IMPRIMANTE THERMIQUE" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 26, "Affichage", "ECRAN PROJECTION" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 25, "Communication", "VISIO CONFERENCE SYSTEM" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 24, "Communication", "CALL MANAGER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 23, "Communication", "POINT D'ACCES WIFI" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 22, "Affichage", "TELEVISION" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 21, "Reception", "RÉCEPTEUR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 20, "Communication", "TELEPHONE IP" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 18, "Aquisition Images", "APPAREIL PHOTO" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 17, "Communication", "FAX" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 16, "Aquisition Images", "SCANNER" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 19, "Energie", "ONDULEUR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 14, "Ordinateur", "SERVEUR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 2, "Ordinateur", "LAPTOP" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 3, "Environnement", "DOCK STATION" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 15, "Stockage", "BAIE DE STOCKAGE" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 5, "Impression", "IMPRIMANTE COULEUR RESEAU" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 6, "Impression", "IMPRIMANTE NOIR USB" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 7, "Impression", "IMPRIMANTE NOIR RESEAU" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 4, "Affichage", "LCD MONITOR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 9, "Impression", "PHOTOCPIEUR COULEUR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 10, "Impression", "PHOTOCPIEUR NOIR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 11, "Affichage", "VIDEO PROJECTEUR" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 12, "Communication", "SWITCH" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 13, "Communication", "FIREWALL" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 8, "Impression", "IMPRIMANTE COULEUR USB" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 12, "BROTHER", "BROTHER" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 20, "LG", "LG" });

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
                values: new object[] { 11, "EPSON", "EPSON" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 19, "HONEYWELL", "HONEYWELL" });

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
                values: new object[] { 10, "ORAY", "ORAY" });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[] { 1, "Hewlett-Packard", "HP" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 7, "E4", "CENTRE" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 5, "E4", "DIPE-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 4, "E1", "DIPA-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 6, "E4", "DRSI-RABAT" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 2, "E3", "DIPE-DAKHLA" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 1, "E3", "DIPA-DAKHLA" });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[] { 3, "E3", "DRSI-DAKHLA" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 10, new DateTime(2019, 7, 16, 22, 49, 52, 627, DateTimeKind.Local).AddTicks(5694), "voluptates", "ex" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 9, new DateTime(2019, 10, 20, 16, 35, 14, 868, DateTimeKind.Local).AddTicks(4876), "doloribus", "placeat" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 8, new DateTime(2020, 2, 4, 2, 11, 33, 194, DateTimeKind.Local).AddTicks(7266), "provident", "eius" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 7, new DateTime(2019, 12, 8, 18, 52, 23, 38, DateTimeKind.Local).AddTicks(9042), "omnis", "dicta" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 6, new DateTime(2020, 3, 17, 21, 1, 38, 694, DateTimeKind.Local).AddTicks(4448), "sunt", "ut" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 4, new DateTime(2019, 12, 18, 16, 52, 31, 828, DateTimeKind.Local).AddTicks(2513), "facilis", "repellendus" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 3, new DateTime(2020, 1, 5, 20, 11, 45, 453, DateTimeKind.Local).AddTicks(7002), "enim", "ut" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 2, new DateTime(2019, 9, 15, 10, 31, 48, 72, DateTimeKind.Local).AddTicks(7481), "at", "earum" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 1, new DateTime(2020, 1, 10, 6, 45, 59, 970, DateTimeKind.Local).AddTicks(6629), "dolorem", "fugit" });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[] { 5, new DateTime(2019, 10, 3, 11, 52, 32, 148, DateTimeKind.Local).AddTicks(1258), "amet", "iusto" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 7, "CHEF DE SERVICE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 9, "Trésorier " });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 10, "VIRTUAL" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 8, "DIRECTRICE" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 6, "CHEF DE DEPARTEMENT" });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[] { 2, "ASSISTANT" });

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
                values: new object[] { 32, "ANDA/R/E1/B05", "SALLE ARCHIVE SBC", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 36, "ANDA/D/APT2", "DAKHLA APT 2", 2 });

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
                values: new object[] { 9, "ANDA/R/E4/LT2", "LOCAL TECHNIQUE SECONDAIRE", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 15, "ANDA/R/E1/B02", "BUREAU CHEF DEP. DIPA", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 31, "ANDA/R/E1/B04", "BUREAU CHEF SERVICE SAT-SE", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 25, "ANDA/R/E4/B05", "BUREAU CHEF SERVICES SRH-SAICG", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 35, "ANDA/D/APT1", "DAKHLA APT 1", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 11, "ANDA/R/E4/B09", "BUREAU CHEF DEP. DIPE", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 16, "ANDA/R/E1/B10", "BUREAU SPA", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 19, "ANDA/R/E4/SR2", "PETITE SALLE DE REUNION", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 21, "ANDA/R/E4/C-OS", "COULOIR OPEN SPACE", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 26, "ANDA/R/E4/B06", "BUREAU TP", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 27, "ANDA/R/E4/B07", "BUREAU CHEF SERVICE SPC-SAI", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 38, "EXT", "HORS ANDA", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 4, "ANDA/R/E4/OS6", "PLATEAU SSI", 4 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 24, "ANDA/R/E4/B04", "BUREAU CHEF SERVICES SBC-SAMG", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 28, "ANDA/R/E4/B08", "BUREAU CHEF DEP. DRSI", 3 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 14, "ANDA/R/E4/OS3", "PLATEAU SPC", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 7, "ANDA/R/E4/OS2", "PLATEAU SRH", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 22, "ANDA/R/E4/C-B", "COULOIR BUREAUX", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 12, "ANDA/R/E1/B09", "BUREAU SE", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 13, "ANDA/R/E4/OS1", "PLATEAU SAI", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 17, "ANDA/R/E1/B08", "BUREAU SAT-SRA", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 18, "ANDA/R/E4/SR1", "GRANDE SALLE DE REUNION", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 20, "ANDA/R/E1/B01", "BUREAU DIRECTION E1", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 23, "ANDA/R/E1/EC", "ESPACE COMMUN", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 29, "ANDA/R/E4/BO", "BUREAU D'ORDRE", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 8, "ANDA/R/E4/LT1", "LOCAL TECHNIQUE PRINCIPAL", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 2, "ANDA/R/E4/B02", "BUREAU ASSISTANAT DE DIRECTION", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 30, "ANDA/R/E1/B03", "BUREAU CHEF SERVICE SRA-SPA", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 33, "ANDA/R/E1/B06", "BUREAU SPA (SIG)", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 34, "ANDA/R/E1/B07", "SALLE REUNION E1", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 37, "ANDA/D/APT3", "DAKHLA APT 3", 1 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 1, "ANDA/R/E4/B01", "BUREAU DIRECTION E4", 2 });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[] { 10, "ANDA/R/E1/LT3", "LOCAL TECHNIQUE", 2 });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 54, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7148), "EPN", 9, 2, 1, 2, "PRO 3400", "0027", "TRF2140RCY", 6650, "BC N°24/2012", "DEFAUT BOITE D'ALIMENTATION" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 49, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7124), "", 26, 19, 7, 2, "ProBook 6460b", "0075", "CNU2060RLH", 11600, "BC N° 05/2012", "Perdu au niveau du ministère en octobre 2012 Déclaration du perte déposé au niveau de commissariat de police de l'Agdal" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 48, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7120), "", 24, 1, 8, 2, "ProBook 6460b", "0007", "CNU2060RGD", 10438, "BC N°02/2011", "Perdu lors du vol de la maison de youssef el Aaraj en 2016" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 41, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7086), "EPN", 14, 5, 13, 2, "VAIO série Z", "0048", "275469555000705", 36480, "BC N°05/2012", "PC toujours chez la directrice Pb Réclamé et pc non rendu " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 55, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7153), "OPR", 6, 16, 13, 2, "PRO 3400", "0134", "TRF2140R9W", 6650, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 45, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7105), "EPN", 4, 7, 9, 2, "ProBook 6460b", "0060", "CNU2060RFX", 14335, "20120238", "CASSER PAR KARFAL" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 44, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7100), "STK", 24, 11, 3, 2, "EliteBook 2560P", "0051", "CNU2024Y1V", 15490, "BC N°05/2012 ", "Etat Moyen à abimé OK (EX AMINE MANSORI)" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 42, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7091), "OPR", 21, 8, 4, 2, "EliteBook 2560P", "0054", "CNU2024ZWB", 15490, "BC N°05/2012 ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 47, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7115), "OPR", 20, 7, 10, 2, "ProBook 6460b", "0072", "CNU2060RFZ", 14335, "20120238", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 57, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7163), "OPR", 11, 20, 2, 2, "HP 2011x", "0068", "CNC201Q4HH", 1200, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 69, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7218), "OPR", 23, 11, 14, 2, "W2072A", "0478", "CNC325PKYW", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 63, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7191), "OPR", 12, 17, 4, 2, "LATITUDE E5430", "0468", "4H3CXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 64, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7195), "OPR", 19, 9, 13, 2, "LATITUDE E5430", "0473", "F13CXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 70, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7223), "OPR", 17, 3, 2, 2, "W2072A", "0476", "CNC334PNWN", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 71, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7228), "OPR", 21, 3, 4, 2, "W2072A", "0477", "CNC334PNWJ", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 74, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7242), "OPR", 23, 12, 9, 2, "W2072A", "0474", "CNC328PRR0", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 78, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7261), "OPR", 7, 7, 15, 2, "IP PHONE 7942", "743", "FCH16248FOQ", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 81, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7275), "OPR", 13, 4, 9, 2, "LASERJET P2055D", "0033", "VNC3F72243", 2651, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 82, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7280), "OPR", 21, 1, 14, 2, "IP PHONE 7942", "736", "FCH16248TT6", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 80, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7270), "OPR", 14, 11, 4, 2, "IP PHONE 7942", "706", "FCH16248FCF", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 61, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7181), "OPR", 25, 3, 10, 2, "LATITUDE E5430", "0471", "BX2CXY1", 10000, "BC N°65/2013", "Utilisation personnelle à la maison." });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 40, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7081), "OPR", 16, 4, 15, 2, "LA2405wg", "0059", "CN414915G9", 2150, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 9, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6866), "OPR", 26, 17, 3, 2, "HP 2011x", "0012", "CNC131S4DR", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 38, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7071), "OPR", 9, 15, 10, 2, "LA2405wg", "0056", "CN41491575", 2150, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 175, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7838), "OPR", 16, 6, 5, 1, "HP PRO M254nw", "0720", "VNC4B22107", 2100, "BC18/2019", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 176, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7842), "STK", 29, 1, 4, 1, "EPSON EB-X05", "NEW", "X4GM9900206", 4400, "BC18/2019", "JAMAIS UTILISER" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 178, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7853), "OPR", 1, 3, 10, 1, "LOAD BALANCER 1841", "NEW_2017", "FCZ105113CY", 2610, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 5, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6846), "OPR", 22, 15, 6, 2, "PRO 3400", "0082", "TRF14200UD", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 84, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7289), "OPR", 4, 11, 12, 2, "MACBOOK PRO", "0618", "CO2VV068HTD6", 38000, "MARCHE N°05/2017/ANDA ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 10, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6870), "OPR", 29, 1, 10, 2, "HP 2011x", "0392", "CNC131NZBS", 1200, "BC N°02/2011", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 11, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6875), "OPR", 11, 14, 15, 2, "HP 2011x", "0006", "CNC131NZ7J", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 13, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6885), "OPR", 29, 9, 6, 2, "HP 2011x", "0083", "CNC131NZ7L", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 15, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6894), "OPR", 10, 20, 14, 2, "HP 2011x", "0143", "CNC131NZ64", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 16, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6898), "OPR", 10, 10, 11, 2, "HP 2011x", "0388", "CNC131NZBW", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 17, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6903), "OPR", 14, 17, 6, 2, "HP 2011x", "0071", "CNC131NZ63", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 18, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6908), "OPR", 25, 14, 12, 2, "HP 2011x", "0378", "CNC131NZBV", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 19, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6913), "OPR", 8, 5, 2, 2, "LA2405wg", "0003", "CN41470F4C", 2150, "BC N°02/2011", "ECRAN VIDEO SURVEILLANCE " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 20, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6918), "STK", 18, 18, 9, 2, "EliteBook 2560P", "0001", "CNU14058DS", 13417, "BC N°02/2011", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 21, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6923), "OPR", 23, 6, 15, 2, "PRO 3400", "0019", "TRF14200UB", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 22, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6927), "OPR", 17, 12, 11, 2, "PRO 3400", "0013", "TRF14200V3", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 26, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6946), "OPR", 27, 9, 15, 2, "PRO 3400", "0023", "CZC20614YN", 6500, "BC N°05/2012 ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 27, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6951), "OPR", 8, 7, 6, 2, "PRO 3400", "0015", "CZC20614YR", 6500, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 29, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6961), "OPR", 23, 5, 6, 2, "HP 2011x", "0065", "CNC150QQ82", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 34, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7052), "OPR", 4, 4, 12, 2, "HP 2011x", "0009", "CNC150R7KR", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 37, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7067), "OPR", 25, 4, 8, 2, "LA2405wg", "0053", "CN4149156Z", 2150, "BC N°05/2012 ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 39, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7076), "OPR", 2, 12, 5, 2, "LA2405wg", "0050", "CN41470F40/C", 2150, "BC N°05/2012", "ECRAN DE SUPERVISION RESEAU" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 85, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7294), "OPR", 11, 12, 15, 2, "LG ULTRA FINE 5K", "0626", "705NTSU8S702", 16800, "MARCHE N°05/2017/ANDA", "Erreur à plusieurs reprise, changement de l'afficheur effectué par le fournisseur, persistance du problème !" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 121, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7544), "OPR", 26, 6, 5, 2, "IP PHONE 7942", "-", "FCH16248TGY", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 92, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7404), "OPR", 9, 17, 2, 2, "IP PHONE 7942", "715", "FCH16248FV2", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 139, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7629), "OPR", 24, 8, 4, 2, "ELITE DISPLAY E271i", "0619", "3CM7350C7J", 2520, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 143, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7648), "OPR", 16, 4, 8, 2, "ELITE BOOK X360 1030G2", "0611", "5CG8090ZPF", 22000, "MC N°5/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 144, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7653), "OPR", 4, 6, 7, 2, "LASERJET COLOR M553", "0623", "JPBUL2007N", 0, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 145, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7658), "OPR", 22, 10, 1, 2, "ELITE BOOK 850 G3", "0614", "5CG80915VD", 15250, "MARCHE N°05/2017/ANDA ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 146, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7662), "", 6, 4, 5, 2, "IP PHONE 7942", "-", "FCH16239H9V", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 147, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7667), "OPR", 16, 19, 7, 2, "LASERJET CP1025", "0043", "CNCHF18978", 3887, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 149, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7677), "OPR", 12, 1, 2, 2, "IP PHONE 7942", "-", "FCH20028JN2", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 150, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7681), "EPN", 2, 1, 4, 2, "LASERJET P2055D", "0041", "VNC3R02165", 2651, "BC N°02/2011", "Carte USB Endommagée" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 152, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7726), "OPR", 3, 6, 15, 2, "IP PHONE 7942", "-", "FCH1623903F", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 153, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7732), "OPR", 15, 15, 9, 2, "IP PHONE 7942", "-", "FCH162393NM", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 156, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7747), "OPR", 21, 19, 7, 2, "BROTHER ", "0085", "E60542L1C285471", 0, "", "Dans l'attente d'installation d'une ligne de fax" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 157, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7752), "STK", 14, 3, 13, 2, "IP PHONE 7942", "-", "FCH16248UMW", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 159, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7761), "OPR", 24, 3, 2, 2, "LASERJET CP1025", "0044", "CNCHD35125", 3887, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 160, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7766), "OPR", 4, 10, 13, 2, "LASERJET P2055D", "0039", "VNC3R02169", 2651, "BC N°02/2011", " " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 162, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7776), "OPR", 26, 7, 12, 2, "LASERJET P2055D", "0034", "VNC3R02170", 2651, "BC N°02/2011", " " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 163, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7781), "STK", 3, 3, 11, 2, "LASERJET P2055D", "0037", "VNC3R02098", 2651, "BC N°02/2011", "Vérification Nécessaire " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 165, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7790), "OPR", 18, 10, 2, 2, "LASERJET P2055D", "0040", "VNC3F72248", 2651, "BC N°02/2011", " " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 166, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7795), "OPR", 1, 14, 1, 2, "MX-3111U", "0413", "25077441", 73020, "F 429/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 167, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7800), "EPN", 25, 4, 12, 2, "BROTHER 33.600", "0084", "E60542L1C284194", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 169, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7810), "OPR", 24, 5, 7, 2, "PROBOOK 450 G5", "0615", "5CD8083M4K", 11150, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 171, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7819), "STK", 13, 16, 3, 2, "ELITE BOOK 850 G3", "NEW", "5CG6524492", 11500, "BC N°18/2019", "NEUF" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 137, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7619), "OPR", 11, 16, 10, 2, "PROBOOK 640 G1", "0554", "5CG4413PS8", 11700, "BC N°41/2015", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 91, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7322), "OPR", 10, 13, 13, 2, "IP PHONE 7942", "756", "FCH19419KGE", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 136, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7614), "OPR", 27, 5, 15, 2, "IP PHONE 7942", "-", "FCH162393W8", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 129, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7581), "OPR", 8, 3, 8, 2, "LASERJET COLOR M553", "0625", "JPBVL2007T", 0, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 93, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7411), "OPR", 13, 3, 3, 2, "IP PHONE 7942", "-", "FCH16248RZD", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 94, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7416), "OPR", 15, 15, 11, 2, "IP PHONE 7942", "-", "FCH20028JMC", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 95, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7421), "OPR", 23, 9, 13, 2, "IP PHONE 7942", "-", "FCH162483UT", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 96, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7425), "OPR", 26, 13, 12, 2, "DS 7500", "0482", "PX3Z003153", 15300, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 97, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7430), "OPR", 9, 17, 12, 2, "", "0415", "E62806J2V551896", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 99, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7440), "OPR", 14, 8, 1, 2, "IP PHONE 7942", "-", "FCH16248EZH", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 101, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7449), "OPR", 6, 14, 6, 2, "IP PHONE 7942", "-", "FCH20028JX3", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 105, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7468), "OPR", 16, 13, 15, 2, "IP PHONE 7942", "-", "FCH16248FEP", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 106, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7473), "OPR", 16, 7, 15, 2, "MFC-8220", "0414", "E62806J2V551902", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 109, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7488), "OPR", 7, 1, 3, 2, "IP PHONE 7942", "-", "FCH16248550", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 110, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7492), "OPR", 13, 5, 12, 2, "IP PHONE 7942", "-", "FCH16248FE8", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 114, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7511), "OPR", 19, 16, 9, 2, "IP PHONE 7942", "-", "FCH1624849L", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 115, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7516), "OPR", 15, 6, 1, 2, "IP PHONE 7942", "-", "FCH19419KBT", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 117, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7525), "OPR", 27, 5, 3, 2, "IP PHONE 7942", "-", "FCH162393UC", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 118, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7529), "OPR", 1, 16, 9, 2, "IP PHONE 7942", "-", "FCH1623901F", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 119, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7534), "OPR", 9, 9, 3, 2, "IP PHONE 7942", "-", "FCH1624908Z", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 174, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7833), "OPR", 15, 4, 12, 1, "HP PRO M254nw", "0721", "VNC4B22346", 2100, "BC18/2019", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 124, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7557), "OPR", 18, 12, 14, 2, "IP PHONE 7942", "-", "FCH16248T36", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 125, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7562), "OPR", 11, 9, 10, 2, "IP PHONE 7942", "-", "FCH16248S31", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 127, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7572), "OPR", 11, 2, 11, 2, "IP PHONE 7942", "-", "FCH16248ZZH", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 128, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7576), "OPR", 29, 10, 8, 2, "LASERJET P2055D", "0035", "VNC3F72244", 2651, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 134, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7604), "OPR", 4, 11, 15, 2, "IP PHONE 7942", "-", "FCH16248S30", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 172, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7824), "STK", 25, 1, 3, 1, "ELITE BOOK 850 G3", "NEW", "5CG65244K3", 11500, "BC N°18/2019", "NEUF" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 126, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7567), "OPR", 21, 13, 3, 1, "ELITE DISPLAY E271i", "0620", "3CM7350CDN", 2520, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 168, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7805), "STK", 18, 16, 15, 1, "PROBBOK 450 G5", "0617", "5CD8083M4L", 11150, "MARCHE N°05/2017/ANDA", "NEUF" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 46, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7110), "OPR", 13, 20, 10, 1, "ProBook 6460b", "0004", "CNU2060RQW", 10438, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 50, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7129), "OPR", 23, 4, 14, 1, "ProBook 6460b", "0010", "CNU2060RFK", 10438, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 51, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7134), "OPR", 26, 2, 13, 1, "PRO 3400", "0138", "TRF2140RDH", 6650, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 52, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7138), "OPR", 24, 10, 10, 1, "PRO 3400", "0142", "TRF2140RDT", 6650, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 53, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7143), "STK", 5, 10, 11, 1, "PRO 3400", "0031", "TRF2140RGD", 6650, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 56, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7158), "OPR", 12, 13, 4, 1, "HP 2011x", "0384", "CNC201Q4HD", 1200, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 58, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7167), "STK", 23, 2, 3, 1, "HP 2011x", "0396", "CNC201Q500", 1200, "BC N°24/2012", "ok" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 43, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7096), "OPR", 20, 12, 13, 1, "EliteBook 2560P", "0057", "CNU2024Y3J", 15490, "BC N°05/2012 ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 59, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7172), "OPR", 9, 20, 4, 1, "HP 2011x", "0079", "CNC201Q4HG", 1200, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 62, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7186), "OPR", 5, 4, 7, 1, "LATITUDE E5430", "0470", "CM5CXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 65, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7200), "OPR", 19, 17, 13, 1, "LATITUDE E5430", "0467", "1YLCXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 66, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7205), "OPR", 9, 5, 11, 1, "LATITUDE E5430", "0469", "GN3CXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 67, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7209), "STK", 2, 5, 1, 1, "LATITUDE E5430", "0466", "6X2CXY1", 10000, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 68, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7214), "EPN", 17, 15, 2, 1, "LATITUDE E5430", "0472", "473CXY1", 10000, "BC N°65/2013", "Cassé Par Mustapha : Lecteur CD/DVD Disque Dur endommagé RAM Enlevée" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 72, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7233), "OPR", 3, 19, 3, 1, "W2072A", "0475", "CNC326QCDS", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 73, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7237), "EPN", 4, 8, 7, 1, "W2072A", "0481", "CNC334PN6D", 1200, "BC N°65/2013", "SUPPORT ABIMé" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 170, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7814), "STK", 14, 2, 4, 1, "ELITE BOOK 850 G3", "0718", "5CG65244HN", 11500, "BC N°18/2019", "NEUF" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 75, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7247), "OPR", 12, 9, 14, 1, "W2072A", "0479", "CNC334PN4Y", 1200, "BC N°65/2013", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 36, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7062), "OPR", 28, 1, 1, 1, "HP 2011x", "0032", "CNC150R7C9", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 33, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7047), "STK", 21, 19, 6, 1, "HP 2011x", "0077", "CNC150R6VR", 1200, "BC N°05/2012", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 1, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(4095), "OPR", 13, 20, 8, 1, "PRO 3400", "0025", "TRF14200T1", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 2, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6739), "OPR", 9, 11, 6, 1, "PRO 3400", "0140", "TRF14200U0", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 3, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6835), "OPR", 11, 14, 2, 1, "PRO 3400", "0029", "TRF14200UP", 6722, "BC N°02/2011", "Utilisé par Sanae" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 4, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6841), "OPR", 11, 13, 7, 1, "PRO 3400", "0021", "TRF14200W7", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 6, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6851), "STK", 2, 10, 5, 1, "PRO 3400", "0080", "TRF14200VF", 6722, "BC N°02/2011", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 7, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6856), "OPR", 1, 11, 11, 1, "HP 2011x", "0028", "CNC131NZ7S", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 8, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6861), "OPR", 2, 16, 13, 1, "HP 2011x", "0016", "CNC131S4G2", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 35, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7057), "OPR", 21, 16, 9, 1, "HP 2011x", "0074", "CNC150QQ23", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 12, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6880), "OPR", 27, 7, 7, 1, "HP 2011x", "0139", "CNC131S4GS", 0, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 23, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6932), "OPR", 25, 18, 12, 1, "PRO 3400", "0017", "TRF14200TT", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 24, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6937), "OPR", 20, 16, 3, 1, "PRO 3400", "0078", "TRF14200UT", 6722, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 25, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6942), "OPR", 18, 17, 14, 1, "PRO 3400", "0136", "CZC20614Y0", 6500, "BC N°05/2012 ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 28, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6956), "OPR", 9, 10, 5, 1, "HP 2011x", "0018", "CNC150QQ27", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 30, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6966), "OPR", 8, 10, 6, 1, "HP 2011x", "0020", "CNC150QQBR", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 31, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6971), "OPR", 10, 14, 2, 1, "HP 2011x", "0022", "CNC150R6VV", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 32, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7039), "OPR", 16, 3, 15, 1, "HP 2011x", "0024", "CNC150QQ87", 1200, "BC N°05/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 14, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(6889), "OPR", 17, 11, 10, 1, "HP 2011x", "0081", "CNC131NZBT", 1200, "BC N°02/2011", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 76, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7251), "STK", 27, 10, 12, 1, "W2072A", "0480", "CNC334PN72", 1200, "BC N°65/2013", "OK" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 60, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7177), "OPR", 10, 11, 14, 1, "HP 2011x", "0135", "CNC201Q502", 1200, "BC N°24/2012", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 79, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7266), "OPR", 24, 16, 14, 1, "IP PHONE 7942", "724", "FCH16248U4J", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 130, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7586), "OPR", 8, 8, 10, 1, "ELITE BOOK 850 G3", "0612", "5CG80915VT", 15250, "MARCHE N°05/2017/ANDA ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 131, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7590), "OPR", 14, 17, 8, 1, "LASERJET CP1025", "0042", "CNCHF18972", 3887, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 132, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7595), "OPR", 7, 14, 9, 1, "IP PHONE 7942", "-", "FCH16248TBW", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 133, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7600), "OPR", 14, 7, 2, 1, "IP PHONE 7942", "-", "FCH16239042", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 135, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7609), "OPR", 2, 13, 4, 1, "PROBOOK 640 G1", "0556", "5CG4413PNN", 10500, "BC N°41/2015", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 138, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7624), "OPR", 18, 16, 6, 1, "IP PHONE 7942", "-", "FCH162394CS", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 140, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7633), "OPR", 6, 4, 9, 1, "LASERJET COLOR M553", "0621", "JPBVL2007S", 0, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 173, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7828), "OPR", 29, 9, 6, 2, "LASERJET COLOR M553", "0622", "JPBVL20086", 0, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 77, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7256), "OPR", 19, 13, 5, 1, "HP 2011x", "0030", "CNC131NZCM", 1200, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 148, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7672), "OPR", 12, 14, 9, 1, "IP PHONE 7942", "-", "FCH162393UD", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 151, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7686), "OPR", 29, 10, 14, 1, "IP PHONE 7942", "-", "FCH19419K9C", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 154, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7738), "OPR", 29, 9, 7, 1, "IP PHONE 7942", "-", "FCH16248RDZ", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 155, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7742), "OPR", 29, 11, 10, 1, "LASERJET COLOR M553", "0624", "JPBVL2007Q", 0, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 158, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7757), "OPR", 24, 8, 3, 1, "ELITE BOOK 840 G4", "0613", "5CG80915VK", 15250, "MARCHE N°05/2017/ANDA ", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 161, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7771), "OPR", 27, 6, 1, 1, "LASERJET P2055D", "0038", "VNC3R02171", 2651, "BC N°02/2011", " " });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 164, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7786), "STK", 20, 6, 7, 1, "LASERJET P2055D", "0036", "VNC3F72240", 2651, "BC N°02/2011", "Vérification Nécessaire" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 142, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7643), "OPR", 12, 18, 3, 1, "PROBOOK 640 G1", "0510", "5CG5031CMD", 12000, "BC N°50/2014", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 123, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7553), "OPR", 15, 5, 4, 1, "LASERJET CP1025", "0045", "CNCHD35121", 3887, "BC N°02/2011", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 141, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7639), "OPR", 16, 5, 13, 1, "EB-X14", "0362", "PTRF210342L", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 120, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7539), "OPR", 4, 6, 7, 1, "IP PHONE 7942", "-", "FCH16248F0G", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 122, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7548), "OPR", 23, 20, 7, 1, "IP PHONE 7942", "-", "FCH16239HNQ", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 83, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7285), "OPR", 19, 8, 10, 1, "IP PHONE 7942", "726", "FCH16248FAQ", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 86, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7299), "EPN", 10, 16, 11, 1, "IP PHONE 7942", "752", "FCH16239BZ2", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 87, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7304), "OPR", 20, 4, 4, 1, "PROBOOK 640 G1", "0552", "5CG4413PP2", 12000, "BC N°41/2015", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 88, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7308), "OPR", 1, 9, 3, 1, "IP PHONE 7942", "730", "FCH16239CXM", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 89, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7313), "OPR", 3, 3, 13, 1, "IP PHONE 7942", "738", "FCH16248ERB", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 90, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7317), "OPR", 5, 2, 13, 1, "IP PHONE 7942", "750", "FCH16238ZQM", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 98, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7435), "OPR", 11, 11, 2, 1, "IP PHONE 7942", "-", "FCH19428DKR", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 100, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7444), "OPR", 16, 3, 11, 1, "IP PHONE 7942", "-", "FCH145286BE", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 177, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7848), "STK", 22, 18, 1, 2, "MOTORISE BRATECK 240*240", "NEW", "04518-2PC18002", 4000, "BC18/2019", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 103, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7459), "OPR", 8, 1, 8, 1, "IP PHONE 7942", "-", "FCH1624902R", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 102, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7454), "OPR", 16, 13, 11, 1, "IP PHONE 7962", "-", "FCH1631AH5P", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 113, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7506), "OPR", 24, 3, 15, 1, "IP PHONE 7942", "-", "FCH16238ZZP", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 112, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7502), "OPR", 27, 8, 3, 1, "IP PHONE 7942", "-", "FCH16248TXX", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 116, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7520), "OPR", 7, 1, 3, 1, "IP PHONE 7942", "-", "FCH162393NB", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 108, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7483), "OPR", 27, 3, 1, 1, "IP PHONE 7942", "-", "FCH16248S10", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 107, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7477), "OPR", 6, 16, 12, 1, "IP PHONE 7962", "-", "FCH1631AH07", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 104, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7463), "OPR", 22, 11, 11, 1, "IP PHONE 7942", "-", "FCH16248S1Q", 0, "", "" });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[] { 111, new DateTime(2020, 6, 10, 18, 45, 43, 679, DateTimeKind.Local).AddTicks(7497), "OPR", 13, 20, 12, 1, "PROBOOK 450 G5", "0616", "5CD8083M4J", 11150, "MARCHE N°05/2017/ANDA", "" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 4, 1, "DIPA/SAT" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 7, 5, "DIPE/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 8, 2, "DIPE/SAI" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 12, 3, "DRSI/SAMG" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 3, 4, "DIPA/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 5, 4, "DIPA/SPA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 6, 4, "DIPA/SRA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 9, 5, "DIPE/SE" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 15, 6, "DRSI/SSI" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 11, 6, "DRSI/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 13, 6, "DRSI/SBC" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 14, 6, "DRSI/SRH" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 1, 7, "ANDA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 2, 7, "DG/" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 16, 7, "RR-DAKHLA" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 17, 7, "SAICG" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 19, 7, "T.P" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 10, 5, "DIPE/SPC" });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[] { 18, 7, "SAICG/" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 22, "", "Kihn-22@angular.io", true, 9, 3, 4, true, "1678603", "Reichert", "123", "Lora" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 7, "", "Carroll-7@angular.io", true, 10, 3, 16, true, "1678577", "Harvey", "123", "Lyla" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 79, "", "Cruickshank-79@angular.io", true, 7, 3, 2, true, "0", "Walter", "123", "Dorothy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 65, "", "Krajcik-65@angular.io", true, 7, 3, 2, true, "123456802", "Rempel", "123", "Maria" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 78, "", "Legros-78@angular.io", true, 10, 3, 1, true, "0", "Senger", "123", "Mara" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 37, "", "Boyle-37@angular.io", true, 6, 3, 1, true, "1678621", "Grady", "123", "Myrtis" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 14, "", "Weber-14@angular.io", true, 4, 3, 1, true, "1678588", "Bartell", "123", "Dedrick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 50, "", "Murphy-50@angular.io", true, 2, 3, 15, true, "1678638", "Klocko", "123", "Lea" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 36, "", "Abernathy-36@angular.io", true, 4, 3, 16, true, "1678620", "Mitchell", "123", "Trenton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 46, "", "Runolfsson-46@angular.io", true, 4, 3, 15, true, "1678632", "Hirthe", "123", "Jimmie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 15, "", "Little-15@angular.io", true, 6, 3, 15, true, "1678589", "Krajcik", "123", "Elyssa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 56, "", "Bergnaum-56@angular.io", true, 9, 3, 14, true, "1678646", "Runolfsson", "123", "Conrad" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 30, "", "Crona-30@angular.io", true, 7, 3, 14, true, "1678613", "Koepp", "123", "Shaun" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 20, "", "Stanton-20@angular.io", true, 7, 3, 14, true, "1678601", "Robel", "123", "Faustino" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 6, "", "Grady-6@angular.io", true, 4, 3, 14, true, "1678576", "Hickle", "123", "Gavin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 2, "", "Lind-2@angular.io", true, 1, 2, 14, true, "1042706", "Bahringer", "123", "Aliyah" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 1, "", "dj-m2x@hotmail.com", true, 7, 1, 14, true, "730533", "Rodriguez", "123", "Lyda" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 42, "", "Schmidt-42@angular.io", true, 8, 3, 15, true, "1678628", "Glover", "123", "Russell" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 24, "", "Fay-24@angular.io", true, 1, 3, 13, true, "1678605", "Harvey", "123", "Marian" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 41, "", "Bechtelar-41@angular.io", true, 5, 3, 16, true, "1678627", "Beatty", "123", "Letitia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 51, "", "Lubowitz-51@angular.io", true, 1, 3, 16, true, "1678639", "Littel", "123", "Tate" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 31, "", "McLaughlin-31@angular.io", true, 7, 3, 19, true, "1678614", "Leannon", "123", "Mazie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 59, "", "Mills-59@angular.io", true, 10, 3, 18, true, "1678650", "McClure", "123", "Marcelino" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 49, "", "Altenwerth-49@angular.io", true, 2, 3, 18, true, "1678637", "Kuhic", "123", "Nat" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 47, "", "Hegmann-47@angular.io", true, 4, 3, 18, true, "1678633", "Graham", "123", "Zelda" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 34, "", "Legros-34@angular.io", true, 1, 3, 18, true, "1678617", "Wolff", "123", "Dana" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 26, "", "Spinka-26@angular.io", true, 1, 3, 18, true, "1678607", "Renner", "123", "Felipe" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 23, "", "VonRueden-23@angular.io", true, 8, 3, 18, true, "1678604", "Raynor", "123", "Francisca" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 43, "", "Turner-43@angular.io", true, 4, 3, 16, true, "1678629", "Okuneva", "123", "Milton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 4, "", "Mayert-4@angular.io", true, 4, 2, 18, true, "1059683", "Kohler", "123", "Lavina" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 44, "", "Legros-44@angular.io", true, 1, 3, 17, true, "1678630", "Durgan", "123", "Chadrick" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 25, "", "Cummings-25@angular.io", true, 3, 3, 17, true, "1678606", "Kemmer", "123", "Abdullah" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 12, "", "Sporer-12@angular.io", true, 4, 3, 17, true, "1678583", "Kuhlman", "123", "Lindsey" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 9, "", "Toy-9@angular.io", true, 5, 3, 17, true, "1678579", "Christiansen", "123", "Donnell" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 8, "", "Robel-8@angular.io", true, 3, 3, 17, true, "1678578", "Hermiston", "123", "Karlee" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 70, "", "Lueilwitz-70@angular.io", true, 7, 3, 16, true, "-1", "Jakubowski", "123", "Camron" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 52, "", "Bogan-52@angular.io", true, 4, 3, 16, true, "1678640", "Hettinger", "123", "Beau" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 68, "", "Graham-68@angular.io", true, 2, 3, 17, true, "123456805", "Smith", "123", "Sean" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 18, "", "Koepp-18@angular.io", true, 9, 3, 13, true, "1678596", "Moore", "123", "Adrianna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 74, "", "Daniel-74@angular.io", true, 8, 3, 11, true, "0", "Wuckert", "123", "Danial" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 73, "", "Kautzer-73@angular.io", true, 9, 3, 11, true, "0", "Hegmann", "123", "Ahmad" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 19, "", "Adams-19@angular.io", true, 3, 3, 3, true, "1678597", "Bergnaum", "123", "Karlee" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 17, "", "Schowalter-17@angular.io", true, 9, 3, 3, true, "1678595", "Larson", "123", "Derek" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 75, "", "Hartmann-75@angular.io", true, 1, 3, 12, true, "0", "Cormier", "123", "Alysha" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 71, "", "Barrows-71@angular.io", true, 2, 3, 12, true, "N.C.1", "Miller", "123", "Weston" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 40, "", "Witting-40@angular.io", true, 6, 3, 12, true, "1678626", "Ondricka", "123", "Margaretta" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 13, "", "Donnelly-13@angular.io", true, 1, 3, 12, true, "1678587", "Stokes", "123", "Magali" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 69, "", "Smitham-69@angular.io", true, 6, 3, 8, true, "123456807", "Marvin", "123", "Jennings" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 11, "", "Feest-11@angular.io", true, 3, 3, 5, true, "1678581", "Bednar", "123", "Athena" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 67, "", "Torphy-67@angular.io", true, 7, 3, 8, true, "123456804", "Lueilwitz", "123", "Nicole" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 39, "", "Mante-39@angular.io", true, 7, 3, 8, true, "1678624", "Carter", "123", "Terrance" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 21, "", "Crona-21@angular.io", true, 7, 3, 8, true, "1678602", "Padberg", "123", "Austin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 77, "", "Bins-77@angular.io", true, 4, 3, 4, true, "0", "Ledner", "123", "Elna" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 60, "", "Runolfsdottir-60@angular.io", true, 2, 3, 4, true, "123456797", "Heller", "123", "Van" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 57, "", "Jakubowski-57@angular.io", true, 6, 3, 4, true, "1678647", "Gutkowski", "123", "Finn" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 48, "", "Greenfelder-48@angular.io", true, 10, 3, 4, true, "1678634", "Huel", "123", "Ebba" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 45, "", "O'Connell-45@angular.io", true, 9, 3, 4, true, "1678631", "Daugherty", "123", "Darren" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 53, "", "Miller-53@angular.io", true, 3, 3, 8, true, "1678641", "Langosh", "123", "Alycia" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 32, "", "Bahringer-32@angular.io", true, 8, 3, 5, true, "1678615", "Jerde", "123", "Annalise" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 33, "", "Bauch-33@angular.io", true, 4, 3, 5, true, "1678616", "Glover", "123", "Davin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 55, "", "Keebler-55@angular.io", true, 9, 3, 5, true, "1678645", "Koepp", "123", "Antone" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 58, "", "Wisoky-58@angular.io", true, 10, 3, 11, true, "1678649", "Vandervort", "123", "Justine" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 29, "", "Barrows-29@angular.io", true, 7, 3, 11, true, "1678610", "Bergnaum", "123", "Tomasa" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 16, "", "Flatley-16@angular.io", true, 2, 3, 11, true, "1678592", "Hagenes", "123", "Crystel" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 3, "", "Fahey-3@angular.io", true, 5, 2, 11, true, "1059644", "Nader", "123", "Jorge" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 72, "", "Rice-72@angular.io", true, 7, 3, 10, true, "-1", "MacGyver", "123", "Maggie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 64, "", "Kautzer-64@angular.io", true, 4, 3, 10, true, "123456801", "Fisher", "123", "Garnett" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 63, "", "Monahan-63@angular.io", true, 1, 3, 10, true, "123456800", "Cummings", "123", "Gavin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 62, "", "Hagenes-62@angular.io", true, 8, 3, 10, true, "123456799", "McDermott", "123", "Dedric" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 38, "", "Corkery-38@angular.io", true, 2, 3, 10, true, "1678623", "Parker", "123", "Angus" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 80, "", "Schaefer-80@angular.io", true, 4, 3, 9, true, "0", "Kreiger", "123", "Buddy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 66, "", "Terry-66@angular.io", true, 6, 3, 7, true, "123456803", "DuBuque", "123", "Jeremie" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 35, "", "Streich-35@angular.io", true, 8, 3, 7, true, "1678618", "MacGyver", "123", "Andy" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 28, "", "Goodwin-28@angular.io", true, 8, 3, 7, true, "1678609", "Grimes", "123", "Blaze" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 27, "", "Prosacco-27@angular.io", true, 3, 3, 7, true, "1678608", "Connelly", "123", "Orpha" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 54, "", "Rath-54@angular.io", true, 10, 3, 6, true, "1678644", "Zulauf", "123", "Raphaelle" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 10, "", "Bergstrom-10@angular.io", true, 6, 3, 6, true, "1678580", "Gleason", "123", "Nikolas" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 5, "", "Jaskolski-5@angular.io", true, 6, 3, 6, true, "1434298", "Ferry", "123", "Sid" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 61, "", "Torphy-61@angular.io", true, 6, 3, 19, true, "123456798", "Dicki", "123", "Easton" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[] { 76, "", "Bosco-76@angular.io", true, 2, 3, 19, true, "0", "Deckow", "123", "Jay" });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 468, "Modifications :  - Statut de NON DEFINI --> Déplacement  - Collaborateur de ANDA ANDA --> AZHAR  MAJDOULINE - Etat de STK --> OPR - Remarques de OK -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6675), 3, 79, 8, 96 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 94, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4776), 4, 16, 12, 41 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 100, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4837), 4, 39, 14, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 103, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4849), 4, 9, 15, 119 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 104, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4853), 4, 36, 19, 12 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 105, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4857), 4, 21, 14, 57 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 108, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4870), 4, 40, 19, 142 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 109, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4874), 4, 44, 32, 116 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 89, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4755), 4, 11, 15, 33 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 111, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4882), 4, 70, 15, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 115, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4899), 3, 4, 12, 89 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 119, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4915), 4, 44, 14, 111 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 124, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4936), 4, 15, 34, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 131, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4965), 4, 7, 7, 168 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 136, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4986), 4, 2, 29, 31 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 137, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4990), 4, 57, 13, 80 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 143, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5015), 4, 55, 31, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 112, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4886), 4, 62, 21, 170 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 86, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4743), 2, 4, 13, 157 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 85, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4739), 4, 39, 32, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 79, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4714), 4, 32, 27, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 12, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4435), 4, 10, 3, 99 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 27, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4497), 4, 80, 29, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 29, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4506), 4, 2, 2, 175 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 32, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4518), 4, 16, 38, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 39, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4547), 4, 21, 1, 14 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 46, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4577), 4, 50, 8, 175 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 49, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4589), 4, 33, 9, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 50, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4593), 4, 54, 26, 26 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 54, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4610), 4, 10, 29, 92 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 55, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4614), 4, 80, 21, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 61, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4639), 4, 1, 13, 133 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 63, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4647), 2, 4, 37, 62 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 65, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4656), 4, 43, 22, 140 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 67, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4664), 3, 4, 19, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 68, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4668), 4, 56, 8, 43 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 70, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4676), 4, 39, 18, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 72, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4685), 4, 3, 29, 137 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 145, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5023), 4, 69, 36, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 150, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5044), 4, 71, 23, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 155, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5066), 4, 27, 11, 6 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 157, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5074), 4, 48, 22, 162 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 230, "Modifications :  - Emplacement de PLATEAU SAI --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5413), 4, 51, 8, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 231, "Modifications :  - Emplacement de PLATEAU SAI --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5417), 4, 11, 26, 64 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 233, "Modifications :  - Remarques de  --> test .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5426), 4, 51, 25, 78 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 234, "Modifications :  - Collaborateur de TOUJGANI  HAFSA --> ZNIBER  SAMIA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5430), 4, 14, 3, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 235, "Modifications :  - Collaborateur de TOUJGANI  HAFSA --> ANDA ANDA - Emplacement de PLATEAU SBC --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de OPR --> STK .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5434), 4, 56, 16, 152 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 238, "Modifications :  - Emplacement de PLATEAU SSI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5447), 4, 38, 17, 164 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 244, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5473), 4, 15, 29, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 254, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5516), 4, 15, 14, 22 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 255, "Modifications :  - Emplacement de BUREAU SPA --> BUREAU CHEF SERVICE SRA-SPA (ANDA/R/E1/B03) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5521), 4, 24, 18, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 267, "Modifications :  - N° Inventaire de 0066 --> - .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5572), 4, 4, 12, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 272, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> EL JOUHARI NAOUAL - Emplacement de NON DEFINI --> PLATEAU SAI (ANDA/R/E4/OS1) - Etat de  --> OPR - N° Inventaire de  --> 0385 - Nom Equipement de  --> ANDA0022D - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5593), 4, 45, 35, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 283, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> DAKHLA APT 1 (ANDA/D/APT1) - Etat de STK --> OPR .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5674), 4, 38, 3, 89 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 286, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5689), 4, 48, 16, 170 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 288, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5697), 4, 6, 33, 36 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 297, "Modifications :  - Remarques de Utilisé pour la visio surveillance -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5736), 4, 58, 11, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 298, "Modifications :  - Collaborateur de AARAB  LAHOUSSINE --> ANDA ANDA - Emplacement de BUREAU CHEF SERVICE SPC-SAI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5740), 4, 4, 22, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 300, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5748), 4, 64, 35, 11 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 228, "Modifications :  - Nom Equipement de ANDA-PC --> ANDA0058L .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5405), 4, 72, 18, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 10, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4427), 4, 69, 19, 167 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 227, "Modifications :  - Collaborateur de ANDA ANDA --> KHALILI  EL MADANI - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> BUREAU SE (ANDA/R/E1/B09) - Etat de STK --> OPR - Remarques de OK(ex kamar) -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5401), 4, 66, 23, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 219, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5368), 4, 16, 12, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 159, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5082), 4, 80, 31, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 162, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5095), 4, 53, 24, 19 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 164, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5103), 4, 4, 20, 1 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 166, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5111), 4, 9, 5, 175 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 167, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5116), 4, 21, 6, 104 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 168, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5120), 4, 65, 12, 43 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 170, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5128), 4, 42, 18, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 173, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5141), 4, 55, 16, 75 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 182, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5178), 4, 24, 3, 58 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 184, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5187), 4, 20, 4, 168 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 194, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5262), 4, 40, 1, 48 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 199, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5283), 4, 3, 38, 140 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 201, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5292), 4, 45, 17, 83 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 203, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5300), 4, 48, 11, 59 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 205, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5309), 4, 72, 33, 65 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 208, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5321), 4, 48, 34, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 209, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5326), 4, 74, 31, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 225, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5393), 4, 41, 27, 162 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 8, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4418), 4, 55, 29, 132 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 5, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4402), 4, 10, 29, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 4, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4302), 4, 15, 21, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 307, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5777), 2, 43, 24, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 329, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5893), 2, 43, 32, 165 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 425, "Modifications :  - Nom Equipement de  --> Switch PoE .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6496), 3, 43, 16, 114 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 619, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7411), 3, 43, 33, 157 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 629, "Modifications :  - Catégorie de LAPTOP --> DESKTOP - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> SHOP BUSINESS AND TECHNOLOGIE - Etat de OPR --> EPN - Date ACHAT de  --> 25/05/2015 - Remarques de  --> Appareil qui s'éteint aléatoirement. En Réparation chez O2IT. - Prix Unitaire de  --> 29700 - Référence d'achat de  --> BC N°13/2015 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7454), 2, 43, 30, 30 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 664, "Modifications :  - Collaborateur de TAHIRI  MOUNIA --> AIT LAMQADEM ATMAN - Emplacement de BUREAU SPA --> BUREAU SPA (SIG) (ANDA/R/E1/B06) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7632), 2, 43, 34, 16 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 47, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4581), 3, 51, 16, 124 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 152, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5053), 3, 51, 3, 178 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 192, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5254), 2, 51, 4, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 197, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5275), 3, 51, 5, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 210, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5330), 2, 51, 2, 74 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 354, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6096), 2, 51, 13, 104 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 403, "Modifications :  - Statut de NON DEFINI --> Local - Etat de OPR --> EPN - Remarques de  --> En réparation, porte endomagée .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6404), 2, 51, 16, 155 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 589, "Modifications :  - Fournisseur de NON DEFINI --> COD2I .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7286), 3, 51, 8, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 607, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7360), 2, 51, 32, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 656, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7599), 2, 51, 17, 146 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 2, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4234), 3, 52, 34, 97 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 257, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5530), 2, 43, 24, 103 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 121, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4924), 3, 52, 38, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 158, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5078), 2, 43, 9, 33 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 618, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7407), 3, 41, 30, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 391, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6352), 2, 79, 2, 173 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 647, "Modifications :  - Collaborateur de EL OUFIR IJLAL --> N/A   - Emplacement de BUREAU DIRECTION E1 --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - Modèle de ELITE BOOK 850 G3 --> ELITE BOOK 840 G4 - N° Série de ----------- --> 5CG80915VK - Remarques de N'est pas encore rendu de la part de Ijlal suite à la fin de son contrat -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7530), 4, 76, 27, 160 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 545, "Modifications :  - Nom Equipement de  --> ANDA0013D .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7069), 3, 79, 5, 170 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 226, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5397), 2, 7, 14, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 246, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5482), 3, 7, 6, 159 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 274, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> Thadi Mustapha - Emplacement de NON DEFINI --> BUREAU TP (ANDA/R/E4/B06) - Etat de  --> OPR - N° Inventaire de  --> 0391 - Nom Equipement de  --> - - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5601), 3, 7, 10, 116 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 313, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5803), 3, 7, 30, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 364, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6190), 2, 7, 10, 28 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 497, "Modifications :  - Statut de Local --> Sélectionnez ... .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6868), 2, 7, 28, 43 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 594, "Modifications :  - Fournisseur de NON DEFINI --> TOP INVEST RYAD - Prix Unitaire de  --> 11500 - Référence d'achat de  --> BC18/2019 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7307), 3, 7, 9, 125 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 336, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5970), 2, 36, 18, 178 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 91, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4764), 2, 41, 1, 172 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 180, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5170), 3, 41, 30, 88 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 284, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> DAKHLA APT 1 (ANDA/D/APT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5681), 2, 41, 14, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 396, "Modifications :  - Collaborateur de ANDA ANDA --> CHERKES MOHAMMED - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> DAKHLA APT 1 (ANDA/D/APT1) - N° Inventaire de - --> 0038 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6373), 3, 41, 3, 70 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 469, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> BUREAU ASSISTANAT DE DIRECTION (ANDA/R/E4/B02) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6747), 2, 41, 15, 105 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 599, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7327), 3, 41, 29, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 141, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5007), 3, 43, 30, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 301, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5752), 4, 69, 23, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 582, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7257), 2, 52, 21, 81 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 335, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5964), 3, 70, 23, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 444, "Modifications :  - Emplacement de BUREAU CHEF SERVICE SAT-SE --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6575), 2, 12, 35, 161 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 501, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de MATERIEL ANDA --> N/A   - Etat de EPN --> OPR - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6885), 3, 12, 6, 76 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 651, "Modifications :  - N° Inventaire de 0603 --> 0063 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7546), 2, 12, 16, 157 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 74, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4693), 3, 25, 3, 54 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 178, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5161), 2, 25, 31, 20 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 269, "Modifications :  - Emplacement de BUREAU SAT-SRA --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5581), 2, 25, 30, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 308, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5781), 2, 25, 10, 132 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 334, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5957), 3, 25, 12, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 462, "Modifications :  - Constructeur de NON DEFINI --> SAMSUNG - Fournisseur de NON DEFINI --> PLANET TV SAT - Date ACHAT de  --> 25/03/2013 - Prix Unitaire de  --> 10600,00 - Référence d'achat de  --> BC 2013 pour Planet TV SAT .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6651), 2, 25, 21, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 123, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4932), 3, 44, 34, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 256, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> JAHID  ASMAA - Emplacement de NON DEFINI --> BUREAU CHEF SERVICE SRA-SPA (ANDA/R/E1/B03) - Etat de  --> OPR - N° Inventaire de  --> 0059 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5525), 2, 44, 34, 83 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 322, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5841), 2, 44, 3, 156 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 454, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6617), 3, 44, 19, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 516, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> ADN SYSTEM - Date ACHAT de  --> 16/12/2016 - Prix Unitaire de  --> 11700 - Référence d'achat de  --> F 72/16 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6948), 2, 44, 34, 149 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 102, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4845), 3, 68, 19, 87 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 521, "Modifications :  - N° Série de 5CG148PG4D --> 5CG4413PTD .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6968), 3, 68, 1, 49 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 3, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4296), 4, 57, 12, 91 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 408, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6425), 3, 12, 38, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 217, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5360), 3, 70, 34, 73 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 258, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5535), 3, 12, 34, 15 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 193, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5258), 3, 12, 22, 68 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 412, "Modifications :  - Constructeur de APPLE --> IBM .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6442), 2, 70, 35, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 565, "Modifications :  - Statut de NON DEFINI --> Local - N° Inventaire de 0391 --> 0078 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7186), 3, 70, 11, 41 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 596, "Modifications :  - Fournisseur de NON DEFINI --> TOP INVEST RYAD - Prix Unitaire de  --> 11500 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7315), 2, 70, 13, 156 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 48, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4585), 2, 8, 5, 173 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 163, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5099), 2, 8, 34, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 223, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5384), 3, 8, 16, 12 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 489, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> HORS ANDA (EXT) - Etat de STK -->  - Remarques de  --> Perdu lors du vol de la maison de youssef el aaraj .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6835), 2, 8, 16, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 498, "Modifications :  - Statut de NON DEFINI --> Déplacement  - Emplacement de PLATEAU SSI --> HORS ANDA (EXT) - Remarques de utilisation personnelle à la maison. --> Utilisation personnelle à la maison. .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6873), 3, 8, 35, 86 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 20, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4468), 2, 9, 31, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 140, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5002), 3, 9, 1, 16 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 144, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5019), 3, 9, 36, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 177, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5157), 2, 9, 8, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 331, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5907), 3, 9, 4, 40 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 389, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6344), 2, 9, 19, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 659, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7612), 2, 9, 3, 144 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 23, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4481), 2, 12, 27, 57 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 41, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4556), 2, 12, 35, 19 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 224, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5388), 2, 12, 10, 82 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 302, "Modifications :  - Emplacement de LOCAL TECHNIQUE --> PLATEAU SSI (ANDA/R/E4/OS6) - Etat de  --> OPR - N° Inventaire de 00000 --> 0020 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5756), 4, 32, 2, 17 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 305, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5769), 4, 65, 13, 62 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 309, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5786), 4, 77, 3, 138 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 390, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6348), 4, 26, 32, 142 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 420, "Modifications :  - N° Série de  --> FD01533V0YG .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6475), 3, 26, 6, 28 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 505, "Modifications :  - Statut de NON DEFINI --> Local - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6902), 3, 26, 18, 12 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 523, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> EL MOUDDEN IMANE - Emplacement de NON DEFINI --> PLATEAU SAI (ANDA/R/E4/OS1) - Etat de  --> OPR - N° Inventaire de  --> 0140 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6977), 3, 26, 28, 128 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 534, "Modifications :  - Statut de NON DEFINI --> Local - Référence d'achat de 20120418 --> BC N°24/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7023), 3, 26, 34, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 575, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7227), 4, 26, 33, 3 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 34, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4526), 3, 34, 2, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 66, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4660), 2, 34, 26, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 310, "Modifications :  - N° Série de FOC1630Z2Y8 --> FOC1630Z2YF .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5790), 3, 34, 31, 159 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 409, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6429), 2, 34, 6, 178 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 465, "Modifications :  - N° Inventaire de 0000 --> 0419 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6663), 4, 34, 24, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 533, "Modifications :  - Collaborateur de EL MOUDDEN IMANE --> MARZOUKI FATIMA ZAHRA - Emplacement de PLATEAU SAI --> BUREAU CHEF SERVICE SRA-SPA (ANDA/R/E1/B03) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7019), 4, 34, 17, 117 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 605, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7352), 4, 34, 31, 151 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 35, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4530), 2, 47, 26, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 260, "Modifications :  - Collaborateur de EL BERRI TAHA YASSINE --> ANDA ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5543), 3, 47, 14, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 341, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6005), 3, 47, 20, 53 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 445, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6580), 2, 47, 5, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 375, "Modifications :  - Statut de NON DEFINI --> Local - Modèle de LASERJET ENTREPRISE M553 --> LASERJET COLOR M553 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6236), 2, 26, 2, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 450, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6601), 3, 47, 37, 172 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 365, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de ANDA ANDA --> AMAKHLOUF  HICHAM - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> PLATEAU SSI (ANDA/R/E4/OS6) - Etat de STK --> OPR - Remarques de ok -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6194), 2, 26, 7, 152 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 125, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4940), 2, 26, 6, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 653, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7554), 4, 56, 26, 155 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 654, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7590), 4, 46, 18, 103 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 658, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7608), 4, 12, 3, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 660, "Modifications :  - Collaborateur de TAHIRI  MOUNIA --> AIT LAMQADEM ATMAN - Emplacement de BUREAU SPA --> BUREAU SPA (SIG) (ANDA/R/E1/B06) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7616), 4, 64, 28, 81 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 662, "Modifications :  - Collaborateur de N/A   --> EL JABORI AMINE - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> BUREAU SPA (ANDA/R/E1/B10) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7624), 4, 27, 27, 118 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 663, "Modifications :  - Collaborateur de AIT LAMQADEM ATMAN --> EL JABORI AMINE - Emplacement de BUREAU SPA (SIG) --> BUREAU SPA (ANDA/R/E1/B10) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7628), 4, 10, 31, 7 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 665, "Modifications :  - Collaborateur de EL JABORI AMINE --> N/A   - Emplacement de BUREAU SPA --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7637), 4, 37, 27, 54 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 77, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4706), 2, 23, 29, 160 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 165, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5107), 4, 23, 31, 118 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 190, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5244), 3, 23, 17, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 271, "Modifications :  - Emplacement de BUREAU SAT-SRA --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5589), 2, 23, 24, 1 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 332, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5930), 4, 23, 27, 63 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 510, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6922), 2, 23, 21, 122 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 530, "Modifications :  - Statut de NON DEFINI --> Local - N° Inventaire de 023 --> 0023 - Référence d'achat de 20120238 --> BC N°05/2012  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7007), 3, 23, 29, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 532, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7015), 4, 23, 25, 63 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 583, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7261), 4, 23, 6, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 625, "Modifications :  - Prix Unitaire de  --> 3290 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7438), 4, 23, 6, 51 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 273, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5597), 2, 26, 9, 158 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 652, "Modifications :  - Collaborateur de KARFAL  BRAHIM --> N/A   - Emplacement de HORS ANDA --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - N° Inventaire de - --> 0066 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7550), 4, 8, 8, 1 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 494, "Modifications :  - Statut de Local --> Sélectionnez ... .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6856), 2, 47, 18, 87 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 517, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> ADN SYSTEM - Date ACHAT de  --> 25/03/2016 - Prix Unitaire de  --> 12000 - Référence d'achat de  --> F 16/16 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6952), 3, 47, 9, 88 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 393, "Modifications :  - Modèle de PROBOOK 450 --> PROBOOK 450 G5 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6360), 3, 31, 2, 175 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 438, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6551), 3, 31, 15, 114 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 524, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> N/A   - Emplacement de NON DEFINI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de  --> STK - N° Inventaire de  --> 0000 - Nom Equipement de  --> ANDA0036D - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6982), 3, 31, 20, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 53, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4606), 3, 61, 8, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 60, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4635), 2, 61, 32, 75 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 146, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5027), 4, 61, 27, 177 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 333, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5947), 4, 61, 1, 119 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 477, "Modifications :  - Emplacement de BUREAU TP --> HORS ANDA (EXT) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6785), 2, 61, 22, 149 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 486, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6823), 2, 61, 6, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 25, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4489), 3, 76, 4, 154 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 98, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4828), 3, 76, 15, 36 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 250, "Modifications :  - Collaborateur de OUAZZANI  FOUAD --> BASLIH  KHALID - Emplacement de BUREAU SAT-SRA --> BUREAU D'ORDRE (ANDA/R/E4/BO) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5498), 2, 76, 34, 11 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 314, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5807), 3, 76, 21, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 385, "Modifications :  - Statut de NON DEFINI --> Local - Etat de STK --> OPR .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6327), 4, 76, 18, 25 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 392, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6356), 4, 76, 14, 135 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 539, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7044), 4, 76, 19, 66 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 560, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7131), 3, 76, 31, 178 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 366, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> BUCLINTEC - Date ACHAT de  --> 26/09/2012 - Prix Unitaire de  --> 2651 - Référence d'achat de  --> BL 107-BUC-11 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6198), 4, 31, 31, 50 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 511, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6926), 2, 47, 26, 33 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 357, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> BUCLINTEC - Date ACHAT de  --> 26/09/2012 - Prix Unitaire de  --> 3887 - Référence d'achat de  --> BL 107-BUC-11 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6117), 4, 31, 35, 5 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 215, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5351), 2, 31, 38, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 584, "Modifications :  - Date ACHAT de  --> 14/12/2016 - Référence d'achat de  --> BC N°43/2016 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7265), 3, 47, 23, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 15, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4447), 2, 49, 31, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 96, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4784), 2, 49, 4, 111 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 186, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5195), 3, 49, 1, 72 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 213, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5343), 2, 49, 34, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 277, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5615), 2, 49, 27, 171 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 312, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5799), 3, 49, 17, 110 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 384, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6322), 4, 49, 8, 135 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 118, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4911), 2, 59, 26, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 122, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4928), 2, 59, 18, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 196, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5270), 3, 59, 22, 73 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 348, "Modifications :  - Statut de NON DEFINI --> Déplacement  - Collaborateur de NON DEFINI --> ANDA ANDA - Emplacement de NON DEFINI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de  --> OPR - N° Inventaire de  --> 0000 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6053), 2, 59, 28, 29 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 464, "Modifications :  - Collaborateur de MAAROUF  MAJIDA --> ANDA ANDA - Emplacement de BUREAU DIRECTION E4 --> PETITE SALLE DE REUNION (ANDA/R/E4/SR2) - Modèle de 40D7000 --> 55ES7000 - N° Série de  --> Z9MP3S2C50000AL - Prix Unitaire de 10600,00 --> 21100,00 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6659), 4, 59, 4, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 626, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7442), 4, 59, 35, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 37, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4539), 3, 31, 2, 41 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 114, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4895), 3, 31, 15, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 169, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5124), 2, 31, 9, 146 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 240, "Modifications :  - Collaborateur de ACHCHAB MANSSOUR --> ANDA ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5456), 2, 31, 33, 72 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 362, "Modifications :  - Collaborateur de AMAKHLOUF  HICHAM --> ANDA ANDA - Emplacement de PLATEAU SSI --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - Remarques de OK --> ECRAN VIDEO SURVEILLANCE  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6178), 2, 79, 18, 169 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 648, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7534), 4, 57, 11, 4 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 640, "Modifications :  - Date ACHAT de 14/03/2014 --> 07/01/2014 - Référence d'achat de BC N°63/2013 --> BC N°65/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7501), 4, 3, 20, 21 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 407, "Modifications :  - Fournisseur de NON DEFINI --> ADN SYSTEM - Date ACHAT de  --> 14/03/2014 - Référence d'achat de  --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6421), 4, 37, 20, 164 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 410, "Modifications :  - Fournisseur de NON DEFINI --> ALPHA BUREAU - Date ACHAT de  --> 09/04/2013 - Prix Unitaire de  --> 73020 - Référence d'achat de  --> F 429/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6433), 4, 29, 31, 29 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 411, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6437), 4, 75, 6, 117 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 416, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6459), 4, 54, 38, 93 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 417, "Modifications :  - Constructeur de APPLE --> APC .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6463), 4, 62, 36, 26 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 424, "Modifications :  - Nom Equipement de  --> Switch PoE .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6492), 4, 68, 33, 87 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 426, "Modifications :  - Nom Equipement de  --> Switch PoE .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6500), 4, 27, 19, 148 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 429, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6512), 4, 5, 28, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 433, "Modifications :  - Modèle de ASA --> ASA 5512 V03 - N° Série de ----- --> FGL1907409G .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6529), 4, 45, 23, 46 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 434, "Modifications :  - N° Inventaire de 0000 --> 0044 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6533), 4, 27, 12, 110 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 436, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6542), 4, 63, 18, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 440, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6559), 4, 46, 38, 14 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 442, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6567), 4, 70, 23, 131 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 446, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6584), 4, 48, 23, 79 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 448, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6592), 4, 42, 27, 30 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 451, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6605), 4, 39, 21, 87 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 463, "Modifications :  - Collaborateur de MAAROUF  MAJIDA --> ANDA ANDA - Emplacement de BUREAU DIRECTION E4 --> COULOIR OPEN SPACE (ANDA/R/E4/C-OS) - N° Série de  --> Z8EK3SHBC00A86B .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6655), 4, 72, 19, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 404, "Modifications :  - Catégorie de PHOTOCPIEUR NOIR --> IMPRIMANTE COULEUR RESEAU - Constructeur de TOSHIBA --> HP - Modèle de ESTUDIO 181 --> LASERJET COLOR M553 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6409), 4, 15, 13, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 467, "Modifications :  - Collaborateur de ANDA ANDA --> BAINA  BOUTAINA - Etat de STK --> OPR .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6671), 4, 77, 28, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 402, "Modifications :  - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 01/12/2012 - Prix Unitaire de  --> 870 - Référence d'achat de  --> Marché N°10/DAG/ANDA/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6400), 4, 33, 37, 34 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 383, "Modifications :  - Collaborateur de EL OUAZZANI  HICHAM --> ANDA ANDA - Etat de OPR --> EPN - N° Inventaire de - --> 0041 - Remarques de  --> Carte USB Endommagée .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6318), 4, 10, 21, 49 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 316, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5815), 4, 45, 5, 162 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 317, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5819), 4, 74, 16, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 321, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5836), 4, 35, 20, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 323, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5845), 4, 73, 8, 92 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 327, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5881), 4, 32, 15, 70 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 342, "Modifications :  - Catégorie de TELEPHONE IP --> POINT D'ACCES WIFI .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6012), 4, 55, 13, 158 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 345, "Modifications :  - Emplacement de COULOIR OPEN SPACE --> ESPACE COMMUN (ANDA/R/E1/EC) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6032), 4, 15, 37, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 351, "Modifications :  - Collaborateur de ANDA ANDA --> BADDI  LOUBNA - Modèle de Probook 4540S --> PROBOOK 4540S .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6074), 4, 41, 34, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 353, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 01/12/2012 - Prix Unitaire de  --> 5600 - Référence d'achat de  --> Marché N°10/DAG/ANDA/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6088), 4, 51, 16, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 355, "Modifications :  - Catégorie de IMPRIMANTE COULEUR RESEAU --> IMPRIMANTE COULEUR USB - Modèle de LASERJETCP 1025 --> LASERJET CP1025 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6103), 4, 1, 14, 10 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 358, "Modifications :  - Statut de NON DEFINI --> Local - Constructeur de NON DEFINI --> HP - Fournisseur de NON DEFINI --> BUCLINTEC - Etat de  --> OPR - Date ACHAT de  --> 26/09/2012 - Prix Unitaire de  --> 3887 - Référence d'achat de  --> BL 107-BUC-11 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6123), 4, 75, 29, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 360, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6165), 4, 4, 26, 44 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 361, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - Etat de STK --> OPR - Remarques de ok --> ECRAN DE VIDEO SURVEILLANCE  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6171), 4, 5, 30, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 363, "Modifications :  - Etat de OPR --> EPN - Remarques de  --> EN PANNE .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6186), 4, 16, 12, 89 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 367, "Modifications :  - Statut de NON DEFINI --> Local - Etat de  --> OPR .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6203), 4, 78, 6, 97 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 372, "Modifications :  - Modèle de LASERJET ENTREPRISE M553 --> LASERJET COLOR M553 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6223), 4, 11, 22, 124 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 374, "Modifications :  - Remarques de  --> Kit De Transfert Abimé .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6232), 4, 28, 8, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 394, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6364), 4, 41, 38, 34 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 646, "Modifications :  - N° Inventaire de NEW --> 0718 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7525), 4, 53, 16, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 471, "Modifications :  - Collaborateur de BADDI  LOUBNA --> ANDA ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6757), 4, 3, 11, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 473, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6765), 4, 74, 27, 50 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 580, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7248), 4, 51, 33, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 581, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7253), 4, 24, 9, 134 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 587, "Modifications :  - Fournisseur de NON DEFINI --> SESA - Date ACHAT de  --> 19/03/2013 - Référence d'achat de  --> BC N° 03/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7277), 4, 36, 31, 140 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 591, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7294), 3, 4, 32, 7 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 600, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7331), 4, 38, 14, 171 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 602, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7340), 4, 45, 12, 172 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 606, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7356), 4, 52, 23, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 608, "Modifications :  - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 10/07/2018 - Référence d'achat de  --> MARCHE N°05/2017/ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7365), 4, 56, 36, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 609, "Modifications :  - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 10/07/2018 - Référence d'achat de  --> MARCHE N°05/2017/ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7369), 4, 46, 1, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 610, "Modifications :  - Fournisseur de NON DEFINI --> ETCE INFO - Date ACHAT de  --> 14/04/2014 - Référence d'achat de  --> BC N°79/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7375), 4, 4, 14, 46 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 612, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7383), 4, 30, 17, 70 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 613, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7387), 4, 51, 5, 144 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 621, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 28/12/2012 - Référence d'achat de  --> Marché N° 10/DAG-ANDA/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7420), 2, 4, 36, 165 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 622, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 28/12/2012 - Référence d'achat de  --> Marché N° 10/DAG-ANDA/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7426), 4, 46, 11, 91 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 633, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7471), 4, 12, 20, 53 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 634, "Modifications :  - Constructeur de NON DEFINI --> LG .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7476), 4, 11, 7, 166 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 638, "Modifications :  - N° Inventaire de 0402 --> 0405 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7492), 4, 22, 15, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 578, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7240), 4, 45, 29, 3 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 472, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6761), 4, 19, 24, 109 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 566, "Modifications :  - N° Inventaire de 0000 --> 0397 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7190), 4, 44, 26, 102 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 556, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7114), 4, 10, 37, 21 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 475, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> HORS ANDA (EXT) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6776), 4, 80, 32, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 493, "Modifications :  - Collaborateur de N/A   --> EL AARAJ YOUSSEF - Remarques de Perdu lors du vol de la maison de youssef el aaraj --> Perdu lors du vol de la maison de youssef el Aaraj .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6852), 4, 45, 19, 74 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 496, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6864), 4, 30, 17, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 499, "Modifications :  - Collaborateur de MATERIEL ANDA --> N/A   - Remarques de pas de disque dur ni lecteur cd ni memoire vif --> Cassé Par Mustapha : Lecteur CD/DVD Disque Dur endommagé RAM Enlevée .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6877), 4, 3, 9, 170 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 508, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6914), 4, 67, 37, 152 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 512, "Modifications :  - Collaborateur de MATERIEL ANDA --> N/A   - Fournisseur de NON DEFINI --> CBI - Remarques de test -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6930), 4, 58, 12, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 515, "Modifications :  - Fournisseur de NON DEFINI --> ADN SYSTEM - Date ACHAT de  --> 16/12/2016 - Prix Unitaire de  --> 11700 - Référence d'achat de  --> F 72/16 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6943), 4, 4, 32, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 518, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> ADN SYSTEM - Date ACHAT de  --> 25/03/2016 - Prix Unitaire de  --> 12000 - Référence d'achat de  --> F 16/16 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6956), 4, 7, 38, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 522, "Modifications :  - Collaborateur de MATERIEL ANDA --> BHABY  SANAA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6973), 4, 2, 8, 39 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 526, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6990), 4, 12, 21, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 535, "Modifications :  - Statut de NON DEFINI --> Local - Référence d'achat de 20120418 --> BC N°24/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7027), 4, 62, 1, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 536, "Modifications :  - Référence d'achat de 20120418 --> BC N°24/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7031), 4, 68, 29, 40 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 538, "Modifications :  - Référence d'achat de 20120418 --> BC N°24/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7040), 4, 28, 38, 166 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 541, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7053), 4, 22, 23, 113 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 546, "Modifications :  - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7073), 4, 16, 29, 81 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 553, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7102), 4, 20, 14, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 555, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7110), 4, 15, 12, 36 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 557, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7119), 4, 58, 19, 84 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 296, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5731), 2, 79, 26, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 661, "Modifications :  - Collaborateur de AIT LAMQADEM ATMAN --> N/A   - Emplacement de BUREAU SPA (SIG) --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7620), 3, 76, 23, 28 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 7, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4413), 2, 79, 9, 97 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 171, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5132), 3, 29, 9, 96 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 287, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5693), 3, 29, 27, 161 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 513, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6935), 3, 29, 25, 122 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 592, "Modifications :  - Modèle de LASERJET COLOR M551 --> LASERJET COLOR M553 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7298), 3, 29, 15, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 617, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7403), 3, 29, 6, 111 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 64, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4652), 3, 58, 30, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 181, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5174), 3, 58, 32, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 380, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6305), 3, 58, 8, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 487, "Modifications :  - Collaborateur de MATERIEL ANDA --> N/A   .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6827), 3, 58, 17, 110 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 595, "Modifications :  - Fournisseur de NON DEFINI --> TOP INVEST RYAD - Prix Unitaire de  --> 11500 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7311), 3, 74, 4, 125 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 78, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4710), 3, 18, 7, 110 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 202, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5296), 3, 18, 16, 88 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 237, "Modifications :  - Emplacement de PLATEAU SSI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5443), 3, 18, 38, 63 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 264, "Modifications :  - Catégorie de IMPRIMANTE NOIR USB --> IMPRIMANTE COULEUR USB - Collaborateur de KARFAL  BRAHIM --> EL OUAZZANI  HICHAM - Emplacement de BUREAU CHEF SERVICE SRA-SPA --> BUREAU CHEF SERVICE SAT-SE (ANDA/R/E1/B04) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5560), 3, 18, 24, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 248, "Modifications :  - Collaborateur de ANDA ANDA --> BAINA  BOUTAINA - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> BUREAU ASSISTANAT DE DIRECTION (ANDA/R/E4/B02) - Etat de STK --> OPR .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5490), 3, 24, 29, 65 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 406, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6417), 3, 1, 23, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 9, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4423), 2, 62, 8, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 650, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7542), 3, 80, 6, 110 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 11, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4431), 2, 48, 25, 6 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 630, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7459), 3, 48, 11, 64 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 620, "Modifications :  - Date ACHAT de 24/04/2014 --> 14/04/2014 - Référence d'achat de BC 79/2013 --> BC N°79/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7416), 3, 40, 9, 102 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 542, "Modifications :  - N° Inventaire de 0140 --> 0082 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7057), 3, 67, 1, 148 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 543, "Modifications :  - Collaborateur de MATERIEL ANDA --> N/A   .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7061), 3, 28, 5, 39 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 544, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de MATERIEL ANDA --> N/A   .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7065), 3, 19, 7, 102 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 548, "Modifications :  - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7081), 3, 32, 32, 39 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 551, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7094), 3, 75, 8, 1 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 552, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7098), 3, 71, 28, 49 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 554, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7106), 3, 5, 38, 5 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 558, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7123), 3, 38, 22, 157 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 561, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7167), 3, 40, 25, 80 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 562, "Modifications :  - N° Inventaire de 0027 --> 0393 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7172), 3, 48, 7, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 567, "Modifications :  - Date ACHAT de 28/11/2012 --> 25/09/2012 - Remarques de  -->  - Référence d'achat de 20120669 --> BC N°45/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7194), 3, 21, 8, 69 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 571, "Modifications :  - N° Inventaire de - --> 0410 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7211), 3, 66, 15, 76 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 586, "Modifications :  - Fournisseur de NON DEFINI --> SESA - Date ACHAT de  --> 19/03/2013 - Référence d'achat de  --> BC N° 03/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7273), 3, 54, 28, 167 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 590, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7290), 3, 54, 27, 36 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 593, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7303), 3, 33, 5, 63 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 603, "Modifications :  - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 10/07/2018 - Référence d'achat de  --> MARCHE N°05/2017/ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7344), 3, 11, 16, 41 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 616, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7399), 3, 54, 34, 161 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 627, "Modifications :  - Catégorie de VIDEO PROJECTEUR --> ECRAN PROJECTION .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7446), 3, 77, 9, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 537, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de ALIMENTATION ENDOMMAGER  --> DEFAUT BOITE D'ALIMENTATION - Référence d'achat de 20120418 --> BC N°24/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7036), 3, 45, 8, 20 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 17, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4456), 2, 48, 27, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 24, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4485), 2, 75, 10, 121 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 161, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5091), 2, 5, 19, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 172, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5136), 2, 28, 35, 37 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 174, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5145), 2, 74, 32, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 175, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5149), 2, 40, 14, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 176, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5153), 2, 32, 36, 7 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 183, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5182), 2, 5, 35, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 187, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5199), 2, 66, 15, 9 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 200, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5287), 2, 77, 15, 80 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 207, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5317), 2, 10, 33, 52 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 211, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5334), 2, 22, 15, 124 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 214, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5347), 2, 18, 25, 70 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 218, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5364), 2, 63, 4, 24 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 220, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5372), 2, 53, 7, 166 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 221, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5376), 2, 39, 35, 86 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 222, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5380), 2, 71, 18, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 229, "Modifications :  - Emplacement de PLATEAU SAI --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5409), 2, 55, 26, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 245, "Modifications :  - Collaborateur de BAINA  BOUTAINA --> ANDA ANDA - Emplacement de BUREAU ASSISTANAT DE DIRECTION --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5477), 2, 27, 12, 65 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 149, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5040), 2, 48, 16, 105 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 19, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4464), 2, 53, 35, 21 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 139, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4998), 2, 33, 15, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 135, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4982), 2, 33, 33, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 40, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4551), 3, 2, 16, 14 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 43, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4564), 2, 62, 23, 66 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 44, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4568), 2, 10, 31, 46 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 56, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4618), 2, 11, 22, 159 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 58, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4627), 2, 54, 28, 111 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 73, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4689), 2, 69, 35, 66 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 80, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4718), 2, 64, 9, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 83, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4731), 2, 28, 26, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 87, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4747), 2, 48, 30, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 97, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4822), 2, 55, 35, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 101, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4841), 2, 53, 28, 69 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 116, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4903), 2, 13, 13, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 126, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4945), 2, 21, 30, 112 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 127, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4949), 2, 17, 33, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 130, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4961), 2, 40, 7, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 132, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4970), 2, 77, 38, 51 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 134, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4978), 2, 29, 7, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 138, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4994), 2, 1, 28, 95 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 519, "Modifications :  - Statut de NON DEFINI --> Local - Date ACHAT de  --> 25/03/2016 - Prix Unitaire de  --> 12000 - Référence d'achat de  --> F 16/16 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6960), 3, 38, 36, 51 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 503, "Modifications :  - Statut de NON DEFINI --> Local - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6893), 3, 11, 24, 117 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 500, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de MATERIEL ANDA --> N/A   - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6881), 3, 35, 31, 95 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 148, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5036), 3, 32, 14, 160 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 151, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5048), 3, 55, 11, 43 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 153, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5058), 3, 19, 2, 89 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 154, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5062), 3, 60, 36, 126 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 189, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5207), 3, 75, 32, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 191, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5250), 3, 28, 9, 53 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 195, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5266), 3, 11, 10, 74 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 198, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5279), 3, 27, 35, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 204, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5304), 3, 13, 5, 108 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 212, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5339), 3, 77, 35, 20 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 236, "Modifications :  - Collaborateur de TOUJGANI  HAFSA --> ANDA ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5439), 3, 63, 9, 148 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 241, "Modifications :  - Collaborateur de ACHCHAB MANSSOUR --> ANDA ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5460), 3, 77, 2, 65 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 243, "Modifications :  - Collaborateur de ZAKHOUR  SMAIL --> ANDA ANDA - Emplacement de PLATEAU SPC --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de OPR --> EPN .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5469), 3, 35, 24, 78 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 259, "Modifications :  - Emplacement de BUREAU SE --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5539), 3, 69, 7, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 266, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5568), 3, 48, 2, 168 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 268, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5577), 3, 67, 27, 128 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 270, "Modifications :  - Emplacement de BUREAU SAT-SRA --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5585), 3, 71, 5, 118 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 129, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4957), 3, 63, 11, 171 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 279, "Modifications :  - Emplacement de BUREAU SAT-SRA --> DAKHLA APT 1 (ANDA/D/APT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5623), 3, 3, 8, 137 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 128, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4953), 3, 60, 35, 168 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 99, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4833), 3, 77, 32, 29 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 6, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4409), 3, 13, 15, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 13, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4439), 3, 38, 3, 142 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 16, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4452), 3, 33, 22, 5 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 18, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4460), 3, 45, 27, 128 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 21, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4472), 3, 71, 22, 20 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 22, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4476), 3, 3, 25, 30 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 26, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4493), 3, 64, 38, 71 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 33, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4522), 3, 72, 21, 25 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 42, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4560), 3, 66, 15, 151 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 59, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4631), 3, 22, 31, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 62, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4643), 3, 27, 10, 139 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 75, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4697), 3, 62, 13, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 76, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4702), 3, 54, 9, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 81, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4722), 3, 3, 37, 130 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 82, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4727), 3, 32, 32, 96 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 90, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4760), 3, 60, 21, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 93, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4772), 3, 69, 12, 49 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 107, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4866), 3, 17, 23, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 280, "Modifications :  - Catégorie de IMPRIMANTE NOIR RESEAU --> IMPRIMANTE NOIR USB - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5627), 3, 27, 16, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 281, "Modifications :  - Catégorie de IMPRIMANTE NOIR RESEAU --> IMPRIMANTE COULEUR RESEAU - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5631), 3, 33, 34, 73 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 290, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5705), 3, 38, 32, 25 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 419, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6471), 3, 77, 7, 131 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 422, "Modifications :  - N° Série de  --> FOC1648Z1B7 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6483), 3, 69, 24, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 427, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6504), 3, 35, 31, 94 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 432, "Modifications :  - Modèle de ASA --> ASA 5512 V03 - N° Série de ---- --> FGL1907409H .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6525), 3, 19, 13, 158 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 437, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6546), 3, 5, 36, 72 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 439, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6555), 3, 10, 34, 68 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 449, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6596), 3, 71, 38, 113 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 460, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> MAAROUF  MAJIDA - Emplacement de NON DEFINI --> BUREAU DIRECTION E4 (ANDA/R/E4/B01) - Etat de  --> EPN - N° Inventaire de  --> 0000 - Remarques de  --> PC toujours chez la directrice Pb Réclamé et pc non rendu  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6643), 3, 5, 25, 161 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 470, "Modifications :  - Collaborateur de BAINA  BOUTAINA --> ANDA ANDA - Emplacement de BUREAU ASSISTANAT DE DIRECTION --> DAKHLA APT 1 (ANDA/D/APT1) - Etat de OPR --> EPN .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6753), 3, 38, 18, 16 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 478, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6789), 3, 5, 34, 10 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 479, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6793), 3, 55, 18, 172 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 480, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6797), 3, 60, 2, 134 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 481, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6801), 3, 45, 6, 40 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 482, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> N/A   - Emplacement de NON DEFINI --> HORS ANDA (EXT) - Etat de  -->  - N° Inventaire de  --> 0000 - Remarques de  --> Perdu au niveau du ministère Déclaration du perte déposé au niveau de commissariat de police de l'Agdal .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6805), 3, 48, 13, 157 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 483, "Modifications :  - Etat de OPR --> EPN .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6810), 3, 11, 7, 119 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 484, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> N/A   - Emplacement de NON DEFINI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de  --> STK - N° Inventaire de  --> 0000 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6814), 3, 40, 3, 139 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 485, "Modifications :  - Emplacement de BUREAU CHEF SERVICE SRA-SPA --> HORS ANDA (EXT) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6818), 3, 64, 7, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 418, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - N° Série de  --> IS1235000198 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6467), 3, 19, 4, 139 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 413, "Modifications :  - N° Série de  --> SKD0Z5N0 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6446), 3, 67, 31, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 405, "Modifications :  - Statut de NON DEFINI --> Local - Prix Unitaire de  --> 15300 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6413), 3, 5, 18, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 398, "Modifications :  - N° Inventaire de - --> 0406 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6381), 3, 69, 20, 16 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 292, "Modifications :  - Collaborateur de NON DEFINI --> ANDA ANDA - Emplacement de NON DEFINI --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - Etat de  --> STK - N° Inventaire de  --> 0010 - Nom Equipement de  --> ANDA0003L - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5714), 3, 39, 6, 165 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 294, "Modifications :  - Nom Equipement de ANDA-DEPLACEMENT1 --> ANDA-DEPLACEMENT2 - Remarques de EB DEPLACEMENT HALIEUTIS -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5722), 3, 33, 30, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 303, "Modifications :  - Statut de NON DEFINI --> Local - Etat de STK --> OPR - Remarques de ok --> Utilisé par Sanae .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5760), 3, 80, 19, 6 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 304, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de  --> Dans l'attente d'installation d'une ligne de fax .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5765), 3, 27, 21, 105 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 311, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5794), 3, 17, 29, 27 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 318, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5823), 3, 13, 16, 63 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 324, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5864), 3, 21, 29, 72 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 328, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5887), 3, 72, 35, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 95, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4780), 2, 79, 36, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 330, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5900), 3, 69, 13, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 344, "Modifications :  - Emplacement de COULOIR OPEN SPACE --> COULOIR BUREAUX (ANDA/R/E4/C-B) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6026), 3, 77, 3, 156 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 349, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6061), 3, 77, 16, 48 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 350, "Modifications :  - Modèle de Probook 4540S --> PROBOOK 4540S .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6067), 3, 80, 25, 103 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 356, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> BUCLINTEC - Date ACHAT de  --> 26/09/2012 - Prix Unitaire de  --> 3887 - Référence d'achat de  --> BL 107-BUC-11 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6110), 3, 69, 11, 44 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 378, "Modifications :  - N° Inventaire de 0000 --> 0047 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6297), 3, 66, 1, 132 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 379, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6301), 3, 11, 25, 128 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 387, "Modifications :  - N° Inventaire de 0000 --> 0486 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6335), 3, 72, 17, 38 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 395, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6368), 3, 60, 22, 97 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 337, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5976), 3, 57, 36, 108 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 251, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5503), 2, 64, 25, 59 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 249, "Modifications :  - Collaborateur de BASLIH  KHALID --> ANDA ANDA - Emplacement de BUREAU D'ORDRE --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5494), 2, 54, 7, 105 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 253, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5512), 3, 2, 10, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 615, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7395), 3, 30, 9, 123 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 643, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7513), 3, 30, 25, 24 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 31, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4514), 3, 56, 12, 121 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 92, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4768), 3, 56, 37, 96 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 110, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4878), 3, 56, 2, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 216, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5355), 3, 56, 16, 98 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 276, "Modifications :  - Catégorie de IMPRIMANTE COULEUR USB --> IMPRIMANTE NOIR USB .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5610), 2, 56, 25, 77 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 428, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6508), 3, 30, 28, 140 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 343, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6019), 3, 56, 1, 163 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 38, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4543), 3, 15, 35, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 133, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4974), 2, 15, 21, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 206, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5313), 3, 15, 7, 139 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 373, "Modifications :  - Statut de NON DEFINI --> Local - Etat de OPR --> EPN - Modèle de LASERJET 500COLOR M551 --> LASERJET COLOR M551 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6228), 3, 15, 25, 176 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 502, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> JAHID  ASMAA - Emplacement de NON DEFINI --> HORS ANDA (EXT) - Etat de  --> OPR - N° Inventaire de  --> 0000 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6889), 3, 15, 1, 151 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 514, "Modifications :  - Etat de OPR --> STK - Date ACHAT de  --> 14/09/2015 - Prix Unitaire de  --> 14000 - Référence d'achat de  --> BC N°50/2014 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6939), 3, 15, 14, 10 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 623, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7430), 2, 15, 18, 95 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 585, "Modifications :  - Fournisseur de NON DEFINI --> ADN SYSTEM .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7269), 3, 56, 27, 50 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 265, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5564), 3, 30, 37, 39 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 232, "Modifications :  - Collaborateur de KHALILI  EL MADANI --> ANDA ANDA - Emplacement de BUREAU SE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) - Etat de OPR --> STK - Remarques de  --> ok .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5421), 3, 30, 7, 46 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 641, "Modifications :  - Emplacement de DAKHLA APT 1 --> PLATEAU SRH (ANDA/R/E4/OS2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7505), 3, 20, 27, 85 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 655, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7595), 2, 72, 37, 46 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 252, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5508), 2, 16, 22, 177 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 142, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5011), 3, 6, 15, 59 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 320, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5832), 2, 6, 27, 48 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 401, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> BUREAU CHEF SERVICE SAT-SE (ANDA/R/E1/B04) - N° Inventaire de - --> 0040 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6396), 2, 6, 35, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 457, "Modifications :  - Statut de NON DEFINI --> Local - Etat de STK --> OPR - Remarques de OK -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6630), 2, 6, 17, 168 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 527, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6994), 2, 6, 14, 174 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 573, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7219), 2, 6, 28, 43 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 645, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7521), 2, 6, 2, 32 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 88, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4751), 2, 20, 37, 102 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 113, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4891), 2, 20, 3, 92 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 117, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4907), 2, 20, 12, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 120, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4920), 3, 20, 28, 33 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 147, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5032), 3, 20, 23, 79 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 282, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> DAKHLA APT 1 (ANDA/D/APT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5635), 3, 20, 8, 93 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 340, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5998), 2, 20, 33, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 431, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6521), 3, 20, 4, 42 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 1, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(2781), 2, 42, 18, 83 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 644, "Modifications :  - Collaborateur de JAHID  ASMAA --> N/A   - Emplacement de HORS ANDA --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7517), 2, 28, 31, 30 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 239, "Modifications :  - Emplacement de PLATEAU SSI --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5451), 3, 42, 16, 50 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 325, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5868), 2, 42, 3, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 106, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4861), 3, 37, 25, 132 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 160, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5086), 2, 37, 16, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 388, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6339), 2, 37, 16, 26 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 495, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6860), 3, 37, 1, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 598, "Modifications :  - N° Série de XXXX --> JPBVL20086 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7323), 3, 37, 37, 17 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 642, "Modifications :  - Emplacement de DAKHLA APT 1 --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7509), 2, 37, 3, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 28, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4502), 2, 78, 21, 177 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 71, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4680), 3, 37, 37, 92 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 69, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4672), 2, 78, 12, 137 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 635, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7480), 2, 78, 7, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 637, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7488), 2, 78, 20, 24 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 649, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7538), 3, 78, 20, 3 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 156, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5070), 2, 65, 38, 12 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 179, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5166), 2, 65, 6, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 261, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de KARAKCHOU  SOUFIANE --> EL BERRI TAHA YASSINE - Emplacement de BUREAU CHEF SERVICES SRH-SAICG --> BUREAU SE (ANDA/R/E1/B09) - N° Inventaire de - --> 0004 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5548), 3, 65, 38, 147 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 447, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6588), 2, 65, 32, 124 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 540, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7048), 3, 78, 6, 172 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 52, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4602), 2, 37, 13, 122 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 51, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4598), 3, 37, 31, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 45, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4572), 3, 37, 31, 123 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 352, "Modifications :  - N° Inventaire de 0000 --> 0402 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6081), 3, 42, 24, 80 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 528, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de MATERIEL ANDA --> N/A   - Etat de OPR --> STK - Référence d'achat de 20120238 --> BC N°05/2012  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6998), 3, 42, 23, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 564, "Modifications :  - Statut de NON DEFINI --> Local - N° Inventaire de 0078 --> 0000 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7182), 2, 42, 36, 10 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 242, "Modifications :  - Collaborateur de ACHCHAB MANSSOUR --> ZAKHOUR  SMAIL - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> PLATEAU SPC (ANDA/R/E4/OS3) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5465), 2, 46, 30, 99 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 563, "Modifications :  - N° Inventaire de 0393 --> 0027 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7177), 3, 46, 30, 68 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 569, "Modifications :  - N° Inventaire de 0000 --> 0048 - Référence d'achat de 20120238 --> BC N°05/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7203), 3, 46, 35, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 14, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4443), 3, 50, 20, 94 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 30, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4510), 3, 50, 31, 106 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 57, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4623), 3, 50, 29, 58 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 188, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5203), 2, 50, 14, 34 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 299, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> AARAB  LAHOUSSINE - Emplacement de NON DEFINI --> BUREAU CHEF SERVICE SPC-SAI (ANDA/R/E4/B07) - Etat de  --> OPR - N° Inventaire de  --> 0386 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5744), 3, 50, 16, 137 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 84, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4735), 2, 14, 28, 160 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 185, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5191), 2, 14, 1, 22 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 459, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6638), 2, 14, 35, 108 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 474, "Modifications :  - Catégorie de VIDEO PROJECTEUR --> VISIO CONFERENCE SYSTEM - Constructeur de NON DEFINI --> POLYCOM - Fournisseur de NON DEFINI --> LATCO - Date ACHAT de  --> 26/12/2013 - Prix Unitaire de  --> 81600 - Référence d'achat de  --> BC LATCO 2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6772), 3, 14, 3, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 568, "Modifications :  - Statut de NON DEFINI --> Local - Date ACHAT de 28/11/2012 --> 25/09/2012 - Référence d'achat de 20120669 --> BC N°45/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7198), 3, 14, 28, 133 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 36, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(4535), 3, 37, 9, 23 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 247, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5486), 3, 42, 1, 151 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 639, "Modifications :  - N° Inventaire de 0000 --> 0469 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7497), 2, 58, 10, 80 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 657, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> LOCAL TECHNIQUE PRINCIPAL (ANDA/R/E4/LT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7603), 2, 5, 16, 20 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 632, "Modifications :  - Statut de NON DEFINI --> Local - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 10/07/2018 - Remarques de  --> Erreur à plusieurs reprise, changement de l'afficheur effectué par le fournisseur, persistance du problème ! - Prix Unitaire de  --> 16800 - Référence d'achat de  --> MARCHE N°05/2017/ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7467), 2, 18, 5, 39 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 376, "Modifications :  - Modèle de LASERJET 500COLOR M551 --> LASERJET COLOR M551 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6286), 2, 57, 23, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 377, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6292), 2, 13, 20, 62 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 381, "Modifications :  - Etat de  --> STK - N° Inventaire de - --> 0037 - Remarques de   -->  Vérification Nécessaire  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6309), 2, 18, 23, 100 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 382, "Modifications :  - Etat de  --> STK - N° Inventaire de - --> 0036 - Remarques de   --> Vérification Nécessaire .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6313), 2, 5, 10, 64 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 386, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6331), 2, 74, 37, 13 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 397, "Modifications :  - N° Inventaire de - --> 0483 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6377), 2, 11, 1, 145 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 399, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> BUREAU SE (ANDA/R/E1/B09) - N° Inventaire de - --> 0039 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6385), 2, 75, 19, 141 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 400, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> PLATEAU SBC (ANDA/R/E4/OS5) - N° Inventaire de - --> 0034 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6389), 2, 22, 13, 115 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 371, "Modifications :  - Statut de NON DEFINI --> Local - Modèle de LASERJET 500COLOR M551 --> LASERJET COLOR M551 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6219), 2, 75, 23, 142 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 414, "Modifications :  - Modèle de X3650 (791562G) --> X3550 (7944D2G) - N° Série de  --> SKD0V3L8 - Prix Unitaire de 77472 --> 36615 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6450), 2, 10, 29, 153 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 421, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6479), 2, 72, 30, 171 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 423, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6488), 2, 1, 23, 129 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 430, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6516), 2, 10, 26, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 435, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de CHEZ Mme IJLAL --> N'est pas encore rendu de la part de Ijlal suite à la fin de son contrat .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6538), 2, 73, 33, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 441, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6563), 2, 80, 6, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 443, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6571), 2, 22, 9, 127 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 452, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6609), 2, 3, 13, 101 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 453, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6613), 2, 10, 6, 92 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 415, "Modifications :  - Collaborateur de ANDA ANDA --> BADDI  LOUBNA - N° Inventaire de - --> 0408 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6455), 2, 66, 8, 169 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 455, "Modifications :  - Statut de NON DEFINI --> Local .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6621), 2, 40, 12, 79 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 370, "Modifications :  - Statut de NON DEFINI --> Local - Modèle de COLOR LASERJET ENTREPRISE M552 --> LASERJET COLOR M552 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6215), 2, 77, 35, 40 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 368, "Modifications :  - Fournisseur de NON DEFINI --> ETCE INFO - Date ACHAT de  --> 24/04/2014 - Prix Unitaire de  --> 2200 - Référence d'achat de  --> BC 79/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6207), 2, 55, 12, 154 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 262, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5552), 2, 38, 37, 156 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 263, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5556), 2, 58, 3, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 275, "Modifications :  - Statut de NON DEFINI --> Local - Collaborateur de NON DEFINI --> Thadi Mustapha - Emplacement de NON DEFINI --> BUREAU TP (ANDA/R/E4/B06) - Etat de  --> OPR - N° Inventaire de  --> 0062 - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5606), 2, 72, 4, 136 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 278, "Modifications :  - Emplacement de BUREAU SAT-SRA --> DAKHLA APT 1 (ANDA/D/APT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5619), 2, 29, 38, 116 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 285, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> DAKHLA APT 1 (ANDA/D/APT1) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5685), 2, 24, 9, 16 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 289, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5701), 2, 69, 17, 70 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 291, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5709), 2, 40, 10, 162 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 293, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5718), 2, 21, 11, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 369, "Modifications :  - Statut de NON DEFINI --> Local - Modèle de LASERJET 500COLOR M551 --> LASERJET COLOR M551 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6211), 2, 64, 1, 8 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 295, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5727), 2, 21, 19, 119 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 315, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5811), 2, 18, 32, 19 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 319, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5828), 2, 57, 9, 159 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 326, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5875), 2, 21, 13, 5 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 338, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5985), 2, 19, 1, 85 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 339, "Modifications :  - Emplacement de LOCAL TECHNIQUE PRINCIPAL --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5992), 2, 55, 13, 7 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 346, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6039), 2, 45, 16, 55 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 347, "Modifications :  - Catégorie de BAIE DE STOCKAGE --> CALL MANAGER .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6046), 2, 18, 38, 107 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 359, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6149), 2, 74, 32, 59 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 306, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(5773), 2, 55, 31, 24 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 636, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7484), 2, 57, 11, 62 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 456, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de  --> Tonner manquant Erreur d'impression fréquentes .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6626), 2, 28, 20, 22 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 549, "Modifications :  - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7085), 2, 38, 27, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 529, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7003), 2, 66, 15, 73 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 531, "Modifications :  - N° Inventaire de 0000 --> 0015 - Référence d'achat de 20120238 --> BC N°05/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7011), 3, 2, 14, 128 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 547, "Modifications :  - Référence d'achat de 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7077), 2, 1, 22, 2 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 458, "Modifications :  - Emplacement de LOCAL TECHNIQUE --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6634), 2, 11, 38, 125 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 550, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7090), 2, 80, 27, 140 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 559, "Modifications :  - Statut de Local --> Sélectionnez ... .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7127), 2, 13, 23, 120 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 525, "Modifications :  - Statut de NON DEFINI --> Local - Remarques de  -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6986), 2, 32, 5, 178 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 570, "Modifications :  - Date ACHAT de 14/03/2014 --> 07/01/2014 - Référence d'achat de BC N°63/2013 --> BC N°65/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7207), 2, 19, 38, 67 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 574, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7223), 2, 39, 31, 109 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 576, "Modifications :  - Date ACHAT de 01/12/2012 --> 28/12/2012 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7231), 2, 17, 34, 6 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 604, "Modifications :  - Date ACHAT de 01/07/2017 --> 10/07/2018 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7348), 2, 16, 6, 86 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 577, "Modifications :  - Emplacement de PLATEAU SBC --> HORS ANDA (EXT) - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 30/04/2017 - Référence d'achat de  --> MARCHE N°05/2017/ANDA  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7235), 2, 48, 19, 61 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 601, "Modifications :  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7335), 2, 62, 34, 19 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 597, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7319), 2, 63, 17, 7 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 572, "Modifications :  - Remarques de  --> Vitre Cassé lors du déplacement à Dakhla .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7215), 2, 75, 30, 1 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 579, "Modifications :  - Fournisseur de NON DEFINI --> COD2I - Date ACHAT de  --> 30/04/2017 - Prix Unitaire de  --> 0 - Référence d'achat de  --> MARCHE N°05/2017/ANDA  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7244), 2, 22, 36, 98 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 611, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7379), 2, 77, 5, 33 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 520, "Modifications :  - Fournisseur de NON DEFINI --> ADN SYSTEM .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6964), 2, 64, 15, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 631, "Modifications :  - Catégorie de FIREWALL --> LOAD BALACER .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7463), 2, 3, 35, 90 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 461, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6647), 2, 69, 14, 76 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 466, "Modifications :  - N° Inventaire de 0000 --> 0420 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6667), 2, 17, 27, 150 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 476, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> HORS ANDA (EXT) .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6781), 2, 29, 18, 82 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 488, "Modifications :  - Collaborateur de MATERIEL ANDA --> N/A   .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6831), 2, 32, 13, 87 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 490, "Modifications :  - Emplacement de HORS ANDA --> LOCAL TECHNIQUE SECONDAIRE (ANDA/R/E4/LT2) - Etat de  --> OPR - Remarques de Perdu lors du vol de la maison de youssef el aaraj -->  .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6839), 2, 57, 7, 18 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 614, "Modifications :  - Date ACHAT de 26/09/2012 --> 03/02/2012 - Référence d'achat de BL 107-BUC-11 --> BC N°02/2011 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7391), 2, 48, 15, 121 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 628, "Modifications :  - Constructeur de NON DEFINI --> HONEYWELL .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7450), 2, 18, 13, 104 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 491, "Modifications :  - Emplacement de LOCAL TECHNIQUE SECONDAIRE --> HORS ANDA (EXT) - Etat de STK -->  - Remarques de  --> Perdu lors du vol de la maison de youssef el aaraj .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6843), 2, 72, 14, 45 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 492, "Modifications :  - Statut de NON DEFINI --> Local - Etat de STK --> EPN - Remarques de CASSER(ex karfal) --> CASSER PAR KARFAL .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6848), 2, 38, 28, 36 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 504, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6898), 2, 40, 20, 166 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 506, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6906), 2, 13, 21, 169 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 507, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6910), 2, 72, 22, 139 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 509, "Modifications :  - Référence d'achat de - --> BC N°63/2013 .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(6918), 2, 75, 10, 59 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 624, "Création de l'équipement.", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7434), 2, 62, 4, 118 });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[] { 588, "Modifications :  - Date ACHAT de  --> 01/07/2017 - Référence d'achat de  --> MARCHE N°05/2017/ANDA .", new DateTime(2020, 6, 10, 18, 45, 43, 664, DateTimeKind.Local).AddTicks(7282), 2, 75, 24, 105 });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 10, new DateTime(2020, 1, 14, 20, 35, 20, 537, DateTimeKind.Local).AddTicks(9286), 1, "distinctio", "consequatur" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 6, new DateTime(2020, 3, 20, 18, 26, 58, 419, DateTimeKind.Local).AddTicks(1606), 6, "harum", "aut" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 2, new DateTime(2020, 1, 8, 20, 16, 11, 593, DateTimeKind.Local).AddTicks(4941), 4, "quas", "accusantium" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 7, new DateTime(2019, 10, 22, 7, 31, 21, 750, DateTimeKind.Local).AddTicks(1916), 9, "et", "minima" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 5, new DateTime(2020, 4, 29, 14, 28, 35, 998, DateTimeKind.Local).AddTicks(765), 9, "deleniti", "quisquam" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 4, new DateTime(2019, 12, 5, 14, 27, 16, 542, DateTimeKind.Local).AddTicks(2184), 8, "est", "ut" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 1, new DateTime(2019, 12, 22, 16, 28, 59, 299, DateTimeKind.Local).AddTicks(6007), 8, "omnis", "impedit" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 9, new DateTime(2020, 4, 3, 21, 48, 23, 109, DateTimeKind.Local).AddTicks(3692), 1, "itaque", "non" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 3, new DateTime(2019, 11, 18, 5, 21, 44, 969, DateTimeKind.Local).AddTicks(3053), 7, "repellat", "alias" });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[] { 8, new DateTime(2020, 5, 6, 12, 42, 16, 800, DateTimeKind.Local).AddTicks(5357), 5, "adipisci", "eos" });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 3, new DateTime(2019, 12, 15, 21, 30, 43, 885, DateTimeKind.Local).AddTicks(4179), 5, 7, 9, "sit", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 9, new DateTime(2019, 8, 24, 22, 11, 37, 690, DateTimeKind.Local).AddTicks(5514), 9, 6, 9, "qui", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 10, new DateTime(2019, 6, 14, 3, 49, 53, 865, DateTimeKind.Local).AddTicks(8106), 7, 3, 9, "aut", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 2, new DateTime(2020, 2, 28, 22, 33, 3, 391, DateTimeKind.Local).AddTicks(3782), 10, 5, 10, "fugiat", false });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 8, new DateTime(2019, 11, 17, 17, 32, 56, 109, DateTimeKind.Local).AddTicks(7455), 4, 3, 10, "culpa", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 1, new DateTime(2020, 3, 23, 15, 57, 28, 6, DateTimeKind.Local).AddTicks(7459), 9, 6, 6, "eveniet", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 5, new DateTime(2020, 2, 1, 8, 53, 54, 412, DateTimeKind.Local).AddTicks(2129), 4, 10, 6, "mollitia", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 6, new DateTime(2019, 12, 24, 8, 15, 3, 20, DateTimeKind.Local).AddTicks(319), 8, 7, 3, "voluptatem", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 4, new DateTime(2019, 10, 30, 20, 23, 1, 937, DateTimeKind.Local).AddTicks(5459), 6, 3, 5, "reprehenderit", true });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[] { 7, new DateTime(2019, 8, 17, 22, 50, 58, 360, DateTimeKind.Local).AddTicks(9463), 4, 2, 7, "esse", true });

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
