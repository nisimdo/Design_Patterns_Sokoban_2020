using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Model;

namespace  Sokoban.Infrastructure.Interfaces.Visitor
{
    public interface IFindFactoryWorkerVisitor : IBoardComponentVisitor
    {
        FactoryWorker GetFactoryWorker();
        void ResetFactoryWorker();
    }
}
