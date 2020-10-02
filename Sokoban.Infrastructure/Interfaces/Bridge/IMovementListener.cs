using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Dependency;

namespace Sokoban.Infrastructure.Interfaces.Bridge
{
    public interface IMovementListener : IRegisterableService
    {
        void StartListen();
        void StopListen();
    }
}
