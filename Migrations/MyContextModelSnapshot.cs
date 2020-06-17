﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Models;

namespace apps.Migrations
{
    [DbContext(typeof(MyContext))]
    partial class MyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Models.Affectation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAgentSi")
                        .HasColumnType("int");

                    b.Property<int>("IdCollaborateur")
                        .HasColumnType("int");

                    b.Property<int>("IdEmplacement")
                        .HasColumnType("int");

                    b.Property<int>("IdEquipement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdAgentSi");

                    b.HasIndex("IdCollaborateur");

                    b.HasIndex("IdEmplacement");

                    b.HasIndex("IdEquipement");

                    b.ToTable("Affectations");
                });

            modelBuilder.Entity("Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Ordinateur",
                            Nom = "DESKTOP"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Ordinateur",
                            Nom = "LAPTOP"
                        });
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int?>("IdReceiver")
                        .HasColumnType("int");

                    b.Property<int>("IdSender")
                        .HasColumnType("int");

                    b.Property<int>("IdTicketSupport")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Vu")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("IdReceiver");

                    b.HasIndex("IdSender");

                    b.HasIndex("IdTicketSupport");

                    b.ToTable("Chats");
                });

            modelBuilder.Entity("Models.Constucteur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Constucteurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Hewlett-Packard",
                            Nom = "HP"
                        },
                        new
                        {
                            Id = 2,
                            Description = "DELL",
                            Nom = "DELL"
                        },
                        new
                        {
                            Id = 3,
                            Description = "TOSHIBA",
                            Nom = "TOSHIBA"
                        },
                        new
                        {
                            Id = 4,
                            Description = "SHARP",
                            Nom = "SHARP"
                        },
                        new
                        {
                            Id = 5,
                            Description = "CANON",
                            Nom = "CANON"
                        },
                        new
                        {
                            Id = 6,
                            Description = "CISCO",
                            Nom = "CISCO"
                        },
                        new
                        {
                            Id = 7,
                            Description = "FORTIGATE",
                            Nom = "FORTIGATE"
                        },
                        new
                        {
                            Id = 8,
                            Description = "APPLE",
                            Nom = "APPLE"
                        },
                        new
                        {
                            Id = 9,
                            Description = "SONY",
                            Nom = "SONY"
                        },
                        new
                        {
                            Id = 10,
                            Description = "ORAY",
                            Nom = "ORAY"
                        },
                        new
                        {
                            Id = 11,
                            Description = "EPSON",
                            Nom = "EPSON"
                        },
                        new
                        {
                            Id = 12,
                            Description = "BROTHER",
                            Nom = "BROTHER"
                        },
                        new
                        {
                            Id = 13,
                            Description = "UNO",
                            Nom = "UNO"
                        },
                        new
                        {
                            Id = 14,
                            Description = "IBM",
                            Nom = "IBM"
                        },
                        new
                        {
                            Id = 15,
                            Description = "APC",
                            Nom = "APC"
                        },
                        new
                        {
                            Id = 16,
                            Description = "SAMSUNG",
                            Nom = "SAMSUNG"
                        },
                        new
                        {
                            Id = 17,
                            Description = "POLYCOM",
                            Nom = "POLYCOM"
                        },
                        new
                        {
                            Id = 18,
                            Description = "ZEBRA",
                            Nom = "ZEBRA"
                        },
                        new
                        {
                            Id = 19,
                            Description = "HONEYWELL",
                            Nom = "HONEYWELL"
                        },
                        new
                        {
                            Id = 20,
                            Description = "LG",
                            Nom = "LG"
                        });
                });

            modelBuilder.Entity("Models.Departement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Etage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Etage = "E1",
                            Nom = "DIPA-RABAT"
                        },
                        new
                        {
                            Id = 2,
                            Etage = "E4",
                            Nom = "DIPE-RABAT"
                        },
                        new
                        {
                            Id = 3,
                            Etage = "E4",
                            Nom = "DRSI-RABAT"
                        },
                        new
                        {
                            Id = 4,
                            Etage = "E4",
                            Nom = "CENTRE"
                        });
                });

            modelBuilder.Entity("Models.Emplacement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeEmplacement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdDepartement")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartement");

                    b.ToTable("Emplacements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodeEmplacement = "ANDA/R/E4/B01",
                            Description = "BUREAU DIRECTION E4",
                            IdDepartement = 2
                        },
                        new
                        {
                            Id = 2,
                            CodeEmplacement = "ANDA/R/E4/B02",
                            Description = "BUREAU ASSISTANAT DE DIRECTION",
                            IdDepartement = 2
                        },
                        new
                        {
                            Id = 3,
                            CodeEmplacement = "ANDA/R/E4/B03",
                            Description = "BUREAU ASSISTANAT TRESORIER PAYEUR",
                            IdDepartement = 3
                        },
                        new
                        {
                            Id = 4,
                            CodeEmplacement = "ANDA/R/E4/OS6",
                            Description = "PLATEAU SSI",
                            IdDepartement = 4
                        },
                        new
                        {
                            Id = 5,
                            CodeEmplacement = "ANDA/R/E4/OS4",
                            Description = "PLATEAU SAMG",
                            IdDepartement = 3
                        },
                        new
                        {
                            Id = 6,
                            CodeEmplacement = "ANDA/R/E4/OS5",
                            Description = "PLATEAU SBC",
                            IdDepartement = 1
                        },
                        new
                        {
                            Id = 7,
                            CodeEmplacement = "ANDA/R/E4/OS2",
                            Description = "PLATEAU SRH",
                            IdDepartement = 1
                        });
                });

            modelBuilder.Entity("Models.Equipement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateAchat")
                        .HasColumnType("datetime2");

                    b.Property<string>("EtatActuel")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdCategorie")
                        .HasColumnType("int");

                    b.Property<int>("IdConstucteur")
                        .HasColumnType("int");

                    b.Property<int>("IdFournisseur")
                        .HasColumnType("int");

                    b.Property<int>("IdStatut")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NInventaire")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrixUnitaireHT")
                        .HasColumnType("int");

                    b.Property<string>("RefAchat")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarques")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCategorie");

                    b.HasIndex("IdConstucteur");

                    b.HasIndex("IdFournisseur");

                    b.HasIndex("IdStatut");

                    b.ToTable("Equipements");
                });

            modelBuilder.Entity("Models.EquipementInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("InfoSystemeHtml")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NSerie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SoftwareHtml")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EquipementInfos");
                });

            modelBuilder.Entity("Models.Fonction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fonctions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nom = "ASSISTANCE"
                        },
                        new
                        {
                            Id = 2,
                            Nom = "ASSISTANT"
                        },
                        new
                        {
                            Id = 3,
                            Nom = "ASSISTANTE"
                        },
                        new
                        {
                            Id = 4,
                            Nom = "CADRE"
                        },
                        new
                        {
                            Id = 5,
                            Nom = "CHAUFFEUR"
                        },
                        new
                        {
                            Id = 6,
                            Nom = "CHEF DE DEPARTEMENT"
                        },
                        new
                        {
                            Id = 7,
                            Nom = "CHEF DE SERVICE"
                        },
                        new
                        {
                            Id = 8,
                            Nom = "DIRECTRICE"
                        },
                        new
                        {
                            Id = 9,
                            Nom = "Trésorier "
                        },
                        new
                        {
                            Id = 10,
                            Nom = "VIRTUAL"
                        });
                });

            modelBuilder.Entity("Models.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Fax")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Tel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Fournisseurs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "email1@angular.io",
                            Fax = "null",
                            Nom = "BUCLINTEC",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 2,
                            Email = "email2@angular.io",
                            Fax = "null",
                            Nom = "PC MEMORIA",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 3,
                            Email = "email3@angular.io",
                            Fax = "null",
                            Nom = "BESTMARK",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 4,
                            Email = "email4@angular.io",
                            Fax = "null",
                            Nom = "COD2I",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 5,
                            Email = "email5@angular.io",
                            Fax = "null",
                            Nom = "REPER",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 6,
                            Email = "email6@angular.io",
                            Fax = "null",
                            Nom = "UFP MAROC",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 7,
                            Email = "email7@angular.io",
                            Fax = "null",
                            Nom = "ADN SYSTEM",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 8,
                            Email = "email8@angular.io",
                            Fax = "null",
                            Nom = "ETCE INFO",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 9,
                            Email = "email9@angular.io",
                            Fax = "null",
                            Nom = "CBI",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 10,
                            Email = "email10@angular.io",
                            Fax = "null",
                            Nom = "ALPHA BUREAU",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 11,
                            Email = "email11@angular.io",
                            Fax = "null",
                            Nom = "PLANET TV SAT",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 12,
                            Email = "email12@angular.io",
                            Fax = "null",
                            Nom = "LATCO",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 13,
                            Email = "email13@angular.io",
                            Fax = "null",
                            Nom = "SESA",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 14,
                            Email = "email14@angular.io",
                            Fax = "null",
                            Nom = "TOP INVEST RYAD",
                            Tel = "null"
                        },
                        new
                        {
                            Id = 15,
                            Email = "email15@angular.io",
                            Fax = "null",
                            Nom = "SHOP BUSINESS AND TECHNOLOGIE",
                            Tel = "null"
                        });
                });

            modelBuilder.Entity("Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "agentSi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "user"
                        });
                });

            modelBuilder.Entity("Models.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("IdDepartement")
                        .HasColumnType("int");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdDepartement");

                    b.ToTable("Services");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            IdDepartement = 1,
                            Nom = "ANDA"
                        },
                        new
                        {
                            Id = 2,
                            IdDepartement = 2,
                            Nom = "DG/"
                        },
                        new
                        {
                            Id = 3,
                            IdDepartement = 3,
                            Nom = "DIPA/"
                        },
                        new
                        {
                            Id = 4,
                            IdDepartement = 4,
                            Nom = "DIPE/"
                        });
                });

            modelBuilder.Entity("Models.Statut", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Statuts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "null",
                            Nom = "Déplacement "
                        },
                        new
                        {
                            Id = 2,
                            Description = "null",
                            Nom = "Local"
                        });
                });

            modelBuilder.Entity("Models.TicketSupport", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreation")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdCollaborateur")
                        .HasColumnType("int");

                    b.Property<bool>("IsClosed")
                        .HasColumnType("bit");

                    b.Property<string>("Priorite")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Question")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdCollaborateur");

                    b.ToTable("TicketSupports");
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodeOfVerification")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("EmailVerified")
                        .HasColumnType("bit");

                    b.Property<int?>("IdFonction")
                        .HasColumnType("int");

                    b.Property<int>("IdRole")
                        .HasColumnType("int");

                    b.Property<int?>("IdService")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Matricule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.HasIndex("IdFonction");

                    b.HasIndex("IdRole");

                    b.HasIndex("IdService");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CodeOfVerification = "",
                            Email = "admin@hotmail.com",
                            EmailVerified = true,
                            IdFonction = 7,
                            IdRole = 1,
                            IdService = 1,
                            IsActive = true,
                            Matricule = "730533",
                            Nom = "Mourabit",
                            Password = "123",
                            Prenom = "mohamed"
                        },
                        new
                        {
                            Id = 2,
                            CodeOfVerification = "",
                            Email = "agentSI@angular.io",
                            EmailVerified = true,
                            IdFonction = 1,
                            IdRole = 2,
                            IdService = 2,
                            IsActive = true,
                            Matricule = "1042706",
                            Nom = "Hicham",
                            Password = "123",
                            Prenom = "Amakhlouf"
                        },
                        new
                        {
                            Id = 3,
                            CodeOfVerification = "",
                            Email = "user@angular.io",
                            EmailVerified = true,
                            IdFonction = 5,
                            IdRole = 2,
                            IdService = 3,
                            IsActive = true,
                            Matricule = "1059644",
                            Nom = "mehdi",
                            Password = "123",
                            Prenom = "tamika"
                        });
                });

            modelBuilder.Entity("Models.Affectation", b =>
                {
                    b.HasOne("Models.User", "AgentSi")
                        .WithMany("AgentSiAffectations")
                        .HasForeignKey("IdAgentSi")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.User", "Collaborateur")
                        .WithMany("CollaborateurAffectations")
                        .HasForeignKey("IdCollaborateur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Emplacement", "Emplacement")
                        .WithMany("EmplacementAffectations")
                        .HasForeignKey("IdEmplacement")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Equipement", "Equipement")
                        .WithMany("EquipementAffectations")
                        .HasForeignKey("IdEquipement")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Chat", b =>
                {
                    b.HasOne("Models.User", "Receiver")
                        .WithMany("ReceiverChats")
                        .HasForeignKey("IdReceiver")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Models.User", "Sender")
                        .WithMany("SenderChats")
                        .HasForeignKey("IdSender")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.TicketSupport", "TicketSupport")
                        .WithMany("TicketSupportChats")
                        .HasForeignKey("IdTicketSupport")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Emplacement", b =>
                {
                    b.HasOne("Models.Departement", "Departement")
                        .WithMany("DepartementEmplacements")
                        .HasForeignKey("IdDepartement")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Equipement", b =>
                {
                    b.HasOne("Models.Categorie", "Categorie")
                        .WithMany("CategorieEquipements")
                        .HasForeignKey("IdCategorie")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Constucteur", "Constucteur")
                        .WithMany("ConstucteurEquipements")
                        .HasForeignKey("IdConstucteur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Fournisseur", "Fournisseur")
                        .WithMany("FournisseurEquipements")
                        .HasForeignKey("IdFournisseur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Statut", "Statut")
                        .WithMany("StatutEquipements")
                        .HasForeignKey("IdStatut")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.Service", b =>
                {
                    b.HasOne("Models.Departement", "Departement")
                        .WithMany("DepartementServices")
                        .HasForeignKey("IdDepartement")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.TicketSupport", b =>
                {
                    b.HasOne("Models.User", "Collaborateur")
                        .WithMany("CollaborateurTicketSupports")
                        .HasForeignKey("IdCollaborateur")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();
                });

            modelBuilder.Entity("Models.User", b =>
                {
                    b.HasOne("Models.Fonction", "Fonction")
                        .WithMany("FonctionCollaborateurs")
                        .HasForeignKey("IdFonction")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Models.Role", "Role")
                        .WithMany("RoleUsers")
                        .HasForeignKey("IdRole")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("Models.Service", "Service")
                        .WithMany("ServiceCollaborateurs")
                        .HasForeignKey("IdService")
                        .OnDelete(DeleteBehavior.NoAction);
                });
#pragma warning restore 612, 618
        }
    }
}
