using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Interfaces.Observer;

namespace Sokoban.Infrastructure.Interfaces.Template
{
    public interface ISokobanGameTemplate : ISokobanObserver<DirectionEnum>, IRegisterableService
    {
        void StartGame();
        void EndGame();
    }
}
