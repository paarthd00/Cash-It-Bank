using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using WebApplication1.ViewModels;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public class ClientAccount
        {
            [Key]
            public int clientID { get; set; }
            public int accountNum { get; set; }
            public virtual Client? Client { get; set; }
            public virtual BankAccount? BankAccount { get; set; }
        }
        public class Client
        {
            [Key]
            public int clientID { get; set; }
            public string? lastName { get; set; }
            public string? firstName { get; set; }
            public string? email { get; set; }
            public virtual ICollection<ClientAccount> ClientAccounts { get; set; } = new List<ClientAccount>();
        }
        public class BankAccount
        {
            [Key]
            public int accountNum { get; set; }
            public string? accountType { get; set; }
            public float? balance { get; set; }
            public virtual ICollection<ClientAccount> ClientsAccount { get; set; } = new List<ClientAccount>();
        }
        public class MyRegisteredUser
        {
            [Key]
            [Required]
            public string Email { get; set; }

            [Display(Name = "First Name")]
            [Required]
            public string FirstName { get; set; }

            [Display(Name = "Last Name")]
            [Required]
            public string LastName { get; set; }

        }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MyRegisteredUser> MyRegisteredUsers { get; set; }
        public DbSet<WebApplication1.ViewModels.RoleVM> RoleVM { get; set; } = default!;
        public DbSet<WebApplication1.ViewModels.UserVM> UserVM { get; set; } = default!;
        public DbSet<WebApplication1.ViewModels.UserRoleVM> UserRoleVM { get; set; } = default!;
        public DbSet<ClientAccount> ClientsAccount { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Client>()
                .HasKey(c => c.clientID);

            modelBuilder.Entity<BankAccount>()
                .HasKey(b => b.accountNum);

            modelBuilder.Entity<ClientAccount>()
                .HasKey(ca => new { ca.clientID, ca.accountNum });

            modelBuilder.Entity<ClientAccount>()
                .HasOne(c => c.Client)
                .WithMany(ca => ca.ClientAccounts)
                .HasForeignKey(fk => new { fk.clientID });

            modelBuilder.Entity<ClientAccount>()
                .HasOne(b => b.BankAccount)
                .WithMany(ca => ca.ClientsAccount)
                .HasForeignKey(fk => new { fk.accountNum })
                .OnDelete(DeleteBehavior.Restrict);
        }

    }
}