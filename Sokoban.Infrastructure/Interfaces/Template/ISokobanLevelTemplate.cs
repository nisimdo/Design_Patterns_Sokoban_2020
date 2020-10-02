using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Infrastructure.Interfaces.Template
{
    public interface ISokobanLevelTemplate
    {
        void LoadLevel(ComponentsEnum[,] level);
        bool isLevelDone();
        BasicBoardComponent[,] GetBoard();
        FactoryWorker GetWorker();
    }
}
