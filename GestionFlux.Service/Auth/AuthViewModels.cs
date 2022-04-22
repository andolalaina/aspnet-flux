using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Auth
{
    public class AuthViewModels
    {
        public class UserLogin
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class UserRegister
        {
            public Int64 Id { get; set; }
            public string Username { get; set; }
            public string Password { get; set; }
            public string Matricule { get; set; }
            public string Department { get; set; }

            public bool isValid()
            {
                if (Username == null || 
                    Password == null || 
                    Matricule == null || 
                    Department == null) 
                    return false;
                return true;
            }
        }
    }
}
