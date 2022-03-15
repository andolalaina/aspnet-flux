using GestionFlux.SMA.Interfaces;
using GestionFlux.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionFlux.SMA.Agents
{
    public class Master : IAgent, IObserver<User>
    {
        private IDisposable unsubscriber;
        public BlackBoard BlackBoard { get; }

        public virtual void Subscribe(IObservable<User> provider)
        {
            unsubscriber = provider.Subscribe(this);
        }
        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }
        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(User value)
        {
            System.Diagnostics.Debug.WriteLine("Receiving value...");
        }
    }
}
