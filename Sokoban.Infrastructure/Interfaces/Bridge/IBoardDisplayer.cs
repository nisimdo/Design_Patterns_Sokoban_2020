using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Infrastructure.Interfaces.Bridge
{
    public interface IBoardDisplayer : IRegisterableService
    {
        void DisplayBoard(BasicBoardComponent[,] board);   // Displaying a single component on the board
        void ClearBoard();                                  // Clearing the board from components
    }
}
