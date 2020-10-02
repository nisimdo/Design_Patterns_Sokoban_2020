using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;

namespace  Sokoban.Infrastructure.Model.Interfaces
{
    public interface IBoardComponent
    {
        void Accept(IBoardComponentVisitor visitor);
        T Accept<T>(IBoardComponentVisitor<T> visitor);
    }
}
