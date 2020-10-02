using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;
using Sokoban.Infrastructure.Model.Interfaces;

namespace Sokoban.Visitor
{
    public class FindFactoryWorkerVisitor : IFindFactoryWorkerVisitor
    {
        private FactoryWorker m_worker;      // The worker that we search
        public void Visit(IBoardComponent component)
        {
            component.Accept(this);
        }

        public void Visit(Cell component)
        {
            var occupant = component.GetMovableOccupant();
            if (occupant != null)
            {
                occupant.Accept(this);
            }
        }

        public void Visit(FactoryWorker component)
        {
            m_worker = component;           // Storing the worker
        }

        public void Visit(Package component)
        {
            // Do Nothing, because we are searching for the factory worker
        }

        public void Visit(Wall component)
        {
            // Do Nothing, because we are searching for the factory worker
        }

        public FactoryWorker GetFactoryWorker()
        {
            return m_worker;
        }
        public void ResetFactoryWorker()
        {
            m_worker = null;
        }
    }
}
