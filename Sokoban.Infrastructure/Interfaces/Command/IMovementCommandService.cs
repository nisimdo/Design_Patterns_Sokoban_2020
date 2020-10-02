using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Infrastructure.Interfaces.Command
{
    public interface IMovementCommandService : IRegisterableService
    {
        void MoveComponent(Cell a_originalCell, Cell a_targetCell);
        bool UndoMove();
    }
}
