using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Command;
using Sokoban.Infrastructure.Model;

namespace Sokoban.Command
{
    public class MovementCommandService : IMovementCommandService
    {
        Stack<ISokobanCommand> m_CommandsCollection;     // The stack of commands that were performed

        public MovementCommandService()
        {
            m_CommandsCollection = new Stack<ISokobanCommand>();        // Creating the stack of commands
        }

        public void MoveComponent(Cell a_originalCell, Cell a_targetCell)
        {
            ISokobanCommand moveCommand = new MoveCommand(a_originalCell, a_targetCell);
            moveCommand.Execute();      // Executing the command
            m_CommandsCollection.Push(moveCommand);     // Adding the command to the head of the stack
        }

        public bool UndoMove()
        {
            if (m_CommandsCollection.Any())
            {
                ISokobanCommand moveCommand = m_CommandsCollection.Pop();
                moveCommand.Undo();      // Undoing the command
                return true;
            }
            return false;
        }
    }
}
