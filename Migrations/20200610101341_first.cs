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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                        .Annotation("SqlServer:Identity", "1, 1"),
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
                values: new object[,]
                {
                    { 1, "consequuntur", "consequatur" },
                    { 2, "provident", "consequatur" },
                    { 3, "dolorum", "perspiciatis" },
                    { 4, "necessitatibus", "ut" },
                    { 5, "aut", "vero" },
                    { 6, "et", "aliquam" },
                    { 7, "dolor", "numquam" },
                    { 8, "error", "accusamus" },
                    { 9, "neque", "cupiditate" },
                    { 10, "aliquid", "omnis" }
                });

            migrationBuilder.InsertData(
                table: "Constucteurs",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { 10, "ut", "sed" },
                    { 9, "aut", "laborum" },
                    { 8, "praesentium", "quos" },
                    { 6, "qui", "sunt" },
                    { 7, "est", "exercitationem" },
                    { 4, "veniam", "expedita" },
                    { 3, "est", "hic" },
                    { 2, "recusandae", "sunt" },
                    { 1, "iure", "rerum" },
                    { 5, "nam", "quis" }
                });

            migrationBuilder.InsertData(
                table: "Departements",
                columns: new[] { "Id", "Etage", "Nom" },
                values: new object[,]
                {
                    { 10, "vel", "soluta" },
                    { 9, "placeat", "est" },
                    { 8, "accusamus", "sunt" },
                    { 7, "ut", "et" },
                    { 6, "error", "sit" },
                    { 5, "quidem", "velit" },
                    { 3, "voluptatem", "quis" },
                    { 2, "sint", "inventore" },
                    { 1, "qui", "ea" },
                    { 4, "aspernatur", "voluptate" }
                });

            migrationBuilder.InsertData(
                table: "EquipementInfos",
                columns: new[] { "Id", "Date", "NSerie", "StringInfo" },
                values: new object[,]
                {
                    { 7, new DateTime(2020, 1, 24, 19, 51, 3, 124, DateTimeKind.Local).AddTicks(2092), "et", "qui" },
                    { 9, new DateTime(2019, 10, 8, 10, 56, 30, 906, DateTimeKind.Local).AddTicks(1261), "et", "tempora" },
                    { 8, new DateTime(2019, 8, 5, 22, 34, 15, 485, DateTimeKind.Local).AddTicks(5052), "placeat", "sed" },
                    { 6, new DateTime(2020, 2, 27, 10, 36, 4, 175, DateTimeKind.Local).AddTicks(8588), "eveniet", "ducimus" },
                    { 10, new DateTime(2020, 3, 17, 23, 18, 46, 318, DateTimeKind.Local).AddTicks(9420), "consequatur", "molestiae" },
                    { 4, new DateTime(2020, 4, 1, 2, 11, 42, 930, DateTimeKind.Local).AddTicks(406), "omnis", "cupiditate" },
                    { 3, new DateTime(2020, 2, 22, 22, 55, 28, 352, DateTimeKind.Local).AddTicks(3371), "ut", "sed" },
                    { 2, new DateTime(2019, 9, 1, 11, 55, 27, 964, DateTimeKind.Local).AddTicks(5661), "omnis", "voluptas" },
                    { 1, new DateTime(2019, 8, 24, 6, 6, 0, 394, DateTimeKind.Local).AddTicks(4115), "consequatur", "dolores" },
                    { 5, new DateTime(2019, 7, 19, 15, 53, 32, 444, DateTimeKind.Local).AddTicks(8254), "recusandae", "et" }
                });

            migrationBuilder.InsertData(
                table: "Fonctions",
                columns: new[] { "Id", "Nom" },
                values: new object[,]
                {
                    { 10, "et" },
                    { 9, "dolores" },
                    { 8, "recusandae" },
                    { 7, "rerum" },
                    { 6, "consequuntur" },
                    { 5, "fugiat" },
                    { 4, "ratione" },
                    { 3, "ea" },
                    { 2, "est" },
                    { 1, "omnis" }
                });

            migrationBuilder.InsertData(
                table: "Fournisseurs",
                columns: new[] { "Id", "Email", "Fax", "Nom", "Tel" },
                values: new object[,]
                {
                    { 9, "Kylian65@hotmail.fr", "asperiores", "in", "temporibus" },
                    { 10, "Noa.Adam0@hotmail.fr", "non", "in", "dolorem" },
                    { 7, "Jules19@gmail.com", "error", "tempora", "voluptas" },
                    { 6, "Mathis.Fabre@yahoo.fr", "consequatur", "doloribus", "laboriosam" },
                    { 8, "Lucas.Garcia21@hotmail.fr", "sit", "exercitationem", "autem" },
                    { 4, "Nathan_Rolland2@yahoo.fr", "error", "omnis", "sit" },
                    { 3, "Charlotte86@yahoo.fr", "recusandae", "quos", "labore" },
                    { 2, "Anais_Leroux@yahoo.fr", "quae", "rem", "dolorem" },
                    { 1, "dj-m2x@hotmail.com", "dolores", "voluptatem", "velit" },
                    { 5, "Ines95@yahoo.fr", "quos", "illum", "non" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 10, "accusantium" },
                    { 9, "et" },
                    { 7, "sit" },
                    { 6, "fugit" },
                    { 8, "distinctio" },
                    { 4, "perferendis" },
                    { 3, "natus" },
                    { 2, "nisi" },
                    { 1, "inventore" },
                    { 5, "quis" }
                });

            migrationBuilder.InsertData(
                table: "Statuts",
                columns: new[] { "Id", "Description", "Nom" },
                values: new object[,]
                {
                    { 9, "quia", "sunt" },
                    { 1, "beatae", "earum" },
                    { 2, "velit", "eos" },
                    { 3, "animi", "vel" },
                    { 4, "dolore", "qui" },
                    { 5, "illum", "ratione" },
                    { 6, "quae", "et" },
                    { 7, "est", "et" },
                    { 8, "sit", "sunt" },
                    { 10, "animi", "error" }
                });

            migrationBuilder.InsertData(
                table: "Emplacements",
                columns: new[] { "Id", "CodeEmplacement", "Description", "IdDepartement" },
                values: new object[,]
                {
                    { 7, "sint", "totam", 5 },
                    { 2, "non", "animi", 2 },
                    { 8, "qui", "labore", 10 },
                    { 5, "corporis", "natus", 3 },
                    { 9, "unde", "alias", 3 },
                    { 3, "a", "ratione", 5 },
                    { 10, "quia", "laudantium", 10 },
                    { 1, "velit", "dolorem", 6 },
                    { 4, "quo", "id", 6 },
                    { 6, "non", "aspernatur", 9 }
                });

            migrationBuilder.InsertData(
                table: "Equipements",
                columns: new[] { "Id", "DateAchat", "EtatActuel", "IdCategorie", "IdConstucteur", "IdFournisseur", "IdStatut", "Model", "NInventaire", "NSerie", "PrixUnitaireHT", "RefAchat", "Remarques" },
                values: new object[,]
                {
                    { 3, new DateTime(2019, 7, 16, 0, 27, 52, 8, DateTimeKind.Local).AddTicks(9441), "dolorem", 1, 7, 8, 3, "autem", "dolorem", "aliquid", 9, "sed", "suscipit" },
                    { 10, new DateTime(2020, 1, 22, 20, 24, 26, 416, DateTimeKind.Local).AddTicks(5425), "magnam", 10, 5, 5, 3, "sit", "vel", "sit", 1, "non", "ea" },
                    { 4, new DateTime(2019, 8, 21, 19, 10, 40, 901, DateTimeKind.Local).AddTicks(9889), "eveniet", 10, 8, 4, 8, "consequatur", "voluptatem", "sequi", 4, "quaerat", "voluptas" },
                    { 6, new DateTime(2020, 2, 18, 11, 28, 41, 825, DateTimeKind.Local).AddTicks(183), "ut", 6, 9, 3, 8, "at", "minus", "recusandae", 10, "qui", "quod" },
                    { 9, new DateTime(2019, 11, 13, 2, 19, 22, 652, DateTimeKind.Local).AddTicks(7151), "ipsum", 1, 9, 1, 4, "odio", "rem", "sunt", 1, "eum", "deserunt" },
                    { 7, new DateTime(2019, 9, 7, 7, 29, 36, 322, DateTimeKind.Local).AddTicks(4616), "tenetur", 6, 6, 4, 5, "omnis", "reprehenderit", "maiores", 9, "eligendi", "qui" },
                    { 5, new DateTime(2020, 2, 14, 12, 42, 38, 192, DateTimeKind.Local).AddTicks(6639), "fugiat", 7, 9, 10, 6, "molestias", "debitis", "magni", 1, "ut", "suscipit" },
                    { 2, new DateTime(2020, 2, 28, 12, 37, 16, 838, DateTimeKind.Local).AddTicks(5727), "ab", 3, 1, 2, 8, "quia", "eaque", "et", 8, "eos", "et" },
                    { 8, new DateTime(2019, 12, 8, 22, 27, 43, 16, DateTimeKind.Local).AddTicks(7297), "sit", 9, 3, 1, 4, "illum", "recusandae", "unde", 10, "similique", "excepturi" },
                    { 1, new DateTime(2019, 8, 30, 1, 36, 38, 138, DateTimeKind.Local).AddTicks(4754), "suscipit", 5, 7, 4, 3, "non", "iure", "omnis", 9, "debitis", "dolores" }
                });

            migrationBuilder.InsertData(
                table: "Services",
                columns: new[] { "Id", "IdDepartement", "Nom" },
                values: new object[,]
                {
                    { 2, 9, "consequatur" },
                    { 8, 9, "porro" },
                    { 6, 9, "ut" },
                    { 4, 6, "hic" },
                    { 10, 4, "id" },
                    { 1, 3, "vitae" },
                    { 7, 2, "et" },
                    { 5, 2, "molestiae" },
                    { 9, 10, "sapiente" },
                    { 3, 1, "laborum" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "CodeOfVerification", "Email", "EmailVerified", "IdFonction", "IdRole", "IdService", "IsActive", "Matricule", "Nom", "Password", "Prenom" },
                values: new object[,]
                {
                    { 3, "sed", "Maelys.Meyer69@hotmail.fr", false, 9, 10, 3, false, "aut", "fugit", "123", "nam" },
                    { 7, "omnis", "Rayan7@gmail.com", false, 8, 10, 3, false, "voluptatem", "aut", "123", "aut" },
                    { 9, "nisi", "Julie_Gautier35@yahoo.fr", true, 7, 6, 1, true, "eaque", "corrupti", "123", "consequatur" },
                    { 1, "ut", "dj-m2x@hotmail.com", true, 9, 8, 10, true, "minima", "possimus", "123", "nemo" },
                    { 4, "repellendus", "Louna14@yahoo.fr", false, 6, 7, 4, true, "corrupti", "officia", "123", "at" },
                    { 8, "aliquid", "Marie.Renault@gmail.com", false, 5, 6, 4, false, "est", "aliquam", "123", "ut" },
                    { 10, "blanditiis", "Quentin_Picard1@yahoo.fr", true, 10, 2, 4, true, "pariatur", "quibusdam", "123", "quia" },
                    { 6, "omnis", "Victor87@yahoo.fr", true, 10, 9, 2, true, "ullam", "optio", "123", "voluptas" },
                    { 2, "dolorem", "Melissa10@gmail.com", true, 1, 4, 8, true, "sit", "cum", "123", "vel" },
                    { 5, "ut", "Zoe63@gmail.com", true, 7, 4, 9, true, "eaque", "dignissimos", "123", "dolor" }
                });

            migrationBuilder.InsertData(
                table: "Affectations",
                columns: new[] { "Id", "Action", "Date", "IdAgentSi", "IdCollaborateur", "IdEmplacement", "IdEquipement" },
                values: new object[,]
                {
                    { 7, "sed", new DateTime(2020, 1, 17, 19, 26, 29, 145, DateTimeKind.Local).AddTicks(7538), 10, 3, 9, 1 },
                    { 5, "earum", new DateTime(2019, 10, 26, 4, 38, 43, 699, DateTimeKind.Local).AddTicks(4150), 7, 2, 10, 2 },
                    { 6, "ut", new DateTime(2020, 1, 31, 9, 6, 5, 311, DateTimeKind.Local).AddTicks(1065), 4, 3, 2, 10 },
                    { 3, "sit", new DateTime(2019, 7, 8, 9, 36, 42, 609, DateTimeKind.Local).AddTicks(4024), 9, 8, 5, 8 },
                    { 4, "earum", new DateTime(2019, 11, 20, 5, 1, 10, 88, DateTimeKind.Local).AddTicks(2079), 2, 10, 8, 8 },
                    { 2, "cupiditate", new DateTime(2019, 7, 11, 2, 6, 56, 120, DateTimeKind.Local).AddTicks(5079), 4, 2, 4, 6 },
                    { 8, "nobis", new DateTime(2020, 4, 21, 10, 58, 24, 617, DateTimeKind.Local).AddTicks(3477), 10, 6, 3, 1 },
                    { 1, "odit", new DateTime(2020, 5, 17, 6, 36, 49, 933, DateTimeKind.Local).AddTicks(9324), 8, 6, 7, 10 },
                    { 9, "ad", new DateTime(2019, 6, 10, 16, 54, 55, 807, DateTimeKind.Local).AddTicks(2270), 5, 5, 6, 3 },
                    { 10, "quis", new DateTime(2020, 1, 27, 4, 38, 20, 164, DateTimeKind.Local).AddTicks(8520), 10, 8, 9, 2 }
                });

            migrationBuilder.InsertData(
                table: "TicketSupports",
                columns: new[] { "Id", "DateCreation", "IdCollaborateur", "Priorite", "Question" },
                values: new object[,]
                {
                    { 7, new DateTime(2019, 7, 19, 13, 50, 58, 28, DateTimeKind.Local).AddTicks(8542), 2, "dolorum", "corrupti" },
                    { 3, new DateTime(2019, 12, 10, 22, 9, 33, 933, DateTimeKind.Local).AddTicks(2179), 3, "doloremque", "cumque" },
                    { 8, new DateTime(2019, 6, 15, 14, 1, 0, 624, DateTimeKind.Local).AddTicks(4214), 8, "dolorem", "molestiae" },
                    { 6, new DateTime(2019, 9, 15, 5, 4, 53, 93, DateTimeKind.Local).AddTicks(7896), 8, "id", "neque" },
                    { 4, new DateTime(2020, 4, 10, 18, 52, 55, 421, DateTimeKind.Local).AddTicks(6327), 8, "voluptas", "accusamus" },
                    { 2, new DateTime(2019, 9, 24, 11, 24, 6, 435, DateTimeKind.Local).AddTicks(3027), 8, "reprehenderit", "et" },
                    { 1, new DateTime(2019, 10, 26, 15, 29, 16, 432, DateTimeKind.Local).AddTicks(3138), 9, "facilis", "error" },
                    { 5, new DateTime(2019, 9, 12, 3, 48, 50, 244, DateTimeKind.Local).AddTicks(5451), 3, "ea", "provident" },
                    { 10, new DateTime(2019, 6, 21, 6, 10, 26, 532, DateTimeKind.Local).AddTicks(5349), 10, "sed", "rerum" },
                    { 9, new DateTime(2020, 4, 6, 0, 12, 47, 298, DateTimeKind.Local).AddTicks(6872), 5, "et", "voluptas" }
                });

            migrationBuilder.InsertData(
                table: "Chats",
                columns: new[] { "Id", "Date", "IdReceiver", "IdSender", "IdTicketSupport", "Message", "Vu" },
                values: new object[,]
                {
                    { 4, new DateTime(2020, 3, 20, 12, 52, 1, 491, DateTimeKind.Local).AddTicks(8855), 4, 10, 3, "est", true },
                    { 1, new DateTime(2020, 1, 6, 10, 28, 52, 807, DateTimeKind.Local).AddTicks(7849), 3, 7, 1, "saepe", true },
                    { 10, new DateTime(2020, 4, 6, 5, 49, 59, 315, DateTimeKind.Local).AddTicks(2145), 9, 5, 1, "dignissimos", false },
                    { 8, new DateTime(2019, 6, 29, 17, 58, 33, 845, DateTimeKind.Local).AddTicks(5314), 9, 8, 2, "deleniti", false },
                    { 2, new DateTime(2019, 6, 29, 6, 50, 0, 831, DateTimeKind.Local).AddTicks(2007), 10, 3, 4, "ut", true },
                    { 6, new DateTime(2019, 12, 9, 10, 52, 51, 950, DateTimeKind.Local).AddTicks(2196), 2, 4, 6, "error", false },
                    { 5, new DateTime(2019, 10, 1, 15, 0, 4, 779, DateTimeKind.Local).AddTicks(39), 4, 8, 7, "enim", false },
                    { 9, new DateTime(2019, 9, 29, 14, 54, 27, 529, DateTimeKind.Local).AddTicks(5038), 1, 10, 7, "libero", false },
                    { 3, new DateTime(2019, 8, 11, 12, 52, 30, 591, DateTimeKind.Local).AddTicks(7848), 6, 3, 9, "autem", true },
                    { 7, new DateTime(2020, 3, 13, 3, 29, 42, 20, DateTimeKind.Local).AddTicks(6063), 9, 10, 9, "enim", false }
                });

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
                unique: true,
                filter: "[Email] IS NOT NULL");

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
                unique: true,
                filter: "[Email] IS NOT NULL");

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
