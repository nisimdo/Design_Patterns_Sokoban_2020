using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Dependency;

namespace Sokoban.Dependency
{
    // The only singleton class that will store all the services available in the system
    public class DependencyContainer : IDependencyContainer
    {
        private IDictionary<Type, IRegisterableService> m_container;     // The container of all the service

        private DependencyContainer()
        {
            m_container = new Dictionary<Type, IRegisterableService>();
        }

        #region Singleton Members
        private static IDependencyContainer s_Instance = null;     // The instance of the container
        public static IDependencyContainer Instance
        {
            get {
                // If the container does not exist
                if (s_Instance == null)
                {
                    s_Instance = new DependencyContainer();
                }
                return s_Instance;
            }
        }
        #endregion Singleton Members

        public void Register<T>(T service) where T : IRegisterableService
        {
            if (m_container.ContainsKey(typeof(T)))
                throw new Exception($"The type ${typeof(T)} already exist in the dependency container");

            m_container.Add(typeof(T), service);        // Storing the service
        }

        public T Resolve<T>() where T : IRegisterableService
        {
            IRegisterableService service = null;
            if (!m_container.TryGetValue(typeof(T), out service))
                throw new Exception($"The type ${typeof(T)} does not exist in the dependency container");

            return (T)service;       // return the converted service
        }
    }
}
