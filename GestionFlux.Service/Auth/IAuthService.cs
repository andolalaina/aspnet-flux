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
        #region CRUD USER
        User GetUser(int id);
        void InsertUser(User user);
        void UpdateUser(int id, User user);
        void DeleteUser(int id);
        #endregion
        IEnumerable<User> GetUsers();
        IEnumerable<Department> GetDepartments();
        User Authenticate(AuthViewModels.UserLogin user);
        User RegisterUser(AuthViewModels.UserRegister newUser);
    }
}
