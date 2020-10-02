using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.AbstractFactory;
using Sokoban.Infrastructure.Interfaces.Bridge;
using Sokoban.Infrastructure.Interfaces.Bridge.Abstraction;
using Sokoban.Infrastructure.Interfaces.Bridge.Implementation;
using Sokoban.Infrastructure.Interfaces.Visitor;

namespace Sokoban.ConsoleIO.AbstractFactory
{
    public class ConsoleOutputInputFactory : IOutputInputFactory
    {
        public IBoardComponentVisitor<string> m_displayImplementor; // How to display the input
        public IMovementImplementer<char> m_movmentImplementor;     // What Input will translate to which action

        public ConsoleOutputInputFactory(IBoardComponentVisitor<string> a_displayImplementor,
            IMovementImplementer<char> a_movmentImplementor)
        {
            m_displayImplementor = a_displayImplementor;
            m_movmentImplementor = a_movmentImplementor;
        }
        public IBoardDisplayer CreateDisplayer()
        {
            return new ConsoleDisplayer(m_displayImplementor);
        }

        public ISubjectMovementListener CreateMovementListener()
        {
            return new ConsoleMovementListener(m_movmentImplementor);
        }
    }
}
