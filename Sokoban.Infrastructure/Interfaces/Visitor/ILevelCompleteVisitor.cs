using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Sokoban.Infrastructure.Interfaces.Visitor
{
    public interface ILevelCompleteVisitor : IBoardComponentVisitor
    {
        bool IsLevelComplete();

        void ResetVisitor();
    }
}
