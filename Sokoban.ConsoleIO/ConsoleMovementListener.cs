using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.ConsoleIO.Abstract;
using Sokoban.Infrastructure.Enums;
using Sokoban.Infrastructure.Interfaces.Bridge.Implementation;

namespace Sokoban.ConsoleIO
{
    public class ConsoleMovementListener : BasicMovementListener
    {
        private IMovementImplementer<char> m_componentImplementor;
        private bool m_stop;

        public ConsoleMovementListener(IMovementImplementer<char> implementor)
        {
            m_componentImplementor = implementor;
        }

        public override void StartListen()
        {
            m_stop = false;

            while(!m_stop)
            {
                DisplayInputOptions();                  // Showing the movement options
                char key = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (m_componentImplementor.hasKey(key))
                    this.Notify(m_componentImplementor.ConvertToDirection(key));
            }
        }

        public override void StopListen()
        {
            m_stop = true;
        }
        
        private void DisplayInputOptions()
        {
            Console.WriteLine(" {0} ", m_componentImplementor.DirectionToType(DirectionEnum.UP));
            Console.WriteLine("{0} {1}", m_componentImplementor.DirectionToType(DirectionEnum.LEFT), m_componentImplementor.DirectionToType(DirectionEnum.RIGHT));
            Console.WriteLine(" {0} ", m_componentImplementor.DirectionToType(DirectionEnum.DOWN));
            Console.WriteLine("Undo -> {0}\n", m_componentImplementor.DirectionToType(DirectionEnum.UNDO));
        }
    }
}
