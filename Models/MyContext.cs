using Microsoft.EntityFrameworkCore;

namespace Models
{
    public partial class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options) { }

        public virtual DbSet<Fonction> Fonctions { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<TicketSupport> TicketSupports { get; set; }
        public virtual DbSet<Chat> Chats { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Affectation> Affectations { get; set; }
        public virtual DbSet<Equipement> Equipements { get; set; }
        public virtual DbSet<EquipementInfo> EquipementInfos { get; set; }
        public virtual DbSet<Emplacement> Emplacements { get; set; }
        public virtual DbSet<Fournisseur> Fournisseurs { get; set; }
        public virtual DbSet<Categorie> Categories { get; set; }
        public virtual DbSet<Statut> Statuts { get; set; }
        public virtual DbSet<Constucteur> Constucteurs { get; set; }
        public virtual DbSet<Departement> Departements { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Fonction>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.HasMany(d => d.FonctionCollaborateurs).WithOne(p => p.Fonction).HasForeignKey(d => d.IdFonction).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.IdDepartement);
                entity.HasOne(d => d.Departement).WithMany(p => p.DepartementServices).HasForeignKey(d => d.IdDepartement);
                entity.HasMany(d => d.ServiceCollaborateurs).WithOne(p => p.Service).HasForeignKey(d => d.IdService).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<TicketSupport>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Question);
                entity.Property(e => e.DateCreation);
                entity.Property(e => e.Priorite);
                entity.Property(e => e.IsClosed);
                entity.Property(e => e.IdCollaborateur);
                entity.HasOne(d => d.Collaborateur).WithMany(p => p.CollaborateurTicketSupports).HasForeignKey(d => d.IdCollaborateur);
                entity.HasMany(d => d.TicketSupportChats).WithOne(p => p.TicketSupport).HasForeignKey(d => d.IdTicketSupport).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Chat>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.IdSender);
                entity.Property(e => e.IdReceiver);
                entity.Property(e => e.Message);
                entity.Property(e => e.Vu);
                entity.Property(e => e.Date);
                entity.Property(e => e.IdTicketSupport);
                entity.HasOne(d => d.TicketSupport).WithMany(p => p.TicketSupportChats).HasForeignKey(d => d.IdTicketSupport);
                entity.HasOne(d => d.Sender).WithMany(p => p.SenderChats).HasForeignKey(d => d.IdSender);
                entity.HasOne(d => d.Receiver).WithMany(p => p.ReceiverChats).HasForeignKey(d => d.IdReceiver);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Name);
                entity.HasMany(d => d.RoleUsers).WithOne(p => p.Role).HasForeignKey(d => d.IdRole).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Matricule);
                entity.Property(e => e.Prenom);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.Property(e => e.Password);
                entity.Property(e => e.CodeOfVerification);
                entity.Property(e => e.EmailVerified);
                entity.Property(e => e.IsActive);
                entity.Property(e => e.IdService);
                entity.Property(e => e.IdFonction);
                entity.Property(e => e.IdRole);
                entity.HasOne(d => d.Role).WithMany(p => p.RoleUsers).HasForeignKey(d => d.IdRole);
                entity.HasOne(d => d.Service).WithMany(p => p.ServiceCollaborateurs).HasForeignKey(d => d.IdService);
                entity.HasOne(d => d.Fonction).WithMany(p => p.FonctionCollaborateurs).HasForeignKey(d => d.IdFonction);
                entity.HasMany(d => d.AgentSiAffectations).WithOne(p => p.AgentSi).HasForeignKey(d => d.IdAgentSi).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.CollaborateurAffectations).WithOne(p => p.Collaborateur).HasForeignKey(d => d.IdCollaborateur).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.CollaborateurTicketSupports).WithOne(p => p.Collaborateur).HasForeignKey(d => d.IdCollaborateur).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.SenderChats).WithOne(p => p.Sender).HasForeignKey(d => d.IdSender).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.ReceiverChats).WithOne(p => p.Receiver).HasForeignKey(d => d.IdReceiver).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Affectation>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Action);
                entity.Property(e => e.Date);
                entity.Property(e => e.IdEquipement);
                entity.Property(e => e.IdEmplacement);
                entity.Property(e => e.IdCollaborateur);
                entity.Property(e => e.IdAgentSi);
                entity.HasOne(d => d.Equipement).WithMany(p => p.EquipementAffectations).HasForeignKey(d => d.IdEquipement);
                entity.HasOne(d => d.Emplacement).WithMany(p => p.EmplacementAffectations).HasForeignKey(d => d.IdEmplacement);
                entity.HasOne(d => d.Collaborateur).WithMany(p => p.CollaborateurAffectations).HasForeignKey(d => d.IdCollaborateur);
                entity.HasOne(d => d.AgentSi).WithMany(p => p.AgentSiAffectations).HasForeignKey(d => d.IdAgentSi);
            });

            modelBuilder.Entity<Equipement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NSerie);
                entity.Property(e => e.Model);
                entity.Property(e => e.DateAchat);
                entity.Property(e => e.RefAchat);
                entity.Property(e => e.EtatActuel);
                entity.Property(e => e.PrixUnitaireHT);
                entity.Property(e => e.NInventaire);
                entity.Property(e => e.Remarques);
                entity.Property(e => e.IdConstucteur);
                entity.Property(e => e.IdCategorie);
                entity.Property(e => e.IdStatut);
                entity.Property(e => e.IdFournisseur);
                entity.HasOne(d => d.Constucteur).WithMany(p => p.ConstucteurEquipements).HasForeignKey(d => d.IdConstucteur);
                entity.HasOne(d => d.Categorie).WithMany(p => p.CategorieEquipements).HasForeignKey(d => d.IdCategorie);
                entity.HasOne(d => d.Fournisseur).WithMany(p => p.FournisseurEquipements).HasForeignKey(d => d.IdFournisseur);
                entity.HasOne(d => d.Statut).WithMany(p => p.StatutEquipements).HasForeignKey(d => d.IdStatut);
                entity.HasMany(d => d.EquipementAffectations).WithOne(p => p.Equipement).HasForeignKey(d => d.IdEquipement).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<EquipementInfo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.NSerie);
                entity.Property(e => e.Date);
                entity.Property(e => e.InfoSystemeHtml);
                entity.Property(e => e.SoftwareHtml);
            });

            modelBuilder.Entity<Emplacement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.CodeEmplacement);
                entity.Property(e => e.Description);
                entity.Property(e => e.IdDepartement);
                entity.HasOne(d => d.Departement).WithMany(p => p.DepartementEmplacements).HasForeignKey(d => d.IdDepartement);
                entity.HasMany(d => d.EmplacementAffectations).WithOne(p => p.Emplacement).HasForeignKey(d => d.IdEmplacement).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Fournisseur>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Tel);
                entity.Property(e => e.Fax);
                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasMany(d => d.FournisseurEquipements).WithOne(p => p.Fournisseur).HasForeignKey(d => d.IdFournisseur).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Categorie>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Description);
                entity.HasMany(d => d.CategorieEquipements).WithOne(p => p.Categorie).HasForeignKey(d => d.IdCategorie).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Statut>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Description);
                entity.HasMany(d => d.StatutEquipements).WithOne(p => p.Statut).HasForeignKey(d => d.IdStatut).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Constucteur>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Description);
                entity.HasMany(d => d.ConstucteurEquipements).WithOne(p => p.Constucteur).HasForeignKey(d => d.IdConstucteur).OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<Departement>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Id).ValueGeneratedOnAdd();
                entity.Property(e => e.Nom);
                entity.Property(e => e.Etage);
                entity.HasMany(d => d.DepartementEmplacements).WithOne(p => p.Departement).HasForeignKey(d => d.IdDepartement).OnDelete(DeleteBehavior.NoAction);
                entity.HasMany(d => d.DepartementServices).WithOne(p => p.Departement).HasForeignKey(d => d.IdDepartement).OnDelete(DeleteBehavior.NoAction);
            });




            modelBuilder
                .Departements()
.Constucteurs()
.Statuts()
.Categories()
.Fournisseurs()
.EquipementInfos()
.Roles()
.Fonctions()
.Services()
.TicketSupports()
.Chats()
.Users()
.Affectations()
.Equipements()
.Emplacements()

                ;
        }


        // partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
