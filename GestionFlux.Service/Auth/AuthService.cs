using GestionFlux.Core.Repository;
using GestionFlux.Domain;
using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Repository.Department;
using GestionFlux.Repository.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Auth
{
    public class AuthService : IAuthService
    {
        private IUserRepository<User, FluxDbContext> _userRepository;
        private IDepartmentRepository<Department, FluxDbContext> _departmentRepository;

        public AuthService(IUserRepository<User, FluxDbContext> userRepository, IDepartmentRepository<Department, FluxDbContext> departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
        }

        #region CRUD USER
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
        #endregion

        public IEnumerable<User> GetUsers()
        {
            return _userRepository.GetAll();
        }
        public IEnumerable<Department> GetDepartments()
        {
            return _departmentRepository.GetAll();
        }
        public User Authenticate(AuthViewModels.UserLogin user)
        {
            IEnumerable<User> users = _userRepository.GetAll().Where(
                x => x.Username == user.Username &&
                x.Password == user.Password.GetHashCode()
            );
            try
            {
                return users.First();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    
        public User RegisterUser(AuthViewModels.UserRegister incomingUser)
        {
            Department incomingUserDepartment = _departmentRepository.FindByNameOrCreate(incomingUser.Department);
            User newUserInstance = new User
            {
                Username = incomingUser.Username,
                Password = incomingUser.Password.GetHashCode(),
                Matricule = incomingUser.Matricule,
            };
            _userRepository.Insert(newUserInstance);
            _userRepository.SetDepartment(newUserInstance.Id, incomingUserDepartment.Id);
            return newUserInstance;
        }
    }
}
