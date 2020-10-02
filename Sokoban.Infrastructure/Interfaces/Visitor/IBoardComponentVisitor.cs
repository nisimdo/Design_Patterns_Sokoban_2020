using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Model;
using Sokoban.Infrastructure.Model.Interfaces;

namespace Sokoban.Infrastructure.Interfaces.Visitor
{
    public interface IBoardComponentVisitor
    {
        void Visit(IBoardComponent component);
        void Visit(Cell component);
        void Visit(FactoryWorker component);
        void Visit(Package component);
        void Visit(Wall component);
    }

    public interface IBoardComponentVisitor<T>
    {
        T Visit(IBoardComponent component);
        T Visit(Cell component);
        T Visit(FactoryWorker component);
        T Visit(Package component);
        T Visit(Wall component);
    }
}
