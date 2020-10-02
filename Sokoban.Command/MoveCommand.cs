using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Command;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Command
{
    public class MoveCommand : ISokobanCommand
    {
        private Cell m_originalCell;
        private Cell m_targetCell;

        public MoveCommand(Cell a_originalCell, Cell a_targetCell)
        {
            m_originalCell = a_originalCell;
            m_targetCell = a_targetCell;
        }

        public void Execute()
        {
            var movableOccupant = m_originalCell.GetMovableOccupant();  // Getting the occupant in the original
            m_originalCell.SetMovableOccupant(null);            // Set that the cell is vacant
            movableOccupant.setParent(m_targetCell);    // Changing the movable parent
            m_targetCell.SetMovableOccupant(movableOccupant);   // Setting the target cell the movable as occupant
        }

        public void Undo()
        {
            var movableOccupant = m_targetCell.GetMovableOccupant();  // Getting the occupant in the original
            m_targetCell.SetMovableOccupant(null);            // Set that the cell is vacant
            movableOccupant.setParent(m_originalCell);    // Changing the movable parent
            m_originalCell.SetMovableOccupant(movableOccupant);   // Setting the target cell the movable as occupant
        }
    }
}
