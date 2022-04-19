using GestionFlux.Core.Repository;
using GestionFlux.Domain;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Auth
{
    public class AuthService : IAuthService
    {
        private BaseRepository<User, FluxDbContext> _userRepository;
        private BaseRepository<Department, FluxDbContext> _departmentRepository;

        public AuthService(BaseRepository<User, FluxDbContext> userRepository, BaseRepository<Department, FluxDbContext> departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return _userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            user.Password = user.Password.GetHashCode();
            _userRepository.Insert(user);
        }
        public void UpdateUser(int id, User user)
        {
            _userRepository.Update(id, user);
        }

        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
            _userRepository.SaveChanges();
        }

        public User Authenticate(string username, string password)
        {
            IEnumerable<User> users = _userRepository.GetAll().Where(x => x.Username == username && x.Password == password.GetHashCode());
            try
            {
                return users.First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }
    }
}
