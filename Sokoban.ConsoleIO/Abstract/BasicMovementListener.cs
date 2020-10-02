using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Bridge.Abstraction;
using Sokoban.Observer;

namespace Sokoban.ConsoleIO.Abstract
{
    public abstract class BasicMovementListener : AbstractSokobanSubject<DirectionEnum>, ISubjectMovementListener
    {
        public abstract void StartListen();

        public abstract void StopListen();
    }
}
