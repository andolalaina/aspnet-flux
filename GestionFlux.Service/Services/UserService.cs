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
   public class UserService : IUserService, IObservable<User>
    {
        private Repository<User> userRepository;
        private List<IObserver<User>> observers;
        private User lastInsertedUser;

        public UserService(Repository<User> userRepository)
        {
            this.userRepository = userRepository;
            observers = new List<IObserver<User>>();
        }

        public IDisposable Subscribe(IObserver<User> observer)
        {
            if(!observers.Contains(observer))
            {
                observers.Add(observer);
                observer.OnNext(lastInsertedUser);
            }
            return new Unsubscriber<User>(observers, observer);
        }

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
            userRepository.Insert(user);
            lastInsertedUser = user;
            DispatchUserInsert();
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

        private void DispatchUserInsert()
        {
            if (observers != null)
            {
                System.Diagnostics.Debug.WriteLine("Dispatching...");
                foreach (var observer in observers) observer.OnNext(lastInsertedUser);
            }
            else System.Diagnostics.Debug.WriteLine("No observers...");
        }
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
