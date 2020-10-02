using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;
using Sokoban.Infrastructure.Model.Interfaces;

namespace Sokoban.Visitor
{
    public class LevelCompleteVistor : ILevelCompleteVisitor
    {
        private int targetCount;
        private int packageInTargetCount;   

        public void Visit(IBoardComponent component)
        {
            component.Accept(this);
        }

        public void Visit(Cell component)
        {
            // We Only check Cells that are target cells
            if(component.IsTarget())
            {
                targetCount++;
                var occupant = component.GetMovableOccupant();
                if (occupant != null)
                {
                    occupant.Accept(this);      // Move to the Occupant
                }
            }
        }

        public void Visit(FactoryWorker component)
        {
            // Do nothing
        }

        public void Visit(Package component)
        {
            packageInTargetCount++;         // If we got here it means the we have a package in target
        }

        public void Visit(Wall component)
        {
            // Do nothing
        }
        public bool IsLevelComplete()
        {
            return targetCount == packageInTargetCount;
        }

        public void ResetVisitor()
        {
            targetCount = 0;
            packageInTargetCount = 0;
        }
    }
}
