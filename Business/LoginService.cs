using Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp84.Data;

namespace Business
{
    public class LoginService
    {
        private ApplicationDbContext _context; 
        public static ApplicationUser ZalogowanyUser { get; set; }
        public static string Rola { get; set; }
        public static UserRegister UserRegister { get; set; }

        public LoginService ()
        {
            _context = new ApplicationDbContext (); 

        }
         
        public bool Zaloguj (string email, string haslo)
        {
            var result = false;
            PasswordHasher <ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser> ();
            var user = _context.Users.FirstOrDefault (f=> f.Email == email);
            if (user != null)
            {
                var passwordResult = passwordHasher.VerifyHashedPassword (user, user.PasswordHash, haslo);
                if (passwordResult == PasswordVerificationResult.Success)
                {
                    ZalogowanyUser = user;

                    // pobranie roli użytkownika

                    var userRole = _context.UserRoles.FirstOrDefault (f=> f.UserId == user.Id);
                    if (userRole != null)
                    {
                        var rola = _context.Roles.FirstOrDefault (f=> f.Id == userRole.RoleId);
                        if (rola != null)
                            Rola = rola.Name;
                    }


                    /*
                        użytkownik, który się zaloguje jest rejestrowany w bazie,
                        dzięki temu wiemy kiedy był w pracy a kiedy nie
                     */

                    UserRegister userRegister = new UserRegister ()
                    {
                        UserRegisterId = Guid.NewGuid ().ToString (),
                        DataZalogowania = DateTime.Now, 
                        UserId = ZalogowanyUser.Id
                    };
                    _context.UserRegisters.Add (userRegister);
                    _context.SaveChanges ();
                    UserRegister = userRegister;

                    return true;
                }
            }
            return result;
        }

    }
}
