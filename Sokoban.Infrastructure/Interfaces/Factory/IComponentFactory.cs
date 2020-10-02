using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Infrastructure.Interfaces.Factory
{

    public interface IBoardComponentFactory : IRegisterableService
    {
        BasicBoardComponent Create(ComponentsEnum a_moveableEnum, int row, int col);
    }
}
