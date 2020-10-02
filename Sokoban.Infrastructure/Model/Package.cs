using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model.Interfaces;

namespace  Sokoban.Infrastructure.Model
{
    public class Package : IBoardComponent, IMovableComponent
    {
        private Cell m_parent;

        public Package(Cell a_parent)
        {
            m_parent = a_parent;
        }

        public Cell getParent()
        {
            return m_parent;
        }

        public void setParent(Cell newParent)
        {
            m_parent = newParent;
        }

        public void Accept(IBoardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public T Accept<T>(IBoardComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
