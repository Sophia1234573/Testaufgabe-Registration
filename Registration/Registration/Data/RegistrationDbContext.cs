using Microsoft.EntityFrameworkCore;
using Registration.Models.Domain;

namespace Registration.Data
{
    public class RegistrationDbContext: DbContext
    {
        public RegistrationDbContext(DbContextOptions<RegistrationDbContext> dbContextOptions) : base(dbContextOptions)
        {
        }

        public DbSet<Branch> Branches { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed data for Branches

            var branches = new List<Branch>()
            {
                new Branch()
                {
                    Id = Guid.Parse("6B13FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Automobilzulieferindustrie",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Elektroindustrie",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B05FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Ernährungsindustrie",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B25FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Kreativ- und Designwirtschaft",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B19FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Luft- und Raumfahrtindustrie",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B39FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Maritime Industrie",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B15FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Maschinenbau und Metallverarbeitung",
                },
                new Branch()
                {
                    Id = Guid.Parse("6B17FC40-CA47-1067-B31D-00DD010662DA"),
                    Name = "Windenergieindustrie",
                },

            };

            modelBuilder.Entity<Branch>().HasData(branches);

            // Seed data for Companies

            var companies = new List<Company>()
            {
                new Company()
                {
                    Id = Guid.Parse("a0481244-7096-452c-8a26-1dd46d3ebe06"),
                    Name = "CompanyName1",
                    BranchId = Guid.Parse("6B13FC40-CA47-1067-B31D-00DD010662DA")
                },
                new Company()
                {
                    Id = Guid.Parse("a8ba4c30-7513-41eb-854b-7325b5efd316"),
                    Name = "CompanyName2",
                    BranchId = Guid.Parse("6B29FC40-CA47-1067-B31D-00DD010662DA")
                },
                new Company()
                {
                    Id = Guid.Parse("dc68dd36-3724-4499-9275-5cd0d57071c2"),
                    Name = "CompanyName3",
                    BranchId = Guid.Parse("6B05FC40-CA47-1067-B31D-00DD010662DA")
                },
            };

            modelBuilder.Entity<Company>().HasData(companies);

            //Seed data for Users

            var users = new List<User>()
            {
                new User()
                {
                    Id = Guid.Parse("ae88b444-4e3d-4085-9487-5af928251e95"),
                    FirstName = "FirstName1",
                    LastName = "LastName1",
                    Username = "Username1",
                    Password = "Password1",
                    Email = "Username1@gmail.com",
                    CompanyId = Guid.Parse("a0481244-7096-452c-8a26-1dd46d3ebe06")
                },
                new User()
                {
                    Id = Guid.Parse("e667decc-a5a8-46f1-a500-566001c4bbb2"),
                    FirstName = "FirstName2",
                    LastName = "LastName2",
                    Username = "Username2",
                    Password = "Password2",
                    Email = "Username2@gmail.com",
                    CompanyId = Guid.Parse("a8ba4c30-7513-41eb-854b-7325b5efd316")
                },
                new User()
                {
                    Id = Guid.Parse("de861852-adc7-41aa-86f2-c6e4bd502eab"),
                    FirstName = "FirstName3",
                    LastName = "LastName3",
                    Username = "Username3",
                    Password = "Password3",
                    Email = "Username3@gmail.com",
                    CompanyId = Guid.Parse("dc68dd36-3724-4499-9275-5cd0d57071c2")
                },
            };

            modelBuilder.Entity<User>().HasData(users);
        }
    }
}
