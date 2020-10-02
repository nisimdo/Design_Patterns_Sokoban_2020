using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace  Sokoban.Infrastructure.Model.Interfaces
{
    public interface IMovableComponent : IBoardComponent
    {
        Cell getParent();     // Getting the parent of the movable component
        void setParent(Cell newParent);
    }
}
