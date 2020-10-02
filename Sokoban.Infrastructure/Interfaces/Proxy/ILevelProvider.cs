using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Dependency;

namespace Sokoban.Infrastructure.Interfaces.Proxy
{
    public interface ILevelProvider : IRegisterableService
    {
        ComponentsEnum[,] GetLevel(int difficulty);       // Getting the level based on it's difficulty
        bool HasLevel(int level);
    }
}
