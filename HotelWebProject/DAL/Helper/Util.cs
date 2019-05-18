using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Helper
{
    public interface Observerable
    {
        void RegisterObserver(Observer observer);
        void RemoveObserver(Observer observer);
        void NotifyObserver();
    }
    public interface Observer
    {
        void Update();
    }
    public class SelfObservation : Observerable
    {
        private event Action observers;

        public void Update()
        {
            observers?.Invoke();
        }

        public void RegisterObserver(Observer observer)
        {
            observers += observer.Update;
        }

        public void RemoveObserver(Observer observer)
        {
            observers -= observer.Update;
        }

        public void NotifyObserver()
        {
            observers?.Invoke();
        }
    }
    public class Util
    {
    }
}
