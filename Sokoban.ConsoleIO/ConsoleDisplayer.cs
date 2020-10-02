using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sokoban.Infrastructure.Interfaces.Bridge;
using Sokoban.Infrastructure.Interfaces.Visitor;
using Sokoban.Infrastructure.Model;

namespace Sokoban.ConsoleIO
{
    public class ConsoleDisplayer : IBoardDisplayer
    {
        private IBoardComponentVisitor<string> m_componentImplementor;        // The implemenation of a single component on the board

        public ConsoleDisplayer(IBoardComponentVisitor<string> implementor)
        {
            m_componentImplementor = implementor;
        }

        public void ClearBoard()
        {
        Console.Clear();        // Clearing the board from components
        }

        public void DisplayBoard(BasicBoardComponent[,] board)
        {
            Console.Write("\n");            // New Line
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    Console.Write(m_componentImplementor.Visit(board[row, col]));       // Printing the implementation of the compoent
                }
                Console.Write("\n");            // New Line
            }
        }
    }
}
