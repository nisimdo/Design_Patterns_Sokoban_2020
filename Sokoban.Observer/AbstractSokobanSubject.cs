using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Observer;

namespace Sokoban.Observer
{
    public abstract class AbstractSokobanSubject<T> : ISokobanSubject<T>
    {
        protected ICollection<ISokobanObserver<T>> m_observers;         // The collection of observers to notify, add and remove

        public AbstractSokobanSubject()
        {
            m_observers = new List<ISokobanObserver<T>>();        // Creating the list of obsevers
        }

        public void Attach(ISokobanObserver<T> observer)
        {
            m_observers.Add(observer);          // Adding the observer to the list
        }

        public void Detach(ISokobanObserver<T> observer)
        {
             m_observers.Remove(observer);          // Adding the observer to the list
        }

        public void Notify(T payload)
        {
            foreach (var observer in m_observers)
            {
                observer.Update(payload);
            }
        }
    }
}
