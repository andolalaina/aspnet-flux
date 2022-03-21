using GestionFlux.Domain.Models;
using GestionFlux.Repository;
using GestionFlux.Repository.Interfaces;
using GestionFlux.Service.Interfaces;
using GestionFlux.Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.Service.Services
{
   public class UserService : IUserService
    {
        private Repository<User> userRepository;
        private Repository<Department> departmentRepository;
        //private List<IObserver<User>> observers;
        //private User lastInsertedUser;

        public UserService(Repository<User> userRepository, Repository<Department> departmentRepository)
        {
            this.userRepository = userRepository;
            this.departmentRepository = departmentRepository;
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
            return userRepository.GetAll();
        }

        public User GetUser(int id)
        {
            return userRepository.Get(id);
        }

        public void InsertUser(User user)
        {
            user.Password = user.Password.GetHashCode();
            userRepository.Insert(user);
            //lastInsertedUser = user;
            //DispatchUserInsert();
        }
        public void UpdateUser(User user)
        {
            userRepository.Update(user);
        }

        public void DeleteUser(int id)
        {
            User user = GetUser(id);
            userRepository.Remove(user);
            userRepository.SaveChanges();
        }

        public User Authenticate(string username, string password)
        {
            IEnumerable<User> users = userRepository.GetAll().Where(x => x.Username == username && x.Password == password.GetHashCode());
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
            return departmentRepository.GetAll();
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
