using GestionFlux.Core.Repository;
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
        //private List<IObserver<User>> observers;
        //private User lastInsertedUser;

        public AuthService(BaseRepository<User, FluxDbContext> userRepository, BaseRepository<Department, FluxDbContext> departmentRepository)
        {
            _userRepository = userRepository;
            _departmentRepository = departmentRepository;
            //observers = new List<IObserver<User>>();
        }

        //public IDisposable Subscribe(IObserver<User> observer)
        //{
        //    if(!observers.Contains(observer))
        //    {
        //        observers.Add(observer);
        //        observer.OnNext(lastInsertedUser);
        //    }
        //    return new Unsubscriber<User>(observers, observer);
        //}

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
            //lastInsertedUser = user;
            //DispatchUserInsert();
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

        //private void DispatchUserInsert()
        //{
        //    if (observers != null)
        //    {
        //        System.Diagnostics.Debug.WriteLine("Dispatching...");
        //        foreach (var observer in observers) observer.OnNext(lastInsertedUser);
        //    }
        //    else System.Diagnostics.Debug.WriteLine("No observers...");
        //}
    }

    internal class Unsubscriber<User> : IDisposable
    {
        private List<IObserver<User>> _observers;
        private IObserver<User> _observer;

        internal Unsubscriber(List<IObserver<User>> observers, IObserver<User> observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }
}
