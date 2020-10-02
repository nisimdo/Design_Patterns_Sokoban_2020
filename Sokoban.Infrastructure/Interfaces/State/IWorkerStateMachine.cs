using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Infrastructure.Interfaces.State
{
    public interface IWorkerStateMachine : IRegisterableService
    {
        bool TryMakeMove(DirectionEnum direction);     // Trying to make a move in the board
        void SetWorker(FactoryWorker worker);       // Setting the worker
        void SetBoard(BasicBoardComponent[,] board);        // Setting the board of the game
    }
}
