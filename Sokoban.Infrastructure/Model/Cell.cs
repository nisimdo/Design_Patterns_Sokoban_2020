using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model.Interfaces;

namespace  Sokoban.Infrastructure.Model
{
    public class Cell : BasicBoardComponent
    {
        private bool m_isTarget;        // Is the cell is a target cell or not
        private IMovableComponent m_movableOccupant;     // In the case that the cell contain a IMovableObject
        public Cell(int row, int col, bool isTarget=false) : base(row, col) {
            m_isTarget = isTarget;
        }

        public bool IsTarget()
        {
            return m_isTarget;
        }

        public IMovableComponent GetMovableOccupant()
        {
            return m_movableOccupant;
        }

        public void SetMovableOccupant(IMovableComponent movableOccupant)
        {
            m_movableOccupant = movableOccupant;
        }

        public override void Accept(IBoardComponentVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override T Accept<T>(IBoardComponentVisitor<T> visitor)
        {
            return visitor.Visit(this);
        }
    }
}
