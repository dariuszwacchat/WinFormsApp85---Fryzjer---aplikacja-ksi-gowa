using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp84.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    { 
        private DataAutogenerator.NetCore.DataAutogenerator _dataAutogenerator = new DataAutogenerator.NetCore.DataAutogenerator ();
        private Random _rand = new Random ();

        public ApplicationDbContext () { }
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        public DbSet<Usluga> Uslugi { get; set; }
        public DbSet<RodzajUslugi> RodzajeUslug { get; set; }
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<Przerwa> Przerwy { get; set; } 
        public DbSet<Placa> Place { get; set; }



        protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WinFormsApp85-Fryzjer;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating (ModelBuilder builder)
        { 


            builder.Entity<ApplicationUser>()
                .HasMany(h => h.UserRegisters).WithOne(w => w.User).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.ClientSetNull);
             
            builder.Entity<ApplicationUser>()
                .HasMany(h => h.Place).WithOne(w => w.User).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.ClientSetNull);

            builder.Entity<ApplicationUser>()
                .HasMany(h => h.Uslugi).WithOne(w => w.User).HasForeignKey(f => f.UserId).OnDelete(DeleteBehavior.ClientSetNull);



            builder.Entity <RodzajUslugi> ()
                .HasMany (h=> h.Uslugi).WithOne (w=> w.RodzajUslugi).HasForeignKey (f=> f.RodzajUslugiId).OnDelete(DeleteBehavior.ClientSetNull);


            // Dodanie ról   
            ApplicationRole adminRole = new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Administrator",
                NormalizedName = "Administrator"
            };
            ApplicationRole personelRole = new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Personel",
                NormalizedName = "Personel",
            };
            ApplicationRole kierownikRole = new ApplicationRole()
            {
                Id = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                Name = "Kierownik",
                NormalizedName = "Kierownik",
            };
            builder.Entity<ApplicationRole>().HasData(adminRole, kierownikRole, personelRole);



            // Dodanie użytkowników  

            string photo = "https://th.bing.com/th?q=User+ICO&w=120&h=120&c=1&rs=1&qlt=90&cb=1&dpr=1.6&pid=InlineBlock&mkt=pl-PL&cc=PL&setlang=pl&adlt=moderate&t=1&mw=247";

            PasswordHasher <ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser> ();

            double placa = _rand.Next (8000,30000);
            ApplicationUser administratorUser = new ApplicationUser ()
            {
                Id = Guid.NewGuid().ToString (),
                Email = "admin@admin.pl",
                UserName = "admin@admin.pl",
                NormalizedUserName = "admin@admin.pl".ToUpper(),
                NormalizedEmail = "admin@admin.pl".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Imie = _dataAutogenerator.Imie(),
                Nazwisko = _dataAutogenerator.Nazwisko (),
                Ulica = _dataAutogenerator.Ulica(),
                Pesel = _dataAutogenerator.Pesel().ToString (),
                Miejscowosc = _dataAutogenerator.Nazwisko (),
                DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                DataDodania = _dataAutogenerator.RandomDateTime(),
                PlacaNetto = placa,
                PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
            };
            administratorUser.PasswordHash = passwordHasher.HashPassword(administratorUser, "SDG%$@5423sdgagSDert");
            IdentityUserRole <string> identityUserRoleAdmin = new IdentityUserRole<string> ()
            {
                UserId = administratorUser.Id,
                RoleId = adminRole.Id
            };

            placa = _rand.Next (8000,30000);
            ApplicationUser kierownikUser = new ApplicationUser ()
            {
                Id = Guid.NewGuid().ToString (),
                Email = "kierownik@kierownik.pl",
                UserName = "kierownik@kierownik.pl",
                NormalizedUserName = "kierownik@kierownik.pl".ToUpper(),
                NormalizedEmail = "kierownik@kierownik.pl".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Imie = _dataAutogenerator.Imie(),
                Nazwisko = _dataAutogenerator.Nazwisko (),
                Ulica = _dataAutogenerator.Ulica(),
                Pesel = _dataAutogenerator.Pesel().ToString (),
                Miejscowosc = _dataAutogenerator.Nazwisko (),
                DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                DataDodania = _dataAutogenerator.RandomDateTime(),
                PlacaNetto = placa,
                PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
            };
            kierownikUser.PasswordHash = passwordHasher.HashPassword(kierownikUser, "SDG%$@5423sdgagSDert");
            IdentityUserRole <string> identityUserRoleKierownik= new IdentityUserRole<string> ()
            {
                UserId = kierownikUser.Id,
                RoleId = kierownikRole.Id
            };

            placa = _rand.Next(5000, 8000);
            ApplicationUser pracownik1 = new ApplicationUser ()
            {
                Id = Guid.NewGuid().ToString (),
                Email = "personel1@personel1.pl",
                UserName = "personel1@personel1.pl",
                NormalizedUserName = "personel1@personel1.pl".ToUpper(),
                NormalizedEmail = "personel1@personel1.pl".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Imie = _dataAutogenerator.Imie(),
                Nazwisko = _dataAutogenerator.Nazwisko (),
                Ulica = _dataAutogenerator.Ulica(),
                Pesel = _dataAutogenerator.Pesel().ToString (),
                Miejscowosc = _dataAutogenerator.Nazwisko (),
                DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                DataDodania = _dataAutogenerator.RandomDateTime(),
                PlacaNetto = placa,
                PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
            };
            pracownik1.PasswordHash = passwordHasher.HashPassword(pracownik1, "SDG%$@5423sdgagSDert");
            IdentityUserRole <string> identityUserRoleUser1 = new IdentityUserRole<string> ()
            {
                UserId = pracownik1.Id,
                RoleId = personelRole.Id
            };

            placa = _rand.Next(5000, 8000);
            ApplicationUser pracownik2 = new ApplicationUser ()
            {
                Id = Guid.NewGuid().ToString (),
                Email = "personel2@personel2.pl",
                UserName = "personel2@personel2.pl",
                NormalizedUserName = "personel2@personel2.pl".ToUpper(),
                NormalizedEmail = "personel2@personel2.pl".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Imie = _dataAutogenerator.Imie(),
                Nazwisko = _dataAutogenerator.Nazwisko (),
                Ulica = _dataAutogenerator.Ulica(),
                Pesel = _dataAutogenerator.Pesel().ToString (),
                Miejscowosc = _dataAutogenerator.Nazwisko (),
                DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                DataDodania = _dataAutogenerator.RandomDateTime(),
                PlacaNetto = placa,
                PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
            };
            pracownik2.PasswordHash = passwordHasher.HashPassword(pracownik2, "SDG%$@5423sdgagSDert");
            IdentityUserRole <string> identityUserRoleUser2 = new IdentityUserRole<string> ()
            {
                UserId = pracownik2.Id,
                RoleId = personelRole.Id
            };

            placa = _rand.Next(5000, 8000);
            ApplicationUser pracownik3 = new ApplicationUser ()
            {
                Id = Guid.NewGuid().ToString (),
                Email = "personel3@personel3.pl",
                UserName = "personel3@personel3.pl",
                NormalizedUserName = "personel3@personel3.pl".ToUpper(),
                NormalizedEmail = "personel3@personel3.pl".ToUpper(),
                SecurityStamp = Guid.NewGuid().ToString(),
                Imie = _dataAutogenerator.Imie(),
                Nazwisko = _dataAutogenerator.Nazwisko (),
                Ulica = _dataAutogenerator.Ulica(),
                Pesel = _dataAutogenerator.Pesel().ToString (),
                Miejscowosc = _dataAutogenerator.Nazwisko (),
                DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                DataDodania = _dataAutogenerator.RandomDateTime(),
                PlacaNetto = placa,
                PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
            };
            pracownik3.PasswordHash = passwordHasher.HashPassword(pracownik3, "SDG%$@5423sdgagSDert");
            IdentityUserRole <string> identityUserRoleUser3 = new IdentityUserRole<string> ()
            {
                UserId = pracownik3.Id,
                RoleId = personelRole.Id
            };

            // pracownicy 
            List <string> usersId = new List<string> ();
            for (var i = 0; i < 20; i++)
            {
                string userName = $"{_dataAutogenerator.Nazwisko()}@{_dataAutogenerator.Nazwisko()}.pl";
                placa = _rand.Next(5000, 8000);
                ApplicationUser user = new ApplicationUser ()
                {
                    Id = Guid.NewGuid().ToString (),
                    Email = userName,
                    UserName = userName,
                    NormalizedUserName = userName.ToUpper(),
                    NormalizedEmail = userName.ToUpper(),
                    SecurityStamp = Guid.NewGuid().ToString(),
                    Imie = _dataAutogenerator.Imie(),
                    Nazwisko = _dataAutogenerator.Nazwisko (),
                    Ulica = _dataAutogenerator.Ulica(),
                    Pesel = _dataAutogenerator.Pesel().ToString (),
                    Miejscowosc = _dataAutogenerator.Nazwisko (),
                    DataUrodzenia = _dataAutogenerator.RandomDateTime(),
                    DataDodania = _dataAutogenerator.RandomDateTime(),
                    PlacaNetto = placa,
                    PlacaBrutto23 = _dataAutogenerator.ZyskBruttoVat22 (placa)
                };
                user.PasswordHash = passwordHasher.HashPassword(user, "SDG%$@5423sdgagSDert");
                usersId.Add(user.Id);
                builder.Entity<ApplicationUser>().HasData(user);
                IdentityUserRole <string> iur = new IdentityUserRole<string> ()
                {
                    UserId = user.Id,
                    RoleId = personelRole.Id
                };
                builder.Entity<IdentityUserRole<string>>().HasData(iur);
            }

            builder.Entity<ApplicationUser>().HasData(administratorUser, kierownikUser, pracownik1, pracownik2, pracownik3);
            builder.Entity<IdentityUserRole<string>>().HasData(identityUserRoleAdmin, identityUserRoleKierownik, identityUserRoleUser1, identityUserRoleUser2, identityUserRoleUser3);
             

            List <string> rodzajeUslug = new List<string> ()
            {
                "Strzyżenie", "Farbowanie", "Paznokcie"
            };
            List <string> rodzajeUslugId = new List<string> ();
            for (var i=0; i<rodzajeUslug.Count; i++)
            {
                RodzajUslugi rodzajUslugi = new RodzajUslugi ()
                {
                    RodzajUslugiId = Guid.NewGuid ().ToString (),
                    Nazwa = rodzajeUslug [i],
                    CenaNetto = _rand.Next(20,200)
                };
                builder.Entity <RodzajUslugi> ().HasData (rodzajUslugi);
                rodzajeUslugId.Add (rodzajUslugi.RodzajUslugiId);
            }

            for (var i=0; i<30; i++)
            {
                double cenaNetto = _rand.Next (20,100);
                Usluga usluga = new Usluga ()
                {
                    UslugaId = Guid.NewGuid ().ToString (),
                    CenaNetto = cenaNetto,  
                    Vat8 = Math.Round(_dataAutogenerator.BruttoVat8(cenaNetto)),
                    Vat22 = Math.Round(_dataAutogenerator.BruttoVat22 (cenaNetto)),
                    ZyskBrutto8 = Math.Round(_dataAutogenerator.ZyskBruttoVat8 (cenaNetto)),
                    ZyskBrutto22 = Math.Round(_dataAutogenerator.ZyskBruttoVat22 (cenaNetto)),
                    RodzajUslugiId = rodzajeUslugId[_rand.Next(0, rodzajeUslugId.Count)],
                    DataWykonania = _dataAutogenerator.RandomDateTime (),
                    DataDodania = DateTime.Now,
                    UserId = usersId[_rand.Next(0,usersId.Count)]
                };
                builder.Entity <Usluga>().HasData (usluga);
            }


            for (var i=0; i<10; i++)
            {

                var dataZalogowania = _dataAutogenerator.RandomDateTime();
                var dataWylogowania = dataZalogowania.AddHours(8);

                UserRegister userRegister = new UserRegister ()
                {
                    UserRegisterId = Guid.NewGuid ().ToString (),
                    DataZalogowania = dataZalogowania,
                    DataWylogowania = dataWylogowania,
                    CzasPracy = dataWylogowania - dataZalogowania,
                    Uwagi = _dataAutogenerator.Description(2),
                    UserId = usersId[_rand.Next(0, usersId.Count)]
                };
                builder.Entity <UserRegister> ().HasData (userRegister);

                var czasPrzerwy = _dataAutogenerator.RandomDateTime();
                var czasPrzerwyDo = czasPrzerwy.AddMinutes(_rand.Next(15,30));
                var lacznie = czasPrzerwyDo - czasPrzerwy;
                Przerwa przerwa = new Przerwa ()
                {
                    PrzerwaId = Guid.NewGuid ().ToString (),
                    Od = czasPrzerwy,
                    Do = czasPrzerwyDo,
                    Lacznie = lacznie, 
                    UserRegisterId = userRegister.UserRegisterId
                };
                builder.Entity <Przerwa> ().HasData (przerwa);
 
            }


            base.OnModelCreating(builder);
        }

    }
}
