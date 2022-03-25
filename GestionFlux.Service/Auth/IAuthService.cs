using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Auth
{
    public interface IAuthService
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Department> GetDepartments();
        User GetUser(int id);
        void InsertUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
        User Authenticate(string username, string password);
    }
}
