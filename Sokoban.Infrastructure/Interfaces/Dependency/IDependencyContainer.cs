using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sokoban.Infrastructure.Interfaces.Dependency
{
    public interface IDependencyContainer
    {
        void Register<T>(T service) where T : IRegisterableService;         // Register a new Service in the container

        T Resolve<T>() where T : IRegisterableService;                      // Return the service according to the given type
    }
}
