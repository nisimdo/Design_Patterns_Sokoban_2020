using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model.Interfaces;

namespace Sokoban.Infrastructure.Model
{
    public abstract class BasicBoardComponent : IBoardComponent
    {
        protected int m_row;
        protected int m_col;

        public BasicBoardComponent(int row, int col)
        {
            m_row = row;
            m_col = col;
        }

        public int GetRow()
        {
            return m_row;
        }

        public int GetCol()
        {
            return m_col;
        }
        public abstract void Accept(IBoardComponentVisitor visitor);
        public abstract T Accept<T>(IBoardComponentVisitor<T> visitor);
    }
}
