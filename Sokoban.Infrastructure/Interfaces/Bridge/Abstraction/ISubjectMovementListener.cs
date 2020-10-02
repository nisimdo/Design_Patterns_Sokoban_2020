using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Observer;

namespace Sokoban.Infrastructure.Interfaces.Bridge.Abstraction
{
    public interface ISubjectMovementListener : IMovementListener, ISokobanSubject<DirectionEnum>
    {
    }
}
