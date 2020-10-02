using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Bridge;
using Sokoban.Infrastructure.Interfaces.Bridge.Abstraction;
using Sokoban.Infrastructure.Interfaces.Dependency;

namespace Sokoban.Infrastructure.Interfaces.AbstractFactory
{
    public interface IOutputInputFactory : IRegisterableService
    {
        IBoardDisplayer CreateDisplayer();      // Create the displayer of the input
        ISubjectMovementListener CreateMovementListener();     // Creating the input handler
    }
}
