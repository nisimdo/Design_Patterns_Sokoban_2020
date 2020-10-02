using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;

namespace  Sokoban.Infrastructure.Model
{
    public class Wall : BasicBoardComponent
    {
        public Wall(int row, int col) : base(row, col) { }

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
