using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;
using Sokoban.Infrastructure.Model.Interfaces;


namespace Sokoban.Implementor.Displayer
{
    public class BigLettersImplementor : IBoardComponentVisitor<string>
    {
        public string Visit(IBoardComponent component)
        {
            return component.Accept(this);
        }

        public string Visit(Cell component)
        {
            IMovableComponent movable = component.GetMovableOccupant();     // If the cell has an occupant within it, we will display the occupant
            if (movable != null)
            {
                return movable.Accept(this);        // We will refer to the appropriate implemntation
            }
            return component.IsTarget()? ".": "_";                 // Return that this is an empty cell
        }

        public string Visit(FactoryWorker component)
        {
            return "W";
        }

        public string Visit(Package component)
        {
            return "P";
        }

        public string Visit(Wall component)
        {
            return "X";
        }
    }
}
