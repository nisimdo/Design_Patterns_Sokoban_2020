using Sokoban.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Implementor.Displayer;
using Sokoban.Implementor.Movement;
using Sokoban.Command;
using Sokoban.ConsoleIO.AbstractFactory;
using Sokoban.Factory;
using Sokoban.Infrastructure.Interfaces.AbstractFactory;
using Sokoban.Infrastructure.Interfaces.Command;
using Sokoban.Infrastructure.Interfaces.Dependency;
using Sokoban.Infrastructure.Interfaces.Facade;
using Sokoban.Infrastructure.Interfaces.Factory;
using Sokoban.Infrastructure.Interfaces.Proxy;
using Sokoban.Infrastructure.Interfaces.State;
using Sokoban.Infrastructure.Interfaces.Template;
using Sokoban.Proxy;
using Sokoban.State;
using Sokoban.Template;

namespace Sokoban.Facade
{
    public class BootstrapFacade : IBootstrapFacade
    {
        private IDependencyContainer m_container;     // The dependenxy Container that will hold all the service registration

        public BootstrapFacade()
        {
            m_container = DependencyContainer.Instance;
        }
        public void LoadApplication()
        {
            RegisterServices();
        }

        private void RegisterServices()
        {
            // Register the Services and creating the container
            m_container.Register<IBoardComponentFactory>(new BoardComponentFactory());
            m_container.Register<ILevelProvider>(new LevelProviderProxy());
            m_container.Register<IMovementCommandService>(new MovementCommandService());
            m_container.Register<IWorkerStateMachine>(new WorkerStateMachine());
            m_container.Register<IOutputInputFactory>(new ConsoleOutputInputFactory(
                new BigLettersImplementor(), new KeyboardImplementor()
                ));
            m_container.Register<ISokobanGameTemplate>(new SokobanGameTemplate());      // Creatingthe Sokoban.Main Game Template
        }
    }
}
