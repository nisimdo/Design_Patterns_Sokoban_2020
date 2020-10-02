using Sokoban.Dependency;
using Sokoban.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Facade;
using Sokoban.Infrastructure.Interfaces.Template;

namespace Sokoban
{
    public class SokobanGame
    {
        static void Main(string[] args)
        {
            IBootstrapFacade bootstrap = new BootstrapFacade();
            bootstrap.LoadApplication();

            ISokobanGameTemplate template = DependencyContainer.Instance.Resolve<ISokobanGameTemplate>();
            template.StartGame();       // Starting the Game
        }
    }
}
